using ServerLib.Controllers;
using ServerLib.Handlers;
using ServerLib.Utilities;
using System.Net;

namespace ServerLib
{
    public class ServerLib
    {
        WebServer _webServer;
        public static string IP = "https://127.0.0.1:7777";
        public static string ip_port = "127.0.0.1:7777";

        /// <summary>
        /// Init the Server by Parameters
        /// </summary>
        /// <param name="Ip">Server IP</param>
        /// <param name="port">Server Port</param>
        /// <param name="LoadPlugin">Can Load Plugins</param>
        public void InitAll(string Ip, int port, bool LoadPlugin = true)
        {
            string ip_port = $"https://{Ip}:{port}";
            IP = ip_port;
            ip_port = $"{Ip}:{port}";
            CertHelper.Make(IPAddress.Parse(Ip), ip_port);
            DatabaseController.Init();
            DialogController.Init();
            AccountController.Init();
            AccountController.GetAccountList();
            CharacterController.Init();
            WebServer webServer = new WebServer();
            webServer.MainStart(Ip, port);
            _webServer = webServer;
            Web.WebSocket.Start(Ip, port + 1);
            if (LoadPlugin)
            {
                PluginLoader.LoadPlugins();
                PluginLoader.PluginWebOverride(webServer);
            }
        }

        /// <summary>
        /// Init The Server from Config file
        /// </summary>
        /// <param name="LoadPlugin">Can Load Plugins</param>
        public void Init(bool LoadPlugin = true)
        {
            DatabaseController.Init();
            var Ip = ConfigController.Configs.Server.Ip;
            var port = ConfigController.Configs.Server.Port;
            string ip_port = $"https://{Ip}:{port}";
            IP = ip_port;
            ip_port = $"{Ip}:{port}";
            CertHelper.Make(IPAddress.Parse(Ip), ip_port);
            DialogController.Init();
            AccountController.Init();
            AccountController.GetAccountList();
            CharacterController.Init();
            WebServer webServer = new WebServer();
            webServer.MainStart(Ip, port);
            _webServer = webServer;
            Web.WebSocket.Start(Ip, port + 1);
            if (LoadPlugin)
            {
                PluginLoader.LoadPlugins();
                PluginLoader.PluginWebOverride(webServer);
            }
        }

        /// <summary>
        /// Stopping the Server
        /// </summary>
        /// <param name="reason">Reason Why stopped</param>
        public void Stop(string reason)
        {
            PluginLoader.UnloadPlugins();
            _webServer.StopServer(reason);
            Web.WebSocket.Stop();
        }

        /// <summary>
        /// Stopping the Server
        /// </summary>
        public void Stop()
        {
            PluginLoader.UnloadPlugins();
            _webServer.StopServer();
            Web.WebSocket.Stop();
        }
    }
}