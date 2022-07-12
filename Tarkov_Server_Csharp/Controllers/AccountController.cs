using Newtonsoft.Json;

namespace Tarkov_Server_Csharp.Controllers
{
    internal class AccountController
    {
        public static List<JsonD.Profile> Profiles;
        public static List<JsonD.Account> Accounts;
        public static List<string> ActiveAccountIds;

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
                Console.WriteLine(ID);
                return ID;
            }

        }
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
        //Same as Controllers/AccountController.js&func=getAllAccounts()
        public static void GetAccounts()
        {
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

        //Same as Controllers/AccountController.js&func=reloadAccountBySessionID()
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
                else
                { 
                
                }
            } 
        }


    }
}
