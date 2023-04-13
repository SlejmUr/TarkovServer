using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class Launcher
    {
        [HTTP("POST", "/launcher/profile/login")]
        public static bool LauncherLogin(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            // RPS
            string resp = AccountController.Login(JsonConvert.DeserializeObject<Json.Classes.Profile.Info>(Uncompressed));
            var rsp = ResponseControl.CompressRsp(resp);
            session.SendResponse(session.Response.MakeGetResponse(rsp).SetHeader("Content-Encoding", "deflate"));
            return true;
        }

        [HTTP("POST", "/launcher/profile/register")]
        public static bool LauncherRegister(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            // RPS
            string resp = AccountController.Register(JsonConvert.DeserializeObject<Json.Classes.Profile.Info>(Uncompressed));
            var rsp = ResponseControl.CompressRsp(resp);
            session.SendResponse(session.Response.MakeGetResponse(rsp).SetHeader("Content-Encoding", "deflate"));
            return true;
        }

        [HTTP("POST", "/launcher/profile/get")]
        public static bool LauncherGet(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            // RPS
            string resp = JsonConvert.SerializeObject(AccountController.FindAccount(Uncompressed));
            var rsp = ResponseControl.CompressRsp(resp);
            session.SendResponse(session.Response.MakeGetResponse(rsp).SetHeader("Content-Encoding", "deflate"));
            return true;
        }

        [HTTP("POST", "/launcher/server/connect")]
        public static bool LauncherServerConnect(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            // RPS
            var server = ConfigController.Configs.Server;
            string resp = "{backendUrl: https://" + server.Ip + ":" + server.Port + ",name:" + server.Name + ",server:" + JsonConvert.SerializeObject(server) + "}";
            var rsp = ResponseControl.CompressRsp(resp);
            session.SendResponse(session.Response.MakeGetResponse(rsp).SetHeader("Content-Encoding", "deflate"));
            return true;
        }

        [HTTP("POST", "/launcher/profile/remove")]
        public static bool LauncherRemove(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            // RPS
            Console.WriteLine(Uncompressed);
            string resp = AccountController.RemoveAccount(Uncompressed);
            var rsp = ResponseControl.CompressRsp(resp);
            session.SendResponse(session.Response.MakeGetResponse(rsp).SetHeader("Content-Encoding", "deflate"));
            return true;
        }

        [HTTP("POST", "/launcher/profile/change/password")]
        public static bool LauncherChangePassword(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            // RPS
            string resp = AccountController.ChangePassword(JsonConvert.DeserializeObject<Json.Classes.Change>(Uncompressed));
            var rsp = ResponseControl.CompressRsp(resp);
            session.SendResponse(session.Response.MakeGetResponse(rsp).SetHeader("Content-Encoding", "deflate"));
            return true;
        }


        [HTTP("POST", "/launcher/profile/change/wipe")]
        public static bool LauncherChangeWipe(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            // RPS
            Console.WriteLine(Uncompressed);
            var resp = AccountController.SetWipe(Uncompressed);
            var rsp = ResponseControl.CompressRsp(resp);
            session.SendResponse(session.Response.MakeGetResponse(rsp).SetHeader("Content-Encoding", "deflate"));
            return true;
        }
    }
}
