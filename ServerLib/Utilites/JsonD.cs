using Newtonsoft.Json.Linq;

namespace ServerLib.Utilities
{
    public class JsonD
    {
        public class Profile
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Edition { get; set; }
            public string Password { get; set; }
        }
        public class Account
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public bool Wipe { get; set; } = false;
            public string Edition { get; set; }
            public string Lang { get; set; } = "en";
            public string[] Friends { get; set; } = Array.Empty<string>();
            public MatchingClass Matching { get; set; }
            public class MatchingClass
            {
                public bool LookingForGroup { get; set; } = false;
            }
            public string[] FriendRequestInbox { get; set; } = Array.Empty<string>();
            public string[] FriendRequestOutbox { get; set; } = Array.Empty<string>();
        }

        public class CharacterOBJ
        {
            public string Id { get; set; }
            public string _id { get; set; }
            public string Nickname { get; set; }
            public int Level { get; set; }
            public bool LookingGroup { get; set; } = false;
            public PlayerVisualRepresentationClass PlayerVisualRepresentation { get; set; } = new();
            public class PlayerVisualRepresentationClass
            {
                public Info Info { get; set; } = new();
                public JObject Customization { get; set; }
            }

            public class Info
            {
                public string Nickname { get; set; }
                public string Side { get; set; }
                public int Level { get; set; }
                public int MemberCategory { get; set; }
                public bool Ignored { get; set; } = false;
                public bool Banned { get; set; } = false;
            }
        }

        public class Database
        {
            public string Globals { get; set; }
            public string Gameplay { get; set; }
            public string Items { get; set; }
            public Dictionary<int, int> ItemPrices { get; set; }
            public core Core { get; set; }
            public class core
            {
                public string BotBase { get; set; }
                public string BotCore { get; set; }
                public string FleaOffer { get; set; }
                public string MatchMetrics { get; set; }
            }
            public Dictionary<string, bots> Bots { get; set; }
            public class bots
            {
                public string BotNames { get; set; }
                public string Appearance { get; set; }
                public appearance Appearances { get; set; }
                public string Chances { get; set; }
                public string Experience { get; set; }
                public string Heneration { get; set; }
                public string Health { get; set; }
                public string Inventory { get; set; }
                public Dictionary<string, string> Inventory_dict { get; set; }
                public difficulty Difficulty { get; set; }

                public class difficulty
                {
                    public string Easy { get; set; }
                    public string Normal { get; set; }
                    public string Hard { get; set; }
                    public string Impossible { get; set; }
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
            public templates Templates { get; set; }
            public class templates
            {
                public string Categories { get; set; }
                public string Items { get; set; }
            }
            public hideout Hideout { get; set; }
            public class hideout
            {
                public string Settings { get; set; }
                public string Areas { get; set; } //DONT OFRGET TO PARSE IT TO JSON! (dynamic)
                public Dictionary<string, string> Production { get; set; }
                public Dictionary<string, string> Scavcase { get; set; }
            }
            public Dictionary<string, string> Quests { get; set; }
            public Dictionary<string, string> Customization { get; set; }
            public string Languages { get; set; }
            public static Dictionary<string, string> Locales { get; set; }
            public locations Locations { get; set; }
            public class locations
            {
                public string LocationBase { get; set; }
                public string StaticLootTable { get; set; }
                public string DynamicLootTable { get; set; }
                public Dictionary<string, string> Base { get; set; }
                public Dictionary<string, loot> Loot { get; set; }
                public class loot
                {
                    public string Forced { get; set; }
                    public string Mounted { get; set; }
                    public string Static { get; set; }
                    public string Dynamic { get; set; }
                }
            }
            public Dictionary<string, traders>  Traders { get; set; }
            public class traders
            {
                public string Base  { get; set; }
                public string Categories { get; set; }
                public string SellCategory { get; set; }
                public string Suits { get; set; }
                public string QuestAssort { get; set; }
                public string RepairPriceRate { get; set; }
                public assort Assort { get; set; }
                public class assort
                {
                    public int NextResupply { get; set; }
                    public Dictionary<string, string> Items { get; set; }
                    public Dictionary<string, string> BarterScheme { get; set; }
                    public Dictionary<string, string> LoyalLevelItems { get; set; }
                }
            }
            public Dictionary<string, string> Weather { get; set; }
        }
    }
}
