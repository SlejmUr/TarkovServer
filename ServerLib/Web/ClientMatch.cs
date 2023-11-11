using JsonLib.Classes.Request;
using JsonLib.Classes.Response;
using JsonLib.Enums;
using ModdableWebServer;
using ModdableWebServer.Attributes;
using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using static JsonLib.Classes.Response.Matches;

namespace ServerLib.Web
{
    public class ClientMatch
    {
        [HTTP("POST", "/client/match/available")]
        public static bool Available(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var rsp = ResponseControl.GetBody("true");
            var SessionId = serverStruct.Headers.GetSessionId();
            var match = MatchController.GetMatch(SessionId);
            match.matchData.Location = "factory4_day";
            match.matchData.RaidMode = ERaidMode.Online;
            MatchController.Matches[match.matchData.MatchId] = match.matchData;
            MatchController.SendStart(match.matchData.MatchId, "192.168.1.50", 7000);
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/offline/end")]
        public static bool OfflineEnd(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            //(exitStatus, exitName, raidSeconds)

            var rsp = ResponseControl.NullResponse();
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/join")]
        public static bool Join(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);

            var sessionId = serverStruct.Headers.GetSessionId();

            var jsonreq = JsonConvert.DeserializeObject<JoinMatchReq>(ResponseControl.DeCompressReq(request.BodyBytes));
            Debug.PrintDebug(JsonConvert.SerializeObject(jsonreq));
            ArgumentNullException.ThrowIfNull(jsonreq);
            MatchController.JoinMatch(sessionId, jsonreq);
            var match = MatchController.GetMatch(sessionId);
            JoinMatch response = new()
            {
                ProfileId = sessionId,
                IpAddress = "192.168.1.50",
                LocationId = match.matchData.Location,
                Port = 7000
            };
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(response));
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/group/start_game")]
        public static bool StartGame(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var sessionId = serverStruct.Headers.GetSessionId();
            var jsonreq = JsonConvert.DeserializeObject<StartGameReq>(ResponseControl.DeCompressReq(request.BodyBytes));
            ArgumentNullException.ThrowIfNull(jsonreq);
            MatchController.SendStart(jsonreq.groupId, "192.168.1.50", 7000);
            var match = MatchController.GetMatch(sessionId);
            JoinMatch join = new()
            {
                ProfileId = sessionId,
                IpAddress = "192.168.1.50",
                LocationId = match.matchData.Location,
                Port = 7000
            };
            //var rsp = ResponseControl.NullResponse();
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(join));
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/group/status")]
        public static bool GroupStatus(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var sessionId = serverStruct.Headers.GetSessionId();
            var jsonreq = JsonConvert.DeserializeObject<GetGroupStatus>(ResponseControl.DeCompressReq(request.BodyBytes));
            ArgumentNullException.ThrowIfNull(jsonreq);
            MatchController.CheckStatus(sessionId, jsonreq);
            ProfileStatus response = new()
            {
                maxPveCountExceeded = false,
                profiles = new()
                {
                }
            };
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(response));
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/exit")]
        public static bool GroupExit(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var sessionId = serverStruct.Headers.GetSessionId();
            Debug.PrintDebug(ResponseControl.DeCompressReq(request.BodyBytes));
            MatchController.Exit(sessionId);
            var rsp = ResponseControl.NullResponse();
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/group/invite/cancel-all")]
        public static bool GroupCancelInvite(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var sessionId = serverStruct.Headers.GetSessionId();
            var rsp = ResponseControl.NullResponse();
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/group/exit_from_menu")]
        public static bool GroupExitFromMenu(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var sessionId = serverStruct.Headers.GetSessionId();
            MatchController.Exit(sessionId);
            var rsp = ResponseControl.NullResponse();
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }


        [HTTP("POST", "/client/match/group/current")]
        public static bool GroupCurrent(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            CurrentGroup currentGroup = new()
            {
                squad = new()
            };
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(currentGroup));
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/raid/ready")]
        public static bool RaidReady(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            var rsp = ResponseControl.GetBody("true");
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }
    }
}
