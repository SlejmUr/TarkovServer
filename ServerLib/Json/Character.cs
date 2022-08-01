using Newtonsoft.Json;

namespace ServerLib.Json
{
    internal class Character
    {
        public class Base
        {
            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("aid")]
            public string Aid { get; set; }

            [JsonProperty("savage")]
            public string Savage { get; set; }

            [JsonProperty("Info")]
            public Info Info { get; set; }

            [JsonProperty("Customization")]
            public Customization Customization { get; set; }

            [JsonProperty("Health")]
            public Health Health { get; set; }

            [JsonProperty("Inventory")]
            public Inventory Inventory { get; set; }

            [JsonProperty("Skills")]
            public Skills Skills { get; set; }

            [JsonProperty("Stats")]
            public Stats Stats { get; set; }

            [JsonProperty("Encyclopedia")]
            public Encyclopedia Encyclopedia { get; set; }

            [JsonProperty("ConditionCounters")]
            public ConditionCounters ConditionCounters { get; set; }

            [JsonProperty("BackendCounters")]
            public BackendCounters BackendCounters { get; set; }

            [JsonProperty("InsuredItems")]
            public List<object> InsuredItems { get; set; }

            [JsonProperty("Hideout")]
            public Hideout Hideout { get; set; }

            [JsonProperty("Bonuses")]
            public List<Bonuse> Bonuses { get; set; }

            [JsonProperty("Notes")]
            public NotesClass Notes { get; set; }

            [JsonProperty("Quests")]
            public List<Quest> Quests { get; set; }

            [JsonProperty("TradersInfo")]
            public TradersInfo TradersInfo { get; set; }

            [JsonProperty("RagfairInfo")]
            public RagfairInfo RagfairInfo { get; set; }

            [JsonProperty("WishList")]
            public List<object> WishList { get; set; }
        }
        public class Info
        {
            [JsonProperty("Nickname")]
            public string Nickname { get; set; }

            [JsonProperty("LowerNickname")]
            public string LowerNickname { get; set; }

            [JsonProperty("Side")]
            public string Side { get; set; }

            [JsonProperty("Voice")]
            public string Voice { get; set; }

            [JsonProperty("Level")]
            public int Level { get; set; }

            [JsonProperty("Experience")]
            public int Experience { get; set; }

            [JsonProperty("RegistrationDate")]
            public int RegistrationDate { get; set; }

            [JsonProperty("GameVersion")]
            public string GameVersion { get; set; }

            [JsonProperty("AccountType")]
            public int AccountType { get; set; }

            [JsonProperty("MemberCategory")]
            public int MemberCategory { get; set; }

            [JsonProperty("lockedMoveCommands")]
            public bool LockedMoveCommands { get; set; }

            [JsonProperty("SavageLockTime")]
            public int SavageLockTime { get; set; }

            [JsonProperty("LastTimePlayedAsSavage")]
            public int LastTimePlayedAsSavage { get; set; }

            [JsonProperty("Settings")]
            public Settings Settings { get; set; }

            [JsonProperty("NeedWipe")]
            public bool NeedWipe { get; set; }

            [JsonProperty("GlobalWipe")]
            public bool GlobalWipe { get; set; }

            [JsonProperty("NicknameChangeDate")]
            public int NicknameChangeDate { get; set; }

            [JsonProperty("Bans")]
            public List<object> Bans { get; set; }
        }
        public class Settings
        {
            [JsonProperty("Role")]
            public string Role { get; set; }

            [JsonProperty("BotDifficulty")]
            public string BotDifficulty { get; set; }

            [JsonProperty("Experience")]
            public int Experience { get; set; }
        }
        public class Customization
        {
            [JsonProperty("Body")]
            public string Body { get; set; }

            [JsonProperty("Feet")]
            public string Feet { get; set; }

            [JsonProperty("Hands")]
            public string Hands { get; set; }

            [JsonProperty("Head")]
            public string Head { get; set; }
        }
        public class Health
        {
            [JsonProperty("Hydration")]
            public Hydration Hydration { get; set; }

            [JsonProperty("Energy")]
            public Energy Energy { get; set; }

            [JsonProperty("Temperature")]
            public Temperature Temperature { get; set; }

            [JsonProperty("BodyParts")]
            public BodyParts BodyParts { get; set; }

            [JsonProperty("UpdateTime")]
            public int UpdateTime { get; set; }

            [JsonProperty("Current")]
            public int Current { get; set; }

            [JsonProperty("Maximum")]
            public int Maximum { get; set; }
        }
        public class Hydration
        {
            [JsonProperty("Current")]
            public int Current { get; set; }

            [JsonProperty("Maximum")]
            public int Maximum { get; set; }
        }
        public class Energy
        {
            [JsonProperty("Current")]
            public int Current { get; set; }

            [JsonProperty("Maximum")]
            public int Maximum { get; set; }
        }
        public class Temperature
        {
            [JsonProperty("Current")]
            public double Current { get; set; }

            [JsonProperty("Maximum")]
            public int Maximum { get; set; }
        }
        public class BodyParts
        {
            [JsonProperty("Head")]
            public Head Head { get; set; }

            [JsonProperty("Chest")]
            public Chest Chest { get; set; }

            [JsonProperty("Stomach")]
            public Stomach Stomach { get; set; }

            [JsonProperty("LeftArm")]
            public LeftArm LeftArm { get; set; }

            [JsonProperty("RightArm")]
            public RightArm RightArm { get; set; }

            [JsonProperty("LeftLeg")]
            public LeftLeg LeftLeg { get; set; }

            [JsonProperty("RightLeg")]
            public RightLeg RightLeg { get; set; }
        }
        public class Head
        {
            [JsonProperty("Health")]
            public Health Health { get; set; }

            [JsonProperty("Amount")]
            public double Amount { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("SourceId")]
            public object SourceId { get; set; }

            [JsonProperty("OverDamageFrom")]
            public string OverDamageFrom { get; set; }

            [JsonProperty("Blunt")]
            public bool Blunt { get; set; }

            [JsonProperty("ImpactsCount")]
            public int ImpactsCount { get; set; }
        }
        public class Chest
        {
            [JsonProperty("Health")]
            public Health Health { get; set; }

            [JsonProperty("Amount")]
            public double Amount { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("SourceId")]
            public object SourceId { get; set; }

            [JsonProperty("OverDamageFrom")]
            public string OverDamageFrom { get; set; }

            [JsonProperty("Blunt")]
            public bool Blunt { get; set; }

            [JsonProperty("ImpactsCount")]
            public int ImpactsCount { get; set; }
        }
        public class Stomach
        {
            [JsonProperty("Health")]
            public Health Health { get; set; }

            [JsonProperty("Amount")]
            public double Amount { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("SourceId")]
            public object SourceId { get; set; }

            [JsonProperty("OverDamageFrom")]
            public string OverDamageFrom { get; set; }

            [JsonProperty("Blunt")]
            public bool Blunt { get; set; }

            [JsonProperty("ImpactsCount")]
            public int ImpactsCount { get; set; }
        }
        public class LeftArm
        {
            [JsonProperty("Health")]
            public Health Health { get; set; }

            [JsonProperty("Amount")]
            public double Amount { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("SourceId")]
            public object SourceId { get; set; }

            [JsonProperty("OverDamageFrom")]
            public string OverDamageFrom { get; set; }

            [JsonProperty("Blunt")]
            public bool Blunt { get; set; }

            [JsonProperty("ImpactsCount")]
            public int ImpactsCount { get; set; }
        }
        public class RightArm
        {
            [JsonProperty("Health")]
            public Health Health { get; set; }

            [JsonProperty("Amount")]
            public double Amount { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("SourceId")]
            public object SourceId { get; set; }

            [JsonProperty("OverDamageFrom")]
            public string OverDamageFrom { get; set; }

            [JsonProperty("Blunt")]
            public bool Blunt { get; set; }

            [JsonProperty("ImpactsCount")]
            public int ImpactsCount { get; set; }
        }
        public class LeftLeg
        {
            [JsonProperty("Health")]
            public Health Health { get; set; }

            [JsonProperty("Amount")]
            public int Amount { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("SourceId")]
            public object SourceId { get; set; }

            [JsonProperty("OverDamageFrom")]
            public object OverDamageFrom { get; set; }

            [JsonProperty("Blunt")]
            public bool Blunt { get; set; }

            [JsonProperty("ImpactsCount")]
            public int ImpactsCount { get; set; }
        }
        public class RightLeg
        {
            [JsonProperty("Health")]
            public Health Health { get; set; }

            [JsonProperty("Amount")]
            public double Amount { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("SourceId")]
            public object SourceId { get; set; }

            [JsonProperty("OverDamageFrom")]
            public string OverDamageFrom { get; set; }

            [JsonProperty("Blunt")]
            public bool Blunt { get; set; }

            [JsonProperty("ImpactsCount")]
            public int ImpactsCount { get; set; }
        }
        public class Inventory
        {
            [JsonProperty("items")]
            public List<Item> Items { get; set; }

            [JsonProperty("equipment")]
            public string Equipment { get; set; }

            [JsonProperty("stash")]
            public string Stash { get; set; }

            [JsonProperty("sortingTable")]
            public string SortingTable { get; set; }

            [JsonProperty("questRaidItems")]
            public string QuestRaidItems { get; set; }

            [JsonProperty("questStashItems")]
            public string QuestStashItems { get; set; }

            [JsonProperty("fastPanel")]
            public FastPanel FastPanel { get; set; }
        }
        public class Item
        {
            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("_tpl")]
            public string Tpl { get; set; }

            [JsonProperty("parentId")]
            public string ParentId { get; set; }

            [JsonProperty("slotId")]
            public string SlotId { get; set; }

            [JsonProperty("location")]
            public Location Location { get; set; }

            [JsonProperty("upd")]
            public Upd Upd { get; set; }
        }
        public class Location
        {
            [JsonProperty("x")]
            public int X { get; set; }

            [JsonProperty("y")]
            public int Y { get; set; }

            [JsonProperty("r")]
            public int R { get; set; }

            [JsonProperty("isSearched")]
            public bool IsSearched { get; set; }
        }
        public class Upd
        {
            [JsonProperty("MedKit")]
            public MedKit? MedKit { get; set; }

            [JsonProperty("Repairable")]
            public Repairable? Repairable { get; set; }

            [JsonProperty("FoodDrink")]
            public FoodDrink? FoodDrink { get; set; }

            [JsonProperty("StackObjectsCount")]
            public int? StackObjectsCount { get; set; }

            [JsonProperty("Dogtag")]
            public Dogtag? Dogtag { get; set; }
        }
        public class Dogtag
        {
            [JsonProperty("AccountId")]
            public string AccountId { get; set; }

            [JsonProperty("ProfileId")]
            public string ProfileId { get; set; }

            [JsonProperty("Nickname")]
            public string Nickname { get; set; }

            [JsonProperty("Side")]
            public string Side { get; set; }

            [JsonProperty("Level")]
            public int Level { get; set; }

            [JsonProperty("Time")]
            public string Time { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }

            [JsonProperty("KillerAccountId")]
            public string KillerAccountId { get; set; }

            [JsonProperty("KillerProfileId")]
            public string KillerProfileId { get; set; }

            [JsonProperty("KillerName")]
            public string KillerName { get; set; }

            [JsonProperty("WeaponName")]
            public string WeaponName { get; set; }
        }
        public class MedKit
        {
            [JsonProperty("HpResource")]
            public int HpResource { get; set; }
        }
        public class Repairable
        {
            [JsonProperty("MaxDurability")]
            public int MaxDurability { get; set; }

            [JsonProperty("Durability")]
            public int Durability { get; set; }
        }
        public class FoodDrink
        {
            [JsonProperty("HpPercent")]
            public int HpPercent { get; set; }
        }
        public class FastPanel
        {
            //TODO THIS
        }
        public class Skills
        {
            [JsonProperty("Common")]
            public List<Common> Common { get; set; }

            [JsonProperty("Mastering")]
            public List<Mastering> Mastering { get; set; }

            [JsonProperty("Bonuses")]
            public object Bonuses { get; set; }

            [JsonProperty("Points")]
            public int Points { get; set; }
        }
        public class Common
        {
            [JsonProperty("Id")]
            public string Id { get; set; }

            [JsonProperty("Progress")]
            public double Progress { get; set; }

            [JsonProperty("PointsEarnedDuringSession")]
            public double PointsEarnedDuringSession { get; set; }

            [JsonProperty("LastAccess")]
            public int LastAccess { get; set; }
        }
        public class Mastering
        {
            [JsonProperty("Id")]
            public string Id { get; set; }

            [JsonProperty("Progress")]
            public int Progress { get; set; }
        }
        public class Stats
        {
            [JsonProperty("SessionCounters")]
            public SessionCounters SessionCounters { get; set; }

            [JsonProperty("OverallCounters")]
            public OverallCounters OverallCounters { get; set; }

            [JsonProperty("SessionExperienceMult")]
            public int SessionExperienceMult { get; set; }

            [JsonProperty("ExperienceBonusMult")]
            public int ExperienceBonusMult { get; set; }

            [JsonProperty("TotalSessionExperience")]
            public int TotalSessionExperience { get; set; }

            [JsonProperty("LastSessionDate")]
            public int LastSessionDate { get; set; }

            [JsonProperty("Aggressor")]
            public object Aggressor { get; set; }

            [JsonProperty("DroppedItems")]
            public List<object> DroppedItems { get; set; }

            [JsonProperty("FoundInRaidItems")]
            public List<object> FoundInRaidItems { get; set; }

            [JsonProperty("Victims")]
            public List<object> Victims { get; set; }

            [JsonProperty("CarriedQuestItems")]
            public List<object> CarriedQuestItems { get; set; }

            [JsonProperty("DamageHistory")]
            public DamageHistory DamageHistory { get; set; }

            [JsonProperty("DeathCause")]
            public DeathCause DeathCause { get; set; }

            [JsonProperty("LastPlayerState")]
            public object LastPlayerState { get; set; }

            [JsonProperty("TotalInGameTime")]
            public int TotalInGameTime { get; set; }

            [JsonProperty("SurvivorClass")]
            public string SurvivorClass { get; set; }
        }
        public class SessionCounters
        {
            [JsonProperty("Items")]
            public List<Item2> Items { get; set; }
        }
        public class Item2
        {
            [JsonProperty("Key")]
            public List<string> Key { get; set; }

            [JsonProperty("Value")]
            public int Value { get; set; }
        }
        public class OverallCounters
        {
            [JsonProperty("Items")]
            public List<Item2> Items { get; set; }
        }
        public class DamageHistory
        {
            [JsonProperty("LethalDamagePart")]
            public string LethalDamagePart { get; set; }

            [JsonProperty("LethalDamage")]
            public object LethalDamage { get; set; }

            [JsonProperty("BodyParts")]
            public BodyParts BodyParts { get; set; }
        }
        public class DeathCause
        {
            [JsonProperty("DamageType")]
            public int DamageType { get; set; }

            [JsonProperty("Side")]
            public int Side { get; set; }

            [JsonProperty("Role")]
            public int Role { get; set; }

            [JsonProperty("WeaponId")]
            public object WeaponId { get; set; }
        }
        public class Encyclopedia
        {
            [JsonProperty("56dfef82d2720bbd668b4567")]
            public bool _56dfef82d2720bbd668b4567 { get; set; }

            [JsonProperty("57dc324a24597759501edc20")]
            public bool _57dc324a24597759501edc20 { get; set; }

            [JsonProperty("57dc334d245977597164366f")]
            public bool _57dc334d245977597164366f { get; set; }

            [JsonProperty("59d36a0086f7747e673f3946")]
            public bool _59d36a0086f7747e673f3946 { get; set; }

            [JsonProperty("590c657e86f77412b013051d")]
            public bool _590c657e86f77412b013051d { get; set; }

            [JsonProperty("544fb3f34bdc2d03748b456a")]
            public bool _544fb3f34bdc2d03748b456a { get; set; }

            [JsonProperty("58864a4f2459770fcc257101")]
            public bool _58864a4f2459770fcc257101 { get; set; }

            [JsonProperty("5448be9a4bdc2dfd2f8b456a")]
            public bool _5448be9a4bdc2dfd2f8b456a { get; set; }

            [JsonProperty("544fb45d4bdc2dee738b4568")]
            public bool _544fb45d4bdc2dee738b4568 { get; set; }

            [JsonProperty("590c678286f77426c9660122")]
            public bool _590c678286f77426c9660122 { get; set; }

            [JsonProperty("5926c3b286f774640d189b6b")]
            public bool _5926c3b286f774640d189b6b { get; set; }

            [JsonProperty("584984812459776a704a82a6")]
            public bool _584984812459776a704a82a6 { get; set; }

            [JsonProperty("59ccfdba86f7747f2109a587")]
            public bool _59ccfdba86f7747f2109a587 { get; set; }

            [JsonProperty("545cdae64bdc2d39198b4568")]
            public bool _545cdae64bdc2d39198b4568 { get; set; }

            [JsonProperty("5645bc214bdc2d363b8b4571")]
            public bool _5645bc214bdc2d363b8b4571 { get; set; }

            [JsonProperty("545cdb794bdc2d3a198b456a")]
            public bool _545cdb794bdc2d3a198b456a { get; set; }

            [JsonProperty("592c2d1a86f7746dbe2af32a")]
            public bool _592c2d1a86f7746dbe2af32a { get; set; }

            [JsonProperty("567143bf4bdc2d1a0f8b4567")]
            public bool _567143bf4bdc2d1a0f8b4567 { get; set; }

            [JsonProperty("59bffbb386f77435b379b9c2")]
            public bool _59bffbb386f77435b379b9c2 { get; set; }

            [JsonProperty("59bffc1f86f77435b128b872")]
            public bool _59bffc1f86f77435b128b872 { get; set; }

            [JsonProperty("595cf16b86f77427440c32e2")]
            public bool _595cf16b86f77427440c32e2 { get; set; }

            [JsonProperty("5644bd2b4bdc2d3b4c8b4572")]
            public bool _5644bd2b4bdc2d3b4c8b4572 { get; set; }

            [JsonProperty("59c6633186f7740cf0493bb9")]
            public bool _59c6633186f7740cf0493bb9 { get; set; }

            [JsonProperty("5649b0544bdc2d1b2b8b458a")]
            public bool _5649b0544bdc2d1b2b8b458a { get; set; }

            [JsonProperty("55d482194bdc2d1d4e8b456b")]
            public bool _55d482194bdc2d1d4e8b456b { get; set; }

            [JsonProperty("56d5a2bbd2720bb8418b456a")]
            public bool _56d5a2bbd2720bb8418b456a { get; set; }

            [JsonProperty("56d5a407d2720bb3418b456b")]
            public bool _56d5a407d2720bb3418b456b { get; set; }

            [JsonProperty("5926bb2186f7744b1c6c6e60")]
            public bool _5926bb2186f7744b1c6c6e60 { get; set; }

            [JsonProperty("5926c0df86f77462f647f764")]
            public bool _5926c0df86f77462f647f764 { get; set; }

            [JsonProperty("5926c36d86f77467a92a8629")]
            public bool _5926c36d86f77467a92a8629 { get; set; }

            [JsonProperty("5926d2be86f774134d668e4e")]
            public bool _5926d2be86f774134d668e4e { get; set; }

            [JsonProperty("5926d3c686f77410de68ebc8")]
            public bool _5926d3c686f77410de68ebc8 { get; set; }

            [JsonProperty("5926e16e86f7742f5a0f7ecb")]
            public bool _5926e16e86f7742f5a0f7ecb { get; set; }

            [JsonProperty("5926c32286f774616e42de99")]
            public bool _5926c32286f774616e42de99 { get; set; }

            [JsonProperty("55801eed4bdc2d89578b4588")]
            public bool _55801eed4bdc2d89578b4588 { get; set; }

            [JsonProperty("559ba5b34bdc2d1f1a8b4582")]
            public bool _559ba5b34bdc2d1f1a8b4582 { get; set; }

            [JsonProperty("5887431f2459777e1612938f")]
            public bool _5887431f2459777e1612938f { get; set; }

            [JsonProperty("56083e1b4bdc2dc8488b4572")]
            public bool _56083e1b4bdc2dc8488b4572 { get; set; }

            [JsonProperty("56083eab4bdc2d26448b456a")]
            public bool _56083eab4bdc2d26448b456a { get; set; }

            [JsonProperty("560e620e4bdc2d724b8b456b")]
            public bool _560e620e4bdc2d724b8b456b { get; set; }

            [JsonProperty("56ea8222d2720b69698b4567")]
            public bool _56ea8222d2720b69698b4567 { get; set; }

            [JsonProperty("58948c8e86f77409493f7266")]
            public bool _58948c8e86f77409493f7266 { get; set; }

            [JsonProperty("5894a51286f77426d13baf02")]
            public bool _5894a51286f77426d13baf02 { get; set; }

            [JsonProperty("5894a5b586f77426d2590767")]
            public bool _5894a5b586f77426d2590767 { get; set; }

            [JsonProperty("5894a2c386f77427140b8342")]
            public bool _5894a2c386f77427140b8342 { get; set; }

            [JsonProperty("58949dea86f77409483e16a8")]
            public bool _58949dea86f77409483e16a8 { get; set; }

            [JsonProperty("5894a42086f77426d2590762")]
            public bool _5894a42086f77426d2590762 { get; set; }

            [JsonProperty("5894a73486f77426d259076c")]
            public bool _5894a73486f77426d259076c { get; set; }

            [JsonProperty("5894a81786f77427140b8347")]
            public bool _5894a81786f77427140b8347 { get; set; }

            [JsonProperty("5894a13e86f7742405482982")]
            public bool _5894a13e86f7742405482982 { get; set; }

            [JsonProperty("58949edd86f77409483e16a9")]
            public bool _58949edd86f77409483e16a9 { get; set; }

            [JsonProperty("55d7217a4bdc2d86028b456d")]
            public bool _55d7217a4bdc2d86028b456d { get; set; }

            [JsonProperty("557ffd194bdc2d28148b457f")]
            public bool _557ffd194bdc2d28148b457f { get; set; }

            [JsonProperty("544a5cde4bdc2d39388b456b")]
            public bool _544a5cde4bdc2d39388b456b { get; set; }

            [JsonProperty("5857a8bc2459772bad15db29")]
            public bool _5857a8bc2459772bad15db29 { get; set; }

            [JsonProperty("5b44c8ea86f7742d1627baf1")]
            public bool _5b44c8ea86f7742d1627baf1 { get; set; }

            [JsonProperty("564ca99c4bdc2d16268b4589")]
            public bool _564ca99c4bdc2d16268b4589 { get; set; }

            [JsonProperty("57cd379a24597778e7682ecf")]
            public bool _57cd379a24597778e7682ecf { get; set; }

            [JsonProperty("57dc2fa62459775949412633")]
            public bool _57dc2fa62459775949412633 { get; set; }

            [JsonProperty("57dc32dc245977596d4ef3d3")]
            public bool _57dc32dc245977596d4ef3d3 { get; set; }

            [JsonProperty("57dc347d245977596754e7a1")]
            public bool _57dc347d245977596754e7a1 { get; set; }

            [JsonProperty("5649ad3f4bdc2df8348b4585")]
            public bool _5649ad3f4bdc2df8348b4585 { get; set; }

            [JsonProperty("5811ce772459770e9e5f9532")]
            public bool _5811ce772459770e9e5f9532 { get; set; }

            [JsonProperty("5894a05586f774094708ef75")]
            public bool _5894a05586f774094708ef75 { get; set; }

            [JsonProperty("56d59856d2720bd8418b456a")]
            public bool _56d59856d2720bd8418b456a { get; set; }

            [JsonProperty("56d59948d2720bb7418b4582")]
            public bool _56d59948d2720bb7418b4582 { get; set; }

            [JsonProperty("56d59d3ad2720bdb418b4577")]
            public bool _56d59d3ad2720bdb418b4577 { get; set; }

            [JsonProperty("56d5a661d2720bd8418b456b")]
            public bool _56d5a661d2720bd8418b456b { get; set; }

            [JsonProperty("56d5a77ed2720b90418b4568")]
            public bool _56d5a77ed2720b90418b4568 { get; set; }

            [JsonProperty("56d5a1f7d2720bb3418b456a")]
            public bool _56d5a1f7d2720bb3418b456a { get; set; }

            [JsonProperty("5448bd6b4bdc2dfc2f8b4569")]
            public bool _5448bd6b4bdc2dfc2f8b4569 { get; set; }

            [JsonProperty("5448c12b4bdc2d02308b456f")]
            public bool _5448c12b4bdc2d02308b456f { get; set; }

            [JsonProperty("573718ba2459775a75491131")]
            public bool _573718ba2459775a75491131 { get; set; }

            [JsonProperty("5649b1c04bdc2d16268b457c")]
            public bool _5649b1c04bdc2d16268b457c { get; set; }

            [JsonProperty("5649af094bdc2df8348b4586")]
            public bool _5649af094bdc2df8348b4586 { get; set; }

            [JsonProperty("5649aa744bdc2ded0b8b457e")]
            public bool _5649aa744bdc2ded0b8b457e { get; set; }

            [JsonProperty("5648b0744bdc2d363b8b4578")]
            public bool _5648b0744bdc2d363b8b4578 { get; set; }

            [JsonProperty("5696686a4bdc2da3298b456a")]
            public bool _5696686a4bdc2da3298b456a { get; set; }

            [JsonProperty("5449016a4bdc2d6f028b456f")]
            public bool _5449016a4bdc2d6f028b456f { get; set; }

            [JsonProperty("5448fee04bdc2dbc018b4567")]
            public bool _5448fee04bdc2dbc018b4567 { get; set; }

            [JsonProperty("544fb25a4bdc2dfb738b4567")]
            public bool _544fb25a4bdc2dfb738b4567 { get; set; }

            [JsonProperty("57347d7224597744596b4e72")]
            public bool _57347d7224597744596b4e72 { get; set; }

            [JsonProperty("544fb3364bdc2d34748b456a")]
            public bool _544fb3364bdc2d34748b456a { get; set; }

            [JsonProperty("5755356824597772cb798962")]
            public bool _5755356824597772cb798962 { get; set; }

            [JsonProperty("5645bcc04bdc2d363b8b4572")]
            public bool _5645bcc04bdc2d363b8b4572 { get; set; }

            [JsonProperty("5751a25924597722c463c472")]
            public bool _5751a25924597722c463c472 { get; set; }

            [JsonProperty("544fb37f4bdc2dee738b4567")]
            public bool _544fb37f4bdc2dee738b4567 { get; set; }

            [JsonProperty("5e831507ea0a7c419c2f9bd9")]
            public bool _5e831507ea0a7c419c2f9bd9 { get; set; }

            [JsonProperty("5648a7494bdc2d9d488b4583")]
            public bool _5648a7494bdc2d9d488b4583 { get; set; }

            [JsonProperty("544a11ac4bdc2d470e8b456a")]
            public bool _544a11ac4bdc2d470e8b456a { get; set; }

            [JsonProperty("5c0e9f2c86f77432297fe0a3")]
            public bool _5c0e9f2c86f77432297fe0a3 { get; set; }

            [JsonProperty("55d4887d4bdc2d962f8b4570")]
            public bool _55d4887d4bdc2d962f8b4570 { get; set; }

            [JsonProperty("54527a984bdc2d4e668b4567")]
            public bool _54527a984bdc2d4e668b4567 { get; set; }

            [JsonProperty("5aa2a7e8e5b5b00016327c16")]
            public bool _5aa2a7e8e5b5b00016327c16 { get; set; }

            [JsonProperty("5ab8f39486f7745cd93a1cca")]
            public bool _5ab8f39486f7745cd93a1cca { get; set; }

            [JsonProperty("54491bb74bdc2d09088b4567")]
            public bool _54491bb74bdc2d09088b4567 { get; set; }

            [JsonProperty("5447a9cd4bdc2dbd208b4567")]
            public bool _5447a9cd4bdc2dbd208b4567 { get; set; }

            [JsonProperty("55d44fd14bdc2d962f8b456e")]
            public bool _55d44fd14bdc2d962f8b456e { get; set; }

            [JsonProperty("5649be884bdc2d79388b4577")]
            public bool _5649be884bdc2d79388b4577 { get; set; }

            [JsonProperty("55d4ae6c4bdc2d8b2f8b456e")]
            public bool _55d4ae6c4bdc2d8b2f8b456e { get; set; }

            [JsonProperty("55d355e64bdc2d962f8b4569")]
            public bool _55d355e64bdc2d962f8b4569 { get; set; }

            [JsonProperty("55d5f46a4bdc2d1b198b4567")]
            public bool _55d5f46a4bdc2d1b198b4567 { get; set; }

            [JsonProperty("55d459824bdc2d892f8b4573")]
            public bool _55d459824bdc2d892f8b4573 { get; set; }

            [JsonProperty("55d3632e4bdc2d972f8b4569")]
            public bool _55d3632e4bdc2d972f8b4569 { get; set; }

            [JsonProperty("56ea8d2fd2720b7c698b4570")]
            public bool _56ea8d2fd2720b7c698b4570 { get; set; }

            [JsonProperty("55d4af3a4bdc2d972f8b456f")]
            public bool _55d4af3a4bdc2d972f8b456f { get; set; }

            [JsonProperty("544a38634bdc2d58388b4568")]
            public bool _544a38634bdc2d58388b4568 { get; set; }

            [JsonProperty("55d4b9964bdc2d1d4e8b456e")]
            public bool _55d4b9964bdc2d1d4e8b456e { get; set; }

            [JsonProperty("58dd3ad986f77403051cba8f")]
            public bool _58dd3ad986f77403051cba8f { get; set; }

            [JsonProperty("5d02778e86f774203e7dedbe")]
            public bool _5d02778e86f774203e7dedbe { get; set; }

            [JsonProperty("5bfeaa0f0db834001b734927")]
            public bool _5bfeaa0f0db834001b734927 { get; set; }

            [JsonProperty("5d1b371186f774253763a656")]
            public bool _5d1b371186f774253763a656 { get; set; }

            [JsonProperty("58d3db5386f77426186285a0")]
            public bool _58d3db5386f77426186285a0 { get; set; }

            [JsonProperty("5aa7d03ae5b5b00016327db5")]
            public bool _5aa7d03ae5b5b00016327db5 { get; set; }

            [JsonProperty("5c165d832e2216398b5a7e36")]
            public bool _5c165d832e2216398b5a7e36 { get; set; }

            [JsonProperty("57c5ac0824597754771e88a9")]
            public bool _57c5ac0824597754771e88a9 { get; set; }

            [JsonProperty("5bfebc5e0db834001a6694e5")]
            public bool _5bfebc5e0db834001a6694e5 { get; set; }

            [JsonProperty("5bfea6e90db834001b7347f3")]
            public bool _5bfea6e90db834001b7347f3 { get; set; }

            [JsonProperty("5bfebc320db8340019668d79")]
            public bool _5bfebc320db8340019668d79 { get; set; }

            [JsonProperty("5bfeb32b0db834001a6694d9")]
            public bool _5bfeb32b0db834001a6694d9 { get; set; }

            [JsonProperty("5bfea7ad0db834001c38f1ee")]
            public bool _5bfea7ad0db834001c38f1ee { get; set; }

            [JsonProperty("557ff21e4bdc2d89578b4586")]
            public bool _557ff21e4bdc2d89578b4586 { get; set; }

            [JsonProperty("5af0454c86f7746bf20992e8")]
            public bool _5af0454c86f7746bf20992e8 { get; set; }

            [JsonProperty("5e9dcf5986f7746c417435b3")]
            public bool _5e9dcf5986f7746c417435b3 { get; set; }

            [JsonProperty("590c5f0d86f77413997acfab")]
            public bool _590c5f0d86f77413997acfab { get; set; }

            [JsonProperty("5c0e655586f774045612eeb2")]
            public bool _5c0e655586f774045612eeb2 { get; set; }

            [JsonProperty("5e870397991fd70db46995c8")]
            public bool _5e870397991fd70db46995c8 { get; set; }

            [JsonProperty("560d5e524bdc2d25448b4571")]
            public bool _560d5e524bdc2d25448b4571 { get; set; }

            [JsonProperty("5e87114fe2db31558c75a120")]
            public bool _5e87114fe2db31558c75a120 { get; set; }

            [JsonProperty("5e87116b81c4ed43e83cefdd")]
            public bool _5e87116b81c4ed43e83cefdd { get; set; }

            [JsonProperty("5e87080c81c4ed43e83cefda")]
            public bool _5e87080c81c4ed43e83cefda { get; set; }

            [JsonProperty("5e87076ce2db31558c75a11d")]
            public bool _5e87076ce2db31558c75a11d { get; set; }

            [JsonProperty("5e87071478f43e51ca2de5e1")]
            public bool _5e87071478f43e51ca2de5e1 { get; set; }

            [JsonProperty("5e8708d4ae379e67d22e0102")]
            public bool _5e8708d4ae379e67d22e0102 { get; set; }

            [JsonProperty("5cadc190ae921500103bb3b6")]
            public bool _5cadc190ae921500103bb3b6 { get; set; }

            [JsonProperty("5cadc2e0ae9215051e1c21e7")]
            public bool _5cadc2e0ae9215051e1c21e7 { get; set; }

            [JsonProperty("5cadc55cae921500103bb3be")]
            public bool _5cadc55cae921500103bb3be { get; set; }

            [JsonProperty("5cadd919ae921500126a77f3")]
            public bool _5cadd919ae921500126a77f3 { get; set; }

            [JsonProperty("5cadd940ae9215051e1c2316")]
            public bool _5cadd940ae9215051e1c2316 { get; set; }

            [JsonProperty("5cadc431ae921500113bb8d5")]
            public bool _5cadc431ae921500113bb8d5 { get; set; }

            [JsonProperty("5cadc1c6ae9215000f2775a4")]
            public bool _5cadc1c6ae9215000f2775a4 { get; set; }

            [JsonProperty("5cadc390ae921500126a77f1")]
            public bool _5cadc390ae921500126a77f1 { get; set; }

            [JsonProperty("57347da92459774491567cf5")]
            public bool _57347da92459774491567cf5 { get; set; }

            [JsonProperty("5a0c27731526d80618476ac4")]
            public bool _5a0c27731526d80618476ac4 { get; set; }

            [JsonProperty("5d2f213448f0355009199284")]
            public bool _5d2f213448f0355009199284 { get; set; }

            [JsonProperty("569668774bdc2da2298b4568")]
            public bool _569668774bdc2da2298b4568 { get; set; }

            [JsonProperty("5755383e24597772cb798966")]
            public bool _5755383e24597772cb798966 { get; set; }

            [JsonProperty("590c695186f7741e566b64a2")]
            public bool _590c695186f7741e566b64a2 { get; set; }

            [JsonProperty("5d403f9186f7743cac3f229b")]
            public bool _5d403f9186f7743cac3f229b { get; set; }

            [JsonProperty("5e4d34ca86f774264f758330")]
            public bool _5e4d34ca86f774264f758330 { get; set; }

            [JsonProperty("590c661e86f7741e566b646a")]
            public bool _590c661e86f7741e566b646a { get; set; }

            [JsonProperty("5d02797c86f774203f38e30a")]
            public bool _5d02797c86f774203f38e30a { get; set; }

            [JsonProperty("5c0e530286f7747fa1419862")]
            public bool _5c0e530286f7747fa1419862 { get; set; }

            [JsonProperty("5e8488fa988a8701445df1e4")]
            public bool _5e8488fa988a8701445df1e4 { get; set; }

            [JsonProperty("5f4f9eb969cdc30ff33f09db")]
            public bool _5f4f9eb969cdc30ff33f09db { get; set; }

            [JsonProperty("5d5e9c74a4b9364855191c40")]
            public bool _5d5e9c74a4b9364855191c40 { get; set; }

            [JsonProperty("570fd6c2d2720bc6458b457f")]
            public bool _570fd6c2d2720bc6458b457f { get; set; }

            [JsonProperty("5c488a752e221602b412af63")]
            public bool _5c488a752e221602b412af63 { get; set; }

            [JsonProperty("5c48a2852e221602b21d5923")]
            public bool _5c48a2852e221602b21d5923 { get; set; }

            [JsonProperty("5c48a2a42e221602b66d1e07")]
            public bool _5c48a2a42e221602b66d1e07 { get; set; }

            [JsonProperty("5c48a14f2e2216152006edd7")]
            public bool _5c48a14f2e2216152006edd7 { get; set; }

            [JsonProperty("5c48a2c22e221602b313fb6c")]
            public bool _5c48a2c22e221602b313fb6c { get; set; }

            [JsonProperty("5aafbde786f774389d0cbc0f")]
            public bool _5aafbde786f774389d0cbc0f { get; set; }

            [JsonProperty("5d5d85c586f774279a21cbdb")]
            public bool _5d5d85c586f774279a21cbdb { get; set; }

            [JsonProperty("544a5caa4bdc2d1a388b4568")]
            public bool _544a5caa4bdc2d1a388b4568 { get; set; }

            [JsonProperty("5d5d940f86f7742797262046")]
            public bool _5d5d940f86f7742797262046 { get; set; }

            [JsonProperty("5e2af47786f7746d404f3aaa")]
            public bool _5e2af47786f7746d404f3aaa { get; set; }

            [JsonProperty("5e2af4a786f7746d3f3c3400")]
            public bool _5e2af4a786f7746d3f3c3400 { get; set; }

            [JsonProperty("5c18b9192e2216398b5a8104")]
            public bool _5c18b9192e2216398b5a8104 { get; set; }

            [JsonProperty("5c18b90d2e2216152142466b")]
            public bool _5c18b90d2e2216152142466b { get; set; }

            [JsonProperty("5d1b36a186f7742523398433")]
            public bool _5d1b36a186f7742523398433 { get; set; }

            [JsonProperty("572b7fa524597762b747ce82")]
            public bool _572b7fa524597762b747ce82 { get; set; }

            [JsonProperty("5ae30bad5acfc400185c2dc4")]
            public bool _5ae30bad5acfc400185c2dc4 { get; set; }

            [JsonProperty("5ae30db85acfc408fb139a05")]
            public bool _5ae30db85acfc408fb139a05 { get; set; }

            [JsonProperty("5ae30e795acfc408fb139a0b")]
            public bool _5ae30e795acfc408fb139a0b { get; set; }
        }
        public class ConditionCounters
        {
            [JsonProperty("Counters")]
            public List<object> Counters { get; set; }
        }
        public class BackendCounters
        {
            //TODO THIS
        }
        public class Hideout
        {
            [JsonProperty("Production")]
            public Production Production { get; set; }

            [JsonProperty("Areas")]
            public List<Area> Areas { get; set; }
        }
        public class Production
        {
            //TODO THIS
        }
        public class Area
        {
            [JsonProperty("type")]
            public int Type { get; set; }

            [JsonProperty("level")]
            public int Level { get; set; }

            [JsonProperty("active")]
            public bool Active { get; set; }

            [JsonProperty("passiveBonusesEnabled")]
            public bool PassiveBonusesEnabled { get; set; }

            [JsonProperty("completeTime")]
            public int CompleteTime { get; set; }

            [JsonProperty("constructing")]
            public bool Constructing { get; set; }

            [JsonProperty("slots")]
            public List<object> Slots { get; set; }

            [JsonProperty("lastRecipe")]
            public string LastRecipe { get; set; }
        }
        public class Bonuse
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("templateId")]
            public string TemplateId { get; set; }
        }
        public class NotesClass
        {
            [JsonProperty("Notes")]
            public List<object> Notes { get; set; }
        }
        public class Quest
        {
            [JsonProperty("qid")]
            public string Qid { get; set; }

            [JsonProperty("startTime")]
            public int StartTime { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("statusTimers")]
            public StatusTimers StatusTimers { get; set; }

            [JsonProperty("completedConditions")]
            public List<object> CompletedConditions { get; set; }
        }
        public class StatusTimers
        {
            [JsonProperty("AvailableForStart")]
            public double? AvailableForStart { get; set; }
        }
        public class TradersInfo
        {
            [JsonProperty("5c0647fdd443bc2504c2d371")]
            public _5c0647fdd443bc2504c2d371 _5c0647fdd443bc2504c2d371 { get; set; }

            [JsonProperty("5935c25fb3acc3127c3d8cd9")]
            public _5935c25fb3acc3127c3d8cd9 _5935c25fb3acc3127c3d8cd9 { get; set; }

            [JsonProperty("58330581ace78e27b8b10cee")]
            public _58330581ace78e27b8b10cee _58330581ace78e27b8b10cee { get; set; }

            [JsonProperty("5a7c2eca46aef81a7ca2145d")]
            public _5a7c2eca46aef81a7ca2145d _5a7c2eca46aef81a7ca2145d { get; set; }

            [JsonProperty("579dc571d53a0658a154fbec")]
            public _579dc571d53a0658a154fbec _579dc571d53a0658a154fbec { get; set; }

            [JsonProperty("5ac3b934156ae10c4430e83c")]
            public _5ac3b934156ae10c4430e83c _5ac3b934156ae10c4430e83c { get; set; }

            [JsonProperty("54cb50c76803fa8b248b4571")]
            public _54cb50c76803fa8b248b4571 _54cb50c76803fa8b248b4571 { get; set; }

            [JsonProperty("54cb57776803fa99248b456e")]
            public _54cb57776803fa99248b456e _54cb57776803fa99248b456e { get; set; }
        }
        public class _5c0647fdd443bc2504c2d371
        {
            [JsonProperty("unlocked")]
            public bool Unlocked { get; set; }

            [JsonProperty("salesSum")]
            public int SalesSum { get; set; }

            [JsonProperty("standing")]
            public double Standing { get; set; }
        }
        public class _5935c25fb3acc3127c3d8cd9
        {
            [JsonProperty("unlocked")]
            public bool Unlocked { get; set; }

            [JsonProperty("salesSum")]
            public int SalesSum { get; set; }

            [JsonProperty("standing")]
            public double Standing { get; set; }
        }
        public class _58330581ace78e27b8b10cee
        {
            [JsonProperty("unlocked")]
            public bool Unlocked { get; set; }

            [JsonProperty("salesSum")]
            public int SalesSum { get; set; }

            [JsonProperty("standing")]
            public double Standing { get; set; }
        }
        public class _5a7c2eca46aef81a7ca2145d
        {
            [JsonProperty("unlocked")]
            public bool Unlocked { get; set; }

            [JsonProperty("salesSum")]
            public int SalesSum { get; set; }

            [JsonProperty("standing")]
            public double Standing { get; set; }
        }
        public class _579dc571d53a0658a154fbec
        {
            [JsonProperty("unlocked")]
            public bool Unlocked { get; set; }

            [JsonProperty("salesSum")]
            public int SalesSum { get; set; }

            [JsonProperty("standing")]
            public double Standing { get; set; }
        }
        public class _5ac3b934156ae10c4430e83c
        {
            [JsonProperty("unlocked")]
            public bool Unlocked { get; set; }

            [JsonProperty("salesSum")]
            public int SalesSum { get; set; }

            [JsonProperty("standing")]
            public double Standing { get; set; }
        }
        public class _54cb50c76803fa8b248b4571
        {
            [JsonProperty("unlocked")]
            public bool Unlocked { get; set; }

            [JsonProperty("salesSum")]
            public int SalesSum { get; set; }

            [JsonProperty("standing")]
            public double Standing { get; set; }
        }
        public class _54cb57776803fa99248b456e
        {
            [JsonProperty("unlocked")]
            public bool Unlocked { get; set; }

            [JsonProperty("salesSum")]
            public int SalesSum { get; set; }

            [JsonProperty("standing")]
            public double Standing { get; set; }
        }
        public class RagfairInfo
        {
            [JsonProperty("rating")]
            public double Rating { get; set; }

            [JsonProperty("isRatingGrowing")]
            public bool IsRatingGrowing { get; set; }

            [JsonProperty("offers")]
            public List<object> Offers { get; set; }
        }
    }
}
