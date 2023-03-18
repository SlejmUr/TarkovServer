using EFT;
using EFT.InventoryLogic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ServerLib.Json
{
    public class Character
    {
        public static string Serialize(Base @base)
        {
            JsonSerializerSettings js = new()
            {
                Converters =
                {
                    new StringEnumConverter()
                }
            };
            return JsonConvert.SerializeObject(@base, js);
        }


        public class Base
        {
            [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty("aid", NullValueHandling = NullValueHandling.Ignore)]
            public string Aid { get; set; }

            [JsonProperty("savage", NullValueHandling = NullValueHandling.Ignore)]
            public string Savage { get; set; }

            [JsonProperty("Info", NullValueHandling = NullValueHandling.Ignore)]
            public Info Info { get; set; }

            [JsonProperty("Customization", NullValueHandling = NullValueHandling.Ignore)]
            public Customization Customization { get; set; }

            [JsonProperty("Health", NullValueHandling = NullValueHandling.Ignore)]
            public Health Health { get; set; }

            [JsonProperty("Inventory", NullValueHandling = NullValueHandling.Ignore)]
            public Inventory Inventory { get; set; }

            [JsonProperty("Skills", NullValueHandling = NullValueHandling.Ignore)]
            public Skills Skills { get; set; }

            [JsonProperty("Stats", NullValueHandling = NullValueHandling.Ignore)]
            public Stats Stats { get; set; }

            [JsonProperty("Encyclopedia", NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, bool> Encyclopedia { get; set; }

            [JsonProperty("ConditionCounters", NullValueHandling = NullValueHandling.Ignore)]
            public ConditionCounters ConditionCounters { get; set; }

            [JsonProperty("BackendCounters", NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, BackendCounter> BackendCounters { get; set; }

            [JsonProperty("InsuredItems", NullValueHandling = NullValueHandling.Ignore)]
            public List<InsuredItemClass> InsuredItems { get; set; }

            [JsonProperty("Hideout", NullValueHandling = NullValueHandling.Ignore)]
            public Hideout Hideout { get; set; }

            [JsonProperty("Bonuses", NullValueHandling = NullValueHandling.Ignore)]
            public List<Bonuse> Bonuses { get; set; }

            [JsonProperty("Notes", NullValueHandling = NullValueHandling.Ignore)]
            public _Notes Notes { get; set; }

            [JsonProperty("Quests", NullValueHandling = NullValueHandling.Ignore)]
            public List<object> Quests { get; set; }

            [JsonProperty("TradersInfo", NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, TradersInfo> TradersInfo { get; set; }

            [JsonProperty("RagfairInfo", NullValueHandling = NullValueHandling.Ignore)]
            public RagfairInfo RagfairInfo { get; set; }

            [JsonProperty("WishList", NullValueHandling = NullValueHandling.Ignore)]
            public List<object> WishList { get; set; }

            [JsonProperty("SurvivorClass", NullValueHandling = NullValueHandling.Ignore)]
            public string SurvivorClass { get; set; }
        }

        public class Info
        {
            [JsonProperty("Nickname", NullValueHandling = NullValueHandling.Ignore)]
            public string Nickname { get; set; }

            [JsonProperty("LowerNickname", NullValueHandling = NullValueHandling.Ignore)]
            public string LowerNickname { get; set; }

            [JsonProperty("Side", NullValueHandling = NullValueHandling.Ignore)]
            public EPlayerSide Side { get; set; }

            [JsonProperty("Voice", NullValueHandling = NullValueHandling.Ignore)]
            public string Voice { get; set; }

            [JsonProperty("Level", NullValueHandling = NullValueHandling.Ignore)]
            public int Level { get; set; }

            [JsonProperty("Experience", NullValueHandling = NullValueHandling.Ignore)]
            public int Experience { get; set; }

            [JsonProperty("RegistrationDate", NullValueHandling = NullValueHandling.Ignore)]
            public int RegistrationDate { get; set; }

            [JsonProperty("GameVersion", NullValueHandling = NullValueHandling.Ignore)]
            public string GameVersion { get; set; }

            [JsonProperty("AccountType", NullValueHandling = NullValueHandling.Ignore)]
            public int AccountType { get; set; }

            [JsonProperty("MemberCategory", NullValueHandling = NullValueHandling.Ignore)]
            public EMemberCategory MemberCategory { get; set; }

            [JsonProperty("lockedMoveCommands", NullValueHandling = NullValueHandling.Ignore)]
            public bool LockedMoveCommands { get; set; }

            [JsonProperty("SavageLockTime", NullValueHandling = NullValueHandling.Ignore)]
            public double SavageLockTime { get; set; }

            [JsonProperty("LastTimePlayedAsSavage", NullValueHandling = NullValueHandling.Ignore)]
            public int LastTimePlayedAsSavage { get; set; }

            [JsonProperty("Settings", NullValueHandling = NullValueHandling.Ignore)]
            public VictimSettings Settings { get; set; } = new();

            [JsonProperty("NicknameChangeDate", NullValueHandling = NullValueHandling.Ignore)]
            public long NicknameChangeDate { get; set; }

            [JsonProperty("BannedState", NullValueHandling = NullValueHandling.Ignore)]
            public bool BannedState { get; set; }

            [JsonProperty("BannedUntil", NullValueHandling = NullValueHandling.Ignore)]
            public int BannedUntil { get; set; }

            [JsonProperty("IsStreamerModeAvailable", NullValueHandling = NullValueHandling.Ignore)]
            public bool IsStreamerModeAvailable { get; set; }

            [JsonProperty("Bans", NullValueHandling = NullValueHandling.Ignore)]
            public List<object> Bans { get; set; }
        }

        public class Health
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public ValueInfo Hydration { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public ValueInfo Energy { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public ValueInfo Temperature { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public ValueInfo Poison { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<EBodyPart, BodyPart> BodyParts { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int UpdateTime { get; set; }
        }

        public class ValueInfo
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public float Current { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public float Minimum { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public float Maximum { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public float OverDamageReceivedMultiplier { get; set; }
        }

        public class BodyPart
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public ValueInfo Health { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, Effect> Effects { get; set; }
        }

        public class Effect
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float Time { get; set; }

            [JsonProperty(TypeNameHandling = TypeNameHandling.All)]
            public object ExtraData { get; set; }
        }

        public class Inventory
        {
            [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
            public List<Item> Items { get; set; }

            [JsonProperty("equipment", NullValueHandling = NullValueHandling.Ignore)]
            public string Equipment { get; set; }

            [JsonProperty("stash", NullValueHandling = NullValueHandling.Ignore)]
            public string Stash { get; set; }

            [JsonProperty("sortingTable", NullValueHandling = NullValueHandling.Ignore)]
            public string SortingTable { get; set; }

            [JsonProperty("questRaidItems", NullValueHandling = NullValueHandling.Ignore)]
            public string QuestRaidItems { get; set; }

            [JsonProperty("questStashItems", NullValueHandling = NullValueHandling.Ignore)]
            public string QuestStashItems { get; set; }

            [JsonProperty("fastPanel", NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<EBoundItem, string> FastPanel { get; set; }
        }

        public class Item
        {
            [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty("_tpl", NullValueHandling = NullValueHandling.Ignore)]
            public string Tpl { get; set; }

            [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
            public string ParentId { get; set; }

            [JsonProperty("slotId", NullValueHandling = NullValueHandling.Ignore)]
            public string SlotId { get; set; }

            [JsonProperty("children", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public List<Item> Children { get; set; }

            [JsonProperty("location", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public Location Location { get; set; }

            [JsonProperty("upd", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public Upd Upd { get; set; }
        }

        public class Location
        {
            [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
            public int X { get; set; }

            [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
            public int Y { get; set; }

            [JsonProperty("r", NullValueHandling = NullValueHandling.Ignore)]
            public int R { get; set; }

            [JsonProperty("isSearched", NullValueHandling = NullValueHandling.Ignore)]
            public bool IsSearched { get; set; }
        }

        public class Upd
        {
            [JsonProperty("Repairable", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public Repairable Repairable { get; set; }

            [JsonProperty("Foldable", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public Foldable Foldable { get; set; }

            [JsonProperty("FireMode", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public _FireMode FireMode { get; set; }

            [JsonProperty("Sight", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public Sight Sight { get; set; }

            [JsonProperty("StackObjectsCount", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public int? StackObjectsCount { get; set; }

            [JsonProperty("BuyRestrictionMax", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public long BuyRestrictionMax { get; set; }

            [JsonProperty("BuyRestrictionCurrent", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public long BuyRestrictionCurrent { get; set; }

            [JsonProperty("UnlimitedCount", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public bool UnlimitedCount { get; set; } = false;

            [JsonProperty("SpawnedInSession", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public bool SpawnedInSession { get; set; }

            [JsonProperty("MedKit", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public MedKit MedKit { get; set; }

            [JsonProperty("FoodDrink", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public FoodDrink FoodDrink { get; set; }

            [JsonProperty("Resource", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public Resource Resource { get; set; }

            [JsonProperty("RepairKit", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public RepairKit RepairKit { get; set; }

            [JsonProperty("Light", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public Light Light { get; set; }
        }

        public class Skills
        {
            [JsonProperty("Common", NullValueHandling = NullValueHandling.Ignore)]
            public List<Common> Common { get; set; }

            [JsonProperty("Mastering", NullValueHandling = NullValueHandling.Ignore)]
            public List<object> Mastering { get; set; }

            [JsonProperty("Points", NullValueHandling = NullValueHandling.Ignore)]
            public int Points { get; set; }
        }

        public class Common
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public ESkillId Id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float Progress { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float PointsEarnedDuringSession { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int LastAccess { get; set; }
        }

        public class Stats
        {
            [JsonProperty("SessionCounters", NullValueHandling = NullValueHandling.Ignore)]
            public SessionCounters SessionCounters { get; set; }

            [JsonProperty("OverallCounters", NullValueHandling = NullValueHandling.Ignore)]
            public OverallCounters OverallCounters { get; set; }

            [JsonProperty("SessionExperienceMult", NullValueHandling = NullValueHandling.Ignore)]
            public int SessionExperienceMult { get; set; }

            [JsonProperty("ExperienceBonusMult", NullValueHandling = NullValueHandling.Ignore)]
            public int ExperienceBonusMult { get; set; }

            [JsonProperty("TotalSessionExperience", NullValueHandling = NullValueHandling.Ignore)]
            public int TotalSessionExperience { get; set; }

            [JsonProperty("LastSessionDate", NullValueHandling = NullValueHandling.Ignore)]
            public int LastSessionDate { get; set; }

            [JsonProperty("Aggressor", NullValueHandling = NullValueHandling.Ignore)]
            public Aggressor Aggressor { get; set; }

            [JsonProperty("DroppedItems", NullValueHandling = NullValueHandling.Ignore)]
            public List<DroppedItem> DroppedItems { get; set; }

            [JsonProperty("FoundInRaidItems", NullValueHandling = NullValueHandling.Ignore)]
            public List<FoundInRaidItem> FoundInRaidItems { get; set; }

            [JsonProperty("Victims", NullValueHandling = NullValueHandling.Ignore)]
            public List<VictimStats> Victims { get; set; }

            [JsonProperty("CarriedQuestItems", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> CarriedQuestItems { get; set; }

            [JsonProperty("DamageHistory", NullValueHandling = NullValueHandling.Ignore)]
            public DamageHistory DamageHistory { get; set; }

            [JsonProperty("DeathCause", NullValueHandling = NullValueHandling.Ignore)]
            public DeathCause DeathCause { get; set; }

            [JsonProperty("LastPlayerState", NullValueHandling = NullValueHandling.Ignore)]
            public PlayerVisualRepresentation LastPlayerState { get; set; }

            [JsonProperty("TotalInGameTime", NullValueHandling = NullValueHandling.Ignore)]
            public long TotalInGameTime { get; set; }

            [JsonProperty("SurvivorClass", NullValueHandling = NullValueHandling.Ignore)]
            public string SurvivorClass { get; set; }
        }

        public class SessionCounters
        {
            [JsonProperty("Items", NullValueHandling = NullValueHandling.Ignore)]
            public List<object> Items { get; set; }
        }

        public class OverallCounters
        {
            [JsonProperty("Items", NullValueHandling = NullValueHandling.Ignore)]
            public List<object> Items { get; set; }
        }

        public class Aggressor
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string AccountId { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string ProfileId { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string MainProfileNickname { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public EPlayerSide Side { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public EBodyPart BodyPart { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public EHeadSegment? HeadSegment { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string WeaponName { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public EMemberCategory Category { get; set; }
        }

        public class ConditionCounters
        {
            [JsonProperty("Counters", NullValueHandling = NullValueHandling.Ignore)]
            public List<object> Counters { get; set; }
        }

        public class Hideout
        {
            [JsonProperty("Production", NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, Production> Production { get; set; }

            [JsonProperty("Areas", NullValueHandling = NullValueHandling.Ignore)]
            public List<Area> Areas { get; set; }

            [JsonProperty("Improvements", NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, Improvements> Improvements { get; set; }
        }

        public class Production
        {
            [JsonProperty("Progress")]
            public float Progress { get; set; }

            [JsonProperty("StartTimestamp", NullValueHandling = NullValueHandling.Ignore)]
            public int StartTimestamp { get; set; }

            [JsonProperty("ProductionTime")]
            public int ProductionTime { get; set; }

            [JsonProperty("inProgress")]
            public bool InProgress { get; set; }

            [JsonProperty("RecipeId")]
            public string RecipeId { get; set; }

            [JsonProperty("Products", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public List<Item> Products { get; set; }

            [JsonProperty("Interrupted")]
            public bool Interrupted { get; set; }
        }

        public class Area
        {
            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public int Type { get; set; }

            [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
            public int Level { get; set; }

            [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
            public bool Active { get; set; }

            [JsonProperty("passiveBonusesEnabled", NullValueHandling = NullValueHandling.Ignore)]
            public bool PassiveBonusesEnabled { get; set; }

            [JsonProperty("completeTime", NullValueHandling = NullValueHandling.Ignore)]
            public int CompleteTime { get; set; }

            [JsonProperty("constructing", NullValueHandling = NullValueHandling.Ignore)]
            public bool Constructing { get; set; }

            [JsonProperty("slots", NullValueHandling = NullValueHandling.Ignore)]
            public List<object> Slots { get; set; }

            [JsonProperty("lastRecipe", NullValueHandling = NullValueHandling.Ignore)]
            public string LastRecipe { get; set; }
        }

        public class Improvements
        {
            [JsonProperty("completed", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public bool Completed { get; set; }

            [JsonProperty("improveCompleteTimestamp", NullValueHandling = NullValueHandling.Ignore)]
            public int CompleteTimestamp { get; set; }
        }

        public class Bonuse
        {
            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string Type { get; set; }

            [JsonProperty("templateId", NullValueHandling = NullValueHandling.Ignore)]
            public string TemplateId { get; set; }
        }

        public class _Notes
        {
            [JsonProperty("Notes", NullValueHandling = NullValueHandling.Ignore)]
            public List<object> Notes { get; set; }
        }

        public class TradersInfo
        {
            [JsonProperty("loyaltyLevel", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public int LoyaltyLevel { get; set; }

            [JsonProperty("salesSum", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public long SalesSum { get; set; }

            [JsonProperty("standing", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public double Standing { get; set; }

            [JsonProperty("nextResupply", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public int NextResupply { get; set; }

            [JsonProperty("disabled", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public bool Disabled { get; set; }

            [JsonProperty("unlocked", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public bool Unlocked { get; set; }
        }

        public class RagfairInfo
        {
            [JsonProperty("rating", NullValueHandling = NullValueHandling.Ignore)]
            public double Rating { get; set; }

            [JsonProperty("isRatingGrowing", NullValueHandling = NullValueHandling.Ignore)]
            public bool IsRatingGrowing { get; set; }

            [JsonProperty("offers", NullValueHandling = NullValueHandling.Ignore)]
            public List<object> Offers { get; set; }
        }

        public class Repairable
        {
            [JsonProperty("MaxDurability", NullValueHandling = NullValueHandling.Ignore)]
            public int MaxDurability { get; set; }

            [JsonProperty("Durability", NullValueHandling = NullValueHandling.Ignore)]
            public int Durability { get; set; }
        }

        public class Foldable
        {
            [JsonProperty("Folded", NullValueHandling = NullValueHandling.Ignore)]
            public bool Folded { get; set; }
        }

        public class _FireMode
        {
            [JsonProperty("FireMode", NullValueHandling = NullValueHandling.Ignore)]
            public string FireMode { get; set; }
        }

        public class Sight
        {
            [JsonProperty("ScopesCurrentCalibPointIndexes", NullValueHandling = NullValueHandling.Ignore)]
            public List<int> ScopesCurrentCalibPointIndexes { get; set; }

            [JsonProperty("ScopesSelectedModes", NullValueHandling = NullValueHandling.Ignore)]
            public List<int> ScopesSelectedModes { get; set; }

            [JsonProperty("SelectedScope", NullValueHandling = NullValueHandling.Ignore)]
            public int SelectedScope { get; set; }
        }

        public class MedKit
        {
            [JsonProperty("HpResource", NullValueHandling = NullValueHandling.Ignore)]
            public int HpResource { get; set; }
        }

        public class FoodDrink
        {
            [JsonProperty("HpPercent", NullValueHandling = NullValueHandling.Ignore)]
            public int HpPercent { get; set; }
        }

        public class Resource
        {
            [JsonProperty("Value", NullValueHandling = NullValueHandling.Ignore)]
            public int Value { get; set; }
        }

        public class RepairKit
        {
            [JsonProperty("Resource", NullValueHandling = NullValueHandling.Ignore)]
            public int Resource { get; set; }
        }

        public class Light
        {
            [JsonProperty("IsActive", NullValueHandling = NullValueHandling.Ignore)]
            public bool IsActive { get; set; }

            [JsonProperty("SelectedMode", NullValueHandling = NullValueHandling.Ignore)]
            public int SelectedMode { get; set; }
        }
    }
}
