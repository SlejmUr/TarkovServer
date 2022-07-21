using ComponentAce.Compression.Libs.zlib;
using Ionic.Zlib;
using System.Net;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Tarkov_Server_Csharp.Handlers;
using Tarkov_Server_Csharp.Controllers;

namespace Tarkov_Server_Csharp
{
    internal class Program
    {
        static string IP_Address = "26.48.71.165"; //Or use Localhost
        static int Port = 7777;
        public static string ip_port = $"https://{IP_Address}:{Port}";
        static void Main(string[] args)
        {
            ArgumentHandler.MainArg(args);
            if (ArgumentHandler.AskHelp)
            {
                ArgumentHandler.PrintHelp();
            }
            ModLoader.LoadMod();
            CertHelper.Make(IPAddress.Parse(IP_Address));
            Console.WriteLine("Hello MAIN!");
            Console.WriteLine(ip_port);
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

            ConfigController.Init();

            LocaleController.Init();

            WebServer webServer = new WebServer();
            webServer.MainStart(IP_Address,Port);
        }
    }
}