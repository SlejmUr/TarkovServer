using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Json
{
    public class Traders
    {
        public class Suits
        {
            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("tid")]
            public string Tid { get; set; }

            [JsonProperty("suiteId")]
            public string SuiteId { get; set; }

            [JsonProperty("isActive")]
            public bool IsActive { get; set; }

            [JsonProperty("requirements")]
            public Requirements Requirements { get; set; }
        }
        public class ItemRequirement
        {
            [JsonProperty("count")]
            public int Count { get; set; }

            [JsonProperty("_tpl")]
            public string Tpl { get; set; }

            [JsonProperty("onlyFunctional")]
            public bool OnlyFunctional { get; set; }
        }

        public class Requirements
        {
            [JsonProperty("loyaltyLevel")]
            public int LoyaltyLevel { get; set; }

            [JsonProperty("profileLevel")]
            public int ProfileLevel { get; set; }

            [JsonProperty("standing")]
            public int Standing { get; set; }

            [JsonProperty("skillRequirements")]
            public List<object> SkillRequirements { get; set; }

            [JsonProperty("questRequirements")]
            public List<string> QuestRequirements { get; set; }

            [JsonProperty("itemRequirements")]
            public List<ItemRequirement> ItemRequirements { get; set; }
        }

        public class Dialog
        {
            [JsonProperty("insuranceStart")]
            public List<string> InsuranceStart { get; set; }

            [JsonProperty("insuranceFound")]
            public List<string> InsuranceFound { get; set; }

            [JsonProperty("insuranceExpired")]
            public List<string> InsuranceExpired { get; set; }

            [JsonProperty("insuranceComplete")]
            public List<string> InsuranceComplete { get; set; }

            [JsonProperty("insuranceFailed")]
            public List<string> InsuranceFailed { get; set; }
        }
    }
}
