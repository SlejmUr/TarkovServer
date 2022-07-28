using ServerLib.Controllers;
using ServerLib.Handlers;
using ServerLib.Utilities;
using System.Net;

namespace ServerLib
{
    public class ServerLib
    {
        WebServer _webServer;
        public void InitAll(string Ip,int port)
        {
            string ip_port = $"https://{Ip}:{port}";
            CertHelper.Make(IPAddress.Parse(Ip), ip_port);
            DatabaseController.Init();
            DialogController.Init();
            AccountController.Init();
            AccountController.GetAccountList();
            WebServer webServer = new WebServer();
            webServer.MainStart(Ip, port);
            _webServer = webServer;
            if (!ArgumentHandler.DontLoadPlugin)
            {
                PluginLoader.LoadPlugins();
                PluginLoader.PluginWebOverride(webServer);
            }
        }
        public void Stop(string reason)
        {
                PluginLoader.UnloadPlugins();
                _webServer.StopServer(reason);
        }
        public void Stop()
        {
            PluginLoader.UnloadPlugins();
            _webServer.StopServer();
        }
    }
}