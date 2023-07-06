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
            string resp = AccountController.Login(JsonConvert.DeserializeObject<Json.Classes.Requests.Login>(request.Body));
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
            string resp = AccountController.Register(JsonConvert.DeserializeObject<Json.Classes.Requests.Register>(request.Body));
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
