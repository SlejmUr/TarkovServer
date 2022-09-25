using ServerLib.Controllers;
using ServerLib.Handlers;
using ServerLib.Utilities;
using System.Net;
using System.Net.WebSockets;

namespace ServerLib
{
    public class ServerLib
    {
        WebServer _webServer;
        public static string IP = "https://localhost:7777";
        public void InitAll(string Ip,int port,bool LoadPlugin = true)
        {
            string ip_port = $"https://{Ip}:{port}";
            IP = ip_port;
            CertHelper.Make(IPAddress.Parse(Ip), ip_port);
            DatabaseController.Init();
            DialogController.Init();
            AccountController.Init();
            AccountController.GetAccountList();
            WebServer webServer = new WebServer();
            webServer.MainStart(Ip, port);
            _webServer = webServer;
            Web.WebSocket.Start(Ip, port+1);
            if (LoadPlugin)
            {
                PluginLoader.LoadPlugins();
                PluginLoader.PluginWebOverride(webServer);
            }
        }
        public void Stop(string reason)
        {
            PluginLoader.UnloadPlugins();
            _webServer.StopServer(reason);
            Web.WebSocket.Stop();
        }
        public void Stop()
        {
            PluginLoader.UnloadPlugins();
            _webServer.StopServer();
            Web.WebSocket.Stop();
        }
    }
}