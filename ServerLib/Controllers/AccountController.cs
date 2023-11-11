using JsonLib.Classes.ProfileRelated;
using JsonLib.Classes.Request;
using ServerLib.Handlers;
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
            Debug.PrintInfo("Initialization Done!", "ACCOUNT");
        }

        public static void GetAccountList()
        {
            ProfileController.ReloadProfiles();
            ProfileController.Profiles.ForEach(profile =>
            {
                if (profile.Info == null)
                    return;

                if (!Accounts.Contains(profile.Info))
                {
                    Debug.PrintInfo($"(Re)Loaded account data for profile: [{profile.Info.Id}]", "ACCOUNT");
                    Accounts.Add(profile.Info);
                }
            });
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
        /// </summary>
        /// <param name="login">Json Serialized login</param>
        /// <returns>AccountId | FAILED</returns>
        public static string Login(Login login)
        {
            var ID = FindAccountIdByUsernameAndPassword(login.username, login.password);

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
        /// </summary>
        /// <param name="login">Json Serialized Profile</param>
        /// <returns>AccountId | ALREADY_IN_USE</returns>
        public static string Register(Login login)
        {
            var ID = FindAccountIdByUsernameAndPassword(login.username, login.password);

            if (IsNameInUse(login.username))
            {
                return "ALREADY_IN_USE";
            }
            if (ID == null)
            {
                string AccountID = AIDHelper.CreateNewID();
                Profile.Info account = new()
                {
                    Id = AccountID,
                    Username = login.username,
                    Wipe = false
                };
                if (ConfigController.Configs.CustomSettings.Account.UseSha1)
                    account.Password = CryptoHelper.Hash(login.password);
                else
                    account.Password = login.password;
                SaveHandler.SaveAccount(AccountID, account);
                SaveHandler.SaveAddon(AccountID, new());
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
        public static string? FindAccountIdByUsernameAndPassword(string name, string passw)
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
        /// </summary>
        /// <param name="name">Username</param>
        /// <returns>True | False</returns>
        public static bool IsNameInUse(string name)
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
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>True | False</returns>
        public static bool ClientHasProfile(string SessionId)
        {
            ReloadAccountBySessionId(SessionId);
            var profile = ProfileController.GetProfile(SessionId);
            if (profile != null)
            {
                return true;
            }
            Debug.PrintInfo($"New account {SessionId} logged in!");
            return false;
        }


        /// <summary>
        /// Reload that account you provide by in SessonID
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void ReloadAccountBySessionId(string SessionId)
        {
            if (SessionId == null) { throw new Exception("SessionId Null!"); }
            var profile = ProfileController.GetProfile(SessionId);
            if (profile == null || profile.Info == null)
                return;

            if (Accounts.Where(x => x.Id != SessionId).Any())
            {
                Debug.PrintInfo($"(Re)Loaded account data for profile: [{profile.Info.Id}]", "ACCOUNT");
                Accounts.Add(profile.Info);
            }
        }

        /// <summary>
        /// Find account data in loaded account list
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
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>True | False</returns>
        public static bool IsWiped(string SessionId)
        {
            var Account = FindAccount(SessionId);
            return Account == null ? throw new Exception("Account null!") : Account.Wipe;
        }

        /// <summary>
        /// Get the Reserved Nickname for the session/account.
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>Account Email</returns>
        public static string GetReservedNickname(string SessionId)
        {
            var Account = FindAccount(SessionId);
            return Account == null ? throw new Exception("Account null!") : Account.Username;
        }

        /// <summary>
        /// Get if Nickname is taken
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Request</param>
        /// <returns>False | True</returns>
        public static bool IsNicknameTaken(Nickname nickname)
        {
            var custom = ConfigController.Configs.CustomSettings;
            if (nickname == null) { return false; }
            if (custom.Account.CheckTakenNickname)
            {
                GetAccountList();
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
            return Account == null ? throw new Exception("Account null!") : Account.Lang;
        }

        /// <summary>
        /// Tries to login and change the Account Password
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Profile & Changes</param>
        /// <returns>AccountID | FAILED</returns>
        public static string ChangePassword(Change changes)
        {
            var AccountID = Login(changes);
            if (AccountID != "FAILED")
            {
                var Account = FindAccount(AccountID);
                ArgumentNullException.ThrowIfNull(Account);
                if (ConfigController.Configs.CustomSettings.Account.UseSha1)
                    Account.Password = CryptoHelper.Hash(Account.Password);
                else
                    Account.Password = Account.Password;
                SaveHandler.SaveAccount(AccountID, Account);
            }
            return AccountID;
        }

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
            //Send this to CharacterController.Wipe
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
        /// <returns>OK | FAILED</returns>
        public static string DeleteAccount(string SessionId)
        {
            if (Directory.Exists($"user/profiles/{SessionId}"))
            {
                if (Accounts.Where(x => x.Id == SessionId).Any())
                {
                    Accounts.Remove(Accounts.Where(x => x.Id == SessionId).First());
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
