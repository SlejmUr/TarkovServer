using Newtonsoft.Json;

namespace ServerLib.Json
{
    public class Database
    {
        public CustomConfig.Base CustomSettings { get; set; }
        public ServerConfig.Base Server { get; set; }
        public string Globals { get; set; }
        public GameplayConfig.Base Gameplay { get; set; }
        public Dictionary<string, ItemBase> Items { get; set; }
        public Dictionary<int, int> ItemPrices { get; set; } = new();
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
            public string Categories { get; set; }
            public string Items { get; set; }
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
            public assort Assort { get; set; } = new();
            public class assort
            {
                public int NextResupply { get; set; }
                public Dictionary<string, string> Items { get; set; } = new();
                public Dictionary<string, string> BarterScheme { get; set; } = new();
                public Dictionary<string, string> LoyalLevelItems { get; set; } = new();
            }
        }
        public Dictionary<string, string> Weather { get; set; } = new();
    }
}
