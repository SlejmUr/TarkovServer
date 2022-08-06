using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace ServerLib.Json
{
    public class Database
    {
        public string Globals { get; set; }
        public Dictionary<string, ItemBase> Items { get; set; }
        public Dictionary<string, int> ItemPrices { get; set; } = new();
        public core Core { get; set; } = new();
        public class core
        {
            public string BotBase { get; set; }
            public string BotCore { get; set; }
            public string FleaOffer { get; set; }
            public string MatchMetrics { get; set; }
        }
        public Dictionary<string, bots> Bots { get; set; } = new();
        public class bots
        {
            public string Profile { get; set; }
            public string BotNames { get; set; }
            public string Appearance { get; set; }
            public appearance Appearances { get; set; } = new();
            public string Chances { get; set; }
            public string Experience { get; set; }
            public string Generation { get; set; }
            public string Health { get; set; }
            public string Inventory { get; set; }
            public Dictionary<string, string> Inventory_dict { get; set; } = new();
            public difficulty Difficulty { get; set; } = new();

            public class difficulty
            {
                public string Easy { get; set; }
                public string Normal { get; set; }
                public string Hard { get; set; }
                public string Impossible { get; set; }
                public string Custom { get; set; }
            }
            public class appearance
            {
                public string[] Body { get; set; } = Array.Empty<string>();
                public string[] Feet { get; set; } = Array.Empty<string>();
                public string[] Hands { get; set; } = Array.Empty<string>();
                public string[] Head { get; set; } = Array.Empty<string>();
                public string[] Voice { get; set; } = Array.Empty<string>();
            }

        }
        public templates Templates { get; set; } = new();
        public class templates
        {
            public List<Templates.Categories> Categories { get; set; }
            public List<Templates.Items> Items { get; set; }
        }
        public hideout Hideout { get; set; } = new();
        public class hideout
        {
            public string Settings { get; set; }
            public string Areas { get; set; } //DONT OFRGET TO PARSE IT TO JSON! (dynamic)
            public Dictionary<string, string> Production { get; set; } = new();
            public Dictionary<string, string> Scavcase { get; set; } = new();
        }
        public string Quests { get; set; }
        public Dictionary<string, string> Customization { get; set; } = new();
        public string Languages { get; set; }
        public Dictionary<string, string> Locales { get; set; } = new();
        public locations Locations { get; set; } = new();
        public class locations
        {
            public string LocationBase { get; set; }
            public string StaticLootTable { get; set; }
            public string DynamicLootTable { get; set; }
            public Dictionary<string, string> Base { get; set; } = new();
            public Dictionary<string, loot> Loot { get; set; } = new();
            public class loot
            {
                public string Forced { get; set; }
                public string Mounted { get; set; }
                public string Static { get; set; }
                public string Dynamic { get; set; }
            }
        }
        public Dictionary<string, traders> Traders { get; set; } = new();
        public class traders
        {
            public string Base { get; set; }
            public string Categories { get; set; }
            public string SellCategory { get; set; }
            public string Suits { get; set; }
            public string QuestAssort { get; set; }
            public string RepairPriceRate { get; set; }
            public assort Assort { get; set; }
            public class assort
            {
                public int NextResupply { get; set; }
                public List<Item> Items { get; set; }

                [JsonProperty("barter_scheme")]
                public Dictionary<string, List<List<Barter>>> BarterScheme { get; set; }

                [JsonProperty("loyal_level_items")]
                public object LoyalLevelItems { get; set; }
            }
        }
        public Dictionary<string, string> Weather { get; set; } = new();

        public partial class Barter
        {
            [JsonProperty("count")]
            public long Count { get; set; }

            [JsonProperty("_tpl")]
            public string Tpl { get; set; }
        }
        public class Item
        {
            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("_tpl")]
            public string Tpl { get; set; }

            [JsonProperty("parentId")]
            public string ParentId { get; set; }

            [JsonProperty("slotId")]
            public string SlotId { get; set; }

            [JsonProperty("upd")]
            public UpdClass Upd { get; set; }
        }
        public class UpdClass
        {
            [JsonProperty("BuyRestrictionMax", NullValueHandling = NullValueHandling.Ignore)]
            public long? BuyRestrictionMax { get; set; }

            [JsonProperty("BuyRestrictionCurrent", NullValueHandling = NullValueHandling.Ignore)]
            public long? BuyRestrictionCurrent { get; set; }

            [JsonProperty("StackObjectsCount")]
            public long StackObjectsCount { get; set; }

            [JsonProperty("UnlimitedCount", NullValueHandling = NullValueHandling.Ignore)]
            public bool? UnlimitedCount { get; set; }
        }

    }
    public static class DatabaseConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
