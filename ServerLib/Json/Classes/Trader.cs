using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class Trader
    {
        public class Base
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public TraderAssort assort { get; set; } = new();

            [JsonProperty("base", NullValueHandling = NullValueHandling.Ignore)]
            public TraderBase traderbase { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, List<string>> dialogue { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, Dictionary<string, string>> questassort { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Suit> suits { get; set; } = new();

        }
        public class TraderBase
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool refreshTraderRagfairOffers { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string _id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool availableInRaid { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string avatar { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int balance_dol { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int balance_eur { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int balance_rub { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool buyer_up { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string currency { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool customization_seller { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int discount { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int discount_end { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int gridHeight { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Insurance insurance { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public ItemBuyData items_buy { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public ItemBuyData items_buy_prohibited { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string location { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<LoyaltyLevel> loyaltyLevels { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool medic { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string name { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int nextResupply { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string nickname { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Repair repair { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> sell_category { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string surname { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool unlockedByDefault { get; set; }

        }
        public class ItemBuyData

        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> category { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> id_list { get; set; } = new();

        }
        public class Insurance
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool availability { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> excluded_category { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int max_return_hour { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int max_storage_time { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int min_payment { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int min_return_hour { get; set; }

        }
        public class LoyaltyLevel
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int buy_price_coef { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int exchange_price_coef { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int heal_price_coef { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int insurance_price_coef { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int minLevel { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int minSalesSum { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double minStanding { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int repair_price_coef { get; set; }

        }
        public class Repair
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool availability { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string currency { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int currency_coefficient { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> excluded_category { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<object> excluded_id_list { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double quality { get; set; }

        }
        public class TraderAssort
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int nextResupply { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Item.Base> items { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, List<List<BarterScheme>>> barter_scheme { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, int> loyal_level_items { get; set; } = new();

        }
        public class BarterScheme
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double count { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string _tpl { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool onlyFunctional { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool sptQuestLocked { get; set; }

        }
        public class Suit
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string _id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string tid { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string suiteId { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool isActive { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Requirements requirements { get; set; } = new();

        }
        public class Requirements
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int loyaltyLevel { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int profileLevel { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double standing { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> skillRequirements { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> questRequirements { get; set; } = new();

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<ItemRequirement> itemRequirements { get; set; } = new();

        }
        public class ItemRequirement
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int count { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string _tpl { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool onlyFunctional { get; set; }

        }
    }
}
