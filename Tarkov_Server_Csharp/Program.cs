using ServerLib;
using ServerLib.Controllers;
using ServerLib.Handlers;
using ServerLib.Utilities;
using ServerLib.Web;
using System.Net;
using System.Text;

namespace Tarkov_Server_Csharp
{
    internal class Program
    {
        static string IP_Address = "26.48.71.165"; //Or use Localhost
        static int Port = 7777;
        public static string ip_port = $"https://{IP_Address}:{Port}";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
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
            Console.WriteLine("Initialization Done!");

            WebServer webServer = new WebServer();
            webServer.MainStart(IP_Address, Port);

            WebSocket.Start(IP_Address, Port + 1);

            if (!ArgumentHandler.DontLoadPlugin)
            {
                PluginLoader.LoadPlugins();
                Console.ReadLine();
                PluginLoader.PluginWebOverride(webServer);
                Console.ReadLine();
                PluginLoader.UnloadPlugins();
            }
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}