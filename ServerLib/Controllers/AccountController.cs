using Newtonsoft.Json;
using ServerLib.Handlers;
using ServerLib.Json.Classes;
using ServerLib.Json.Helpers;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Controllers
{
    public class AccountController
    {
        static AccountController()
        {
            if (!Directory.Exists("user/profiles")) { Directory.CreateDirectory("user/profiles"); }

            Accounts = new();
            Accounts.Clear();
            ActiveAccountIds = new();
            ActiveAccountIds.Clear();
        }

        public static List<Profile.Info> Accounts;
        public static List<string> ActiveAccountIds;

        #region Custom Made Functions
        public static void Init()
        {
            GetAccountList();
            Debug.PrintInfo("Initialization Done!", "[ACCOUNT]");
        }

        public static void GetAccountList()
        {
            string[] dirs = Directory.GetDirectories("user/profiles");
            foreach (string dir in dirs)
            {
                if (!File.Exists($"{dir}/account.json")) { continue; }
                var account = JsonConvert.DeserializeObject<Profile.Info>(File.ReadAllText($"{dir}/account.json"));
                if (!Accounts.Contains(account))
                {
                    Debug.PrintInfo("(Re)Loaded account data for profile: " + account.Id, "[ACCOUNT]");
                    Accounts.Add(account);
                }
                if (!ActiveAccountIds.Contains(account.Id))
                {
                    ActiveAccountIds.Add(account.Id);
                }
            }
        }

        /// <summary>
        /// Remove Session from ActiveAccounts
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void SessionLogout(string SessionId)
        {
            Debug.PrintDebug($"User with ID {SessionId} has been logged out");
            ActiveAccountIds.Remove(SessionId);
        }

        #endregion
        #region Ported Functions
        /// <summary>
        /// Login the Profile to the Server 
        /// <br>Same as Controllers/AccountController.js@func=login()</br>
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Profile</param>
        /// <returns>AccountId | FAILED</returns>
        public static string Login(Profile.Info profile)
        {
            string ID = FindAccountIdByUsernameAndPassword(profile.Username, profile.Password);

            if (ID == null)
            {
                Debug.PrintInfo("Login FAILED! " + ID);
                return "FAILED";
            }
            else
            {
                Debug.PrintInfo("Login Success! " + ID);
                if (!ActiveAccountIds.Contains(ID))
                {
                    ActiveAccountIds.Add(ID);
                }
                return ID;
            }
        }

        /// <summary>
        /// Register the Profile to the Server
        /// <br>Same as Controllers/AccountController.js@func=register()</br>
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Profile</param>
        /// <returns>AccountId | ALREADY_IN_USE</returns>
        public static string Register(Profile.Info profile)
        {
            string ID = FindAccountIdByUsernameAndPassword(profile.Username, profile.Password);

            if (IsEmailAlreadyInUse(profile.Username))
            {
                return "ALREADY_IN_USE";
            }
            if (ID == null)
            {
                string AccountID = Utils.CreateNewID("AID");
                Profile.Info account = new()
                {
                    Id = AccountID,
                    Username = profile.Username,
                    Edition = profile.Edition,
                    Wipe = false
                };
                if (ConfigController.Configs.CustomSettings.Account.UseSha1)
                    account.Password = CryptoHelper.Hash(profile.Password);
                else
                    account.Password = profile.Password;
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
        /// <br>Same as Controllers/AccountController.js@func=findAccountIdByUsernameAndPassword()</br>
        /// </summary>
        /// <param name="name">UserName</param>
        /// <param name="passw">Password</param>
        /// <returns>AccountId | ""</returns>
        public static string FindAccountIdByUsernameAndPassword(string name, string passw)
        {
            GetAccountList();
            foreach (var account in Accounts)
            {
                if (ConfigController.Configs.CustomSettings.Account.UseSha1)
                {
                    if (account.Username == name && account.Password == CryptoHelper.Hash(passw))
                    {
                        return account.Id;
                    }
                }
                else
                {
                    if (account.Username == name && account.Password == passw)
                    {
                        return account.Id;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Check if already is Email is used by another user.
        /// <br>Same as Controllers/AccountController.js@func=isEmailAlreadyInUse()</br>
        /// </summary>
        /// <param name="name">Username</param>
        /// <returns>True | False</returns>
        public static bool IsEmailAlreadyInUse(string name)
        {
            GetAccountList();
            foreach (var account in Accounts)
            {
                if (account.Username == name)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check the Client character exist.
        /// <br>Same as Controllers/AccountController.js@func=clientHasProfile()</br>
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>True | False</returns>
        public static bool ClientHasProfile(string SessionId)
        {
            ReloadAccountBySessionId(SessionId);
            var account = FindAccount(SessionId);
            if (account != null)
            {
                if (!File.Exists("user/profiles/" + SessionId + "/character.json"))
                {
                    Debug.PrintInfo($"New account {SessionId} logged in!");
                }
                return true;
            }
            return false;
        }


        /// <summary>
        /// Reload that account you provide by in SessonID
        /// <br>Same as Controllers/AccountController.js@func=reloadAccountBySessionId()</br>
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void ReloadAccountBySessionId(string SessionId)
        {
            if (SessionId == null) { new Exception("SessionId Null!"); }
            if (!File.Exists($"user/profiles/{SessionId}/account.json"))
            {
                Debug.PrintWarn("Account file not exist. ID: " + SessionId);
            }
            else
            {
                if (Accounts.Where(x => x.Id == SessionId).Count() == 0)
                {
                    Debug.PrintInfo("[WARN] Account isnt Cached, Load from disk. ID:" + SessionId);
                    var account = JsonConvert.DeserializeObject<Profile.Info>(File.ReadAllText($"user/profiles/{SessionId}/account.json"));
                    Accounts.Add(account);
                }
            }
        }

        /// <summary>
        /// Find account data in loaded account list
        /// <br>Same as Controllers/AccountController.js@func=find()</br>
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>Account Data | null</returns>
        public static Profile.Info? FindAccount(string SessionId)
        {
            ReloadAccountBySessionId(SessionId);
            foreach (var account in Accounts)
            {
                if (account.Id == SessionId)
                {
                    return account;
                }
            }
            return null;
        }

        /// <summary>
        /// Get if the Account is Wiped or not
        /// <br>Same as Controllers/AccountController.js@func=IsWiped()</br>
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>True | False</returns>
        public static bool IsWiped(string SessionId)
        {
            var Account = FindAccount(SessionId);
            if (Account == null) { new Exception("Account null!"); }
            return Account.Wipe;
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
            return Account.Username;
        }

        /// <summary>
        /// Get if Nickname is taken
        /// <br>Same as Controllers/AccountController.js@func=nicknameTaken()</br>
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Request</param>
        /// <returns>False | True</returns>
        public static bool IsNicknameTaken(Nickname nickname)
        {
            var custom = ConfigController.Configs.CustomSettings;
            if (nickname == null) { return false; }
            if (custom.Account.CheckTakenNickname)
            {
                foreach (var acc in Accounts)
                {
                    if (acc.Username.ToLower() == nickname.nickname.ToLower())
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Validate a Nickname
        /// <br>Same as Controllers/AccountController.js@func=validateNickname()</br>
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Request</param>
        /// <returns>tooshort | taken | OK</returns>
        public static string ValidateNickname(Nickname nickname)
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
        /// Get the Lang from Account by SessionId
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>"en" | Account Lang</returns>
        public static string GetAccountLang(string SessionId)
        {
            var Account = FindAccount(SessionId);
            if (Account == null) { new Exception("Account null!"); }
            return Account.Lang;
        }

        /// <summary>
        /// Tries to login and change the Account Password
        /// <br>Same as Controllers/AccountController.js@func=changePassword()</br>
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Profile & Changes</param>
        /// <returns>AccountID | FAILED</returns>
        public static string ChangePassword(Change changes)
        {
            var AccountID = Login(JsonHelper.FromLogin(changes));
            if (AccountID != "FAILED")
            {
                var Account = FindAccount(AccountID);
                if (ConfigController.Configs.CustomSettings.Account.UseSha1)
                    Account.Password = CryptoHelper.Hash(Account.Password);
                else
                    Account.Password = Account.Password;
                SaveHandler.SaveAccount(AccountID, Account);
            }
            return AccountID;
        }
        #endregion
        #region Edited but same functions
        /// <summary>
        /// Set session ready to WIPE
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>OK | FAILED</returns>
        public static string SetWipe(string SessionId)
        {
            var Account = FindAccount(SessionId);
            if (Account == null) { return "FAILED"; }
            Account.Wipe = true;
            SaveHandler.SaveAccount(SessionId, Account);
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
            Directory.Delete($"user/profiles/{SessionId}", true);
            return "OK";
        }

        /// <summary>
        /// Delete everything that this account was used for.
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="profile">Account/Profile Name</param>
        /// <returns>OK | FAILED</returns>
        public static string DeleteAccount(string SessionId)
        {
            if (Directory.Exists($"user/profiles/{SessionId}"))
            {
                if (Accounts.Where(x => x.Id == SessionId).Count() > 0)
                {
                    Accounts.Remove(Accounts.Where(x => x.Id == SessionId).FirstOrDefault());
                }
                if (ActiveAccountIds.Contains(SessionId))
                {
                    ActiveAccountIds.Remove(SessionId);
                }
                KeepAliveController.DeleteKeepAlive(SessionId);
                Directory.Delete($"user/profiles/{SessionId}", true);
                return "OK";
            }
            return "FAILED";
        }
        #endregion

    }
}
