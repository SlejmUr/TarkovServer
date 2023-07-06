using EFT;
using Newtonsoft.Json;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using ServerLib.Web;
using static ServerLib.Controllers.MatchController;
using static ServerLib.Json.Classes.Other;

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
            public string Mode;
            public bool IsStarted;
            public struct UserStruct
            {
                public string sessionId;

            }
        }
        public static (MatchData matchData, bool IsNew) GetMatch(string ProfileId)
        {
            foreach (var item in Matches.Values)
            {
                if (item.CreatorId == ProfileId)
                    return (item, false);
            }
            var id = Utils.CreateNewID();
            var match = new MatchData() { CreatorId = ProfileId, MatchId = id, Users = new() { new() { sessionId = ProfileId } } };
            Matches.Add(id, match);
            return (match, true);
        }

        public static void Exit(string ProfileId)
        {
            
            var match = GetMatch(ProfileId);
            Debug.PrintDebug($"Match [{match.matchData.MatchId}] is Deleted", "MatchController");
            Matches.Remove(match.matchData.MatchId);
        }

        public static void JoinMatch(string ProfileId, Requests.MatchJoin joinMatch)
        {

            var matchData = GetMatch(ProfileId).matchData;
            matchData.Location = joinMatch.location;
            matchData.Ip = ConfigController.Configs.Server.Servers[0].Ip;
            matchData.Port = ConfigController.Configs.Server.Servers[0].Port;
            matchData.Mode = joinMatch.mode;
            Debug.PrintDebug($"Match [{matchData.MatchId}] created for {ProfileId}", "MatchController");
            Matches[matchData.MatchId] = matchData;
        }
    }
}
