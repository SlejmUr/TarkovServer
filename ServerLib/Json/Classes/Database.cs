namespace ServerLib.Json.Classes
{
    public class Database
    {
        public bot Bot { get; set; } = new();
        public class bot
        {
            public string Base { get; set; }
            public string Appearance { get; set; }
            public string WeaponCache { get; set; }
            public Dictionary<string, Bots.BotType> Types { get; set; } = new();

        }
        public characters Characters { get; set; } = new();
        public class characters
        {
            public Dictionary<string, Character.Base> CharacterBase = new();
            public Dictionary<string, List<string>> CharacterStorage = new();
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
            public Dictionary<string, string> Locales { get; set; } = new();
            public Dictionary<string, Dictionary<string, string>> LocalesDict { get; set; } = new();
        }
        public location Location { get; set; } = new();
        public class location
        {
            public string AllLocations { get; set; }
            public string Base { get; set; }
            public Dictionary<string, string> Locations { get; set; } = new();
        }

        public others Others { get; set; } = new();
        public class others
        {
            public Handbook.Base Templates { get; set; }
            public string Quests { get; set; }
            public Dictionary<string, CustomizationItem.Base> Customization { get; set; } = new();
            public Dictionary<string, TemplateItem.Base> Items { get; set; }
            public Dictionary<string, int> ItemPrices { get; set; } = new();
            public Dictionary<string, int> Resupply { get; set; } = new();
        }

        public trader Trader = new();
        public class trader
        {
            public Dictionary<string, Trader.Base> Traders { get; set; } = new();
        }
        public Dictionary<string, string> Weather { get; set; } = new();

        public LootBase Loot { get; set; } = new();
    }
}
