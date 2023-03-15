using EFT.Hideout;
using Newtonsoft.Json;
using static ServerLib.Json.Traders;

namespace ServerLib.Json
{
    public class ProfleChanges
    {
        [JsonProperty("profileChanges")]
        public Dictionary<string, PChanges> ProfileChanges = new();

        [JsonProperty("warnings")]
        public InventoryWarning[] InventoryWarning;
    }

    public class InventoryWarning
    {
        [JsonProperty("data")]
        public object Data;

        [JsonProperty("index")]
        public int RequestIndex { get; set; }

        [JsonProperty("errmsg")]
        public string ErrorMessage { get; set; }

        [JsonProperty("code")]
        public string ErrorCode { get; set; }

        [JsonProperty("msg")]
        private string MSG { get; set; }
    }
    public class PChanges
    {
        [JsonProperty("experience")]
        public int Experience;

        [JsonProperty("items")]
        public Stash Stash;

        [JsonProperty("quests")]
        public RawQuestClass[] Quests;

        [JsonProperty("repeatableQuests")]
        public DailyQuestClass[] RepeatableQuests;

        [JsonProperty("ragFairOffers")]
        public RagfairOffer[] RagFairOffers;

        [JsonProperty("traderRelations")]
        public Dictionary<string, Character.TradersInfo> TradersData;

        [JsonProperty("recipeUnlocked")]
        public Dictionary<string, bool> UnlockedRecipes;

        [JsonProperty("builds")]
        public Build[] Builds;

        [JsonProperty("production")]
        public Dictionary<string, ProductionData> Production;

        [JsonProperty("improvements")]
        public Dictionary<string, GClass1818> Improvements;

        [JsonProperty("skills")]
        public Character.Skills Skills;

        [JsonProperty("questsStatus")]
        public QuestDataClass[] QuestsStatus;
    }


    public class Command
    {
        [JsonProperty("Action")]
        public string Action = "Move";
        [JsonProperty("item")]
        public string Item;
        [JsonProperty("to")]
        public To To;
    }


    public sealed class To
    {
        public string parentItem;

        public string container;

        public Character.Location location;
    }






}
