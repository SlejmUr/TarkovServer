using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using static ServerLib.Json.Classes.Response.Matches;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class ClientMatch
    {
        [HTTP("POST", "/client/match/available")]
        public static bool Available(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var rsp = ResponseControl.GetBody("true");
            var SessionId = Utils.GetSessionId(session.Headers);
            var match = MatchController.GetMatch(SessionId);
            match.matchData.Location = "factory4_day";
            MatchController.Matches[match.matchData.MatchId] = match.matchData;
            MatchController.SendStart(match.matchData.MatchId,"192.168.1.50",1000);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/join")]
        public static bool Join(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);

            var sessionId = Utils.GetSessionId(session.Headers);

            var jsonreq = JsonConvert.DeserializeObject<JoinMatchReq>(ResponseControl.DeCompressReq(request.BodyBytes));
            Debug.PrintDebug(JsonConvert.SerializeObject(jsonreq));
            MatchController.JoinMatch(sessionId, jsonreq);
            var match = MatchController.GetMatch(sessionId);
            ProfileStatus.Response response = new()
            {
                profiles = new()
                {
                    new()
                    {
                        profileid = "pmc" + sessionId,
                        profileToken = match.matchData.Users.Where(x => x.sessionId == sessionId).FirstOrDefault().profileToken,
                        status = "MatchWait",
                        sid = "",
                        ip = "",
                        port = 0,
                        location = jsonreq.location,
                        mode = "deathmatch"
                    }
                }
            };
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(response));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/exit")]
        public static bool GroupExit(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            var sessionId = Utils.GetSessionId(session.Headers);
            Debug.PrintDebug(ResponseControl.DeCompressReq(request.BodyBytes));
            MatchController.Exit(sessionId);
            var rsp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
    }
}
