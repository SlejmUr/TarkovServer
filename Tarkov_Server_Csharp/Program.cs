using Newtonsoft.Json;
using ServerLib;
using ServerLib.Controllers;
using ServerLib.Handlers;
using ServerLib.Utilities;
using ServerLib.Json;
using System.Net;
using System.Globalization;
using Newtonsoft.Json.Converters;

namespace Tarkov_Server_Csharp
{
    internal class Program
    {
        static string IP_Address = "26.48.71.165"; //Or use Localhost
        static int Port = 7777;
        public static string ip_port = $"https://{IP_Address}:{Port}";
        static void Main(string[] args)
        {
            var version = new CVersion();
            Console.WriteLine("Welcome in Tarkov Server Console!");
            Console.WriteLine();
            Console.WriteLine("Versions: \n" + Versions.ServerVersion + "\n" + version.LoadVersion);
            Console.WriteLine();
            ArgumentHandler.MainArg(args);
            if (ArgumentHandler.AskHelp)
            {
                ArgumentHandler.PrintHelp();
            }
            if (!string.IsNullOrWhiteSpace(ArgumentHandler.LoadMyPlugin))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning! You loading a plugin before everything else is loaded!");
                Console.ResetColor();

                Console.WriteLine(ArgumentHandler.LoadMyPlugin);
                PluginLoader.ManualLoadPlugin(ArgumentHandler.LoadMyPlugin);
            }

            CertHelper.Make(IPAddress.Parse(IP_Address), ip_port);
            Utils.PrintDebug(ip_port);
            DatabaseController.Init();
            DialogController.Init();
            AccountController.Init();
            AccountController.GetAccountList();

            /*
            HOW TO Add to an array outside
            var acc = Controllers.AccountController.FindAccount("AID9b38399c1e9c5bc056387382");
            var list = acc.Friends.ToList(); 
            list.Add("yeehaw");
            acc.Friends = list.ToArray();
            Console.WriteLine(JsonConvert.SerializeObject(acc));      
             */
            WebServer webServer = new WebServer();
            webServer.MainStart(IP_Address, Port);

            if (!ArgumentHandler.DontLoadPlugin)
            {
                PluginLoader.LoadPlugins();
                Console.ReadLine();
                PluginLoader.PluginWebOverride(webServer);
                Console.ReadLine();
                PluginLoader.UnloadPlugins();
            }
            FriendsController._Test("AID0f70e9b4c288de524afcfade7a9d346b", "AID4af2452028e9c7f8b0b74ca63e384923");
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}