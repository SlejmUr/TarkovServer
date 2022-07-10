using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Tarkov_Server_Csharp.Controllers
{
    internal class AccountController //AKA AccountController
    {
        public static List<JsonD.Profile> Profiles = new();
        public static List<JsonD.Account> Accounts = new();
        public static List<string> ActiveAccountIds = new();
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
                string AccountID = CreateNewProfileID();
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
            GetAccountList();
            foreach (var account in Accounts)
            {
                if (account.Id == sessionID)
                {
                    if (!File.Exists("user/profiles/" + sessionID + "/character.json"))
                    {
                        Console.WriteLine($"\nNew account {sessionID} logged in!");
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









        public static string CreateNewProfileID()
        {
            Random rand = new Random();

            // Choosing the size of string
            // Using Next() string
            int stringlen = 24;
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < stringlen; i++)
            {

                // Generating a random number.
                randValue = rand.Next(0, 26);

                // Generating random character by converting
                // the random number into character.
                letter = Convert.ToChar(randValue + 65);

                // Appending the letter to string.
                str = str + letter;
            }
            string md5_str = ConvertStringtoMD5(str);
            Console.Write("Random String: " + md5_str + "\n");
            return "AID" + md5_str;
        }

        public static string ConvertStringtoMD5(string strword)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(strword);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
