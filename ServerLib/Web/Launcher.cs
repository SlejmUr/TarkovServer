using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ModdableWebServer;
using ModdableWebServer.Attributes;
using ModdableWebServer.Helper;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Web
{
    public class Launcher
    {
        [HTTP("POST", "/launcher/profile/login")]
        public static bool LauncherLogin(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            // RPS
            var req = JsonConvert.DeserializeObject<Json.Classes.Login>(Uncompressed);
            ArgumentNullException.ThrowIfNull(req);
            string resp = AccountController.Login(req);
            var rsp = ResponseControl.CompressRsp(resp);
            serverStruct.Response.MakeGetResponse(rsp).SetHeader("Content-Encoding", "deflate");
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("POST", "/launcher/profile/register")]
        public static bool LauncherRegister(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            // RPS
            var req = JsonConvert.DeserializeObject<Json.Classes.Login>(Uncompressed);
            ArgumentNullException.ThrowIfNull(req);
            string resp = AccountController.Register(req);
            var rsp = ResponseControl.CompressRsp(resp);
            serverStruct.Response.MakeGetResponse(rsp).SetHeader("Content-Encoding", "deflate");
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("POST", "/launcher/profile/get")]
        public static bool LauncherGet(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            // RPS
            string resp = JsonConvert.SerializeObject(AccountController.FindAccount(Uncompressed));
            var rsp = ResponseControl.CompressRsp(resp);
            serverStruct.Response.MakeGetResponse(rsp).SetHeader("Content-Encoding", "deflate");
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("POST", "/launcher/server/connect")]
        public static bool LauncherServerConnect(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            // RPS
            var server = ConfigController.Configs.Server;
            string resp = "{backendUrl: https://" + server.Ip + ":" + server.Port + ",name:" + server.Name + ",server:" + JsonConvert.SerializeObject(server) + "}";
            var rsp = ResponseControl.CompressRsp(resp);
            serverStruct.Response.MakeGetResponse(rsp).SetHeader("Content-Encoding", "deflate");
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("POST", "/launcher/profile/remove")]
        public static bool LauncherRemove(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            // RPS
            Console.WriteLine(Uncompressed);
            string resp = AccountController.RemoveAccount(Uncompressed);
            var rsp = ResponseControl.CompressRsp(resp);
            serverStruct.Response.MakeGetResponse(rsp).SetHeader("Content-Encoding", "deflate");
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("POST", "/launcher/profile/change/password")]
        public static bool LauncherChangePassword(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            // RPS
            var req = JsonConvert.DeserializeObject<Json.Classes.Change>(Uncompressed);
            ArgumentNullException.ThrowIfNull(req);
            string resp = AccountController.ChangePassword(req);
            var rsp = ResponseControl.CompressRsp(resp);
            serverStruct.Response.MakeGetResponse(rsp).SetHeader("Content-Encoding", "deflate");
            serverStruct.SendResponse();
            return true;
        }


        [HTTP("POST", "/launcher/profile/change/wipe")]
        public static bool LauncherChangeWipe(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);

            // RPS
            Console.WriteLine(Uncompressed);
            var resp = AccountController.SetWipe(Uncompressed);
            var rsp = ResponseControl.CompressRsp(resp);
            serverStruct.Response.MakeGetResponse(rsp).SetHeader("Content-Encoding", "deflate");
            serverStruct.SendResponse();
            return true;
        }
    }
}
