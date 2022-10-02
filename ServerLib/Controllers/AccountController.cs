﻿using Newtonsoft.Json;
using ServerLib.Json;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class AccountController
    {
        public static List<LoginProfile> Profiles;
        public static List<Account> Accounts;
        public static List<string> ActiveAccountIds;

        #region Custom Made Functions
        public static void Init()
        {
            if (!Directory.Exists("user/profiles")) { Directory.CreateDirectory("user/profiles"); }

            Profiles = new();
            Profiles.Clear();
            Accounts = new();
            Accounts.Clear();
            ActiveAccountIds = new();
            ActiveAccountIds.Clear();
            Utils.PrintDebug("Initialization Done!", "debug", "[ACCOUNT]");
            GetAccountList();
        }

        public static void GetAccountList()
        {
            string[] dirs = Directory.GetDirectories("user/profiles");
            foreach (string dir in dirs)
            {
                if (!File.Exists($"{dir}/account.json")) { continue; }
                var account = JsonConvert.DeserializeObject<Account>(File.ReadAllText($"{dir}/account.json"));
                if (!Accounts.Contains(account))
                {
                    Accounts.Add(account);
                }
            }
        }

        /// <summary>
        /// Remove Session from ActiveAccounts
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        public static void SessionLogout(string sessionID)
        {
            Utils.PrintDebug($"User with ID {sessionID} has been logged out");
            ActiveAccountIds.Remove(sessionID);
        }

        #endregion
        #region Ported Functions
        /// <summary>
        /// Login the Profile to the Server 
        /// <br>Same as Controllers/AccountController.js@func=login()</br>
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Profile</param>
        /// <returns>AccountId | FAILED</returns>
        public static string Login(string JsonInfo)
        {
            var profile = JsonConvert.DeserializeObject<LoginProfile>(JsonInfo);
            string ID = FindAccountIdByUsernameAndPassword(profile.UserName, profile.Password);

            if (ID == null)
            {
                Console.WriteLine("Login FAILED! " + ID);
                return "FAILED";
            }
            else
            {
                Console.WriteLine("Login Success! " + ID);
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
        public static string Register(string JsonInfo)
        {
            var profile = JsonConvert.DeserializeObject<LoginProfile>(JsonInfo);
            string ID = FindAccountIdByUsernameAndPassword(profile.UserName, profile.Password);

            if (IsEmailAlreadyInUse(profile.UserName))
            {
                return "ALREADY_IN_USE";
            }
            if (ID == null)
            {
                string AccountID = Utils.CreateNewID("AID");
                Account account = new();
                account.Email = profile.Email;
                account.Password = profile.Password;
                account.Edition = profile.Edition;
                account.Id = AccountID;
                account.Matching = new();
                string serjson = JsonConvert.SerializeObject(account, Formatting.Indented);
                if (!Directory.Exists($"user/profiles/{AccountID}")) { Directory.CreateDirectory($"user/profiles/{AccountID}"); }
                File.WriteAllText($"user/profiles/{AccountID}/account.json", serjson);
                Console.WriteLine("Register Success! " + AccountID);
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
        /// <returns>AccountId | null</returns>
        public static string FindAccountIdByUsernameAndPassword(string name, string passw)
        {
            if (!Directory.Exists("user/profiles")) { Directory.CreateDirectory("user/profiles"); }
            string[] dirs = Directory.GetDirectories("user/profiles");
            foreach (string dir in dirs)
            {
                if (!File.Exists($"{dir}/account.json")) { continue; }
                var account = JsonConvert.DeserializeObject<Account>(File.ReadAllText($"{dir}/account.json"));
                if (account.Email == name && account.Password == passw)
                {
                    Console.WriteLine(dir);
                    return dir.Replace("user/profiles\\", "");
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
            if (!Directory.Exists("user/profiles")) { Directory.CreateDirectory("user/profiles"); }

            string[] dirs = Directory.GetDirectories("user/profiles");
            foreach (string dir in dirs)
            {
                if (!File.Exists($"{dir}/account.json")) { continue; }
                var account = JsonConvert.DeserializeObject<Account>(File.ReadAllText($"{dir}/account.json"));
                if (account.Email == name)
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
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>True | False</returns>
        public static bool ClientHasProfile(string sessionID)
        {
            if (sessionID == null) { Console.WriteLine("SessionID null?"); return false; }
            var account = FindAccount(sessionID);
            if (account != null)
            {
                if (!File.Exists("user/profiles/" + sessionID + "/character.json"))
                {
                    Console.WriteLine($"New account {sessionID} logged in!");
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets ALL of the account data from every profile in the user/profiles directory
        /// <br>Same as Controllers/AccountController.js@func=getAllAccounts()</br>
        /// </summary>
        /// <returns>All the Account data neccessary to process accounts in the Server and Client</returns>
        public static List<CharacterOBJ> GetAccounts()
        {
            List<CharacterOBJ> fullyLoadedAccounts = new();
            string[] dirs = Directory.GetDirectories("user/profiles");
            foreach (string dir in dirs)
            {
                string ID = dir.Replace("user/profiles\\", "");
                ReloadAccountBySessionID(ID);
                //InitializeProfile(ID);

                if (!File.Exists($"{dir}/character.json")) { continue; }
                var character = JsonConvert.DeserializeObject<Character.Base>(File.ReadAllText($"{dir}/character.json"));
                Console.WriteLine(character.Aid);
                CharacterOBJ obj = new();
                obj.Id = character.Aid;
                obj._id = character.Aid;
                obj.Nickname = character.Info.Nickname;
                obj.Level = character.Info.Level;
                obj.PlayerVisualRepresentation = new();
                obj.PlayerVisualRepresentation.Info.Nickname = character.Info.Nickname;
                obj.PlayerVisualRepresentation.Info.Side = character.Info.Side;
                obj.PlayerVisualRepresentation.Info.Level = character.Info.Level;
                obj.PlayerVisualRepresentation.Info.MemberCategory = character.Info.MemberCategory;
                obj.PlayerVisualRepresentation.Customization = character.Customization;
                fullyLoadedAccounts.Add(obj);
            }
            return fullyLoadedAccounts;
        }

        /// <summary>
        /// Reload that account you provide by in SessonID
        /// <br>Same as Controllers/AccountController.js@func=reloadAccountBySessionID()</br>
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        public static void ReloadAccountBySessionID(string sessionID)
        {
            if (sessionID == null) { new Exception("SessionID Null!"); }
            if (!File.Exists($"user/profiles/{sessionID}/account.json"))
            {
                Console.WriteLine("[WARN] Account file not exist. ID: " + sessionID);
            }
            else
            {
                if (Accounts.Where(x => x.Id == sessionID).Count() == 0)
                {
                    Console.WriteLine("[WARN] Account isnt Cached, Load from disk. ID:" + sessionID);
                    var account = JsonConvert.DeserializeObject<Account>(File.ReadAllText($"user/profiles/{sessionID}/account.json"));
                    Accounts.Add(account);
                }
            }
        }

        /// <summary>
        /// Find account data in loaded account list
        /// <br>Same as Controllers/AccountController.js@func=find()</br>
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>Account Data | null</returns>
        public static Account FindAccount(string sessionID)
        {
            ReloadAccountBySessionID(sessionID);
            foreach (var account in Accounts)
            {
                if (account.Id == sessionID)
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
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>True | False</returns>
        public static bool IsWiped(string sessionID)
        {
            var Account = FindAccount(sessionID);
            if (Account == null) { new Exception("Account null!"); }
            return Account.Wipe;
        }

        /// <summary>
        /// Get the Reserved Nickname for the session/account.
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>Account Email</returns>
        public static string GetReservedNickname(string sessionID)
        {
            ReloadAccountBySessionID(sessionID);
            var Account = FindAccount(sessionID);
            if (Account == null) { new Exception("Account null!"); }
            return Account.Email;
        }

        /// <summary>
        /// Get if Nickname is taken
        /// <br>Same as Controllers/AccountController.js@func=nicknameTaken()</br>
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Request</param>
        /// <returns>False | True</returns>
        public static bool IsNicknameTaken(string JsonInfo)
        {
            var nickname = JsonConvert.DeserializeObject<NicknameValidate>(JsonInfo);
            var custom = ConfigController.Configs.CustomSettings;
            if (nickname == null) { return false; }
            if (custom.Account.CheckTakenNickname)
            {
                foreach (var acc in Accounts)
                {
                    if (acc.Email.ToLower() == nickname.Nickname.ToLower()) return true;
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
        public static string ValidateNickname(string JsonInfo)
        {
            var nickname = JsonConvert.DeserializeObject<NicknameValidate>(JsonInfo);
            if (nickname == null) { return "taken"; }
            if (nickname.Nickname.Length < 3)
            {
                return "tooshort";
            }
            if (IsNicknameTaken(JsonInfo))
            {
                return "taken";
            }
            return "OK";
        }

        /// <summary>
        /// Get the Lang from Account by SessionId
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>"en" | Account Lang</returns>
        public static string GetAccountLang(string sessionID)
        {
            var Account = FindAccount(sessionID);
            if (Account == null) { new Exception("Account null!"); }
            return Account.Lang;
        }

        /// <summary>
        /// Tries to login and change the Account Password
        /// <br>Same as Controllers/AccountController.js@func=changePassword()</br>
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Profile & Changes</param>
        /// <returns>AccountID | FAILED</returns>
        public static string ChangePassword(string JsonInfo)
        {
            var AccountID = Login(JsonInfo);
            var changes = JsonConvert.DeserializeObject<Changes>(JsonInfo);
            if (AccountID != "FAILED")
            {
                var Account = FindAccount(AccountID);
                Account.Password = changes.Change;
                Handlers.SaveHandler.SaveAccount(AccountID, Account);
            }
            return AccountID;
        }

        /// <summary>
        /// Tries to login and change the Account Email
        /// <br>Same as Controllers/AccountController.js@func=changeEmail()</br>
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Profile & Changes</param>
        /// <returns>AccountID | FAILED</returns>
        public static string ChangeEmail(string JsonInfo)
        {
            var AccountID = Login(JsonInfo);
            var changes = JsonConvert.DeserializeObject<Changes>(JsonInfo);
            if (AccountID != "FAILED")
            {
                var Account = FindAccount(AccountID);
                Account.Email = changes.Change;
                Handlers.SaveHandler.SaveAccount(AccountID, Account);
            }
            return AccountID;
        }
        #endregion
        #region Edited but same functions
        /// <summary>
        /// Set session ready to WIPE
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>OK | FAILED</returns>
        public static string SetWipe(string sessionID)
        {
            var Account = FindAccount(sessionID);
            if (Account == null) { return "FAILED"; }
            Account.Wipe = true;
            return "OK";
        }

        /// <summary>
        /// Remove a directory if account exist
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>OK | FAILED</returns>
        public static string RemoveAccount(string sessionID)
        {
            var Account = FindAccount(sessionID);
            if (Account == null) { return "FAILED"; }
            Directory.Delete($"user/profiles/{sessionID}", true);
            return "OK";
        }

        /// <summary>
        /// Delete everything that this account was used for.
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <param name="profile">Account/Profile Name</param>
        /// <returns>OK | FAILED</returns>
        public static string DeleteAccount(string sessionID, string profile)
        {
            if (Directory.Exists($"user/profiles/{sessionID}"))
            {
                if (Accounts.Where(x => x.Id == sessionID).Count() > 0)
                {
                    Accounts.Remove(Accounts.Where(x => x.Id == sessionID).FirstOrDefault());
                }
                if (Profiles.Where(x => x.UserName == profile).Count() > 0)
                {
                    Profiles.Remove(Profiles.Where(x => x.UserName == profile).FirstOrDefault());
                }
                if (ActiveAccountIds.Contains(sessionID))
                {
                    ActiveAccountIds.Remove(sessionID);
                }
                DialogController.RemoveDialog(sessionID);
                Handlers.SaveHandler.DeleteAll(sessionID);
                KeepAliveController.DeleteKeepAlive(sessionID);
                Directory.Delete($"user/profiles/{sessionID}", true);
                return "OK";
            }
            return "FAILED";
        }
        #endregion

    }
}
