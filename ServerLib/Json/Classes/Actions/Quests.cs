using Newtonsoft.Json;

namespace ServerLib.Json.Classes.Actions
{
    public class Quests
    {
        public class AcceptQuest
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string Action { get; set; } = "QuestAccept";

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string qid { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string type { get; set; }

        }
        public class CompleteQuest
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string Action { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string qid { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public bool removeExcessItems { get; set; }

        }

        public class FailQuest
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string Action { get; set; } = "QuestComplete";

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string qid { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public bool removeExcessItems { get; set; }

        }
        public class IHandoverQuestRequestData
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string Action { get; set; } = "QuestHandover";

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string qid { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string conditionId { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public List<Item> items { get; set; }
            public class Item
            {
                [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
                public string id { get; set; }

                [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
                public int count { get; set; }

            }
        }

    }
}
