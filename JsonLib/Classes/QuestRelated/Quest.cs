using JsonLib.Classes.ItemRelated;
using Newtonsoft.Json;
using static JsonLib.Converters;

namespace JsonLib.Classes.QuestRelated
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
            public string acceptPlayerMessage { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string declinePlayerMessage { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string completePlayerMessage { get; set; }

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
            public List<Condition> Started { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Condition> AvailableForFinish { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Condition> AvailableForStart { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Condition> Success { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Condition> Fail { get; set; }

        }

        public class Condition
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int index { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string compareMethod { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool dynamicLocale { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<VisibilityCondition> visibilityConditions { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string globalQuestCounterId { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string parentId { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public QuestTarget? target { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string value { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public object type { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<int> status { get; set; } //EQuestStatus

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
            public ConditionCounter counter { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int plantTime { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string zoneId { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool countInRaid { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int completeInSeconds { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool isEncoded { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string conditionType { get; set; }

        }

        public class VisibilityCondition
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string target { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int value { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool dynamicLocale { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool oneSessionOnly { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string conditionType { get; set; }
        }

        public class ConditionCounter
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<ConditionCounterCondition> conditions { get; set; }

        }

        public class ConditionCounterCondition
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool dynamicLocale { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public QuestTarget? target { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int completeInSeconds { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public ValueCompare energy { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string exitName { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public ValueCompare hydration { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public ValueCompare time { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string compareMethod { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string value { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> weapon { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public ConditionDistance distance { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<List<string>> equipmentInclusive { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<List<string>> weaponModsInclusive { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<List<string>> weaponModsExclusive { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<List<string>> enemyEquipmentInclusive { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<List<string>> enemyEquipmentExclusive { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> weaponCaliber { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> savageRole { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> status { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> bodyPart { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public DaytimeCounter daytime { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string conditionType { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<EnemyHealthEffect> enemyHealthEffects { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool resetOnSessionEnd { get; set; }
        }

        public class DaytimeCounter
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int from { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int to { get; set; }
        }

        public class ValueCompare
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string compareMethod { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int value { get; set; }
        }

        public class EnemyHealthEffect
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> bodyParts { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> effects { get; set; }
        }


        public class ConditionDistance
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int value { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string compareMethod { get; set; }
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
        public class Reward
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double value { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string type { get; set; } //QuestRewardType

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int index { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public QuestTarget target { get; set; }

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
