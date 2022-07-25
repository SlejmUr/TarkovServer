using Newtonsoft.Json;

namespace ServerLib.Json
{
    public class GameplayConfig
    {
        public class Base
        {
            [JsonProperty("inRaid")]
            public InRaid InRaid { get; set; }
            
            [JsonProperty("fence")]
            public Fence Fence { get; set; }

            [JsonProperty("other")]
            public Other Other { get; set; }

            [JsonProperty("defaultRaidSettings")]
            public DefaultRaidSettings DefaultRaidSettings { get; set; }

            [JsonProperty("hideout")]
            public Hideout Hideout { get; set; }

            [JsonProperty("trading")]
            public Trading Trading { get; set; }

            [JsonProperty("location")]
            public Location Location { get; set; }

            [JsonProperty("locationloot")]
            public Locationloot Locationloot { get; set; }

            [JsonProperty("match")]
            public Match Match { get; set; }

            [JsonProperty("weapons")]
            public Weapons Weapons { get; set; }
        }
        public class InRaid
        {
            [JsonProperty("showDeathMessage")]
            public bool ShowDeathMessage { get; set; }

            [JsonProperty("createFriendlyAI")]
            public bool CreateFriendlyAI { get; set; }

            [JsonProperty("airdropSettings")]
            public AirdropSettings AirdropSettings { get; set; }
        }
        public class AirdropSettings
        {
            [JsonProperty("airdropChancePercent")]
            public AirdropChancePercent AirdropChancePercent { get; set; }

            [JsonProperty("airdropMinStartTimeSeconds")]
            public int AirdropMinStartTimeSeconds { get; set; }

            [JsonProperty("airdropMaxStartTimeSeconds")]
            public int AirdropMaxStartTimeSeconds { get; set; }

            [JsonProperty("airdropMinOpenHeight")]
            public int AirdropMinOpenHeight { get; set; }

            [JsonProperty("airdropMaxOpenHeight")]
            public int AirdropMaxOpenHeight { get; set; }

            [JsonProperty("planeMinFlyHeight")]
            public int PlaneMinFlyHeight { get; set; }

            [JsonProperty("planeMaxFlyHeight")]
            public int PlaneMaxFlyHeight { get; set; }

            [JsonProperty("planeVolume")]
            public double PlaneVolume { get; set; }

            [JsonProperty("maximumAirdopsPerRaid")]
            public int MaximumAirdopsPerRaid { get; set; }
        }
        public class AirdropChancePercent
        {
            [JsonProperty("bigmap")]
            public int Bigmap { get; set; }

            [JsonProperty("woods")]
            public int Woods { get; set; }

            [JsonProperty("lighthouse")]
            public int Lighthouse { get; set; }

            [JsonProperty("shoreline")]
            public int Shoreline { get; set; }

            [JsonProperty("interchange")]
            public int Interchange { get; set; }

            [JsonProperty("reserve")]
            public int Reserve { get; set; }
        }
        public class Fence
        {
            [JsonProperty("killingScavsFenceLevelChange")]
            public double KillingScavsFenceLevelChange { get; set; }

            [JsonProperty("killingPMCsFenceLevelChange")]
            public double KillingPMCsFenceLevelChange { get; set; }

            [JsonProperty("fenceLevelAssortModifier")]
            public double FenceLevelAssortModifier { get; set; }
        }
        public class Other
        {
            [JsonProperty("RedeemTime")]
            public int RedeemTime { get; set; }
        }
        public class DefaultRaidSettings
        {
            [JsonProperty("aiAmount")]
            public string AiAmount { get; set; }

            [JsonProperty("aiDifficulty")]
            public string AiDifficulty { get; set; }

            [JsonProperty("bossEnabled")]
            public bool BossEnabled { get; set; }

            [JsonProperty("scavWars")]
            public bool ScavWars { get; set; }

            [JsonProperty("taggedAndCursed")]
            public bool TaggedAndCursed { get; set; }
        }
        public class Hideout
        {
            [JsonProperty("productionTimeDivide_Areas")]
            public int ProductionTimeDivideAreas { get; set; }

            [JsonProperty("hideoutConstructionUpgradeFixedTime")]
            public int HideoutConstructionUpgradeFixedTime { get; set; }

            [JsonProperty("productionTimeDivide_ScavCase")]
            public int ProductionTimeDivideScavCase { get; set; }

            [JsonProperty("productionTimeDivide_Bitcoin")]
            public int ProductionTimeDivideBitcoin { get; set; }

            [JsonProperty("productionTimeDivide_Production")]
            public int ProductionTimeDivideProduction { get; set; }
        }
        public class Trading
        {
            [JsonProperty("fleaMarket")]
            public FleaMarket FleaMarket { get; set; }

            [JsonProperty("repairMultiplier")]
            public int RepairMultiplier { get; set; }

            [JsonProperty("insureMultiplier")]
            public double InsureMultiplier { get; set; }

            [JsonProperty("insurerMultiplier")]
            public InsurerMultiplier InsurerMultiplier { get; set; }

            [JsonProperty("insureReturnChance")]
            public int InsureReturnChance { get; set; }

            [JsonProperty("fenceAssortSize")]
            public int FenceAssortSize { get; set; }

            [JsonProperty("buyItemsMarkedFound")]
            public bool BuyItemsMarkedFound { get; set; }

            [JsonProperty("traderSupply")]
            public TraderSupply TraderSupply { get; set; }
        }
        public class FleaMarket
        {
            [JsonProperty("ragfairMultiplierDesc")]
            public string RagfairMultiplierDesc { get; set; }

            [JsonProperty("ragfairMultiplier")]
            public double RagfairMultiplier { get; set; }

            [JsonProperty("minItemsInOffer")]
            public int MinItemsInOffer { get; set; }

            [JsonProperty("maxItemsInOffer")]
            public int MaxItemsInOffer { get; set; }

            [JsonProperty("filtersByRarityDesc")]
            public string FiltersByRarityDesc { get; set; }

            [JsonProperty("filtersByRarity")]
            public bool FiltersByRarity { get; set; }

            [JsonProperty("UseFleaMarketTradingBlacklist")]
            public bool UseFleaMarketTradingBlacklist { get; set; }

            [JsonProperty("UseFleaMarketLevelLock")]
            public bool UseFleaMarketLevelLock { get; set; }
        }
        public class InsurerMultiplier
        {
            [JsonProperty("5a7c2eca46aef81a7ca2145d")]
            public _5a7c2eca46aef81a7ca2145d _5a7c2eca46aef81a7ca2145d { get; set; }
        }
        public class _5a7c2eca46aef81a7ca2145d
        {
            [JsonProperty("0")]
            public double _0 { get; set; }

            [JsonProperty("1")]
            public double _1 { get; set; }

            [JsonProperty("2")]
            public double _2 { get; set; }

            [JsonProperty("3")]
            public double _3 { get; set; }
        }
        public class TraderSupply
        {
            [JsonProperty("5a7c2eca46aef81a7ca2145d")]
            public int _5a7c2eca46aef81a7ca2145d { get; set; }

            [JsonProperty("5ac3b934156ae10c4430e83c")]
            public int _5ac3b934156ae10c4430e83c { get; set; }

            [JsonProperty("5c0647fdd443bc2504c2d371")]
            public int _5c0647fdd443bc2504c2d371 { get; set; }

            [JsonProperty("54cb50c76803fa8b248b4571")]
            public int _54cb50c76803fa8b248b4571 { get; set; }

            [JsonProperty("54cb57776803fa99248b456e")]
            public int _54cb57776803fa99248b456e { get; set; }

            [JsonProperty("579dc571d53a0658a154fbec")]
            public int _579dc571d53a0658a154fbec { get; set; }

            [JsonProperty("5935c25fb3acc3127c3d8cd9")]
            public int _5935c25fb3acc3127c3d8cd9 { get; set; }

            [JsonProperty("58330581ace78e27b8b10cee")]
            public int _58330581ace78e27b8b10cee { get; set; }
        }
        public class Location
        {
            [JsonProperty("realTimeEnabled")]
            public bool RealTimeEnabled { get; set; }

            [JsonProperty("forceWeatherEnabled")]
            public bool ForceWeatherEnabled { get; set; }

            [JsonProperty("forceWeatherId")]
            public bool ForceWeatherId { get; set; }
        }
        public class Locationloot
        {
            [JsonProperty("containers")]
            public Containers Containers { get; set; }

            [JsonProperty("RarityMultipliers")]
            public RarityMultipliers RarityMultipliers { get; set; }

            [JsonProperty("noDuplicatesTill")]
            public int NoDuplicatesTill { get; set; }

            [JsonProperty("useDynamicLootFromItemsArray")]
            public bool UseDynamicLootFromItemsArray { get; set; }

            [JsonProperty("useDynamicLootMultiplier")]
            public bool UseDynamicLootMultiplier { get; set; }

            [JsonProperty("DynamicLooseLootMultiplier")]
            public double DynamicLooseLootMultiplier { get; set; }
        }
        public class Containers
        {
            [JsonProperty("ChanceForEmpty")]
            public int ChanceForEmpty { get; set; }

            [JsonProperty("ChanceToSpawnNextItem")]
            public int ChanceToSpawnNextItem { get; set; }

            [JsonProperty("AttemptsToPlaceLoot")]
            public int AttemptsToPlaceLoot { get; set; }
        }
        public class RarityMultipliers
        {
            [JsonProperty("Not_exist")]
            public int NotExist { get; set; }

            [JsonProperty("Common")]
            public double Common { get; set; }

            [JsonProperty("Uncommon")]
            public double Uncommon { get; set; }

            [JsonProperty("Rare")]
            public double Rare { get; set; }

            [JsonProperty("Superrare")]
            public double Superrare { get; set; }
        }
        public class Match
        {
            [JsonProperty("enabled")]
            public bool Enabled { get; set; }
        }
        public class Weapons
        {
            [JsonProperty("cameraRecoilDesc")]
            public string CameraRecoilDesc { get; set; }

            [JsonProperty("cameraRecoil")]
            public int CameraRecoil { get; set; }

            [JsonProperty("verticalRecoilDesc")]
            public string VerticalRecoilDesc { get; set; }

            [JsonProperty("verticalRecoil")]
            public int VerticalRecoil { get; set; }

            [JsonProperty("horizontalRecoilDesc")]
            public string HorizontalRecoilDesc { get; set; }

            [JsonProperty("horizontalRecoil")]
            public int HorizontalRecoil { get; set; }
        }
    }
}
