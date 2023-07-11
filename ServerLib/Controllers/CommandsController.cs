using ServerLib.Handlers;
using DB = ServerLib.Utilities.Debug;
using System.Diagnostics;
using ServerLib.Json.Enums;
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
             { "deletematches" , DeleteMatches }
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
            { "deletematches" , EPerms.Mod }
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
            DB.PrintInfo("Debug mode has been enabled!");
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
            { "help" , Help },
            { "restart" , Restart },
            { "reload" , Reload },
            { "stop" , Stop },
            { "op" , Op },
            { "deop" , DeOp },
            { "setpermission" , SetPerm },
            { "ban" , Ban },
            { "unban" , UnBan },
            { "debug" , DebugEnable }
            
            */
            Console.WriteLine("Commands List: " + string.Join(", ", Commands.Keys.ToList()));
            Console.WriteLine();
            Console.WriteLine("reload:\t\t\t\tRestart the server");
            Console.WriteLine("restart:\t\t\tRestart the current app (Console)");
            Console.WriteLine("stop:\t\t\t\tStops the server");
            Console.WriteLine("op <AID>:\t\t\tGives admin to the specified AID");
            Console.WriteLine("deop <AID>:\t\t\tRemove admin from the specified AID");
            Console.WriteLine("setpermission <AID> <PermId>:\tSets Permission to the specified AID");
            Console.WriteLine("ban <AID>:\t\t\tBan the specified AID");
            Console.WriteLine("unban <AID>:\t\t\tUnban the specified AID");
            Console.WriteLine("debug:\t\t\t\tEnable Debug options");
            Console.WriteLine();
            Console.WriteLine("AID stands for "Account ID".");
            Console.WriteLine("You can find a user's AID in the profiles folder inside of your ConsoleApp.");
            Console.WriteLine("The user's AID is the name of the folder.");
            Console.WriteLine();
            Console.WriteLine("All commands should start with !");
            Console.WriteLine();
        }

        public static void Op(object obj)
        {
            var x = (string[])obj;
            if (x.Length == 0)
            {
                DB.PrintWarn("No user to give OP. use: !op <AID>");
                return;
            }               
            var AID = x[x.Length-1];
            var profile = ProfileController.GetProfile(AID);
            if (profile == null)
            {
                DB.PrintWarn("Profile doesn't exist. You cannot give OP to a non-existent profile!");
                return;
            }
            profile.ProfileAddon.Permission = Json.Enums.EPerms.Admin;
            SaveHandler.SaveAddon(AID,profile.ProfileAddon);
            DB.PrintInfo($"AID {AID} is now {Json.Enums.EPerms.Admin}");
        }

        public static void SetPerm(object obj)
        {
            var x = (string[])obj; 
            if (x.Length > 2)
            {
                DB.PrintWarn("No AID or permission defined. Use: !setpermission <AID>");
                return;
            }
            var AID = x[0];
            var perm = int.Parse(x[1]);
            var profile = ProfileController.GetProfile(AID);
            if (profile == null)
            {
                DB.PrintWarn("Profile doesn't exist. You cannot give OP to a non-existent profile!");
                return;
            }
            profile.ProfileAddon.Permission = (Json.Enums.EPerms)perm;
            SaveHandler.SaveAddon(AID, profile.ProfileAddon);
            DB.PrintInfo($"AID {AID} is now {(Json.Enums.EPerms)perm}");
        }

        public static void DeOp(object obj)
        {
            var x = (string[])obj;
            if (x.Length == 0)
            {
                DB.PrintWarn("No AID to DEOP, use: !deop <AID>");
                return;
            }
            var AID = x[0];
            var profile = ProfileController.GetProfile(AID);
            if (profile == null)
            {
                DB.PrintWarn("Profile doesn't exist. You cannot remove OP from a non-existent profile!");
                return;
            }
            profile.ProfileAddon.Permission = Json.Enums.EPerms.User;
            SaveHandler.SaveAddon(AID, profile.ProfileAddon);
            DB.PrintInfo($"AID {AID} is now {Json.Enums.EPerms.User}");
        }

        public static void Ban(object obj)
        {
            var x = (string[])obj;
            var AID = x[0];
            var profile = ProfileController.GetProfile(AID);
            if (profile == null)
            {
                DB.PrintWarn("Profile doesn't exist. You cannot ban a non-existent profile!");
                return;
            }
            profile.ProfileAddon.Permission = Json.Enums.EPerms.Blocked;
            SaveHandler.SaveAddon(AID, profile.ProfileAddon);
            DB.PrintInfo($"AID {AID} is now Banned");
        }

        public static void UnBan(object obj)
        {
            var x = (string[])obj;
            var AID = x[0];
            var profile = ProfileController.GetProfile(AID);
            if (profile == null)
            {
                DB.PrintWarn("Profile doesn't exist. You cannot unban a non-existent profile!");
                return;
            }
            profile.ProfileAddon.Permission = Json.Enums.EPerms.User;
            SaveHandler.SaveAddon(AID, profile.ProfileAddon);
            DB.PrintInfo($"AID {AID} is now Unbanned");
        }

        public static void ListMatches(object obj)
        {
            var maches = JsonConvert.SerializeObject(MatchController.Matches);
            DB.PrintInfo($"Current Matches: {maches}");
        }
        public static void DeleteMatches(object obj)
        {
            MatchController.Matches.Clear();
            DB.PrintInfo($"Matches Cleared!");
        }
    }
}
