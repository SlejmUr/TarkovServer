using Newtonsoft.Json;

namespace ServerLib.Json
{
    public class Other
    {
        public class TPLCOUNT
        {
            [JsonProperty("_tpl")]
            public string Tpl { get; set; }

            [JsonProperty("count")]
            public int Count { get; set; }
        }
        public class AmmoItems
        {
            public string _id { get; set; }
            public string _tpl { get; set; }
            public Upd upd { get; set; }
        }

        public class Upd
        {
            public int StackObjectsCount { get; set; }
        }

        public class Chat
        {
            public string _id { get; set; } = "0";
            public int Members { get; set; } = 0;
        }

        public class ChatServerList
        {
            public string _id { get; set; } = "5ae20a0dcb1c13123084756f";
            public int RegistrationId { get; set; } = 20;
            public int DateTime { get; set; }
            public bool IsDeveloper { get; set; } = true;
            public List<string> Regions { get; set; } = new();
            public string VersionId { get; set; } = "bgkidft87ddd";
            public string Ip { get; set; } = "";
            public int Port { get; set; } = 0;
            public List<Chat> Chats { get; set; } = new();
        }
        public class ItemMove
        {
            public string ItemId { get; set; }
            public int Count { get; set; }
        }
        public class ExpTable
        {
            [JsonProperty("exp")]
            public int Exp { get; set; }
        }

        public class ExpTableClass
        {
            [JsonProperty("exp_table")]
            public List<ExpTable> ExpTable { get; set; }
        }
        public class FriendRequester
        {
            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("from")]
            public string From { get; set; }

            [JsonProperty("to")]
            public string To { get; set; }

            [JsonProperty("date")]
            public int Date { get; set; }

            [JsonProperty("profile")]
            public string Profile { get; set; }
        }

        public class FriendsList
        {
            [JsonProperty("Friends")]
            public List<object> Friends { get; set; } = new();

            [JsonProperty("Ignore")]
            public List<object> Ignore { get; set; } = new();

            [JsonProperty("InIgnoreList")]
            public List<object> InIgnoreList { get; set; } = new();
        }

        public class FriendsReq
        {
            [JsonProperty("request_id")]
            public string? req_Id { get; set; }

            [JsonProperty("to")]
            public string? toId { get; set; }

            [JsonProperty("requestId")]
            public string? reqId { get; set; }

            [JsonProperty("uid")]
            public string? uid { get; set; }
        }

        public class AddFriendRsp
        {
            [JsonProperty("requestId")]
            public string RequestId { get; set; }

            [JsonProperty("retryAfter")]
            public int RetryAfter { get; set; } = 30;

            [JsonProperty("status")]
            public int Status { get; set; } = 0;
        }

        public class Lang
        {
            public int err { get; set; }
            public string errmsg { get; set; }
            public object data { get; set; }
            public int crc { get; set; }
        }

        public class GameConfigBackend
        {
            [JsonProperty("Trading")]
            public string Trading { get; set; }

            [JsonProperty("Messaging")]
            public string Messaging { get; set; }

            [JsonProperty("Main")]
            public string Main { get; set; }

            [JsonProperty("RagFair")]
            public string RagFair { get; set; }

            [JsonProperty("Lobby")]
            public string Lobby { get; set; }
        }

        public class GameConfig
        {
            [JsonProperty("aid")]
            public string Aid { get; set; }

            [JsonProperty("lang")]
            public string Lang { get; set; }

            [JsonProperty("languages")]
            public object Languages { get; set; }

            [JsonProperty("ndaFree")]
            public bool NdaFree { get; set; }

            [JsonProperty("taxonomy")]
            public int Taxonomy { get; set; }

            [JsonProperty("activeProfileId")]
            public string ActiveProfileId { get; set; }

            [JsonProperty("backend")]
            public GameConfigBackend Backend { get; set; }

            [JsonProperty("utc_time")]
            public double UtcTime { get; set; }

            [JsonProperty("totalInGame")]
            public int TotalInGame { get; set; }

            [JsonProperty("reportAvailable")]
            public bool ReportAvailable { get; set; }

            [JsonProperty("twitchEventMember")]
            public bool TwitchEventMember { get; set; }
        }

        public class RaidKilled
        {
            public string killedByAID { get; set; }
            public string diedFaction { get; set; }
        }

        public class Notifier
        {
            [JsonProperty("server", NullValueHandling = NullValueHandling.Ignore)]
            public string Server { get; set; }

            [JsonProperty("channel_id", NullValueHandling = NullValueHandling.Ignore)]
            public string ChannelId { get; set; }

            [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
            public string Url { get; set; }

            [JsonProperty("notifierServer", NullValueHandling = NullValueHandling.Ignore)]
            public string NotifierServer { get; set; }

            [JsonProperty("ws", NullValueHandling = NullValueHandling.Ignore)]
            public string Ws { get; set; }
        }
    }
}
