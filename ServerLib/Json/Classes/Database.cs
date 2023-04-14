using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace ServerLib.Json.Classes
{
    public class Database
    {
        public basic Basic { get; set; } = new();
        public class basic
        {
            public List<string> BlacklistedIds { get; set; }
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
            public Dictionary<string, List<string>> CharacterStorage = new();
            public Dictionary<string, Character.Customization> DefaultCustomization = new();
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
            public Dictionary<string, Dictionary<string, string>> LocalesDict { get; set; } = new();
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
            public string Quests { get; set; }
            public Dictionary<string, string> Customization { get; set; } = new();
            public Dictionary<string, TemplateItem.Base> Items { get; set; }
            public Dictionary<string, int> ItemPrices { get; set; } = new();
            public Dictionary<string, int> Resupply { get; set; } = new();
        }

        public Handbook.Base Templates { get; set; }

        public trader Trader = new();
        public class trader
        {
            public string LiveFlea { get; set; }
            public Dictionary<string, Trader.Base> Traders { get; set; } = new();
        }
        public Dictionary<string, string> Weather { get; set; } = new();
    }
}
