using ServerLib.Controllers;
using ServerLib.Handlers;
using ServerLib.Utilities;
using ServerLib.Web;
using System.Net;
using static ServerLib.Web.HTTPServer;

namespace ServerLib
{
    public class ServerLib
    {
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
            Controllers.DialogController.Init();
            AccountController.Init();
            AccountController.GetAccountList();
            CharacterController.Init();
            HTTPServer.Start(Ip, port);
            Web.WebSocket.Start(Ip, port + 1);
            if (LoadPlugin)
            {
                PluginLoader.LoadPlugins();
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
            Controllers.DialogController.Init();
            AccountController.Init();
            AccountController.GetAccountList();
            CharacterController.Init();
            HTTPServer.Start(Ip, port);
            Web.WebSocket.Start(Ip, port + 1);
            if (LoadPlugin)
            {
                PluginLoader.LoadPlugins();
            }
        }

        /// <summary>
        /// Get the running Webserver
        /// </summary>
        /// <returns>Webserver</returns>
        public HttpsBackendServer? GetWebServer()
        {
            return HTTPServer.GetServer();
        }

        /// <summary>
        /// Stopping the Server
        /// </summary>
        /// <param name="reason">Reason Why stopped</param>
        public void Stop(string reason)
        {
            PluginLoader.UnloadPlugins();
            HTTPServer.Stop();
            Web.WebSocket.Stop();
        }

        /// <summary>
        /// Stopping the Server
        /// </summary>
        public void Stop()
        {
            PluginLoader.UnloadPlugins();
            HTTPServer.Stop();
            Web.WebSocket.Stop();
        }
    }
}