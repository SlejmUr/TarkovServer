using Newtonsoft.Json;
using ServerLib.Handlers;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Controllers
{
    public class AccountController
    {
        static AccountController()
        {
            if (!Directory.Exists("profiles")) { Directory.CreateDirectory("profiles"); }

            Accounts = new();
            Accounts.Clear();
            AccountsDict = new();
            AccountsDict.Clear();
            ActiveAccountIds = new();
            ActiveAccountIds.Clear();
        }

        public static List<Account> Accounts;
        public static Dictionary<string, Account> AccountsDict;
        public static List<string> ActiveAccountIds;

        
        public static void Init()
        {
            ReloadAccounts();
            Debug.PrintInfo("Initialization Done!", "ACCOUNT");
        }

        public static void ReloadAccounts()
        {
            foreach (var dir in Directory.GetDirectories("profiles"))
            {
                foreach (var file in Directory.GetFiles(dir))
                {
                    if (file.Contains("account.json"))
                    { 
                        var acc = JsonConvert.DeserializeObject<Account>(File.ReadAllText(file));
                        if (acc != null)
                        {
                            if (!Accounts.Contains(acc))
                                Accounts.Add(acc);
                            AccountsDict.TryAdd(acc.Aid, acc);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Remove Session from ActiveAccounts
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void SessionLogout(string SessionId)
        {
            Debug.PrintDebug($"User with ID {SessionId} has logged out");
            ActiveAccountIds.Remove(SessionId);
        }

        /// <summary>
        /// Login the Profile to the Server 
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Profile</param>
        /// <returns>AccountId | FAILED</returns>
        public static string Login(Requests.Login login)
        {
            string ID = FindAccountIdByUsernameAndPassword(login.email, login.pass);

            if (ID == null)
            {
                Debug.PrintInfo("Login FAILED: " + ID);
                return "FAILED";
            }
            else
            {
                Debug.PrintInfo("Login Success: " + ID);
                if (!ActiveAccountIds.Contains(ID))
                {
                    ActiveAccountIds.Add(ID);
                }
                return ID;
            }
        }

        /// <summary>
        /// Register the Profile to the Server
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Profile</param>
        /// <returns>AccountId | ALREADY_IN_USE</returns>
        public static string Register(Requests.Register register)
        {
            string ID = FindAccountIdByUsernameAndPassword(register.email, register.pass);

            if (IsEmailAlreadyInUse(register.email))
            {
                return "ALREADY_IN_USE";
            }
            if (ID == null)
            {
                string AccountID = Utils.CreateNewID();
                Account account = new()
                {
                    Aid = AccountID,
                    Id = Accounts.Count + 1,
                    Email = register.email,
                    Permission = Json.EPerms.User
                };
                if (ConfigController.Configs.CustomSettings.Account.UseSha1)
                    account.Password = CryptoHelper.Hash(register.pass);
                else
                    account.Password = register.pass;
                SaveHandler.SaveAccount(AccountID, account);
                Debug.PrintInfo("Register Success! " + AccountID);
                if (!ActiveAccountIds.Contains(AccountID))
                {
                    ActiveAccountIds.Add(AccountID);
                }
                return AccountID;
            }
            else
            {
                return ID;
            }
        }

        /// <summary>
        /// Searching AccountId by Username and Password.
        /// </summary>
        /// <param name="name">UserName</param>
        /// <param name="passw">Password</param>
        /// <returns>AccountId | ""</returns>
        public static string FindAccountIdByUsernameAndPassword(string mail, string passw)
        {
            ReloadAccounts();
            foreach (var account in Accounts)
            {
                if (ConfigController.Configs.CustomSettings.Account.UseSha1)
                {
                    if (account.Email == mail && account.Password == CryptoHelper.Hash(passw))
                    {
                        return account.Aid;
                    }
                }
                else
                {
                    if (account.Email == mail && account.Password == passw)
                    {
                        return account.Aid;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Check if already is Email is used by another user.
        /// </summary>
        /// <param name="name">Username</param>
        /// <returns>True | False</returns>
        public static bool IsEmailAlreadyInUse(string mail)
        {
            ReloadAccounts();
            foreach (var account in Accounts)
            {
                if (account.Email == mail)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check the Client character exist.
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>True | False</returns>
        public static bool ClientHasProfile(string SessionId)
        {
            ReloadAccounts();
            var profile = CharacterController.GetCharacter(SessionId);
            if (profile != null)
            {
                return true;
            }
            Debug.PrintInfo($"New account {SessionId} logged in!");
            return false;
        }

        /// <summary>
        /// Find account data in loaded account list
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>Account Data | null</returns>
        public static Account? FindAccount(string SessionId)
        {
            ReloadAccounts();
            foreach (var account in Accounts)
            {
                if (account.Aid == SessionId)
                {
                    return account;
                }
            }
            return null;
        }

        /// <summary>
        /// Get the Reserved Nickname for the session/account.
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>Account Email</returns>
        public static string GetReservedNickname(string SessionId)
        {
            var Account = FindAccount(SessionId);
            if (Account == null) { new Exception("Account null!"); }
            return Account.Email;
        }

        /// <summary>
        /// Get if Nickname is taken
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Request</param>
        /// <returns>False | True</returns>
        public static bool IsNicknameTaken(Requests.Nickname nickname)
        {
            var custom = ConfigController.Configs.CustomSettings;
            if (nickname == null) { return false; }
            if (custom.Account.CheckTakenNickname)
            {
                foreach (var acc in Accounts)
                {
                    if (acc.Email.ToLower() == nickname.nickname.ToLower())
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Validate a Nickname
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Request</param>
        /// <returns>tooshort | taken | OK</returns>
        public static string ValidateNickname(Requests.Nickname nickname)
        {
            if (nickname == null)
                return "taken";
            if (nickname.nickname.Length < 3)
                return "tooshort";
            if (IsNicknameTaken(nickname))
                return "taken";
            return "OK";
        }

        /// <summary>
        /// Remove a directory if account exist
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>OK | FAILED</returns>
        public static string RemoveAccount(string SessionId)
        {
            var Account = FindAccount(SessionId);
            if (Account == null) { return "FAILED"; }
            Directory.Delete($"profiles/{SessionId}", true);
            return "OK";
        }

        /// <summary>
        /// Delete everything that this account was used for.
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>OK | FAILED</returns>
        public static string DeleteAccount(string SessionId)
        {
            if (Directory.Exists($"profiles/{SessionId}"))
            {
                if (Accounts.Where(x => x.Aid == SessionId).Count() > 0)
                {
                    Accounts.Remove(Accounts.Where(x => x.Aid == SessionId).FirstOrDefault());
                }
                if (ActiveAccountIds.Contains(SessionId))
                {
                    ActiveAccountIds.Remove(SessionId);
                }
                KeepAliveController.DeleteKeepAlive(SessionId);
                Directory.Delete($"profiles/{SessionId}", true);
                return "OK";
            }
            return "FAILED";
        }
    }
}
