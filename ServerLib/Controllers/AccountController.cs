using Newtonsoft.Json;
using ServerLib.Utilities;
using ServerLib.Json;

namespace ServerLib.Controllers
{
    public class AccountController
    {
        public static List<LoginProfile> Profiles;
        public static List<Account> Accounts;
        public static List<string> ActiveAccountIds;
        //public static Dictionary<string,int> AccountActiveTime;

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
            Utils.PrintDebug("Initialization Done!", "debug","[ACCOUNT]");
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

        #endregion
        #region Ported Functions
        /// <summary>
        /// Login the Profile to the Server 
        /// <br>Same as Controllers/AccountController.js@func=login()</br>
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Profile</param>
        /// <returns>AccountId or FAILED</returns>
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
        /// <returns>AccountId or ALREADY_IN_USE</returns>
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
                string AccountID = Utils.CreateNewProfileID("AID");
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
                //Console.WriteLine(ID);
                return ID;
            }
        }

        /// <summary>
        /// Searching AccountId by Username and Password.
        /// <br>Same as Controllers/AccountController.js@func=findAccountIdByUsernameAndPassword()</br>
        /// </summary>
        /// <param name="name">UserName</param>
        /// <param name="passw">Password</param>
        /// <returns>AccountId or null</returns>
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
        /// <returns>True or False</returns>
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
        /// <returns>True or False</returns>
        public static bool ClientHasProfile(string sessionID)
        {
            if (sessionID==null) { Console.WriteLine("SessionID null?"); return false; }
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
                var character = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText($"{dir}/character.json"));
                Console.WriteLine(character.aid);
                CharacterOBJ obj = new();
                obj.Id = character.aid;
                obj._id = character.aid;
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
        /// Tries to find account data in loaded account list if not present returns null
        /// <br>Same as Controllers/AccountController.js@func=find()</br>
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>Account Data</returns>
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
        /// <returns>True or False</returns>
        public static bool IsWiped(string sessionID)
        {
            var Account = FindAccount(sessionID);
            if (Account == null) { new Exception("Account null!"); }
            return Account.Wipe;
        }

        /// <summary>
        /// Get the Reserved Nickname for the session/account.
        /// <br>Same as Controllers/AccountController.js@func=getReservedNickName()</br>
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>"" (kinda emtpy string)</returns>
        public static string GetReservedNickname(string sessionID)
        {
            ReloadAccountBySessionID(sessionID);
            return "";
        }

        /// <summary>
        /// Get if Nickname is taken
        /// <br>Same as Controllers/AccountController.js@func=nicknameTaken()</br>
        /// </summary>
        /// <param name="JsonInfo">Json Serialized Request</param>
        /// <returns>Always False</returns>
        public static bool IsNicknameTaken(string JsonInfo)
        {
            var nickname = JsonConvert.DeserializeObject<NicknameValidate>(JsonInfo);
            var custom = DatabaseController.DataBase.CustomSettings;
            if (nickname==null) { return false; }
            if (custom == null) { return false; }
            if (custom.Account.CheckTakenNickname)
            {
                foreach (var acc in Accounts)
                {
                    if (acc.Email.ToLower() == nickname.Nickname.ToLower()) return true;
                }
            }
            return false;
        }

        public static string GetPMCPath(string sessionID)
        {
            if (!File.Exists($"user/profiles/{sessionID}/character.json"))
            {
                return $"user/profiles/{sessionID}/character.json";
            }
            else
            {
                throw new Exception("PMC Path is not exist!");
            }
        }

        public static string GetAccountLang(string sessionID)
        {
            var Account = FindAccount(sessionID);
            if (Account == null) { new Exception("Account null!"); }

            if (Account.Lang == null)
            {
                Account.Lang = "en";
                //save Account!!!
            }
            return Account.Lang;
        }
        #endregion

    }
}
