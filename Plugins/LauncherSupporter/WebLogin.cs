using ModdableWebServer;
using ModdableWebServer.Helper;
using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ModdableWebServer.Attributes;
using JsonLib.Classes.Request;

namespace LauncherSupporter
{
    public class WebLogin
    {
        [HTTP("POST", "/webprofile/login")]
        public static bool GameStart(HttpRequest request, ServerStruct serverStruct)
        {
            Console.WriteLine(request.Body);
            // RPS
            var req  = JsonConvert.DeserializeObject<Login>(request.Body);
            ArgumentNullException.ThrowIfNull(req);
            string resp = AccountController.Login(req);
            Console.WriteLine(resp);
            serverStruct.SendRSP(resp);
            return true;
        }

        [HTTP("POST", "/webprofile/test")]
        public static bool GameeTest(HttpRequest request, ServerStruct serverStruct)
        {
            serverStruct.SendRSP("test");
            return true;
        }

        [HTTP("POST", "/webprofile/register")]
        public static bool LauncherRegister(HttpRequest request, ServerStruct serverStruct)
        {
            Console.WriteLine(request.Body);
            // RPS
            var req = JsonConvert.DeserializeObject<Login>(request.Body);
            ArgumentNullException.ThrowIfNull(req);
            string resp = AccountController.Register(req);
            Console.WriteLine(resp);
            serverStruct.SendRSP(resp);
            return true;
        }

        [HTTP("POST", "/webprofile/wipe")]
        public static bool LauncherWipe(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            var WipeProfile = JsonConvert.DeserializeObject<WebProfile.WebWipe>(request.Body);
            ArgumentNullException.ThrowIfNull(WipeProfile);
            // RPS
            string resp = AccountController.SetWipe(WipeProfile.AccountId);
            serverStruct.SendRSP(resp);
            return true;
        }

        [HTTP("POST", "/webprofile/delete")]
        public static bool LauncherDelete(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            var profile = JsonConvert.DeserializeObject<WebProfile.WebAccount>(request.Body);
            ArgumentNullException.ThrowIfNull(profile);
            // RPS
            string resp = AccountController.DeleteAccount(profile.AccountId);
            serverStruct.SendRSP(resp);
            return true;
        }
    }
}