using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Tarkov_Server_Csharp.Controllers
{
    internal class AccountController
    {
        public static List<JsonD.Profile> Profiles;
        public static List<JsonD.Account> Accounts;
        public static List<string> ActiveAccountIds;

        #region Custom Made Functions
        public static void Init()
        {
            Profiles = new();
            Profiles.Clear();
            Accounts = new();
            Accounts.Clear();
            ActiveAccountIds = new();
            ActiveAccountIds.Clear();
            Console.WriteLine("Init Done!");
        }

        public static void GetAccountList()
        {
            string[] dirs = Directory.GetDirectories("user/profiles");
            foreach (string dir in dirs)
            {
                if (!File.Exists($"{dir}/account.json")) { continue; }
                var account = JsonConvert.DeserializeObject<JsonD.Account>(File.ReadAllText($"{dir}/account.json"));
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
            var profile = JsonConvert.DeserializeObject<JsonD.Profile>(JsonInfo);
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
            var profile = JsonConvert.DeserializeObject<JsonD.Profile>(JsonInfo);
            string ID = FindAccountIdByUsernameAndPassword(profile.UserName, profile.Password);

            if (IsEmailAlreadyInUse(profile.UserName))
            {
                return "ALREADY_IN_USE";
            }
            if (ID == null)
            {
                string AccountID = Utils.CreateNewProfileID();
                JsonD.Account account = new();
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
                var account = JsonConvert.DeserializeObject<JsonD.Account>(File.ReadAllText($"{dir}/account.json"));
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
                var account = JsonConvert.DeserializeObject<JsonD.Account>(File.ReadAllText($"{dir}/account.json"));
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
            ReloadAccountBySessionID(sessionID);
            foreach (var account in Accounts)
            {
                if (account.Id == sessionID)
                {
                    if (!File.Exists("user/profiles/" + sessionID + "/character.json"))
                    {
                        Console.WriteLine($"New account {sessionID} logged in!");
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Get all accounts
        /// <br>Same as Controllers/AccountController.js@func=getAllAccounts()</br>
        /// </summary>
        public static void GetAccounts()
        {
            List<JObject> fullyLoadedAccounts = new();
            /*
            JObject jObject = new();
            jObject.Add(new JProperty("xxx","xxx"));
            Console.WriteLine(jObject.ToString());
            fullyLoadedAccounts.Add(jObject);
            jObject.Add(new JProperty("x2xx", "xx2x"));
            fullyLoadedAccounts.Add(jObject);
            foreach (var x in fullyLoadedAccounts)
            {
                Console.WriteLine(x);
            }*/
            string[] dirs = Directory.GetDirectories("user/profiles");
            foreach (string dir in dirs)
            {
                if (!File.Exists($"{dir}/character.json")) { continue; }
                var account = JsonConvert.DeserializeObject<JsonD.Account>(File.ReadAllText($"{dir}/character.json"));
                if (!Accounts.Contains(account))
                {
                    Accounts.Add(account);
                }
            }
        }

        /// <summary>
        /// Reload that account you provide by in SessonID
        /// <br>Same as Controllers/AccountController.js@func=reloadAccountBySessionID()</br>
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        public static void ReloadAccountBySessionID(string sessionID) 
        {
            if (!File.Exists($"user/profiles/{sessionID}/account.json"))
            {
                Console.WriteLine("[WARN] Account file not exist. ID: " + sessionID);
            }
            else
            {
                if (Accounts.Where(x => x.Id == sessionID).Count() == 0)
                {
                    Console.WriteLine("[WARN] Account isnt Cached, Load from disk. ID:" + sessionID);
                    var account = JsonConvert.DeserializeObject<JsonD.Account>(File.ReadAllText($"user/profiles/{sessionID}/account.json"));
                    Accounts.Add(account);
                }
            } 
        }
        #endregion

    }
}
