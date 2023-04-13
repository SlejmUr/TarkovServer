using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class ClientRaid
    {
        [HTTP("POST", "/client/raid/person/killed/showMessage")]
        public static bool ShowMessage(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            // RPS
            var rsp = ResponseControl.CompressRsp(ConfigController.Configs.Gameplay.Raid.InRaid.ShowDeathMessage.ToString());
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/person/killed")]
        public static bool RaidKilled(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string SessionId = Utils.GetSessionId(session.Headers);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            CharacterController.RaidKilled(Uncompressed, SessionId);
            // RPS
            var rsp = ResponseControl.CompressRsp("{}");
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/profile/save")]
        public static bool RaidSave(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(request.BodyBytes);
            File.AppendAllText("saveAccount.json", decomp);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/person/lootingContainer")]
        public static bool RaidLootingContainer(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(request.BodyBytes);
            File.AppendAllText("lootingContainer.json", decomp);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/configuration")]
        public static bool RaidConfig(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(request.BodyBytes);
            File.AppendAllText("RaidSettings.json", decomp);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/raid/configuration-by-profile")]
        public static bool RaidConfigByProfile(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            //REQ stuff
            var decomp = ResponseControl.DeCompressReq(request.BodyBytes);
            File.AppendAllText("CoopRaidSettings.json", decomp);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

    }
}
