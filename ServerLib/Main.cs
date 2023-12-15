using ServerLib.Controllers;
using ServerLib.Handlers;
using ServerLib.Utilities.Helpers;
using ServerLib.Web;
using System.Diagnostics;
using System.Net;

namespace ServerLib
{
    public class Main
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
        public static void InitAll(string Ip, int port, bool ssl = true)
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
            var sw = Stopwatch.StartNew();
            Utilities.Debug.PrintInfo(VersionController.GetAll());
            DatabaseController.Init();
            ConfigController.Configs.Server.Ip = Ip;
            ConfigController.Configs.Server.Port = port;
            ConfigController.Configs.Server.EnableSSL = ssl;
            if (ssl)
            {
                string _ip_port = $"https://{Ip}:{port}";
                IP = _ip_port;
                ip_port = $"{Ip}:{port}";
                CertHelper.Make(IPAddress.Parse(Ip), _ip_port);
            }
            else
            {
                string _ip_port = $"http://{Ip}:{port}";
                IP = _ip_port;
                ip_port = $"{Ip}:{port}";
            }
            ProfileController.Init();
            DialogueController.Init();
            AccountController.Init();
            CharacterController.Init();
            QuestController.Init();
            ServerManager.Start(Ip, port, ssl);
            if (!ArgumentHandler.DontLoadPlugin)
            {
                PluginLoader.LoadPlugins();
            }
            sw.Stop();
            Utilities.Debug.PrintTime($"Init Taken {sw.ElapsedMilliseconds}ms");
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
            var sw = Stopwatch.StartNew();
            Utilities.Debug.PrintInfo(VersionController.GetAll());
            DatabaseController.Init();
            var Ip = ConfigController.Configs.Server.Ip;
            var port = ConfigController.Configs.Server.Port;
            if (ConfigController.Configs.Server.EnableSSL)
            {
                string _ip_port = $"https://{Ip}:{port}";
                IP = _ip_port;
                ip_port = $"{Ip}:{port}";
                CertHelper.Make(IPAddress.Parse(Ip), _ip_port);
            }
            else
            {
                string _ip_port = $"http://{Ip}:{port}";
                IP = _ip_port;
                ip_port = $"{Ip}:{port}";
            }

            ProfileController.Init();
            DialogueController.Init();
            AccountController.Init();
            CharacterController.Init();
            QuestController.Init();
            ServerManager.Start(Ip, port, ConfigController.Configs.Server.EnableSSL);
            if (!ArgumentHandler.DontLoadPlugin)
            {
                PluginLoader.LoadPlugins();
            }
            sw.Stop();
            Utilities.Debug.PrintTime($"Init Taken {sw.ElapsedMilliseconds}ms");
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