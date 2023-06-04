using EFT.Quests;
using Newtonsoft.Json;
using static ServerLib.Json.Converters;

namespace ServerLib.Json.Classes
{
    public class Quest
    {
        public class Base
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string QuestName { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string _id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool canShowNotificationsInGame { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Conditions conditions { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string description { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string failMessageText { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string name { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string note { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string traderId { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string location { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string image { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string type { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool isKey { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public object questStatus { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool restartable { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool instantComplete { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool secretQuest { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string startedMessageText { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string successMessageText { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string templateId { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Rewards rewards { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string status { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool KeyQuest { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string changeQuestMessageText { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string side { get; set; }

        }
        public class Conditions
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<AvailableForConditions> Started { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<AvailableForConditions> AvailableForFinish { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<AvailableForConditions> AvailableForStart { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<AvailableForConditions> Success { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<AvailableForConditions> Fail { get; set; }

        }
        public class AvailableForConditions
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string _parent { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public AvailableForProps _props { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool dynamicLocale { get; set; }

        }
        public class AvailableForProps
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int index { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string parentId { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool isEncoded { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool dynamicLocale { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string value { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string compareMethod { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<VisibilityCondition> visibilityConditions { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public QuestTarget? target { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<EQuestStatus> status { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int availableAfter { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int dispersion { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool onlyFoundInRaid { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool oneSessionOnly { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool doNotResetIfCounterCompleted { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int dogtagLevel { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int maxDurability { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int minDurability { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public AvailableForCounter counter { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int plantTime { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string zoneId { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public object type { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool countInRaid { get; set; }

        }
        public class AvailableForCounter

        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<CounterCondition> conditions { get; set; }

        }
        public class CounterCondition

        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string _parent { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public CounterProps _props { get; set; }

        }
        public class CounterProps

        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public QuestTarget? target { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string compareMethod { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string value { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> weapon { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<List<string>> equipmentInclusive { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<List<string>> weaponModsInclusive { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> status { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> bodyPart { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public DaytimeCounter daytime { get; set; }

        }
        public class DaytimeCounter

        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int from { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int to { get; set; }

        }
        public class VisibilityCondition

        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int value { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool dynamicLocale { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool oneSessionOnly { get; set; }

        }
        public class Rewards
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Reward> AvailableForStart { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Reward> AvailableForFinish { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Reward> Started { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Reward> Success { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Reward> Fail { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Reward> FailRestartable { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Reward> Expired { get; set; }

        }
        public class Reward : Item.Base
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string value { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string type { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int index { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string target { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Item.Base> items { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int loyaltyLevel { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string traderId { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool unknown { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool findInRaid { get; set; }

        }

    }
}
