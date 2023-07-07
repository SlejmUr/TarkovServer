using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using static ServerLib.Controllers.MatchController;
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
            var match = GetMatch(SessionId);
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/join")]
        public static bool Join(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);

            var sessionId = Utils.GetSessionId(session.Headers);

            var jsonreq = JsonConvert.DeserializeObject<Requests.MatchJoin>(ResponseControl.DeCompressReq(request.BodyBytes));
            Debug.PrintDebug(JsonConvert.SerializeObject(jsonreq));
            JoinMatch(sessionId, jsonreq);
            var character = CharacterController.GetCharacter(sessionId);
            if (character == null)
            {
                Debug.PrintError("Character not found!", "ProfileStatus");
            }
            var match = GetMatch(sessionId);
            Other.ProfileStatus[] response =
            {
                    new()
                    {
                        profileid = character.Id,
                        status = "Busy",
                        ip = match.matchData.Ip,
                        port = match.matchData.Port,
                        location = match.matchData.Location,
                        gameMode = "deathmatch"
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
            Exit(sessionId);
            var rsp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
    }
}
