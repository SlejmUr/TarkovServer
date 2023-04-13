using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class WebLogin
    {
        [HTTP("POST", "/webprofile/login")]
        public static bool GameStart(HttpRequest request, HttpsBackendSession session)
        {
            Console.WriteLine(request.Body);
            // RPS
            string resp = AccountController.Login(JsonConvert.DeserializeObject<Json.Classes.Profile.Info>(request.Body));
            Console.WriteLine(resp);
            var rsp = session.Response.MakeGetResponse(resp);
            session.SendResponse(rsp);
            return true;
        }

        [HTTP("POST", "/webprofile/register")]
        public static bool LauncherRegister(HttpRequest request, HttpsBackendSession session)
        {
            Console.WriteLine(request.Body);
            // RPS
            string resp = AccountController.Register(JsonConvert.DeserializeObject<Json.Classes.Profile.Info>(request.Body));
            var rsp = session.Response.MakeGetResponse(resp);
            session.SendResponse(rsp);
            return true;
        }

        [HTTP("POST", "/webprofile/wipe")]
        public static bool LauncherWipe(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            var WipeProfile = JsonConvert.DeserializeObject<Json.WebProfile.WebWipe>(request.Body);
            // RPS
            string resp = AccountController.SetWipe(WipeProfile.AccountId);
            var rsp = session.Response.MakeGetResponse(resp);
            session.SendResponse(rsp);
            return true;
        }

        [HTTP("POST", "/webprofile/delete")]
        public static bool LauncherDelete(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            var profile = JsonConvert.DeserializeObject<Json.WebProfile.WebAccount>(request.Body);
            // RPS
            string resp = AccountController.DeleteAccount(profile.AccountId);
            var rsp = session.Response.MakeGetResponse(resp);
            session.SendResponse(rsp);
            return true;
        }
    }
}
