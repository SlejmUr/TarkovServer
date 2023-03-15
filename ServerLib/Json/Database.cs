using EFT.InventoryLogic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace ServerLib.Json
{
    public class Database
    {
        public basic Basic { get; set; } = new();
        public class basic
        {
            public List<string> BlacklistedIds { get; set; }
            public string Globals { get; set; }
        }
        public bot Bot { get; set; } = new();
        public class bot
        {
            public string Base { get; set; }
            public string Settings { get; set; }
            public Bots.BotNames Names { get; set; }
            public Dictionary<string, List<string>> NamesDict { get; set; } = new();
            public string Appearance { get; set; }
            public string WeaponCache { get; set; }
            public Dictionary<string, bots> Bots { get; set; } = new();
            public class bots
            {
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
        }
        public characters Characters { get; set; } = new();
        public class characters
        {
            public Dictionary<string, Character.Base> CharacterBase = new();
            public CharacterOBJ.CharacterStorage CharacterStorage = new();
            public CharacterOBJ.DefaultCustomization DefaultCustomization = new();
        }
        public hideout Hideout { get; set; } = new();
        public class hideout
        {
            public string Areas { get; set; }
            public string Production { get; set; }
            public string Qte { get; set; }
            public string Scavcase { get; set; }
            public string Settings { get; set; }
        }
        public locale Locale { get; set; } = new();
        public class locale
        {
            public string Languages { get; set; }
            public string Extras { get; set; }
            public Dictionary<string, string> Locales { get; set; } = new();
        }
        public location Location { get; set; } = new();
        public class location
        {
            public string AllLocations { get; set; }
            public Dictionary<string, string> Locations { get; set; } = new();

            // Adding more on locations currently doing only Base
        }

        public others Others { get; set; } = new();
        public class others
        {
            public List<string> ChildlessList { get; set; }
            public string FleaOffer { get; set; }
            public string MatchMetrics { get; set; }
            public string Quests { get; set; }
            public Dictionary<string, string> Customization { get; set; } = new();
            public Dictionary<string, ItemBase> Items { get; set; }
            public Dictionary<string, int> ItemPrices { get; set; } = new();

            // Not Loaded:  client.settings.json,  raidConfig.json, seasonalevents.json, staticWeaponsData.json
        }

        public templates Templates { get; set; } = new();
        public class templates
        {
            public List<Templates.Categories> Categories { get; set; }
            public List<Templates.Items> Items { get; set; }

            // more templates
        }

        public trader Trader = new();
        public class trader
        {
            public string LiveFlea { get; set; }
            public Dictionary<string, traders> Traders { get; set; } = new();
            public class traders
            {
                public Traders.Base Base { get; set; }
                public List<string> Categories { get; set; }
                public string RagfairCategories { get; set; }
                public List<TraderSuits> Suits { get; set; }
                public Traders.Dialog Dialog { get; set; }
                public string QuestAssort { get; set; }
                public assort Assort { get; set; }
                public class assort
                {
                    public int NextResupply { get; set; }
                    public List<Traders.Item> Items { get; set; }

                    [JsonProperty("barter_scheme")]
                    public Dictionary<string, List<List<Traders.Barter>>> BarterScheme { get; set; }

                    [JsonProperty("loyal_level_items")]
                    public Dictionary<string, long> LoyalLevelItems { get; set; }
                }
            }
        }
        public Dictionary<string, string> Weather { get; set; } = new();



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
