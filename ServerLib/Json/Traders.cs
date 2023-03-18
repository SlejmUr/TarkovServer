using EFT.UI.Ragfair;
using Newtonsoft.Json;

namespace ServerLib.Json
{
    public class Traders
    {
        public class Customization
        {
            [JsonProperty("traderID")]
            public string TraderID { get; set; }

            [JsonProperty("suite")]
            public JsonCustomization.Base Suite { get; set; }
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
            public List<string> SkillRequirements { get; set; } = new();

            [JsonProperty("questRequirements")]
            public List<string> QuestRequirements { get; set; } = new();

            [JsonProperty("itemRequirements")]
            public List<ItemRequirement> ItemRequirements { get; set; } = new();
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

        public class Insurance
        {
            [JsonProperty("availability")]
            public bool Availability { get; set; }

            [JsonProperty("min_payment")]
            public int MinPayment { get; set; }

            [JsonProperty("min_return_hour")]
            public int MinReturnHour { get; set; }

            [JsonProperty("max_return_hour")]
            public int MaxReturnHour { get; set; }

            [JsonProperty("max_storage_time")]
            public int MaxStorageTime { get; set; }

            [JsonProperty("excluded_category")]
            public List<object> ExcludedCategory { get; set; }
        }

        public class LoyaltyLevel
        {
            [JsonProperty("minLevel")]
            public int MinLevel { get; set; }

            [JsonProperty("minSalesSum")]
            public int MinSalesSum { get; set; }

            [JsonProperty("minStanding")]
            public double MinStanding { get; set; }

            [JsonProperty("buy_price_coef")]
            public int BuyPriceCoef { get; set; }

            [JsonProperty("repair_price_coef")]
            public int RepairPriceCoef { get; set; }

            [JsonProperty("insurance_price_coef")]
            public object InsurancePriceCoef { get; set; }

            [JsonProperty("exchange_price_coef")]
            public int ExchangePriceCoef { get; set; }

            [JsonProperty("heal_price_coef")]
            public int HealPriceCoef { get; set; }
        }

        public class Repair
        {
            [JsonProperty("availability")]
            public bool Availability { get; set; }

            [JsonProperty("quality")]
            public string Quality { get; set; }

            [JsonProperty("excluded_id_list")]
            public List<object> ExcludedIdList { get; set; }

            [JsonProperty("excluded_category")]
            public List<object> ExcludedCategory { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("currency_coefficient")]
            public int CurrencyCoefficient { get; set; }
        }

        public class Base
        {
            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("customization_seller")]
            public bool CustomizationSeller { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("surname")]
            public string Surname { get; set; }

            [JsonProperty("nickname")]
            public string Nickname { get; set; }

            [JsonProperty("location")]
            public string Location { get; set; }

            [JsonProperty("avatar")]
            public string Avatar { get; set; }

            [JsonProperty("balance_rub")]
            public int BalanceRub { get; set; }

            [JsonProperty("balance_dol")]
            public int BalanceDol { get; set; }

            [JsonProperty("balance_eur")]
            public int BalanceEur { get; set; }

            [JsonProperty("unlockedByDefault")]
            public bool UnlockedByDefault { get; set; }

            [JsonProperty("discount")]
            public int Discount { get; set; }

            [JsonProperty("discount_end")]
            public int DiscountEnd { get; set; }

            [JsonProperty("buyer_up")]
            public bool BuyerUp { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("nextResupply")]
            public int NextResupply { get; set; }

            [JsonProperty("repair")]
            public Repair Repair { get; set; }

            [JsonProperty("insurance")]
            public Insurance Insurance { get; set; }

            [JsonProperty("medic")]
            public bool Medic { get; set; }

            [JsonProperty("gridHeight")]
            public int GridHeight { get; set; }

            [JsonProperty("loyaltyLevels")]
            public List<LoyaltyLevel> LoyaltyLevels { get; set; }

            [JsonProperty("sell_category")]
            public List<object> SellCategory { get; set; }
        }

        public partial class Barter
        {
            [JsonProperty("count")]
            public long Count { get; set; }

            [JsonProperty("_tpl")]
            public string Tpl { get; set; }
        }

        public class RagfairOffer
        {
            [JsonProperty("_id")]
            public string Id { get; set; }
            public long IntId { get; set; }
            public Character.Item Item { get; set; }
            public List<Barter> Requirements { get; set; }
            public Offer.Merchant User { get; set; }
            public int BuyRestrictionMax { get; set; }
            public int BuyRestrictionCurrent { get; set; }
            public int LoyaltyLevel { get; set; }
            public int SummaryCost { get; set; }
            public int ItemsCost { get; set; }
            public int RequirementsCost { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public bool Locked { get; set; }
            public bool UnlimitedCount { get; set; }
            public bool SellInOnePiece { get; set; }
        }
    }
}
