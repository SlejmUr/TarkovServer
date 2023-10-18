using ModdableWebServer;
using ModdableWebServer.Helper;
using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ModdableWebServer.Attributes;

namespace ServerLib.Web
{
    public class WebLogin
    {
        [HTTP("POST", "/webprofile/login")]
        public static bool GameStart(HttpRequest request, ServerStruct serverStruct)
        {
            Console.WriteLine(request.Body);
            // RPS
            string resp = AccountController.Login(JsonConvert.DeserializeObject<Json.Classes.Login>(request.Body));
            Console.WriteLine(resp);
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("POST", "/webprofile/register")]
        public static bool LauncherRegister(HttpRequest request, ServerStruct serverStruct)
        {
            Console.WriteLine(request.Body);
            // RPS
            string resp = AccountController.Register(JsonConvert.DeserializeObject<Json.Classes.Login>(request.Body));
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("POST", "/webprofile/wipe")]
        public static bool LauncherWipe(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            var WipeProfile = JsonConvert.DeserializeObject<Json.WebProfile.WebWipe>(request.Body);
            // RPS
            string resp = AccountController.SetWipe(WipeProfile.AccountId);
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("POST", "/webprofile/delete")]
        public static bool LauncherDelete(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            var profile = JsonConvert.DeserializeObject<Json.WebProfile.WebAccount>(request.Body);
            // RPS
            string resp = AccountController.DeleteAccount(profile.AccountId);
            serverStruct.Response.MakeGetResponse(resp);
            serverStruct.SendResponse();
            return true;
        }
    }
}
