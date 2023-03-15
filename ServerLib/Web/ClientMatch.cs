using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;


namespace ServerLib.Web
{
    public class ClientMatch
    {
        [HTTP("POST", "/client/match/available")]
        public static bool ClientMatchAvailable(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody("true"));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/offline/end")]
        public static bool ClientMatchOfflineEnd(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            //Class73<T, U, V> | (exitStatus, exitName, raidSeconds)

            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/join")]
        public static bool ClientMatchJoin(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/group/start_game")]
        public static bool ClientMatchStartGame(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/group/status")]
        public static bool ClientMatchGroupStatus(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/group/create")]
        public static bool ClientMatchGroupCreate(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);

            ClientGroupStatusJson clientGroupStatus = new();
            List<Members> fromProfile = new();
            clientGroupStatus.Players = fromProfile.ToArray();

            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody(JsonConvert.SerializeObject(clientGroupStatus)));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
    }
}
