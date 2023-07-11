using ServerLib.Handlers;
using DB = ServerLib.Utilities.Debug;
using System.Diagnostics;
using ServerLib.Json;
using Newtonsoft.Json;

namespace ServerLib.Controllers
{
    public class CommandsController
    {
        public static Dictionary<string, Action<object>> Commands = new()
        {
            { "help" , Help },
            { "restart" , Restart },
            { "reload" , Reload },
            { "stop" , Stop },
            { "op" , Op },
            { "deop" , DeOp },
            { "setpermission" , SetPerm },
            { "ban" , Ban },
            { "unban" , UnBan },
            { "debug" , DebugEnable },
            { "listmatches" , ListMatches },
            { "deletematches" , DeleteMatches },
            { "registeruser", RegisterUser }
        };
        public static Dictionary<string, EPerms> CommandsPermission = new()
        {
            { "help" , EPerms.User },
            { "restart" , EPerms.Admin },
            { "reload" , EPerms.Admin },
            { "stop" , EPerms.Console },
            { "op" , EPerms.Mod },
            { "deop" , EPerms.Mod },
            { "setpermission" , EPerms.Mod },
            { "ban" , EPerms.Mod },
            { "unban" , EPerms.Mod },
            { "debug" , EPerms.Console },
            { "listmatches" , EPerms.User },
            { "deletematches" , EPerms.Mod },
            { "registeruser", EPerms.User }
        };

        public static void Run(string CommandName)
        {
            var splitted = CommandName.Split(" ");
            CommandName = splitted[0];
            var Parameter = splitted[1..];
            Console.WriteLine(string.Join("," , Parameter));
            if (Commands.TryGetValue(CommandName.Replace("!", ""), out var action))
            {
                action(Parameter);
            }
        }

        public static void Nothing()
        {

        }


        public static void DebugEnable(object obj)
        {
            ArgumentHandler.Debug = true;
            DB.PrintInfo("Debug has been enabled!");
        }

        public static void Restart(object obj)
        {
            var path = AppDomain.CurrentDomain.FriendlyName;
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = "/C timeout /T 3 && \"" + path + "\"";
            Info.FileName = "cmd.exe";
            Process.Start(Info);
            Console.Clear();
            Environment.Exit(0);
        }

        public static void Reload(object obj)
        {
            ServerLib.Stop();
            ServerLib.Init();
        }

        public static void Stop(object obj)
        {
            ServerLib.Stop();
        }

        public static void Help(object obj)
        {
            /*
            { "help" , EPerms.User },
            { "restart" , EPerms.Admin },
            { "reload" , EPerms.Admin },
            { "stop" , EPerms.Console },
            { "op" , EPerms.Mod },
            { "deop" , EPerms.Mod },
            { "setpermission" , EPerms.Mod },
            { "ban" , EPerms.Mod },
            { "unban" , EPerms.Mod },
            { "debug" , EPerms.Console },
            { "listmatches" , EPerms.User },
            { "deletematches" , EPerms.Mod },
            { "registeruser", EPerms.User }
            */
            Console.WriteLine("Commands List: " + string.Join(", ", Commands.Keys.ToList()));
            Console.WriteLine();
            Console.WriteLine("reload:\t\t\t\tRestart the server");
            Console.WriteLine("restart:\t\t\tRestart the current app (Console)");
            Console.WriteLine("stop:\t\t\t\tStops the server");
            Console.WriteLine("op <AID>:\t\t\tGives admin to the given AID");
            Console.WriteLine("deop <AID>:\t\t\tRemoves admin from the given AID");
            Console.WriteLine("setpermission <AID> <PermId>:\tSets permissions for the given AID");
            Console.WriteLine("ban <AID>:\t\t\tBan the given AID");
            Console.WriteLine("unban <AID>:\t\t\tUnban the given AID");
            Console.WriteLine("debug:\t\t\t\tEnable Debug options");
            Console.WriteLine("listmatches:\t\t\tList all matches");
            Console.WriteLine("deletematches:\t\t\tDelete all matches");
            Console.WriteLine("registeruser <mail> <pass>:\t\tRegister designed user");
            Console.WriteLine();
            Console.WriteLine("AID stands for "Account ID". You can find a user's AID in ConsoleApp's 'profiles' folder.");
            Console.WriteLine("The name of the folder is the user's AID.");
        }

        public static void Op(object obj)
        {
            var x = (string[])obj;
            if (x.Length == 0)
            {
                DB.PrintWarn("No User to OP, use: !op <AID>");
                return;
            }               
            var AID = x[x.Length-1];
            var account = AccountController.FindAccount(AID);
            if (account == null)
            {
                DB.PrintWarn("Profile null, cannot give OP to a non-existent profile!");
                return;
            }
            account.Permission = EPerms.Admin;
            SaveHandler.SaveAccount(AID, account);
            DB.PrintInfo($"User {AID} is now {EPerms.Admin}");
        }

        public static void SetPerm(object obj)
        {
            var x = (string[])obj; 
            if (x.Length > 2)
            {
                DB.PrintWarn("No User or Permission defined. Use: !setpermission <AID>");
                return;
            }
            var AID = x[0];
            var perm = int.Parse(x[1]);
            var account = AccountController.FindAccount(AID);
            if (account == null)
            {
                DB.PrintWarn("Profile null, cannot set permission for a non-existent profile!");
                return;
            }
            account.Permission = (EPerms)perm;
            SaveHandler.SaveAccount(AID, account);
            DB.PrintInfo($"User {AID} is now {(EPerms)perm}");
        }

        public static void DeOp(object obj)
        {
            var x = (string[])obj;
            if (x.Length == 0)
            {
                DB.PrintWarn("No User to DEOP, use: !deop <AID>");
                return;
            }
            var AID = x[0];
            var account = AccountController.FindAccount(AID);
            if (account == null)
            {
                DB.PrintWarn("Profile null, cannot remove OP from non-existent profile!");
                return;
            }
            account.Permission = EPerms.User;
            SaveHandler.SaveAccount(AID, account);
            DB.PrintInfo($"User {AID} is now {EPerms.User}");
        }

        public static void Ban(object obj)
        {
            var x = (string[])obj;
            var AID = x[0];
            var account = AccountController.FindAccount(AID);
            if (account == null)
            {
                DB.PrintWarn("Profile null, cannot ban non-existent profile!");
                return;
            }
            account.Permission = EPerms.Blocked;
            SaveHandler.SaveAccount(AID, account);
            DB.PrintInfo($"User {AID} is now Banned");
        }

        public static void UnBan(object obj)
        {
            var x = (string[])obj;
            var AID = x[0];
            var account = AccountController.FindAccount(AID);
            if (account == null)
            {
                DB.PrintWarn("Profile null, cannot unban non-existent profile!");
                return;
            }
            account.Permission = EPerms.User;
            SaveHandler.SaveAccount(AID, account);
            DB.PrintInfo($"User {AID} unbanned");
        }

        public static void ListMatches(object obj)
        {
            var maches = JsonConvert.SerializeObject(MatchController.Matches);
            DB.PrintInfo($"Matches: {maches}");
        }
        public static void DeleteMatches(object obj)
        {
            MatchController.Matches.Clear();
            DB.PrintInfo($"Matches Cleared!");
        }

        public static void RegisterUser(object obj)
        {
            var x = (string[])obj;
            var email = x[0];
            var pass = x[1];
            if (x.Length < 1)
            {
                DB.PrintWarn("Command not complete. Use: !registeruser <mail> <pass> (with <mail> and <pass> being your username and password)");
                return;
            }
            var account = AccountController.Register(new()
            { 
                email = email,
                pass = pass
            });
            DB.PrintInfo($"AID {account} created!");
        }
    }
}
