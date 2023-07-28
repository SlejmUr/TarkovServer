using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ServerLib.Json.Classes
{
    public class Character
    {
        public partial class Base
        {
            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("aid")]
            public string Aid { get; set; }

            [JsonProperty("savage")]
            public string Savage { get; set; }

            [JsonProperty("Info")]
            public Info Info { get; set; }

            [JsonProperty("Customization")]
            public Customization Customization { get; set; }

            [JsonProperty("Encyclopedia")]
            public Dictionary<string,bool> Encyclopedia { get; set; }

            [JsonProperty("Health")]
            public Health Health { get; set; }

            [JsonProperty("Inventory")]
            public Inventory Inventory { get; set; }

            [JsonProperty("Skills")]
            public Skills Skills { get; set; }

            [JsonProperty("Notes")]
            public Notes Notes { get; set; }

            [JsonProperty("Quests")]
            public Quest[] Quests { get; set; }

            [JsonProperty("TraderStandings")]
            public Dictionary<string, TraderStanding> TraderStandings { get; set; }

            [JsonProperty("ConditionCounters")]
            public ConditionCounters ConditionCounters { get; set; }

            [JsonProperty("BackendCounters")]
            public Dictionary<string, BackendCounters> BackendCounters { get; set; }

            [JsonProperty("Stats")]
            public Stats Stats { get; set; }
        }

        public partial class BackendCounters
        {
            public int value { get; set; }
            public string id { get; set; }
            public string qid { get; set; }
        }

        public partial class TraderStanding
        {
            public int currentSalesSum { get; set; }
            public int currentLevel { get; set; }
            public int currentStanding { get; set; }
            public StandingLevel NextLoyalty { get; set; }
            public Dictionary<string, StandingLevel> loyaltyLevels { get; set; }
            public class StandingLevel
            {
                public int minLevel { get; set; }
                public int minSalesSum { get; set; }
                public float minStanding { get; set; }
            }
        }

        public partial class ConditionCounters
        {
            [JsonProperty("Counters")]
            public object[] Counters { get; set; }
        }

        public partial class Customization
        {
            [JsonProperty("Head")]
            public Body Head { get; set; }

            [JsonProperty("Body")]
            public Body Body { get; set; }

            [JsonProperty("Feet")]
            public Body Feet { get; set; }

            [JsonProperty("Hands")]
            public Body Hands { get; set; }
        }

        public partial class Body
        {
            [JsonProperty("path")]
            public string Path { get; set; }

            [JsonProperty("rcid")]
            public string Rcid { get; set; }
        }

        public partial class Health
        {
            [JsonProperty("BodyParts")]
            public BodyParts BodyParts { get; set; }

            [JsonProperty("Energy")]
            public Energy Energy { get; set; }

            [JsonProperty("Hydration")]
            public Energy Hydration { get; set; }
        }

        public partial class BodyParts
        {
            [JsonProperty("Head")]
            public Chest Head { get; set; }

            [JsonProperty("Chest")]
            public Chest Chest { get; set; }

            [JsonProperty("Stomach")]
            public Chest Stomach { get; set; }

            [JsonProperty("LeftArm")]
            public Chest LeftArm { get; set; }

            [JsonProperty("RightArm")]
            public Chest RightArm { get; set; }

            [JsonProperty("LeftLeg")]
            public Chest LeftLeg { get; set; }

            [JsonProperty("RightLeg")]
            public Chest RightLeg { get; set; }
        }

        public partial class Chest
        {
            [JsonProperty("Health")]
            public Energy Health { get; set; }

            [JsonProperty("Effects")]
            public object Effects { get; set; }
        }

        public partial class Energy
        {
            [JsonProperty("Current")]
            public long Current { get; set; }

            [JsonProperty("Maximum")]
            public long Maximum { get; set; }
        }

        public partial class Info
        {
            [JsonProperty("Nickname")]
            public string Nickname { get; set; }

            [JsonProperty("LowerNickname")]
            public string LowerNickname { get; set; }

            [JsonProperty("Side")]
            public string Side { get; set; }

            [JsonProperty("Voice")]
            public string Voice { get; set; }

            [JsonProperty("Level")]
            public long Level { get; set; }

            [JsonProperty("Experience")]
            public long Experience { get; set; }

            [JsonProperty("RegistrationDate")]
            public long RegistrationDate { get; set; }

            [JsonProperty("GameVersion")]
            public string GameVersion { get; set; }

            [JsonProperty("AccountType")]
            public long AccountType { get; set; }

            [JsonProperty("MemberCategory")]
            public long MemberCategory { get; set; }

            [JsonProperty("lockedMoveCommands")]
            public bool LockedMoveCommands { get; set; }

            [JsonProperty("LastTimePlayedAsSavage")]
            public long LastTimePlayedAsSavage { get; set; }

            [JsonProperty("Settings")]
            public Settings Settings { get; set; }

            [JsonProperty("NeedWipe")]
            public bool NeedWipe { get; set; }

            [JsonProperty("GlobalWipe")]
            public bool GlobalWipe { get; set; }

            [JsonProperty("NicknameChangeDate")]
            public long NicknameChangeDate { get; set; }
        }

        public partial class Settings
        {
            [JsonProperty("Role")]
            public string Role { get; set; }

            [JsonProperty("BotDifficulty")]
            public string BotDifficulty { get; set; }

            [JsonProperty("Experience")]
            public long Experience { get; set; }
        }

        public partial class Inventory
        {
            [JsonProperty("items")]
            public List<Item> Items { get; set; }

            [JsonProperty("equipment")]
            public string Equipment { get; set; }

            [JsonProperty("stash")]
            public string Stash { get; set; }

            [JsonProperty("fastPanel")]
            public object FastPanel { get; set; }

            [JsonProperty("questRaidItems")]
            public string QuestRaidItems { get; set; }

            [JsonProperty("questStashItems")]
            public string QuestStashItems { get; set; }
        }


        public partial class Item
        {
            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("_tpl")]
            public string Tpl { get; set; }

            [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
            public string ParentId { get; set; }

            [JsonProperty("slotId", NullValueHandling = NullValueHandling.Ignore)]
            public string SlotId { get; set; }

            [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
            public Location Location { get; set; }

            [JsonProperty("upd", NullValueHandling = NullValueHandling.Ignore)]
            public Upd Upd { get; set; }
        }

        public partial class Location
        {
            [JsonProperty("x")]
            public long X { get; set; }

            [JsonProperty("y")]
            public long Y { get; set; }

            [JsonProperty("r")]
            public string R { get; set; }

            [JsonProperty("isSearched")]
            public bool IsSearched { get; set; }
        }

        public partial class Upd
        {
            [JsonProperty("StackObjectsCount")]
            public long StackObjectsCount { get; set; }
        }

        public partial class Notes
        {
            [JsonProperty("Notes")]
            public InsideNotes[] NotesNotes { get; set; }
        }

        public partial class InsideNotes
        {
            public long Time { get; set; }
            public string Text { get; set; }
        }

        public partial class Skills
        {
            [JsonProperty("Common")]
            public Common[] Common { get; set; }

            [JsonProperty("Mastering")]
            public object[] Mastering { get; set; }

            [JsonProperty("Points")]
            public long Points { get; set; }
        }

        public partial class Common
        {
            [JsonProperty("Id")]
            public string Id { get; set; }

            [JsonProperty("Progress")]
            public long Progress { get; set; }

            [JsonProperty("MaxAchieved")]
            public long MaxAchieved { get; set; }

            [JsonProperty("LastAccess")]
            public long LastAccess { get; set; }
        }

        public partial class Stats
        {
            [JsonProperty("SessionCounters")]
            public Counters SessionCounters { get; set; }

            [JsonProperty("OverallCounters")]
            public Counters OverallCounters { get; set; }

            [JsonProperty("SessionExperienceMult")]
            public float SessionExperienceMult { get; set; }

            [JsonProperty("TotalSessionExperience")]
            public long TotalSessionExperience { get; set; }

            [JsonProperty("LastSessionDate")]
            public long LastSessionDate { get; set; }

            [JsonProperty("DroppedItems")]
            public object[] DroppedItems { get; set; }

            [JsonProperty("Victims")]
            public object[] Victims { get; set; }

            [JsonProperty("Aggressor")]
            public object Aggressor { get; set; }

            [JsonProperty("CarriedQuestItems")]
            public object[] CarriedQuestItems { get; set; }

            [JsonProperty("TotalInGameTime")]
            public long TotalInGameTime { get; set; }
        }

        public partial class Counters
        {
            [JsonProperty("Items")]
            public ItemElement[] Items { get; set; }
        }

        public partial class ItemElement
        {
            [JsonProperty("Key")]
            public string[] Key { get; set; }

            [JsonProperty("Value")]
            public long Value { get; set; }
        }
        public class Quest
        {
            public string qid { get; set; }
            public int startTime { get; set; }
            public string status { get; set; }
            public string[] completedConditions { get; set; }
            public Dictionary<int, double> StatusTimers { get; set; }
        }


        public partial class Base
        {
            public static Base FromJson(string json) => JsonConvert.DeserializeObject<Base>(json, Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }
    }
}
