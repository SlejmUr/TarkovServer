using JsonLib.Classes.ItemRelated;
using JsonLib.Classes.LocationRelated;
using JsonLib.Classes.ProfileRelated;
using JsonLib.Classes.TradeRelated;

namespace JsonLib.Classes.DatabaseRelated
{
    public class DatabaseCore
    {
        public DB_Bot Bot { get; set; } = new();
        public class DB_Bot
        {
            public string Base { get; set; }
            public string Appearance { get; set; }
            public string WeaponCache { get; set; }
            public Dictionary<string, Bots.BotType> Types { get; set; } = new();

        }
        public DB_Characters Characters { get; set; } = new();
        public class DB_Characters
        {
            public Dictionary<string, Character.Base> CharacterBase = new();
            public Dictionary<string, List<string>> CharacterStorage = new();
        }
        public DB_Hideout Hideout { get; set; } = new();
        public class DB_Hideout
        {
            public string Areas { get; set; }
            public string Production { get; set; }
            public string Qte { get; set; }
            public string Scavcase { get; set; }
            public string Settings { get; set; }
        }
        public DB_Locale Locale { get; set; } = new();
        public class DB_Locale
        {
            public string Languages { get; set; }
            public Dictionary<string, string> Locales { get; set; } = new();
            public Dictionary<string, Dictionary<string, string>> LocalesDict { get; set; } = new();
        }
        public DB_Location Location { get; set; } = new();
        public class DB_Location
        {
            public string AllLocations { get; set; }
            public string Base { get; set; }
            public Dictionary<string, string> Locations { get; set; } = new();
        }

        public DB_Others Others { get; set; } = new();
        public class DB_Others
        {
            public Handbook.Base Templates { get; set; }
            public string Quests { get; set; }
            public Dictionary<string, CustomizationItem.Base> Customization { get; set; } = new();
            public Dictionary<string, TemplateItem.Base> Items { get; set; }
            public Dictionary<string, int> ItemPrices { get; set; } = new();
            public Dictionary<string, int> Resupply { get; set; } = new();
        }

        public DB_Traders Trader = new();
        public class DB_Traders
        {
            public Dictionary<string, Trader.Base> Traders { get; set; } = new();
        }
        public Dictionary<string, string> Weather { get; set; } = new();
        public List<Achievement> Achievements { get; set; } = new();
    }
}
