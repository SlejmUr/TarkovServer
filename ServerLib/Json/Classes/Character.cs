using EFT.Quests;
using Newtonsoft.Json;
using ServerLib.Json.Enums;

namespace ServerLib.Json.Classes
{
    public class Character
    {
        public class Base
        {

            [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty("aid", NullValueHandling = NullValueHandling.Ignore)]
            public string Aid { get; set; }

            [JsonProperty("savage", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public string Savage { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Info Info { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Customization Customization { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Health Health { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Inventory Inventory { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Skills Skills { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Stats Stats { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, bool> Encyclopedia { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public ConditionCounters ConditionCounters { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, BackendCounter> BackendCounters { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<InsuredItem> InsuredItems { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Hideout Hideout { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<Quest> Quests { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, TraderInfo> TradersInfo { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public UnlockedInfo UnlockedInfo { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public RagfairInfo RagfairInfo { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<RepeatableQuests.CharacterRepeatableQuest> RepeatableQuests { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<Bonus> Bonuses { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public _Notes Notes { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string SurvivorClass { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<string> WishList { get; set; }

        }

        public class UnlockedInfo
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<string> unlockedProductionRecipe { get; set; }

        }
        public class Info
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string EntryPoint { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Nickname { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string LowerNickname { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Side { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Voice { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int Level { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int Experience { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int RegistrationDate { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string GameVersion { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int AccountType { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public EMemberCategory MemberCategory { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool lockedMoveCommands { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public double SavageLockTime { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int LastTimePlayedAsSavage { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Settings Settings { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int NicknameChangeDate { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<object> NeedWipeOptions { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<Ban> Bans { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool BannedState { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int BannedUntil { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool IsStreamerModeAvailable { get; set; }

        }
        public class Settings
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Role { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string BotDifficulty { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int Experience { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public double StandingForKill { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public double AggressorBonus { get; set; }

        }
        public class Ban
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public EBan type { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int dateTime { get; set; }

        }

        public class Customization
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Head { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Body { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Feet { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Hands { get; set; }

        }
        public class Health
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public CurrentMax Hydration { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public CurrentMax Energy { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public CurrentMax Temperature { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public BodyPartsHealth BodyParts { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int UpdateTime { get; set; }

        }
        public class BodyPartsHealth
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public BodyPartHealth Head { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public BodyPartHealth Chest { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public BodyPartHealth Stomach { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public BodyPartHealth LeftArm { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public BodyPartHealth RightArm { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public BodyPartHealth LeftLeg { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public BodyPartHealth RightLeg { get; set; }

        }
        public class BodyPartHealth
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public CurrentMax Health { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, BodyPartEffectProperties> Effects { get; set; }

        }
        public class BodyPartEffectProperties

        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int Time { get; set; }

        }
        public class CurrentMax
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public double Current { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public double Maximum { get; set; }

        }
        public class Inventory
        {
            [JsonProperty("items",  NullValueHandling = NullValueHandling.Ignore)]
            public List<Item.Base> Items { get; set; }

            [JsonProperty("equipment",  NullValueHandling = NullValueHandling.Ignore)]
            public string Equipment { get; set; }

            [JsonProperty("stash",  NullValueHandling = NullValueHandling.Ignore)]
            public string Stash { get; set; }

            [JsonProperty("sortingTable",  NullValueHandling = NullValueHandling.Ignore)]
            public string SortingTable { get; set; }

            [JsonProperty("questRaidItems",  NullValueHandling = NullValueHandling.Ignore)]
            public string QuestRaidItems { get; set; }

            [JsonProperty("questStashItems",  NullValueHandling = NullValueHandling.Ignore)]
            public string QuestStashItems { get; set; }

            [JsonProperty("fastPanel",  NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, string> FastPanel { get; set; }

        }
        public class Skills
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<BaseSkill> Common { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<BaseSkill> Mastering { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int Points { get; set; }
        }

        public class DictSkills
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, BaseSkill> Common { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, BaseSkill> Mastering { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int Points { get; set; }
        }

        public class BaseSkill
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public double Progress { get; set; }

            //Common START
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public double PointsEarnedDuringSession { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int LastAccess { get; set; }
            //Common END
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public double max { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public double min { get; set; }

        }

        public class Stats
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<string> CarriedQuestItems { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<Victim> Victims { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int TotalSessionExperience { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int LastSessionDate { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public SessionCounters SessionCounters { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public OverallCounters OverallCounters { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int SessionExperienceMult { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int ExperienceBonusMult { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Aggressor Aggressor { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<DroppedItem> DroppedItems { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<FoundInRaidItem> FoundInRaidItems { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public DamageHistory DamageHistory { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public DeathCause DeathCause { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public LastPlayerState LastPlayerState { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int TotalInGameTime { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string SurvivorClass { get; set; }

        }
        public class DroppedItem

        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string QuestId { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string ItemId { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string ZoneId { get; set; }

        }
        public class FoundInRaidItem

        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string QuestId { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string ItemId { get; set; }

        }
        public class Victim
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string AccountId { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string ProfileId { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Side { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string BodyPart { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Time { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int Distance { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int Level { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Weapon { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Role { get; set; }

        }
        public class SessionCounters
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<CounterKeyValue> Items { get; set; }

        }
        public class OverallCounters
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<CounterKeyValue> Items { get; set; }

        }
        public class CounterKeyValue
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Key { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int Value { get; set; }

        }
        public class ConditionCounters
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<Counter> Counters { get; set; }

        }
        public class Counter
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int value { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string qid { get; set; }

        }
        public class Aggressor
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string AccountId { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string ProfileId { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string MainProfileNickname { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Side { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string BodyPart { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string HeadSegment { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string WeaponName { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Category { get; set; }

        }
        public class DamageHistory
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string LethalDamagePart { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public LethalDamage LethalDamage { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public BodyPartsDamageHistory BodyParts { get; set; }

        }
        public class LethalDamage
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int Amount { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Type { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string SourceId { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string OverDamageFrom { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool Blunt { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int ImpactsCount { get; set; }

        }
        public class BodyPartsDamageHistory
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<DamageStats> Head { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<DamageStats> Chest { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<DamageStats> Stomach { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<DamageStats> LeftArm { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<DamageStats> RightArm { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<DamageStats> LeftLeg { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<DamageStats> RightLeg { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<DamageStats> Common { get; set; }

        }
        public class DamageStats
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int Amount { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Type { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string SourceId { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string OverDamageFrom { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool Blunt { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int ImpactsCount { get; set; }

        }
        public class DeathCause
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string DamageType { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Side { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Role { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string WeaponId { get; set; }

        }
        public class LastPlayerState

        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public LastPlayerStateInfo Info { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, string> Customization { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public object Equipment { get; set; }

        }
        public class LastPlayerStateInfo

        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Nickname { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Side { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int Level { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string MemberCategory { get; set; }

        }
        public class BackendCounter
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string qid { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int value { get; set; }

        }
        public class InsuredItem
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string tid { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string itemId { get; set; }

        }
        public class Hideout
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, Productive> Production { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<HideoutArea> Areas { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, HideoutImprovement> Improvements { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int sptUpdateLastRunTimestamp { get; set; }

        }
        public class HideoutImprovement

        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool completed { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int improveCompleteTimestamp { get; set; }

        }

        public class Productive
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string RecipeId { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<Product> Products { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int Progress { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool inProgress { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int StartTimestamp { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int SkipTime { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int ProductionTime { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool sptIsScavCase { get; set; }

        }

        public class Product
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string _id { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string _tpl { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Item._Upd upd { get; set; }

        }
        public class HideoutArea
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public EHideoutAreas type { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int level { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool active { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool passiveBonusesEnabled { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int completeTime { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool constructing { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<HideoutSlot> slots { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string lastRecipe { get; set; }

        }
        public class HideoutSlot
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int locationIndex { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<HideoutItem> item { get; set; }

        }
        public class HideoutItem
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string _id { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string _tpl { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Item._Upd upd { get; set; }

        }

        public class _Notes
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<Note> Notes { get; set; }

        }

        public class Quest
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string qid { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int startTime { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public EQuestStatus status { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, int> statusTimers { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<string> completedConditions { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int availableAfter { get; set; }

        }
        public class TraderInfo
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int loyaltyLevel { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int salesSum { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool disabled { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public double standing { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int nextResupply { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool unlocked { get; set; }

        }
        public class RagfairInfo
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public double rating { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool isRatingGrowing { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<RagfairOffer.Base> offers { get; set; }

        }
        public class Bonus
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string type { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string templateId { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool passive { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool production { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public bool visible { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int value { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string icon { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public List<string> filter { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string skillType { get; set; }

        }
        public class Note
        {
            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public int Time { get; set; }

            [JsonProperty( NullValueHandling = NullValueHandling.Ignore)]
            public string Text { get; set; }

        }
    }
}
