using ServerLib.Controllers;
using ServerLib.Handlers;
using ServerLib.Utilities.Helpers;
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
        public void InitAll(string Ip, int port)
        {
            string _ip_port = $"https://{Ip}:{port}";
            IP = _ip_port;
            ip_port = $"{Ip}:{port}";
            CertHelper.Make(IPAddress.Parse(Ip), _ip_port);
            DatabaseController.Init();
            ProfileController.Init();
            Controllers.DialogController.Init();
            AccountController.Init();
            CharacterController.Init();
            Start(Ip, port);
            WebSocket.Start(Ip, port + 1);
            if (!ArgumentHandler.DontLoadPlugin)
            {
                PluginLoader.LoadPlugins();
            }
        }

        /// <summary>
        /// Init The Server from Config file
        /// </summary>
        /// <param name="LoadPlugin">Can Load Plugins</param>
        public void Init()
        {
            DatabaseController.Init();
            var Ip = ConfigController.Configs.Server.Ip;
            var port = ConfigController.Configs.Server.Port;
            string _ip_port = $"https://{Ip}:{port}";
            IP = _ip_port;
            ip_port = $"{Ip}:{port}";
            CertHelper.Make(IPAddress.Parse(Ip), _ip_port);
            ProfileController.Init();
            Controllers.DialogController.Init();
            AccountController.Init();
            CharacterController.Init();
            Start(Ip, port);
            WebSocket.Start(Ip, port + 1);
            if (!ArgumentHandler.DontLoadPlugin)
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
            return GetServer();
        }

        /// <summary>
        /// Stopping the Server
        /// </summary>
        public void Stop()
        {
            PluginLoader.UnloadPlugins();
            HTTPServer.Stop();
            WebSocket.Stop();
        }
    }
}