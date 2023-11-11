using JsonLib.Enums;

namespace JsonLib.Classes.MatchRelated
{
    public class MatchData
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
        public class UserStruct
        {
            public string sessionId;
            public string profileToken;

        }
    }
}
