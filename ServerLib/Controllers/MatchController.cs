using EFT;
using Newtonsoft.Json;
using ServerLib.Json.Classes;
using ServerLib.Json.Classes.Response;
using ServerLib.Json.Classes.Websocket;
using ServerLib.Utilities;
using ServerLib.Web;
using static ServerLib.Controllers.MatchController;
using static ServerLib.Json.Classes.ProfileStatus;

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
            public List<UserStruct> Users;
            public string Ip;
            public int Port;
            public string Location;
            public string Sid;
            public ERaidMode RaidMode;
            public bool IsStarted;
            public struct UserStruct
            {
                public string profileid;
                public string profileToken;

            }
        }
        public static MatchData? GetMatch(string ProfileId)
        {
            foreach (var item in Matches.Values)
            {
                if (item.CreatorId == ProfileId)
                    return item;
            }
            return null;
        }


        public static string GenerateMatchId(string ProfileId)
        {
            var match = GetMatch(ProfileId);
            if (match.HasValue)
            {
                Debug.PrintDebug($"Match [{match.Value.MatchId}] found by SessionId [{ProfileId}]", "MatchController");
                return match.Value.MatchId;
            }
            else
            {
                var id = Utils.CreateNewID();
                Debug.PrintDebug($"Match is not found by SessionId [{ProfileId}]. Creating match. MatchId: {id}", "MatchController");
                Matches.Add(id, new() { CreatorId = ProfileId, MatchId = id, Users = new() { new() { profileid = ProfileId } } });
                return id;
            }
        }

        public static void CheckStatus(string ProfileId, GetGroupStatus groupStatus)
        {
            var match = Matches[GenerateMatchId(ProfileId)];
            match.Location = groupStatus.location;
            match.RaidMode = groupStatus.raidMode;
        }

        public static void Exit(string ProfileId)
        {
            
            var match = GetMatch(ProfileId);
            if (match.HasValue)
            {
                Debug.PrintDebug($"Match [{match.Value.MatchId}] found by SessionId [{ProfileId}]", "MatchController");
                Matches.Remove(match.Value.MatchId);
            }
            //  Todo: Add WS send to quit the match!
        }

        public static void JoinMatch(string ProfileId, JoinMatchReq joinMatch)
        {

            var match = GetMatch(ProfileId);
            if (match.HasValue)
            {
                Matches.TryGetValue(match.Value.MatchId, out var matchData);
                Debug.PrintDebug($"Match [{matchData.MatchId}] found by SessionId [{ProfileId}]", "MatchController");
                matchData.Location = joinMatch.location;
                matchData.Ip = joinMatch.servers[0].ip;
                matchData.Port = int.Parse(joinMatch.servers[0].port);
                matchData.RaidMode = ERaidMode.Online;
                matchData.Sid = $"{matchData.Ip}_{matchData.Port}-Match-{Matches.Count}";
                Matches[matchData.MatchId] = matchData;
                SendStart(matchData.MatchId, matchData.Ip, matchData.Port);

            }
            else
            {
                Debug.PrintDebug($"Match for SessionId not exist, creating one.", "MatchController");
                var matchData = Matches[GenerateMatchId(ProfileId)];
                matchData.Location = joinMatch.location;
                matchData.Ip = joinMatch.servers[0].ip;
                matchData.Port = int.Parse(joinMatch.servers[0].port);
                matchData.RaidMode = ERaidMode.Online;
                matchData.Sid = $"{matchData.Ip}_{matchData.Port}-Match-{Matches.Count}";
                Debug.PrintDebug($"Match [{matchData.MatchId}] created for SessionId [{ProfileId}]", "MatchController");
                Matches[matchData.MatchId] = matchData;
                SendStart(matchData.MatchId, matchData.Ip, matchData.Port);
            }

            
        }

        public static void SendStart(string groupId, string Ip, int Port)
        {
            var ws = NewWebSocket.GetServer();
            if (ws != null)
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
                    var token = Utils.CreateNewID();
                    user.profileToken = token;
                    UserConfirmed confirmed = new()
                    {
                        profileid = user.profileid,
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
                    ws.MulticastText(JsonConvert.SerializeObject(confirmed));
                    match.Users[i] = user;
                }
                match.IsStarted = true;
                Matches[match.MatchId] = match;
            }
        }
    }
}
