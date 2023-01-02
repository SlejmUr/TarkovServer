using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace ServerLib.Json
{
    public class Database
    {
        public string Globals { get; set; }
        public List<string> BlacklistedIds { get; set; }
        public Dictionary<string, ItemBase> Items { get; set; }
        public Dictionary<string, int> ItemPrices { get; set; } = new();
        public core Core { get; set; } = new();
        public class core
        {
            public class bot
            {
                public string Base { get; set; }
                public string Settings { get; set; }
                public string Names { get; set; }
                public string Appearance { get; set; }
                public Dictionary<string, string> WeaponCache { get; set; }
            }
            public bot Bot { get; set; } = new();
            public string FleaOffer { get; set; }
            public string PlayerScav { get; set; }
            public string MatchMetrics { get; set; }
        }
        public Dictionary<string, bots> Bots { get; set; } = new();
        public class bots
        {
            public string Profile { get; set; }
            public string Health { get; set; }
            public string Loadout { get; set; }
            public difficulty Difficulty { get; set; } = new();

            public class difficulty
            {
                public string Easy { get; set; }
                public string Normal { get; set; }
                public string Hard { get; set; }
                public string Impossible { get; set; }
                public string Custom { get; set; }
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
        public string AllLocations { get; set; }
        public Dictionary<string, string> Locations { get; set; } = new();
        public Dictionary<string, traders> Traders { get; set; } = new();
        public class traders
        {
            public Traders.Base Base { get; set; }
            public List<string> Categories { get; set; }
            public string RagfairCategories { get; set; }
            public List<ACS.TraderSuits> Suits { get; set; }
            public Traders.Dialog Dialog { get; set; }
            public string QuestAssort { get; set; }
            public assort Assort { get; set; }
            public class assort
            {
                public int NextResupply { get; set; }
                public List<Item> Items { get; set; }

                [JsonProperty("barter_scheme")]
                public Dictionary<string, List<List<Barter>>> BarterScheme { get; set; }

                [JsonProperty("loyal_level_items")]
                public Dictionary<string, long> LoyalLevelItems { get; set; }
            }
        }
        public Dictionary<string, string> Weather { get; set; } = new();

        public characters Characters { get; set; } = new();

        public class characters
        {
            public Dictionary<string, Character.Base> CharacterBase = new();
            public CharacterOBJ.CharacterStorage CharacterStorage = new();
        }

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
