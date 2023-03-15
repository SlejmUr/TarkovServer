using Newtonsoft.Json;

namespace ServerLib.Json
{
    public class GameplayConfig
    {
        #region Config
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class AirdropChancePercent
        {
            [JsonProperty("bigmap", NullValueHandling = NullValueHandling.Ignore)]
            public int? Bigmap;

            [JsonProperty("woods", NullValueHandling = NullValueHandling.Ignore)]
            public int? Woods;

            [JsonProperty("lighthouse", NullValueHandling = NullValueHandling.Ignore)]
            public int? Lighthouse;

            [JsonProperty("shoreline", NullValueHandling = NullValueHandling.Ignore)]
            public int? Shoreline;

            [JsonProperty("interchange", NullValueHandling = NullValueHandling.Ignore)]
            public int? Interchange;

            [JsonProperty("reserve", NullValueHandling = NullValueHandling.Ignore)]
            public int? Reserve;

            [JsonProperty("tarkovStreets", NullValueHandling = NullValueHandling.Ignore)]
            public int? TarkovStreets;
        }

        public class AirdropSettings
        {
            [JsonProperty("airdropChancePercent", NullValueHandling = NullValueHandling.Ignore)]
            public AirdropChancePercent AirdropChancePercent;

            [JsonProperty("airdropMinStartTimeSeconds", NullValueHandling = NullValueHandling.Ignore)]
            public int? AirdropMinStartTimeSeconds;

            [JsonProperty("airdropMaxStartTimeSeconds", NullValueHandling = NullValueHandling.Ignore)]
            public int? AirdropMaxStartTimeSeconds;

            [JsonProperty("planeMinFlyHeight", NullValueHandling = NullValueHandling.Ignore)]
            public int? PlaneMinFlyHeight;

            [JsonProperty("planeMaxFlyHeight", NullValueHandling = NullValueHandling.Ignore)]
            public int? PlaneMaxFlyHeight;

            [JsonProperty("planeVolume", NullValueHandling = NullValueHandling.Ignore)]
            public double? PlaneVolume;

            [JsonProperty("planeSpeed", NullValueHandling = NullValueHandling.Ignore)]
            public int? PlaneSpeed;

            [JsonProperty("crateFallSpeed", NullValueHandling = NullValueHandling.Ignore)]
            public int? CrateFallSpeed;
        }

        public class AllExamined
        {
            [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Enabled;

            [JsonProperty("exceptTheseParents", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> ExceptTheseParents;
        }

        public class BodyPart
        {
            [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
            public string Key;

            [JsonProperty("relativeProbability", NullValueHandling = NullValueHandling.Ignore)]
            public double? RelativeProbability;

            [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Data;
        }

        public class Bot
        {
            [JsonProperty("backpackChance", NullValueHandling = NullValueHandling.Ignore)]
            public int? BackpackChance;

            [JsonProperty("headwearChance", NullValueHandling = NullValueHandling.Ignore)]
            public int? HeadwearChance;

            [JsonProperty("facecoverChance", NullValueHandling = NullValueHandling.Ignore)]
            public int? FacecoverChance;

            [JsonProperty("earpieceChance", NullValueHandling = NullValueHandling.Ignore)]
            public int? EarpieceChance;

            [JsonProperty("primaryWeaponChance", NullValueHandling = NullValueHandling.Ignore)]
            public int? PrimaryWeaponChance;

            [JsonProperty("secondaryWeaponChance", NullValueHandling = NullValueHandling.Ignore)]
            public int? SecondaryWeaponChance;

            [JsonProperty("holsterWeaponChance", NullValueHandling = NullValueHandling.Ignore)]
            public int? HolsterWeaponChance;
        }

        public class Bots
        {
            [JsonProperty("_preload", NullValueHandling = NullValueHandling.Ignore)]
            public string _Preload;

            [JsonProperty("preload", NullValueHandling = NullValueHandling.Ignore)]
            public Preload Preload;

            [JsonProperty("_randomAmmos", NullValueHandling = NullValueHandling.Ignore)]
            public string _RandomAmmos;

            [JsonProperty("randomAmmos", NullValueHandling = NullValueHandling.Ignore)]
            public RandomAmmos RandomAmmos;
        }

        public class Completion
        {
            [JsonProperty("minRequestedAmount", NullValueHandling = NullValueHandling.Ignore)]
            public int? MinRequestedAmount;

            [JsonProperty("maxRequestedAmount", NullValueHandling = NullValueHandling.Ignore)]
            public int? MaxRequestedAmount;

            [JsonProperty("minRequestedBulletAmount", NullValueHandling = NullValueHandling.Ignore)]
            public int? MinRequestedBulletAmount;

            [JsonProperty("maxRequestedBulletAmount", NullValueHandling = NullValueHandling.Ignore)]
            public int? MaxRequestedBulletAmount;

            [JsonProperty("useWhitelist", NullValueHandling = NullValueHandling.Ignore)]
            public bool? UseWhitelist;

            [JsonProperty("useBlacklist", NullValueHandling = NullValueHandling.Ignore)]
            public bool? UseBlacklist;
        }

        public class Config
        {
            [JsonProperty("Exploration", NullValueHandling = NullValueHandling.Ignore)]
            public Exploration Exploration;

            [JsonProperty("Completion", NullValueHandling = NullValueHandling.Ignore)]
            public Completion Completion;

            [JsonProperty("Elimination", NullValueHandling = NullValueHandling.Ignore)]
            public Elimination Elimination;
        }

        public class Customization
        {
            [JsonProperty("allHeadsOnCharacterCreation", NullValueHandling = NullValueHandling.Ignore)]
            public bool? AllHeadsOnCharacterCreation;

            [JsonProperty("allVoicesOnCharacterCreation", NullValueHandling = NullValueHandling.Ignore)]
            public bool? AllVoicesOnCharacterCreation;

            [JsonProperty("allPocketsHaveSpecialSlots", NullValueHandling = NullValueHandling.Ignore)]
            public bool? AllPocketsHaveSpecialSlots;
        }

        public class Daily
        {
            [JsonProperty("requiredLevel", NullValueHandling = NullValueHandling.Ignore)]
            public int? RequiredLevel;

            [JsonProperty("maxQuests", NullValueHandling = NullValueHandling.Ignore)]
            public int? MaxQuests;

            [JsonProperty("resetTime", NullValueHandling = NullValueHandling.Ignore)]
            public int? ResetTime;

            [JsonProperty("config", NullValueHandling = NullValueHandling.Ignore)]
            public Config Config;
        }

        public class Data
        {
            [JsonProperty("isBoss", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsBoss;
        }

        public class DefaultRaidSettings
        {
            [JsonProperty("aiAmount", NullValueHandling = NullValueHandling.Ignore)]
            public string AiAmount;

            [JsonProperty("aiDifficulty", NullValueHandling = NullValueHandling.Ignore)]
            public string AiDifficulty;

            [JsonProperty("bossEnabled", NullValueHandling = NullValueHandling.Ignore)]
            public bool? BossEnabled;

            [JsonProperty("scavWars", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ScavWars;

            [JsonProperty("taggedAndCursed", NullValueHandling = NullValueHandling.Ignore)]
            public bool? TaggedAndCursed;
        }

        public class Development
        {
            [JsonProperty("_development", NullValueHandling = NullValueHandling.Ignore)]
            public string _Development;

            [JsonProperty("openWebLauncher", NullValueHandling = NullValueHandling.Ignore)]
            public bool? OpenWebLauncher;

            [JsonProperty("debugBots", NullValueHandling = NullValueHandling.Ignore)]
            public bool? DebugBots;

            [JsonProperty("devInsuranceTimers", NullValueHandling = NullValueHandling.Ignore)]
            public bool? DevInsuranceTimers;

            [JsonProperty("devInsuranceTimes", NullValueHandling = NullValueHandling.Ignore)]
            public DevInsuranceTimes DevInsuranceTimes;
        }

        public class DevInsuranceTimes
        {
            [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
            public double? Min;

            [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
            public double? Max;
        }

        public class Elimination
        {
            [JsonProperty("targets", NullValueHandling = NullValueHandling.Ignore)]
            public List<Target> Targets;

            [JsonProperty("bodyPartProb", NullValueHandling = NullValueHandling.Ignore)]
            public double? BodyPartProb;

            [JsonProperty("bodyParts", NullValueHandling = NullValueHandling.Ignore)]
            public List<BodyPart> BodyParts;

            [JsonProperty("specificLocationProb", NullValueHandling = NullValueHandling.Ignore)]
            public double? SpecificLocationProb;

            [JsonProperty("distLocationBlacklist", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> DistLocationBlacklist;

            [JsonProperty("distProb", NullValueHandling = NullValueHandling.Ignore)]
            public double? DistProb;

            [JsonProperty("maxDist", NullValueHandling = NullValueHandling.Ignore)]
            public int? MaxDist;

            [JsonProperty("minDist", NullValueHandling = NullValueHandling.Ignore)]
            public int? MinDist;

            [JsonProperty("maxKills", NullValueHandling = NullValueHandling.Ignore)]
            public int? MaxKills;

            [JsonProperty("minKills", NullValueHandling = NullValueHandling.Ignore)]
            public int? MinKills;
        }

        public class Event
        {
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name;

            [JsonProperty("startDay", NullValueHandling = NullValueHandling.Ignore)]
            public string StartDay;

            [JsonProperty("startMonth", NullValueHandling = NullValueHandling.Ignore)]
            public string StartMonth;

            [JsonProperty("endDay", NullValueHandling = NullValueHandling.Ignore)]
            public string EndDay;

            [JsonProperty("endMonth", NullValueHandling = NullValueHandling.Ignore)]
            public string EndMonth;
        }

        public class Exploration
        {
            [JsonProperty("maxExtracts", NullValueHandling = NullValueHandling.Ignore)]
            public int? MaxExtracts;

            [JsonProperty("specificExits", NullValueHandling = NullValueHandling.Ignore)]
            public SpecificExits SpecificExits;
        }

        public class Fence
        {
            [JsonProperty("killingScavsFenceLevelChange", NullValueHandling = NullValueHandling.Ignore)]
            public double? KillingScavsFenceLevelChange;

            [JsonProperty("killingPMCsFenceLevelChange", NullValueHandling = NullValueHandling.Ignore)]
            public double? KillingPMCsFenceLevelChange;

            [JsonProperty("fenceLevelAssortModifier", NullValueHandling = NullValueHandling.Ignore)]
            public double? FenceLevelAssortModifier;
        }

        public class Flea
        {
            [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Enabled;

            [JsonProperty("minUserLevel", NullValueHandling = NullValueHandling.Ignore)]
            public int? MinUserLevel;

            [JsonProperty("removeBlacklist", NullValueHandling = NullValueHandling.Ignore)]
            public bool? RemoveBlacklist;

            [JsonProperty("liveFleaPrices", NullValueHandling = NullValueHandling.Ignore)]
            public bool? LiveFleaPrices;
        }

        public class Hideout
        {
            [JsonProperty("fastScavcase", NullValueHandling = NullValueHandling.Ignore)]
            public bool? FastScavcase;

            [JsonProperty("fastProduction", NullValueHandling = NullValueHandling.Ignore)]
            public bool? FastProduction;

            [JsonProperty("wallUnlockInSeconds", NullValueHandling = NullValueHandling.Ignore)]
            public int? WallUnlockInSeconds;
        }

        public class InRaid
        {
            [JsonProperty("showDeathMessage", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ShowDeathMessage;

            [JsonProperty("createFriendlyAI", NullValueHandling = NullValueHandling.Ignore)]
            public bool? CreateFriendlyAI;
        }

        public class Items
        {
            [JsonProperty("quickExamine", NullValueHandling = NullValueHandling.Ignore)]
            public bool? QuickExamine;

            [JsonProperty("allExamined", NullValueHandling = NullValueHandling.Ignore)]
            public AllExamined AllExamined;

            [JsonProperty("stackSize", NullValueHandling = NullValueHandling.Ignore)]
            public StackSize StackSize;

            [JsonProperty("stimMaxUses", NullValueHandling = NullValueHandling.Ignore)]
            public int? StimMaxUses;

            [JsonProperty("noArmorRestrictions", NullValueHandling = NullValueHandling.Ignore)]
            public bool? NoArmorRestrictions;

            [JsonProperty("Weight", NullValueHandling = NullValueHandling.Ignore)]
            public Weight Weight;
        }

        public class Location
        {
            [JsonProperty("realTimeEnabled", NullValueHandling = NullValueHandling.Ignore)]
            public bool? RealTimeEnabled;

            [JsonProperty("forceWeatherEnabled", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ForceWeatherEnabled;

            [JsonProperty("forceWeatherId", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ForceWeatherId;

            [JsonProperty("changeRaidTime", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ChangeRaidTime;

            [JsonProperty("raidTimerMultiplier", NullValueHandling = NullValueHandling.Ignore)]
            public int? RaidTimerMultiplier;

            [JsonProperty("changeExfiltrationTime", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ChangeExfiltrationTime;

            [JsonProperty("exfiltrationTime", NullValueHandling = NullValueHandling.Ignore)]
            public int? ExfiltrationTime;
        }

        public class Locations
        {
            [JsonProperty("any", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Any;

            [JsonProperty("factory4_day", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Factory4Day;

            [JsonProperty("bigmap", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Bigmap;

            [JsonProperty("Woods", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Woods;

            [JsonProperty("Shoreline", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Shoreline;

            [JsonProperty("Interchange", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Interchange;

            [JsonProperty("Lighthouse", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Lighthouse;

            [JsonProperty("laboratory", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Laboratory;

            [JsonProperty("RezervBase", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> RezervBase;
        }

        public class Loot
        {
        }

        public class Match
        {
            [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Enabled;
        }

        public class Preload
        {
            [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Enabled;

            [JsonProperty("maxBossPreload", NullValueHandling = NullValueHandling.Ignore)]
            public int? MaxBossPreload;

            [JsonProperty("minBossPreload", NullValueHandling = NullValueHandling.Ignore)]
            public int? MinBossPreload;

            [JsonProperty("maxFollowerPreload", NullValueHandling = NullValueHandling.Ignore)]
            public int? MaxFollowerPreload;

            [JsonProperty("minFollowerPreload", NullValueHandling = NullValueHandling.Ignore)]
            public int? MinFollowerPreload;

            [JsonProperty("maxScavPreload", NullValueHandling = NullValueHandling.Ignore)]
            public int? MaxScavPreload;

            [JsonProperty("minScavPreload", NullValueHandling = NullValueHandling.Ignore)]
            public int? MinScavPreload;

            [JsonProperty("limiter", NullValueHandling = NullValueHandling.Ignore)]
            public int? Limiter;
        }

        public class Quests
        {
            [JsonProperty("repeatable", NullValueHandling = NullValueHandling.Ignore)]
            public Repeatable Repeatable;

            [JsonProperty("Elimination", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Elimination;

            [JsonProperty("Exploration", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Exploration;

            [JsonProperty("Completion", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Completion;
        }

        public class Ragman
        {
            [JsonProperty("sellAllDrip", NullValueHandling = NullValueHandling.Ignore)]
            public bool? SellAllDrip;
        }

        public class Raid
        {
            [JsonProperty("allowSelectEntryPoint", NullValueHandling = NullValueHandling.Ignore)]
            public bool? AllowSelectEntryPoint;

            [JsonProperty("maxBotsAliveOnMap", NullValueHandling = NullValueHandling.Ignore)]
            public int? MaxBotsAliveOnMap;

            [JsonProperty("waveCoef", NullValueHandling = NullValueHandling.Ignore)]
            public WaveCoef WaveCoef;

            [JsonProperty("timeBeforeDeploy", NullValueHandling = NullValueHandling.Ignore)]
            public int? TimeBeforeDeploy;

            [JsonProperty("inRaidModding", NullValueHandling = NullValueHandling.Ignore)]
            public bool? InRaidModding;

            [JsonProperty("insuranceEnabled", NullValueHandling = NullValueHandling.Ignore)]
            public bool? InsuranceEnabled;

            [JsonProperty("inRaid", NullValueHandling = NullValueHandling.Ignore)]
            public InRaid InRaid;

            [JsonProperty("defaultRaidSettings", NullValueHandling = NullValueHandling.Ignore)]
            public DefaultRaidSettings DefaultRaidSettings;

            [JsonProperty("airdropSettings", NullValueHandling = NullValueHandling.Ignore)]
            public AirdropSettings AirdropSettings;
        }

        public class RandomAmmos
        {
            [JsonProperty("looseEnabled", NullValueHandling = NullValueHandling.Ignore)]
            public bool? LooseEnabled;

            [JsonProperty("magazineEnabled", NullValueHandling = NullValueHandling.Ignore)]
            public string MagazineEnabled;

            [JsonProperty("chance", NullValueHandling = NullValueHandling.Ignore)]
            public int? Chance;

            [JsonProperty("maxTypes", NullValueHandling = NullValueHandling.Ignore)]
            public int? MaxTypes;
        }

        public class Repeatable
        {
            [JsonProperty("Daily", NullValueHandling = NullValueHandling.Ignore)]
            public Daily Daily;

            [JsonProperty("Weekly", NullValueHandling = NullValueHandling.Ignore)]
            public Weekly Weekly;

            [JsonProperty("locations", NullValueHandling = NullValueHandling.Ignore)]
            public Locations Locations;

            [JsonProperty("quests", NullValueHandling = NullValueHandling.Ignore)]
            public Quests Quests;

            [JsonProperty("rewardBaseTypeBlacklist", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> RewardBaseTypeBlacklist;

            [JsonProperty("rewardBlacklist", NullValueHandling = NullValueHandling.Ignore)]
            public List<object> RewardBlacklist;
        }

        public class Base
        {
            [JsonProperty("seasonalEvents", NullValueHandling = NullValueHandling.Ignore)]
            public SeasonalEvents SeasonalEvents;

            [JsonProperty("bots", NullValueHandling = NullValueHandling.Ignore)]
            public Bots Bots;

            [JsonProperty("development", NullValueHandling = NullValueHandling.Ignore)]
            public Development Development;

            [JsonProperty("bot", NullValueHandling = NullValueHandling.Ignore)]
            public Bot Bot;

            [JsonProperty("customization", NullValueHandling = NullValueHandling.Ignore)]
            public Customization Customization;

            [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
            public Items Items;

            [JsonProperty("raid", NullValueHandling = NullValueHandling.Ignore)]
            public Raid Raid;

            [JsonProperty("trading", NullValueHandling = NullValueHandling.Ignore)]
            public Trading Trading;

            [JsonProperty("hideout", NullValueHandling = NullValueHandling.Ignore)]
            public Hideout Hideout;

            [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
            public Location Location;

            [JsonProperty("quests", NullValueHandling = NullValueHandling.Ignore)]
            public Quests Quests;

            [JsonProperty("loot", NullValueHandling = NullValueHandling.Ignore)]
            public Loot Loot;

            [JsonProperty("match", NullValueHandling = NullValueHandling.Ignore)]
            public Match Match;

            [JsonProperty("weapons", NullValueHandling = NullValueHandling.Ignore)]
            public Weapons Weapons;
        }

        public class SeasonalEvents
        {
            [JsonProperty("enable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Enable;

            [JsonProperty("events", NullValueHandling = NullValueHandling.Ignore)]
            public List<Event> Events;
        }

        public class SpecificExits
        {
            [JsonProperty("probability", NullValueHandling = NullValueHandling.Ignore)]
            public double? Probability;

            [JsonProperty("passageRequirementWhitelist", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> PassageRequirementWhitelist;
        }

        public class StackSize
        {
            [JsonProperty("ammo", NullValueHandling = NullValueHandling.Ignore)]
            public int? Ammo;

            [JsonProperty("money", NullValueHandling = NullValueHandling.Ignore)]
            public int? Money;
        }

        public class Target
        {
            [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
            public object Key;

            [JsonProperty("relativeProbability", NullValueHandling = NullValueHandling.Ignore)]
            public double? RelativeProbability;

            [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
            public Data Data;
        }

        public class Trading
        {
            [JsonProperty("redeemTimeInHours", NullValueHandling = NullValueHandling.Ignore)]
            public int? RedeemTimeInHours;

            [JsonProperty("refreshTimeInMinutes", NullValueHandling = NullValueHandling.Ignore)]
            public int RefreshTimeInMinutes;

            [JsonProperty("tradePurchasedIsFoundInRaid", NullValueHandling = NullValueHandling.Ignore)]
            public bool? TradePurchasedIsFoundInRaid;

            [JsonProperty("fence", NullValueHandling = NullValueHandling.Ignore)]
            public Fence Fence;

            [JsonProperty("ragman", NullValueHandling = NullValueHandling.Ignore)]
            public Ragman Ragman;

            [JsonProperty("flea", NullValueHandling = NullValueHandling.Ignore)]
            public Flea Flea;
        }

        public class WaveCoef
        {
            [JsonProperty("low", NullValueHandling = NullValueHandling.Ignore)]
            public int? Low;

            [JsonProperty("mid", NullValueHandling = NullValueHandling.Ignore)]
            public double? Mid;

            [JsonProperty("high", NullValueHandling = NullValueHandling.Ignore)]
            public double? High;

            [JsonProperty("horde", NullValueHandling = NullValueHandling.Ignore)]
            public int? Horde;
        }

        public class Weapons
        {
        }

        public class Weekly
        {
            [JsonProperty("requiredLevel", NullValueHandling = NullValueHandling.Ignore)]
            public int? RequiredLevel;

            [JsonProperty("maxQuests", NullValueHandling = NullValueHandling.Ignore)]
            public int? MaxQuests;

            [JsonProperty("resetTime", NullValueHandling = NullValueHandling.Ignore)]
            public int? ResetTime;

            [JsonProperty("config", NullValueHandling = NullValueHandling.Ignore)]
            public Config Config;
        }

        public class Weight
        {
            [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Enabled;

            [JsonProperty("modifier", NullValueHandling = NullValueHandling.Ignore)]
            public double? Modifier;
        }


        #endregion
    }
}
