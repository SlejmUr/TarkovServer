using ModdableWebServer;
using ModdableWebServer.Attributes;
using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities.Helpers;
using JsonLib.Classes.Request;

namespace LauncherSupporter
{
    public class Launcher
    {
        [HTTP("POST", "/launcher/profile/login")]
        public static bool LauncherLogin(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var req = JsonConvert.DeserializeObject<Login>(serverStruct.GetRequets(request));
            ArgumentNullException.ThrowIfNull(req);
            string resp = AccountController.Login(req);
            serverStruct.SendRSP(resp);
            return true;
        }

        [HTTP("POST", "/launcher/profile/register")]
        public static bool LauncherRegister(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var req = JsonConvert.DeserializeObject<Login>(serverStruct.GetRequets(request));
            ArgumentNullException.ThrowIfNull(req);
            string resp = AccountController.Register(req);
            serverStruct.SendRSP(resp);
            return true;
        }

        [HTTP("POST", "/launcher/profile/get")]
        public static bool LauncherGet(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = JsonConvert.SerializeObject(AccountController.FindAccount(serverStruct.GetRequets(request)));
            serverStruct.SendRSP(resp);
            return true;
        }

        [HTTP("POST", "/launcher/server/connect")]
        public static bool LauncherServerConnect(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            ServerHelper.PrintRequest(request, serverStruct);
            var server = ConfigController.Configs.Server;
            string resp = "{backendUrl: https://" + server.Ip + ":" + server.Port + ",name:" + server.Name + ",server:" + JsonConvert.SerializeObject(server) + "}";
            serverStruct.SendRSP(resp);
            return true;
        }

        [HTTP("POST", "/launcher/profile/remove")]
        public static bool LauncherRemove(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            ServerHelper.PrintRequest(request, serverStruct);
            string resp = AccountController.RemoveAccount(serverStruct.GetRequets(request));
            serverStruct.SendRSP(resp);
            return true;
        }

        [HTTP("POST", "/launcher/profile/change/password")]
        public static bool LauncherChangePassword(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            ServerHelper.PrintRequest(request, serverStruct);
            // RPS
            var req = JsonConvert.DeserializeObject<Change>(serverStruct.GetRequets(request));
            ArgumentNullException.ThrowIfNull(req);
            string resp = AccountController.ChangePassword(req);
            serverStruct.SendRSP(resp);
            return true;
        }


        [HTTP("POST", "/launcher/profile/change/wipe")]
        public static bool LauncherChangeWipe(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            ServerHelper.PrintRequest(request, serverStruct);
            var resp = AccountController.SetWipe(serverStruct.GetRequets(request));
            serverStruct.SendRSP(resp);
            return true;
        }
    }
}
