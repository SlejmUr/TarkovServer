using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using static ServerLib.Json.Classes.Response.Matches;
using ModdableWebServer;
using ModdableWebServer.Attributes;

namespace ServerLib.Web
{
    public class ClientMatch
    {
        [HTTP("POST", "/client/match/available")]
        public static bool Available(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            var rsp = ResponseControl.GetBody("true");
            var SessionId = Utils.GetSessionId(serverStruct.Headers);
            var match = MatchController.GetMatch(SessionId);
            match.matchData.Location = "factory4_day";
            match.matchData.RaidMode = EFT.ERaidMode.Online;
            MatchController.Matches[match.matchData.MatchId] = match.matchData;
            MatchController.SendStart(match.matchData.MatchId,"192.168.1.50",1000);
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/offline/end")]
        public static bool OfflineEnd(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            //(exitStatus, exitName, raidSeconds)

            var rsp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/join")]
        public static bool Join(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);

            var sessionId = Utils.GetSessionId(serverStruct.Headers);

            var jsonreq = JsonConvert.DeserializeObject<JoinMatchReq>(ResponseControl.DeCompressReq(request.BodyBytes));
            Debug.PrintDebug(JsonConvert.SerializeObject(jsonreq));
            MatchController.JoinMatch(sessionId, jsonreq);
            var match = MatchController.GetMatch(sessionId);
            ProfileStatus.Response response = new()
            {
                maxPveCountExceeded = false,
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
                        raidMode = "Online",
                        mode = "deathmatch",
                        shortId = "",
                        version = "live",
                        additional_info = new()
                    }
                }
            };
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(response));
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/group/start_game")]
        public static bool StartGame(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct); 
            var sessionId = Utils.GetSessionId(serverStruct.Headers);
            var jsonreq = JsonConvert.DeserializeObject<StartGameReq>(ResponseControl.DeCompressReq(request.BodyBytes));
            MatchController.SendStart(jsonreq.groupId, "192.168.1.50",1000);
            var match = MatchController.GetMatch(sessionId);
            var user = match.matchData.Users.Where(x=>x.sessionId == sessionId).FirstOrDefault();
            ProfileStatus.Response response = new()
            {
                maxPveCountExceeded = false,
                profiles = new()
                {
                    new()
                    {
                        profileid = "pmc" +sessionId,
                        profileToken = user.profileToken,
                        status = "MatchWait",
                        sid = "",
                        ip = "",
                        port = 0,
                        location = match.matchData.Location,
                        raidMode = "Online",
                        mode = "deathmatch",
                        shortId = ""
                    }
                }
            };
            var rsp = ResponseControl.NullResponse();
            //var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(response));
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/group/status")]
        public static bool GroupStatus(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            var sessionId = Utils.GetSessionId(serverStruct.Headers);
            var jsonreq = JsonConvert.DeserializeObject<GetGroupStatus>(ResponseControl.DeCompressReq(request.BodyBytes));
            MatchController.CheckStatus(sessionId, jsonreq);
            ProfileStatus.Response response = new()
            {
                maxPveCountExceeded = false,
                profiles = new()
                {
                }
            };
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(response));
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/exit")]
        public static bool GroupExit(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            var sessionId = Utils.GetSessionId(serverStruct.Headers);
            Debug.PrintDebug(ResponseControl.DeCompressReq(request.BodyBytes));
            MatchController.Exit(sessionId);
            var rsp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/group/invite/cancel-all")]
        public static bool GroupCancelInvite(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            var sessionId = Utils.GetSessionId(serverStruct.Headers);
            var rsp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/group/exit_from_menu")]
        public static bool GroupExitFromMenu(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            var sessionId = Utils.GetSessionId(serverStruct.Headers);
            MatchController.Exit(sessionId);
            var rsp = ResponseControl.NullResponse();
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }


        [HTTP("POST", "/client/match/group/current")]
        public static bool GroupCurrent(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            CurrentGroup currentGroup = new()
            { 
                squad = new()
            };
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(currentGroup));
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/match/raid/ready")]
        public static bool RaidReady(HttpRequest request, ServerStruct serverStruct)
        {
            Utils.PrintRequest(request, serverStruct);
            var rsp = ResponseControl.GetBody("true");
            Utils.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }
    }
}
