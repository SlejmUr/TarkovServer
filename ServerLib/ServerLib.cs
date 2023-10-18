using ServerLib.Controllers;
using ServerLib.Handlers;
using ServerLib.Utilities.Helpers;
using ServerLib.Web;
using System.Net;

namespace ServerLib
{
    public class ServerLib
    {
        public static bool IsAlreadyQuited = false;
        public static string IP = "https://127.0.0.1:7777";
        public static string ip_port = "127.0.0.1:7777";

        /// <summary>
        /// Init the Server by Parameters
        /// </summary>
        /// <param name="Ip">Server IP</param>
        /// <param name="port">Server Port</param>
        /// <param name="LoadPlugin">Can Load Plugins</param>
        public static void InitAll(string Ip, int port)
        {
            if (!Directory.Exists("ServerResponses"))
            {
                Directory.CreateDirectory("ServerResponses");
            }
            else
            {
                Directory.Delete("ServerResponses", true);
                Directory.CreateDirectory("ServerResponses");
            }
            string _ip_port = $"https://{Ip}:{port}";
            IP = _ip_port;
            ip_port = $"{Ip}:{port}";
            CertHelper.Make(IPAddress.Parse(Ip), _ip_port);
            DatabaseController.Init();
            ProfileController.Init();
            Controllers.DialogueController.Init();
            AccountController.Init();
            CharacterController.Init();
            ServerManager.Start(Ip, port);
            if (!ArgumentHandler.DontLoadPlugin)
            {
                PluginLoader.LoadPlugins();
            }
        }

        /// <summary>
        /// Init The Server from Config file
        /// </summary>
        /// <param name="LoadPlugin">Can Load Plugins</param>
        public static void Init()
        {
            if (!Directory.Exists("ServerResponses"))
            {
                Directory.CreateDirectory("ServerResponses");
            }
            else
            {
                Directory.Delete("ServerResponses", true);
                Directory.CreateDirectory("ServerResponses");
            }
            DatabaseController.Init();
            var Ip = ConfigController.Configs.Server.Ip;
            var port = ConfigController.Configs.Server.Port;
            string _ip_port = $"https://{Ip}:{port}";
            IP = _ip_port;
            ip_port = $"{Ip}:{port}";
            CertHelper.Make(IPAddress.Parse(Ip), _ip_port);
            ProfileController.Init();
            Controllers.DialogueController.Init();
            AccountController.Init();
            CharacterController.Init();
            Controllers.QuestController.Init();
            ServerManager.Start(Ip, port);
            if (!ArgumentHandler.DontLoadPlugin)
            {
                PluginLoader.LoadPlugins();
            }
        }

        /// <summary>
        /// Stopping the Server
        /// </summary>
        public static void Stop()
        {
            if (IsAlreadyQuited)
                return;
            PluginLoader.UnloadPlugins();
            ConfigController.Save();
            ServerManager.Stop();
            IsAlreadyQuited = true;
        }
    }
}