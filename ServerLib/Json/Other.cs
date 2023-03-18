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

        public class QuestBase
        {
            public string name { get; set; }
            public string description { get; set; }
            public string failMessageText { get; set; }
            public string successMessageText { get; set; }
        }

        public class WidthHeight
        {
            [JsonProperty("Width", NullValueHandling = NullValueHandling.Ignore)]
            public long Width { get; set; }

            [JsonProperty("Height", NullValueHandling = NullValueHandling.Ignore)]
            public long Height { get; set; }
        }

        public class Size
        {
            [JsonProperty("SizeUp", NullValueHandling = NullValueHandling.Ignore)]
            public int SizeUp { get; set; }

            [JsonProperty("SizeDown", NullValueHandling = NullValueHandling.Ignore)]
            public int SizeDown { get; set; }

            [JsonProperty("SizeLeft", NullValueHandling = NullValueHandling.Ignore)]
            public int SizeLeft { get; set; }

            [JsonProperty("SizeRight", NullValueHandling = NullValueHandling.Ignore)]
            public int SizeRight { get; set; }
        }

        public class Forced
        {
            [JsonProperty("ForcedUp", NullValueHandling = NullValueHandling.Ignore)]
            public int ForcedUp { get; set; }

            [JsonProperty("ForcedDown", NullValueHandling = NullValueHandling.Ignore)]
            public int ForcedDown { get; set; }

            [JsonProperty("ForcedLeft", NullValueHandling = NullValueHandling.Ignore)]
            public int ForcedLeft { get; set; }

            [JsonProperty("ForcedRight", NullValueHandling = NullValueHandling.Ignore)]
            public int ForcedRight { get; set; }
        }

        public class ContainerMap
        {
            [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty("map", NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, Map> Map { get; set; }
        }

        public class Map
        {
            [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
            public int Height { get; set; }

            [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
            public int Width { get; set; }

            [JsonProperty("grid", NullValueHandling = NullValueHandling.Ignore)]
            public List<List<string>> Grid { get; set; }
        }

        public class FreeSlot
        {
            [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
            public int X { get; set; }

            [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
            public int Y { get; set; }

            [JsonProperty("r", NullValueHandling = NullValueHandling.Ignore)]
            public int R { get; set; }

            [JsonProperty("slotId", NullValueHandling = NullValueHandling.Ignore)]
            public string SlotId { get; set; }
        }
    }
}
