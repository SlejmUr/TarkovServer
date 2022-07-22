using ServerLib.Controllers;
using ServerLib.Handlers;
using ServerLib.Utilities;
using System.Net;

namespace ServerLib
{
    public class ServerLib
    {
        public void InitAll(string Ip,int port)
        {
            string ip_port = $"https://{Ip}:{port}";
            CertHelper.Make(IPAddress.Parse(Ip), ip_port);
            Console.WriteLine("Hello MAIN!");
            Console.WriteLine(ip_port);
            ConfigController.Init();


            AccountController.Init();
            AccountController.GetAccountList();

            

            LocaleController.Init();

            WebServer webServer = new WebServer();
            webServer.MainStart(Ip, port);
            PluginLoader.LoadPlugins();


            Console.ReadLine();
            PluginLoader.UnloadPlugins();


        }
    }
}