using EFT;
using ModdableWebServer.Helper;
using Newtonsoft.Json;
using ServerLib.Json.Classes;
using ServerLib.Json.Classes.Websocket;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using ServerLib.Web;

namespace ServerLib.Controllers
{
    public class MatchController
    {
        static MatchController()
        {
            Matches = new();
            Debug.PrintInfo("Initialization Done!", "MatchController");
        }

        public static Dictionary<string, MatchData> Matches;

        public struct MatchData
        {
            public string MatchId;
            public string CreatorId;
            public bool IsScav;
            public List<UserStruct> Users;
            public string Ip;
            public int Port;
            public string Location;
            public string Sid;
            public ERaidMode RaidMode;
            public bool IsStarted;
            public struct UserStruct
            {
                public string sessionId;
                public string profileToken;

            }
        }
        public static (MatchData matchData, bool IsNew) GetMatch(string ProfileId)
        {
            foreach (var item in Matches.Values)
            {
                if (item.CreatorId == ProfileId)
                    return (item, false);
            }
            var id = AIDHelper.CreateNewID();
            var match = new MatchData() { CreatorId = ProfileId, MatchId = id, Users = new() { new() { sessionId = ProfileId } } };
            Matches.Add(id, match);
            return (match, true);
        }

        public static void CheckStatus(string ProfileId, GetGroupStatus groupStatus)
        {
            var match = GetMatch(ProfileId).matchData;
            match.Location = groupStatus.location;
            match.RaidMode = groupStatus.raidMode;
        }

        public static void Exit(string ProfileId)
        {

            var match = GetMatch(ProfileId);
            Debug.PrintDebug($"Match [{match.matchData.MatchId}] is Deleted", "MatchController");
            Matches.Remove(match.matchData.MatchId);
            //  Todo: Add WS send to quit the match!
        }

        public static void JoinMatch(string ProfileId, JoinMatchReq joinMatch)
        {

            var matchData = GetMatch(ProfileId).matchData;
            matchData.Location = joinMatch.location;
            matchData.Ip = joinMatch.servers[0].ip;
            matchData.Port = int.Parse(joinMatch.servers[0].port);
            matchData.RaidMode = ERaidMode.Online;
            matchData.Sid = $"{matchData.Ip}_{matchData.Port}-Match-{Matches.Count}";
            matchData.IsScav = joinMatch.savage;
            Debug.PrintDebug($"Match [{matchData.MatchId}] created for {ProfileId}", "MatchController");
            Matches[matchData.MatchId] = matchData;
            SendStart(matchData.MatchId, matchData.Ip, matchData.Port);
        }

        public static void SendStart(string groupId, string Ip, int Port)
        {
            var sid = $"{Ip}_{Port}-Match-{Matches.Count}";
            var match = Matches[groupId];
            if (match.Ip != Ip)
                match.Ip = Ip;
            if (match.Port != Port)
                match.Port = Port;
            if (string.IsNullOrEmpty(match.Sid))
                match.Sid = sid;
            for (int i = 0; i < match.Users.Count; i++)
            {
                var user = match.Users[i];
                var token = AIDHelper.CreateNewID();
                user.profileToken = token;
                UserConfirmed confirmed = new()
                {

                    profileid = "pmc" + user.sessionId,
                    profileToken = token,
                    status = "Busy",
                    ip = match.Ip,
                    port = match.Port,
                    sid = match.Sid,
                    version = "live",
                    location = match.Location,
                    mode = "deathmatch",
                    shortId = "VD0ABA",
                    raidMode = match.RaidMode.ToString(),
                    additional_info = new() { }
                };
                if (match.IsScav)
                    confirmed.profileid = "scav" + user.sessionId;
                var socket = WebSocket.GetUser(user.sessionId);
                socket?.MulticastWebSocketText(JsonConvert.SerializeObject(confirmed));
                match.Users[i] = user;
            }
            match.IsStarted = true;
            Matches[match.MatchId] = match;
        }
    }
}
