using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ServerLib.Json.Classes
{
    public class Item
    {
        public partial class Base
        {
            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("_name")]
            public string Name { get; set; }

            [JsonProperty("_parent")]
            public string Parent { get; set; }

            [JsonProperty("_type")]
            public TypeEnum Type { get; set; }

            [JsonProperty("_props")]
            public ItemProps Props { get; set; }

            [JsonProperty("_proto", NullValueHandling = NullValueHandling.Ignore)]
            public string Proto { get; set; }
        }

        public partial class ItemProps
        {
            [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty("ShortName", NullValueHandling = NullValueHandling.Ignore)]
            public string ShortName { get; set; }

            [JsonProperty("Description", NullValueHandling = NullValueHandling.Ignore)]
            public string Description { get; set; }

            [JsonProperty("Weight", NullValueHandling = NullValueHandling.Ignore)]
            public double? Weight { get; set; }

            [JsonProperty("BackgroundColor", NullValueHandling = NullValueHandling.Ignore)]
            public BackgroundColor? BackgroundColor { get; set; }

            [JsonProperty("Width", NullValueHandling = NullValueHandling.Ignore)]
            public long? Width { get; set; }

            [JsonProperty("Height", NullValueHandling = NullValueHandling.Ignore)]
            public long? Height { get; set; }

            [JsonProperty("StackMaxSize", NullValueHandling = NullValueHandling.Ignore)]
            public long? StackMaxSize { get; set; }

            [JsonProperty("Rarity", NullValueHandling = NullValueHandling.Ignore)]
            public Rarity? Rarity { get; set; }

            [JsonProperty("SpawnChance", NullValueHandling = NullValueHandling.Ignore)]
            public long? SpawnChance { get; set; }

            [JsonProperty("CreditsPrice", NullValueHandling = NullValueHandling.Ignore)]
            public long? CreditsPrice { get; set; }

            [JsonProperty("ItemSound", NullValueHandling = NullValueHandling.Ignore)]
            public string ItemSound { get; set; }

            [JsonProperty("Prefab", NullValueHandling = NullValueHandling.Ignore)]
            public ConfigPath Prefab { get; set; }

            [JsonProperty("StackObjectsCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? StackObjectsCount { get; set; }

            [JsonProperty("NotShownInSlot", NullValueHandling = NullValueHandling.Ignore)]
            public bool? NotShownInSlot { get; set; }

            [JsonProperty("ExaminedByDefault", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ExaminedByDefault { get; set; }

            [JsonProperty("ExamineTime", NullValueHandling = NullValueHandling.Ignore)]
            public double? ExamineTime { get; set; }

            [JsonProperty("IsUnlootable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsUnlootable { get; set; }

            [JsonProperty("IsUndiscardable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsUndiscardable { get; set; }

            [JsonProperty("IsUnsaleable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsUnsaleable { get; set; }

            [JsonProperty("IsUnbuyable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsUnbuyable { get; set; }

            [JsonProperty("IsUngivable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsUngivable { get; set; }

            [JsonProperty("IsLockedafterEquip", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsLockedafterEquip { get; set; }

            [JsonProperty("LootExperience", NullValueHandling = NullValueHandling.Ignore)]
            public long? LootExperience { get; set; }

            [JsonProperty("ExamineExperience", NullValueHandling = NullValueHandling.Ignore)]
            public long? ExamineExperience { get; set; }

            [JsonProperty("HideEntrails", NullValueHandling = NullValueHandling.Ignore)]
            public bool? HideEntrails { get; set; }

            [JsonProperty("StackMinRandom", NullValueHandling = NullValueHandling.Ignore)]
            public long? StackMinRandom { get; set; }

            [JsonProperty("StackMaxRandom", NullValueHandling = NullValueHandling.Ignore)]
            public long? StackMaxRandom { get; set; }

            [JsonProperty("ammoType", NullValueHandling = NullValueHandling.Ignore)]
            public AmmoType? AmmoType { get; set; }

            [JsonProperty("Damage", NullValueHandling = NullValueHandling.Ignore)]
            public long? Damage { get; set; }

            [JsonProperty("ammoAccr", NullValueHandling = NullValueHandling.Ignore)]
            public long? AmmoAccr { get; set; }

            [JsonProperty("ammoRec", NullValueHandling = NullValueHandling.Ignore)]
            public long? AmmoRec { get; set; }

            [JsonProperty("ammoDist", NullValueHandling = NullValueHandling.Ignore)]
            public long? AmmoDist { get; set; }

            [JsonProperty("buckshotBullets", NullValueHandling = NullValueHandling.Ignore)]
            public long? BuckshotBullets { get; set; }

            [JsonProperty("PenetrationPower", NullValueHandling = NullValueHandling.Ignore)]
            public long? PenetrationPower { get; set; }

            [JsonProperty("ammoHear", NullValueHandling = NullValueHandling.Ignore)]
            public long? AmmoHear { get; set; }

            [JsonProperty("ammoSfx", NullValueHandling = NullValueHandling.Ignore)]
            public AmmoSfx? AmmoSfx { get; set; }

            [JsonProperty("MisfireChance", NullValueHandling = NullValueHandling.Ignore)]
            public double? MisfireChance { get; set; }

            [JsonProperty("MinFragmentsCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? MinFragmentsCount { get; set; }

            [JsonProperty("MaxFragmentsCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxFragmentsCount { get; set; }

            [JsonProperty("ammoShiftChance", NullValueHandling = NullValueHandling.Ignore)]
            public long? AmmoShiftChance { get; set; }

            [JsonProperty("casingName", NullValueHandling = NullValueHandling.Ignore)]
            public string CasingName { get; set; }

            [JsonProperty("casingEjectPower", NullValueHandling = NullValueHandling.Ignore)]
            public long? CasingEjectPower { get; set; }

            [JsonProperty("casingMass", NullValueHandling = NullValueHandling.Ignore)]
            public double? CasingMass { get; set; }

            [JsonProperty("casingSounds", NullValueHandling = NullValueHandling.Ignore)]
            public CasingSounds? CasingSounds { get; set; }

            [JsonProperty("ProjectileCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? ProjectileCount { get; set; }

            [JsonProperty("InitialSpeed", NullValueHandling = NullValueHandling.Ignore)]
            public long? InitialSpeed { get; set; }

            [JsonProperty("PenetrationChance", NullValueHandling = NullValueHandling.Ignore)]
            public double? PenetrationChance { get; set; }

            [JsonProperty("RicochetChance", NullValueHandling = NullValueHandling.Ignore)]
            public double? RicochetChance { get; set; }

            [JsonProperty("FragmentationChance", NullValueHandling = NullValueHandling.Ignore)]
            public double? FragmentationChance { get; set; }

            [JsonProperty("BallisticCoeficient", NullValueHandling = NullValueHandling.Ignore)]
            public double? BallisticCoeficient { get; set; }

            [JsonProperty("Deterioration", NullValueHandling = NullValueHandling.Ignore)]
            public long? Deterioration { get; set; }

            [JsonProperty("Grids", NullValueHandling = NullValueHandling.Ignore)]
            public Grid[] Grids { get; set; }

            [JsonProperty("Slots", NullValueHandling = NullValueHandling.Ignore)]
            public Slot[] Slots { get; set; }

            [JsonProperty("Durability", NullValueHandling = NullValueHandling.Ignore)]
            public long? Durability { get; set; }

            [JsonProperty("Accuracy", NullValueHandling = NullValueHandling.Ignore)]
            public long? Accuracy { get; set; }

            [JsonProperty("Recoil", NullValueHandling = NullValueHandling.Ignore)]
            public double? Recoil { get; set; }

            [JsonProperty("Loudness", NullValueHandling = NullValueHandling.Ignore)]
            public long? Loudness { get; set; }

            [JsonProperty("EffectiveDistance", NullValueHandling = NullValueHandling.Ignore)]
            public long? EffectiveDistance { get; set; }

            [JsonProperty("Ergonomics", NullValueHandling = NullValueHandling.Ignore)]
            public double? Ergonomics { get; set; }

            [JsonProperty("Velocity", NullValueHandling = NullValueHandling.Ignore)]
            public long? Velocity { get; set; }

            [JsonProperty("RaidModdable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? RaidModdable { get; set; }

            [JsonProperty("ToolModdable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ToolModdable { get; set; }

            [JsonProperty("BlocksFolding", NullValueHandling = NullValueHandling.Ignore)]
            public bool? BlocksFolding { get; set; }

            [JsonProperty("BlocksCollapsible", NullValueHandling = NullValueHandling.Ignore)]
            public bool? BlocksCollapsible { get; set; }

            [JsonProperty("ModesCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? ModesCount { get; set; }

            [JsonProperty("ammoCaliber", NullValueHandling = NullValueHandling.Ignore)]
            public string AmmoCaliber { get; set; }

            [JsonProperty("StackSlots", NullValueHandling = NullValueHandling.Ignore)]
            public Cartridge[] StackSlots { get; set; }

            [JsonProperty("modDurab", NullValueHandling = NullValueHandling.Ignore)]
            public long? ModDurab { get; set; }

            [JsonProperty("muzzleModType", NullValueHandling = NullValueHandling.Ignore)]
            public MuzzleModType? MuzzleModType { get; set; }

            [JsonProperty("weapClass", NullValueHandling = NullValueHandling.Ignore)]
            public string WeapClass { get; set; }

            [JsonProperty("weapUseType", NullValueHandling = NullValueHandling.Ignore)]
            public WeapUseType? WeapUseType { get; set; }

            [JsonProperty("weapFireType", NullValueHandling = NullValueHandling.Ignore)]
            public WeapFireType[] WeapFireType { get; set; }

            [JsonProperty("MaxDurability", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxDurability { get; set; }

            [JsonProperty("OperatingResource", NullValueHandling = NullValueHandling.Ignore)]
            public long? OperatingResource { get; set; }

            [JsonProperty("RepairComplexity", NullValueHandling = NullValueHandling.Ignore)]
            public long? RepairComplexity { get; set; }

            [JsonProperty("durabSpawnMin", NullValueHandling = NullValueHandling.Ignore)]
            public long? DurabSpawnMin { get; set; }

            [JsonProperty("durabSpawnMax", NullValueHandling = NullValueHandling.Ignore)]
            public long? DurabSpawnMax { get; set; }

            [JsonProperty("isFastReload", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsFastReload { get; set; }

            [JsonProperty("RecoilForceUp", NullValueHandling = NullValueHandling.Ignore)]
            public long? RecoilForceUp { get; set; }

            [JsonProperty("RecoilForceBack", NullValueHandling = NullValueHandling.Ignore)]
            public long? RecoilForceBack { get; set; }

            [JsonProperty("Convergence", NullValueHandling = NullValueHandling.Ignore)]
            public double? Convergence { get; set; }

            [JsonProperty("RecoilAngle", NullValueHandling = NullValueHandling.Ignore)]
            public long? RecoilAngle { get; set; }

            [JsonProperty("RecolDispersion", NullValueHandling = NullValueHandling.Ignore)]
            public long? RecolDispersion { get; set; }

            [JsonProperty("bFirerate", NullValueHandling = NullValueHandling.Ignore)]
            public long? BFirerate { get; set; }

            [JsonProperty("bEffDist", NullValueHandling = NullValueHandling.Ignore)]
            public long? BEffDist { get; set; }

            [JsonProperty("bHearDist", NullValueHandling = NullValueHandling.Ignore)]
            public long? BHearDist { get; set; }

            [JsonProperty("isChamberLoad", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsChamberLoad { get; set; }

            [JsonProperty("chamberAmmoCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? ChamberAmmoCount { get; set; }

            [JsonProperty("isBoltCatch", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsBoltCatch { get; set; }

            [JsonProperty("defMagType", NullValueHandling = NullValueHandling.Ignore)]
            public string DefMagType { get; set; }

            [JsonProperty("shotgunDispersion", NullValueHandling = NullValueHandling.Ignore)]
            public long? ShotgunDispersion { get; set; }

            [JsonProperty("Chambers", NullValueHandling = NullValueHandling.Ignore)]
            public Chamber[] Chambers { get; set; }

            [JsonProperty("CameraRecoil", NullValueHandling = NullValueHandling.Ignore)]
            public double? CameraRecoil { get; set; }

            [JsonProperty("ReloadMode", NullValueHandling = NullValueHandling.Ignore)]
            public ReloadMode? ReloadMode { get; set; }

            [JsonProperty("CenterOfImpact", NullValueHandling = NullValueHandling.Ignore)]
            public double? CenterOfImpact { get; set; }

            [JsonProperty("AimPlane", NullValueHandling = NullValueHandling.Ignore)]
            public double? AimPlane { get; set; }

            [JsonProperty("DeviationCurve", NullValueHandling = NullValueHandling.Ignore)]
            public long? DeviationCurve { get; set; }

            [JsonProperty("DeviationMax", NullValueHandling = NullValueHandling.Ignore)]
            public long? DeviationMax { get; set; }

            [JsonProperty("armorPoints", NullValueHandling = NullValueHandling.Ignore)]
            public long? ArmorPoints { get; set; }

            [JsonProperty("armorClass", NullValueHandling = NullValueHandling.Ignore)]
            public ArmorClass? ArmorClass { get; set; }

            [JsonProperty("speedPenaltyPercent", NullValueHandling = NullValueHandling.Ignore)]
            public long? SpeedPenaltyPercent { get; set; }

            [JsonProperty("mousePenalty", NullValueHandling = NullValueHandling.Ignore)]
            public long? MousePenalty { get; set; }

            [JsonProperty("weaponErgonomicPenalty", NullValueHandling = NullValueHandling.Ignore)]
            public long? WeaponErgonomicPenalty { get; set; }

            [JsonProperty("armorZone", NullValueHandling = NullValueHandling.Ignore)]
            public string[] ArmorZone { get; set; }

            [JsonProperty("medUseTime", NullValueHandling = NullValueHandling.Ignore)]
            public long? MedUseTime { get; set; }

            [JsonProperty("medEffectType", NullValueHandling = NullValueHandling.Ignore)]
            public DEffectType? MedEffectType { get; set; }

            [JsonProperty("MaxHpResource", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxHpResource { get; set; }

            [JsonProperty("hpResourceRate", NullValueHandling = NullValueHandling.Ignore)]
            public long? HpResourceRate { get; set; }

            [JsonProperty("effects_health", NullValueHandling = NullValueHandling.Ignore)]
            public EffectsHealth EffectsHealth { get; set; }

            [JsonProperty("effects_damage", NullValueHandling = NullValueHandling.Ignore)]
            public EffectsDamage EffectsDamage { get; set; }

            [JsonProperty("effects_speed", NullValueHandling = NullValueHandling.Ignore)]
            public EffectsSpeed EffectsSpeed { get; set; }

            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string Type { get; set; }

            [JsonProperty("eqMin", NullValueHandling = NullValueHandling.Ignore)]
            public long? EqMin { get; set; }

            [JsonProperty("eqMax", NullValueHandling = NullValueHandling.Ignore)]
            public long? EqMax { get; set; }

            [JsonProperty("rate", NullValueHandling = NullValueHandling.Ignore)]
            public long? Rate { get; set; }

            [JsonProperty("throwType", NullValueHandling = NullValueHandling.Ignore)]
            public string ThrowType { get; set; }

            [JsonProperty("explEff", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ExplEff { get; set; }

            [JsonProperty("explSounds", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ExplSounds { get; set; }

            [JsonProperty("colSounds", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ColSounds { get; set; }

            [JsonProperty("throwMinDist", NullValueHandling = NullValueHandling.Ignore)]
            public long? ThrowMinDist { get; set; }

            [JsonProperty("throwMaxDist", NullValueHandling = NullValueHandling.Ignore)]
            public long? ThrowMaxDist { get; set; }

            [JsonProperty("explRadius", NullValueHandling = NullValueHandling.Ignore)]
            public long? ExplRadius { get; set; }

            [JsonProperty("explDelay", NullValueHandling = NullValueHandling.Ignore)]
            public double? ExplDelay { get; set; }

            [JsonProperty("throwDamMin", NullValueHandling = NullValueHandling.Ignore)]
            public long? ThrowDamMin { get; set; }

            [JsonProperty("throwDamMax", NullValueHandling = NullValueHandling.Ignore)]
            public long? ThrowDamMax { get; set; }

            [JsonProperty("contusionDist", NullValueHandling = NullValueHandling.Ignore)]
            public long? ContusionDist { get; set; }

            [JsonProperty("contMinTime", NullValueHandling = NullValueHandling.Ignore)]
            public long? ContMinTime { get; set; }

            [JsonProperty("contMaxType", NullValueHandling = NullValueHandling.Ignore)]
            public long? ContMaxType { get; set; }

            [JsonProperty("throwDamPenetr", NullValueHandling = NullValueHandling.Ignore)]
            public long? ThrowDamPenetr { get; set; }

            [JsonProperty("isFlash", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsFlash { get; set; }

            [JsonProperty("isStun", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsStun { get; set; }

            [JsonProperty("isDesorient", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsDesorient { get; set; }

            [JsonProperty("throwEffMinTime", NullValueHandling = NullValueHandling.Ignore)]
            public long? ThrowEffMinTime { get; set; }

            [JsonProperty("throwEffMaxTime", NullValueHandling = NullValueHandling.Ignore)]
            public long? ThrowEffMaxTime { get; set; }

            [JsonProperty("throwSensMin", NullValueHandling = NullValueHandling.Ignore)]
            public long? ThrowSensMin { get; set; }

            [JsonProperty("throwSensMax", NullValueHandling = NullValueHandling.Ignore)]
            public long? ThrowSensMax { get; set; }

            [JsonProperty("smokeColor", NullValueHandling = NullValueHandling.Ignore)]
            public bool? SmokeColor { get; set; }

            [JsonProperty("smokeTime", NullValueHandling = NullValueHandling.Ignore)]
            public long? SmokeTime { get; set; }

            [JsonProperty("sonarPeriod", NullValueHandling = NullValueHandling.Ignore)]
            public long? SonarPeriod { get; set; }

            [JsonProperty("sonarTime", NullValueHandling = NullValueHandling.Ignore)]
            public long? SonarTime { get; set; }

            [JsonProperty("MinExplosionDistance", NullValueHandling = NullValueHandling.Ignore)]
            public long? MinExplosionDistance { get; set; }

            [JsonProperty("MaxExplosionDistance", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxExplosionDistance { get; set; }

            [JsonProperty("FragmentsCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? FragmentsCount { get; set; }

            [JsonProperty("MinFragmentDamage", NullValueHandling = NullValueHandling.Ignore)]
            public long? MinFragmentDamage { get; set; }

            [JsonProperty("MaxFragmentDamage", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxFragmentDamage { get; set; }

            [JsonProperty("foodUseTime", NullValueHandling = NullValueHandling.Ignore)]
            public long? FoodUseTime { get; set; }

            [JsonProperty("foodEffectType", NullValueHandling = NullValueHandling.Ignore)]
            public FoodEffectType? FoodEffectType { get; set; }

            [JsonProperty("MaxResource", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxResource { get; set; }

            [JsonProperty("sightModType", NullValueHandling = NullValueHandling.Ignore)]
            public SightModType? SightModType { get; set; }

            [JsonProperty("variableZoom", NullValueHandling = NullValueHandling.Ignore)]
            public bool? VariableZoom { get; set; }

            [JsonProperty("varZoomCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? VarZoomCount { get; set; }

            [JsonProperty("varZoomAdd", NullValueHandling = NullValueHandling.Ignore)]
            public long? VarZoomAdd { get; set; }

            [JsonProperty("aimingSensitivity", NullValueHandling = NullValueHandling.Ignore)]
            public double? AimingSensitivity { get; set; }

            [JsonProperty("IsShoulderContact", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsShoulderContact { get; set; }

            [JsonProperty("apResource", NullValueHandling = NullValueHandling.Ignore)]
            public long? ApResource { get; set; }

            [JsonProperty("krResource", NullValueHandling = NullValueHandling.Ignore)]
            public long? KrResource { get; set; }

            [JsonProperty("knifeHitDelay", NullValueHandling = NullValueHandling.Ignore)]
            public long? KnifeHitDelay { get; set; }

            [JsonProperty("knifeHitSlashRate", NullValueHandling = NullValueHandling.Ignore)]
            public long? KnifeHitSlashRate { get; set; }

            [JsonProperty("knifeHitStabRate", NullValueHandling = NullValueHandling.Ignore)]
            public long? KnifeHitStabRate { get; set; }

            [JsonProperty("knifeHitRadius", NullValueHandling = NullValueHandling.Ignore)]
            public double? KnifeHitRadius { get; set; }

            [JsonProperty("knifeHitSlashDam", NullValueHandling = NullValueHandling.Ignore)]
            public long? KnifeHitSlashDam { get; set; }

            [JsonProperty("knifeHitStabDam", NullValueHandling = NullValueHandling.Ignore)]
            public long? KnifeHitStabDam { get; set; }

            [JsonProperty("knifeDurab", NullValueHandling = NullValueHandling.Ignore)]
            public long? KnifeDurab { get; set; }

            [JsonProperty("magAnimationIndex", NullValueHandling = NullValueHandling.Ignore)]
            public long? MagAnimationIndex { get; set; }

            [JsonProperty("Cartridges", NullValueHandling = NullValueHandling.Ignore)]
            public Cartridge[] Cartridges { get; set; }

            [JsonProperty("CanFast", NullValueHandling = NullValueHandling.Ignore)]
            public bool? CanFast { get; set; }

            [JsonProperty("CanHit", NullValueHandling = NullValueHandling.Ignore)]
            public bool? CanHit { get; set; }

            [JsonProperty("CanAdmin", NullValueHandling = NullValueHandling.Ignore)]
            public bool? CanAdmin { get; set; }

            [JsonProperty("containType", NullValueHandling = NullValueHandling.Ignore)]
            public object[] ContainType { get; set; }

            [JsonProperty("sizeWidth", NullValueHandling = NullValueHandling.Ignore)]
            public long? SizeWidth { get; set; }

            [JsonProperty("sizeHeight", NullValueHandling = NullValueHandling.Ignore)]
            public long? SizeHeight { get; set; }

            [JsonProperty("isSecured", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsSecured { get; set; }

            [JsonProperty("spawnTypes", NullValueHandling = NullValueHandling.Ignore)]
            public MuzzleModType? SpawnTypes { get; set; }

            [JsonProperty("lootFilter", NullValueHandling = NullValueHandling.Ignore)]
            public object[] LootFilter { get; set; }

            [JsonProperty("spawnRarity", NullValueHandling = NullValueHandling.Ignore)]
            public SpawnRarity? SpawnRarity { get; set; }

            [JsonProperty("minCountSpawn", NullValueHandling = NullValueHandling.Ignore)]
            public long? MinCountSpawn { get; set; }

            [JsonProperty("maxCountSpawn", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxCountSpawn { get; set; }

            [JsonProperty("openedByKeyID", NullValueHandling = NullValueHandling.Ignore)]
            public object[] OpenedByKeyId { get; set; }

            [JsonProperty("SpawnFilter", NullValueHandling = NullValueHandling.Ignore)]
            public string[] SpawnFilter { get; set; }

            [JsonProperty("KeyIds", NullValueHandling = NullValueHandling.Ignore)]
            public string[] KeyIds { get; set; }

            [JsonProperty("ConfigPath", NullValueHandling = NullValueHandling.Ignore)]
            public ConfigPath ConfigPath { get; set; }

            [JsonProperty("MaxMarkersCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxMarkersCount { get; set; }

            [JsonProperty("scaleMin", NullValueHandling = NullValueHandling.Ignore)]
            public double? ScaleMin { get; set; }

            [JsonProperty("scaleMax", NullValueHandling = NullValueHandling.Ignore)]
            public long? ScaleMax { get; set; }
        }

        public partial class Cartridge
        {
            [JsonProperty("_name")]
            public CartridgeName Name { get; set; }

            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("_parent")]
            public string Parent { get; set; }

            [JsonProperty("_max_count")]
            public long MaxCount { get; set; }

            [JsonProperty("_props")]
            public CartridgeProps Props { get; set; }

            [JsonProperty("_proto")]
            public CartridgeProto Proto { get; set; }
        }

        public partial class CartridgeProps
        {
            [JsonProperty("filters")]
            public PurpleFilter[] Filters { get; set; }
        }

        public partial class PurpleFilter
        {
            [JsonProperty("Filter")]
            public string[] Filter { get; set; }
        }

        public partial class Chamber
        {
            [JsonProperty("_name")]
            public ChamberName Name { get; set; }

            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("_parent")]
            public string Parent { get; set; }

            [JsonProperty("_props")]
            public ChamberProps Props { get; set; }

            [JsonProperty("_required")]
            public bool ChamberRequired { get; set; }

            [JsonProperty("_proto")]
            public ChamberProto Proto { get; set; }
        }

        public partial class ChamberProps
        {
            [JsonProperty("filters")]
            public FluffyFilter[] Filters { get; set; }
        }

        public partial class FluffyFilter
        {
            [JsonProperty("Filter")]
            public string[] Filter { get; set; }

            [JsonProperty("MaxStackCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxStackCount { get; set; }
        }

        public partial class ConfigPath
        {
            [JsonProperty("path")]
            public string Path { get; set; }

            [JsonProperty("rcid")]
            public string Rcid { get; set; }
        }

        public partial class EffectsDamage
        {
            [JsonProperty("bloodloss")]
            public Bloodloss Bloodloss { get; set; }

            [JsonProperty("fracture")]
            public Bloodloss Fracture { get; set; }

            [JsonProperty("pain")]
            public Bloodloss Pain { get; set; }

            [JsonProperty("contusion")]
            public Bloodloss Contusion { get; set; }

            [JsonProperty("toxication")]
            public Bloodloss Toxication { get; set; }

            [JsonProperty("radExposure")]
            public Bloodloss RadExposure { get; set; }
        }

        public partial class Bloodloss
        {
            [JsonProperty("remove")]
            public bool Remove { get; set; }

            [JsonProperty("time")]
            public long Time { get; set; }

            [JsonProperty("duration")]
            public long Duration { get; set; }
        }

        public partial class EffectsHealth
        {
            [JsonProperty("common")]
            public ArmLeft Common { get; set; }

            [JsonProperty("head")]
            public ArmLeft Head { get; set; }

            [JsonProperty("arm_left")]
            public ArmLeft ArmLeft { get; set; }

            [JsonProperty("arm_right")]
            public ArmLeft ArmRight { get; set; }

            [JsonProperty("chest")]
            public ArmLeft Chest { get; set; }

            [JsonProperty("tummy")]
            public ArmLeft Tummy { get; set; }

            [JsonProperty("leg_left")]
            public ArmLeft LegLeft { get; set; }

            [JsonProperty("leg_right")]
            public ArmLeft LegRight { get; set; }

            [JsonProperty("energy")]
            public ArmLeft Energy { get; set; }

            [JsonProperty("hydration")]
            public ArmLeft Hydration { get; set; }
        }

        public partial class ArmLeft
        {
            [JsonProperty("value")]
            public long Value { get; set; }

            [JsonProperty("percent")]
            public bool Percent { get; set; }

            [JsonProperty("time")]
            public long Time { get; set; }

            [JsonProperty("duration")]
            public long Duration { get; set; }
        }

        public partial class EffectsSpeed
        {
            [JsonProperty("mobility")]
            public ArmLeft Mobility { get; set; }

            [JsonProperty("recoil")]
            public ArmLeft Recoil { get; set; }

            [JsonProperty("reloadSpeed")]
            public ArmLeft ReloadSpeed { get; set; }

            [JsonProperty("lootSpeed")]
            public ArmLeft LootSpeed { get; set; }

            [JsonProperty("unlockSpeed")]
            public ArmLeft UnlockSpeed { get; set; }
        }

        public partial class Grid
        {
            [JsonProperty("_name")]
            public string Name { get; set; }

            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("_parent")]
            public string Parent { get; set; }

            [JsonProperty("_props")]
            public GridProps Props { get; set; }

            [JsonProperty("_proto")]
            public GridProto Proto { get; set; }
        }

        public partial class GridProps
        {
            [JsonProperty("filters")]
            public PurpleFilter[] Filters { get; set; }

            [JsonProperty("cellsH")]
            public long CellsH { get; set; }

            [JsonProperty("cellsV")]
            public long CellsV { get; set; }

            [JsonProperty("maxCount")]
            public long MaxCount { get; set; }

            [JsonProperty("maxWeight")]
            public long MaxWeight { get; set; }
        }

        public partial class Slot
        {
            [JsonProperty("_name")]
            public string Name { get; set; }

            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("_parent")]
            public string Parent { get; set; }

            [JsonProperty("_props")]
            public SlotProps Props { get; set; }

            [JsonProperty("_required")]
            public bool SlotRequired { get; set; }

            [JsonProperty("_proto")]
            public ChamberProto Proto { get; set; }
        }

        public partial class SlotProps
        {
            [JsonProperty("filters")]
            public TentacledFilter[] Filters { get; set; }
        }

        public partial class TentacledFilter
        {
            [JsonProperty("Shift", NullValueHandling = NullValueHandling.Ignore)]
            public long? Shift { get; set; }

            [JsonProperty("Filter")]
            public string[] Filter { get; set; }

            [JsonProperty("AnimationIndex", NullValueHandling = NullValueHandling.Ignore)]
            public long? AnimationIndex { get; set; }
        }

        public enum AmmoSfx { Standart, Tracer, TracerRed };

        public enum AmmoType { Buckshot, Bullet, Grenade };

        public enum BackgroundColor { Black, Blue, Default, Green, Grey, Orange, Red, Violet, Yellow };

        public enum CartridgeName { Cartridges };

        public enum CartridgeProto { The5748538B2459770Af276A261 };

        public enum CasingSounds { PistolSmall, Rifle556, Rifle762, ShotgunBig, The40Mmgrenade };

        public enum ChamberName { PatronInWeapon, PatronInWeapon001, PatronInWeapon002 };

        public enum ChamberProto { The55D30C394Bdc2Dae468B4577, The55D30C4C4Bdc2Db4468B457E, The55D4Af244Bdc2D962F8B4571, The55D721144Bdc2D89028B456F };

        public enum DEffectType { AfterUse, DuringUse };

        public enum GridProto { The55D329C24Bdc2D892F8B4567 };

        public enum Rarity { Common, NotExist, Rare, Superrare };

        public enum ReloadMode { ExternalMagazine, InternalMagazine, OnlyBarrel };

        public enum SightModType { Hybrid, Iron, Optic, Reflex };

        public enum WeapFireType { Doublet, Fullauto, Single };

        public enum WeapUseType { Primary, Secondary };

        public enum TypeEnum { Item, Node };

        public partial struct ArmorClass
        {
            public bool? Bool;
            public long? Integer;

            public static implicit operator ArmorClass(bool Bool) => new ArmorClass { Bool = Bool };
            public static implicit operator ArmorClass(long Integer) => new ArmorClass { Integer = Integer };
        }

        public partial struct FoodEffectType
        {
            public bool? Bool;
            public DEffectType? Enum;

            public static implicit operator FoodEffectType(bool Bool) => new FoodEffectType { Bool = Bool };
            public static implicit operator FoodEffectType(DEffectType Enum) => new FoodEffectType { Enum = Enum };
        }

        public partial struct MuzzleModType
        {
            public bool? Bool;
            public string String;

            public static implicit operator MuzzleModType(bool Bool) => new MuzzleModType { Bool = Bool };
            public static implicit operator MuzzleModType(string String) => new MuzzleModType { String = String };
        }

        public partial struct SpawnRarity
        {
            public bool? Bool;
            public Rarity? Enum;

            public static implicit operator SpawnRarity(bool Bool) => new SpawnRarity { Bool = Bool };
            public static implicit operator SpawnRarity(Rarity Enum) => new SpawnRarity { Enum = Enum };
        }

        public partial class Base
        {
            public static Base FromJson(string json) => JsonConvert.DeserializeObject<Base>(json, Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                BackgroundColorConverter.Singleton,
                CartridgeNameConverter.Singleton,
                CartridgeProtoConverter.Singleton,
                ChamberNameConverter.Singleton,
                ChamberProtoConverter.Singleton,
                GridProtoConverter.Singleton,
                RarityConverter.Singleton,
                ReloadModeConverter.Singleton,
                AmmoSfxConverter.Singleton,
                AmmoTypeConverter.Singleton,
                ArmorClassConverter.Singleton,
                CasingSoundsConverter.Singleton,
                FoodEffectTypeConverter.Singleton,
                DEffectTypeConverter.Singleton,
                MuzzleModTypeConverter.Singleton,
                SightModTypeConverter.Singleton,
                SpawnRarityConverter.Singleton,
                WeapFireTypeConverter.Singleton,
                WeapUseTypeConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class BackgroundColorConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(BackgroundColor) || t == typeof(BackgroundColor?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "black":
                        return BackgroundColor.Black;
                    case "blue":
                        return BackgroundColor.Blue;
                    case "default":
                        return BackgroundColor.Default;
                    case "green":
                        return BackgroundColor.Green;
                    case "grey":
                        return BackgroundColor.Grey;
                    case "orange":
                        return BackgroundColor.Orange;
                    case "red":
                        return BackgroundColor.Red;
                    case "violet":
                        return BackgroundColor.Violet;
                    case "yellow":
                        return BackgroundColor.Yellow;
                }
                throw new Exception("Cannot unmarshal type BackgroundColor");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (BackgroundColor)untypedValue;
                switch (value)
                {
                    case BackgroundColor.Black:
                        serializer.Serialize(writer, "black");
                        return;
                    case BackgroundColor.Blue:
                        serializer.Serialize(writer, "blue");
                        return;
                    case BackgroundColor.Default:
                        serializer.Serialize(writer, "default");
                        return;
                    case BackgroundColor.Green:
                        serializer.Serialize(writer, "green");
                        return;
                    case BackgroundColor.Grey:
                        serializer.Serialize(writer, "grey");
                        return;
                    case BackgroundColor.Orange:
                        serializer.Serialize(writer, "orange");
                        return;
                    case BackgroundColor.Red:
                        serializer.Serialize(writer, "red");
                        return;
                    case BackgroundColor.Violet:
                        serializer.Serialize(writer, "violet");
                        return;
                    case BackgroundColor.Yellow:
                        serializer.Serialize(writer, "yellow");
                        return;
                }
                throw new Exception("Cannot marshal type BackgroundColor");
            }

            public static readonly BackgroundColorConverter Singleton = new BackgroundColorConverter();
        }

        internal class CartridgeNameConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(CartridgeName) || t == typeof(CartridgeName?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "cartridges")
                {
                    return CartridgeName.Cartridges;
                }
                throw new Exception("Cannot unmarshal type CartridgeName");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (CartridgeName)untypedValue;
                if (value == CartridgeName.Cartridges)
                {
                    serializer.Serialize(writer, "cartridges");
                    return;
                }
                throw new Exception("Cannot marshal type CartridgeName");
            }

            public static readonly CartridgeNameConverter Singleton = new CartridgeNameConverter();
        }

        internal class CartridgeProtoConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(CartridgeProto) || t == typeof(CartridgeProto?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "5748538b2459770af276a261")
                {
                    return CartridgeProto.The5748538B2459770Af276A261;
                }
                throw new Exception("Cannot unmarshal type CartridgeProto");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (CartridgeProto)untypedValue;
                if (value == CartridgeProto.The5748538B2459770Af276A261)
                {
                    serializer.Serialize(writer, "5748538b2459770af276a261");
                    return;
                }
                throw new Exception("Cannot marshal type CartridgeProto");
            }

            public static readonly CartridgeProtoConverter Singleton = new CartridgeProtoConverter();
        }

        internal class ChamberNameConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ChamberName) || t == typeof(ChamberName?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "patron_in_weapon":
                        return ChamberName.PatronInWeapon;
                    case "patron_in_weapon001":
                        return ChamberName.PatronInWeapon001;
                    case "patron_in_weapon002":
                        return ChamberName.PatronInWeapon002;
                }
                throw new Exception("Cannot unmarshal type ChamberName");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ChamberName)untypedValue;
                switch (value)
                {
                    case ChamberName.PatronInWeapon:
                        serializer.Serialize(writer, "patron_in_weapon");
                        return;
                    case ChamberName.PatronInWeapon001:
                        serializer.Serialize(writer, "patron_in_weapon001");
                        return;
                    case ChamberName.PatronInWeapon002:
                        serializer.Serialize(writer, "patron_in_weapon002");
                        return;
                }
                throw new Exception("Cannot marshal type ChamberName");
            }

            public static readonly ChamberNameConverter Singleton = new ChamberNameConverter();
        }

        internal class ChamberProtoConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ChamberProto) || t == typeof(ChamberProto?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "55d30c394bdc2dae468b4577":
                        return ChamberProto.The55D30C394Bdc2Dae468B4577;
                    case "55d30c4c4bdc2db4468b457e":
                        return ChamberProto.The55D30C4C4Bdc2Db4468B457E;
                    case "55d4af244bdc2d962f8b4571":
                        return ChamberProto.The55D4Af244Bdc2D962F8B4571;
                    case "55d721144bdc2d89028b456f":
                        return ChamberProto.The55D721144Bdc2D89028B456F;
                }
                throw new Exception("Cannot unmarshal type ChamberProto");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ChamberProto)untypedValue;
                switch (value)
                {
                    case ChamberProto.The55D30C394Bdc2Dae468B4577:
                        serializer.Serialize(writer, "55d30c394bdc2dae468b4577");
                        return;
                    case ChamberProto.The55D30C4C4Bdc2Db4468B457E:
                        serializer.Serialize(writer, "55d30c4c4bdc2db4468b457e");
                        return;
                    case ChamberProto.The55D4Af244Bdc2D962F8B4571:
                        serializer.Serialize(writer, "55d4af244bdc2d962f8b4571");
                        return;
                    case ChamberProto.The55D721144Bdc2D89028B456F:
                        serializer.Serialize(writer, "55d721144bdc2d89028b456f");
                        return;
                }
                throw new Exception("Cannot marshal type ChamberProto");
            }

            public static readonly ChamberProtoConverter Singleton = new ChamberProtoConverter();
        }

        internal class GridProtoConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(GridProto) || t == typeof(GridProto?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "55d329c24bdc2d892f8b4567")
                {
                    return GridProto.The55D329C24Bdc2D892F8B4567;
                }
                throw new Exception("Cannot unmarshal type GridProto");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (GridProto)untypedValue;
                if (value == GridProto.The55D329C24Bdc2D892F8B4567)
                {
                    serializer.Serialize(writer, "55d329c24bdc2d892f8b4567");
                    return;
                }
                throw new Exception("Cannot marshal type GridProto");
            }

            public static readonly GridProtoConverter Singleton = new GridProtoConverter();
        }

        internal class RarityConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Rarity) || t == typeof(Rarity?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Common":
                        return Rarity.Common;
                    case "Not_exist":
                        return Rarity.NotExist;
                    case "Rare":
                        return Rarity.Rare;
                    case "Superrare":
                        return Rarity.Superrare;
                }
                throw new Exception("Cannot unmarshal type Rarity");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Rarity)untypedValue;
                switch (value)
                {
                    case Rarity.Common:
                        serializer.Serialize(writer, "Common");
                        return;
                    case Rarity.NotExist:
                        serializer.Serialize(writer, "Not_exist");
                        return;
                    case Rarity.Rare:
                        serializer.Serialize(writer, "Rare");
                        return;
                    case Rarity.Superrare:
                        serializer.Serialize(writer, "Superrare");
                        return;
                }
                throw new Exception("Cannot marshal type Rarity");
            }

            public static readonly RarityConverter Singleton = new RarityConverter();
        }

        internal class ReloadModeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ReloadMode) || t == typeof(ReloadMode?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "ExternalMagazine":
                        return ReloadMode.ExternalMagazine;
                    case "InternalMagazine":
                        return ReloadMode.InternalMagazine;
                    case "OnlyBarrel":
                        return ReloadMode.OnlyBarrel;
                }
                throw new Exception("Cannot unmarshal type ReloadMode");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ReloadMode)untypedValue;
                switch (value)
                {
                    case ReloadMode.ExternalMagazine:
                        serializer.Serialize(writer, "ExternalMagazine");
                        return;
                    case ReloadMode.InternalMagazine:
                        serializer.Serialize(writer, "InternalMagazine");
                        return;
                    case ReloadMode.OnlyBarrel:
                        serializer.Serialize(writer, "OnlyBarrel");
                        return;
                }
                throw new Exception("Cannot marshal type ReloadMode");
            }

            public static readonly ReloadModeConverter Singleton = new ReloadModeConverter();
        }

        internal class AmmoSfxConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(AmmoSfx) || t == typeof(AmmoSfx?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "standart":
                        return AmmoSfx.Standart;
                    case "tracer":
                        return AmmoSfx.Tracer;
                    case "tracer_red":
                        return AmmoSfx.TracerRed;
                }
                throw new Exception("Cannot unmarshal type AmmoSfx");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (AmmoSfx)untypedValue;
                switch (value)
                {
                    case AmmoSfx.Standart:
                        serializer.Serialize(writer, "standart");
                        return;
                    case AmmoSfx.Tracer:
                        serializer.Serialize(writer, "tracer");
                        return;
                    case AmmoSfx.TracerRed:
                        serializer.Serialize(writer, "tracer_red");
                        return;
                }
                throw new Exception("Cannot marshal type AmmoSfx");
            }

            public static readonly AmmoSfxConverter Singleton = new AmmoSfxConverter();
        }

        internal class AmmoTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(AmmoType) || t == typeof(AmmoType?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "buckshot":
                        return AmmoType.Buckshot;
                    case "bullet":
                        return AmmoType.Bullet;
                    case "grenade":
                        return AmmoType.Grenade;
                }
                throw new Exception("Cannot unmarshal type AmmoType");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (AmmoType)untypedValue;
                switch (value)
                {
                    case AmmoType.Buckshot:
                        serializer.Serialize(writer, "buckshot");
                        return;
                    case AmmoType.Bullet:
                        serializer.Serialize(writer, "bullet");
                        return;
                    case AmmoType.Grenade:
                        serializer.Serialize(writer, "grenade");
                        return;
                }
                throw new Exception("Cannot marshal type AmmoType");
            }

            public static readonly AmmoTypeConverter Singleton = new AmmoTypeConverter();
        }

        internal class ArmorClassConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ArmorClass) || t == typeof(ArmorClass?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Boolean:
                        var boolValue = serializer.Deserialize<bool>(reader);
                        return new ArmorClass { Bool = boolValue };
                    case JsonToken.String:
                    case JsonToken.Date:
                        var stringValue = serializer.Deserialize<string>(reader);
                        long l;
                        if (Int64.TryParse(stringValue, out l))
                        {
                            return new ArmorClass { Integer = l };
                        }
                        break;
                }
                throw new Exception("Cannot unmarshal type ArmorClass");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (ArmorClass)untypedValue;
                if (value.Bool != null)
                {
                    serializer.Serialize(writer, value.Bool.Value);
                    return;
                }
                if (value.Integer != null)
                {
                    serializer.Serialize(writer, value.Integer.Value.ToString());
                    return;
                }
                throw new Exception("Cannot marshal type ArmorClass");
            }

            public static readonly ArmorClassConverter Singleton = new ArmorClassConverter();
        }

        internal class CasingSoundsConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(CasingSounds) || t == typeof(CasingSounds?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "40mmgrenade":
                        return CasingSounds.The40Mmgrenade;
                    case "pistol_small":
                        return CasingSounds.PistolSmall;
                    case "rifle556":
                        return CasingSounds.Rifle556;
                    case "rifle762":
                        return CasingSounds.Rifle762;
                    case "shotgun_big":
                        return CasingSounds.ShotgunBig;
                }
                throw new Exception("Cannot unmarshal type CasingSounds");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (CasingSounds)untypedValue;
                switch (value)
                {
                    case CasingSounds.The40Mmgrenade:
                        serializer.Serialize(writer, "40mmgrenade");
                        return;
                    case CasingSounds.PistolSmall:
                        serializer.Serialize(writer, "pistol_small");
                        return;
                    case CasingSounds.Rifle556:
                        serializer.Serialize(writer, "rifle556");
                        return;
                    case CasingSounds.Rifle762:
                        serializer.Serialize(writer, "rifle762");
                        return;
                    case CasingSounds.ShotgunBig:
                        serializer.Serialize(writer, "shotgun_big");
                        return;
                }
                throw new Exception("Cannot marshal type CasingSounds");
            }

            public static readonly CasingSoundsConverter Singleton = new CasingSoundsConverter();
        }

        internal class FoodEffectTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(FoodEffectType) || t == typeof(FoodEffectType?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Boolean:
                        var boolValue = serializer.Deserialize<bool>(reader);
                        return new FoodEffectType { Bool = boolValue };
                    case JsonToken.String:
                    case JsonToken.Date:
                        var stringValue = serializer.Deserialize<string>(reader);
                        switch (stringValue)
                        {
                            case "afterUse":
                                return new FoodEffectType { Enum = DEffectType.AfterUse };
                            case "duringUse":
                                return new FoodEffectType { Enum = DEffectType.DuringUse };
                        }
                        break;
                }
                throw new Exception("Cannot unmarshal type FoodEffectType");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (FoodEffectType)untypedValue;
                if (value.Bool != null)
                {
                    serializer.Serialize(writer, value.Bool.Value);
                    return;
                }
                if (value.Enum != null)
                {
                    switch (value.Enum)
                    {
                        case DEffectType.AfterUse:
                            serializer.Serialize(writer, "afterUse");
                            return;
                        case DEffectType.DuringUse:
                            serializer.Serialize(writer, "duringUse");
                            return;
                    }
                }
                throw new Exception("Cannot marshal type FoodEffectType");
            }

            public static readonly FoodEffectTypeConverter Singleton = new FoodEffectTypeConverter();
        }

        internal class DEffectTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(DEffectType) || t == typeof(DEffectType?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "afterUse":
                        return DEffectType.AfterUse;
                    case "duringUse":
                        return DEffectType.DuringUse;
                }
                throw new Exception("Cannot unmarshal type DEffectType");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (DEffectType)untypedValue;
                switch (value)
                {
                    case DEffectType.AfterUse:
                        serializer.Serialize(writer, "afterUse");
                        return;
                    case DEffectType.DuringUse:
                        serializer.Serialize(writer, "duringUse");
                        return;
                }
                throw new Exception("Cannot marshal type DEffectType");
            }

            public static readonly DEffectTypeConverter Singleton = new DEffectTypeConverter();
        }

        internal class MuzzleModTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(MuzzleModType) || t == typeof(MuzzleModType?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Boolean:
                        var boolValue = serializer.Deserialize<bool>(reader);
                        return new MuzzleModType { Bool = boolValue };
                    case JsonToken.String:
                    case JsonToken.Date:
                        var stringValue = serializer.Deserialize<string>(reader);
                        return new MuzzleModType { String = stringValue };
                }
                throw new Exception("Cannot unmarshal type MuzzleModType");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (MuzzleModType)untypedValue;
                if (value.Bool != null)
                {
                    serializer.Serialize(writer, value.Bool.Value);
                    return;
                }
                if (value.String != null)
                {
                    serializer.Serialize(writer, value.String);
                    return;
                }
                throw new Exception("Cannot marshal type MuzzleModType");
            }

            public static readonly MuzzleModTypeConverter Singleton = new MuzzleModTypeConverter();
        }

        internal class SightModTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(SightModType) || t == typeof(SightModType?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "hybrid":
                        return SightModType.Hybrid;
                    case "iron":
                        return SightModType.Iron;
                    case "optic":
                        return SightModType.Optic;
                    case "reflex":
                        return SightModType.Reflex;
                }
                throw new Exception("Cannot unmarshal type SightModType");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (SightModType)untypedValue;
                switch (value)
                {
                    case SightModType.Hybrid:
                        serializer.Serialize(writer, "hybrid");
                        return;
                    case SightModType.Iron:
                        serializer.Serialize(writer, "iron");
                        return;
                    case SightModType.Optic:
                        serializer.Serialize(writer, "optic");
                        return;
                    case SightModType.Reflex:
                        serializer.Serialize(writer, "reflex");
                        return;
                }
                throw new Exception("Cannot marshal type SightModType");
            }

            public static readonly SightModTypeConverter Singleton = new SightModTypeConverter();
        }

        internal class SpawnRarityConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(SpawnRarity) || t == typeof(SpawnRarity?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Boolean:
                        var boolValue = serializer.Deserialize<bool>(reader);
                        return new SpawnRarity { Bool = boolValue };
                    case JsonToken.String:
                    case JsonToken.Date:
                        var stringValue = serializer.Deserialize<string>(reader);
                        switch (stringValue)
                        {
                            case "Common":
                                return new SpawnRarity { Enum = Rarity.Common };
                            case "Not_exist":
                                return new SpawnRarity { Enum = Rarity.NotExist };
                            case "Rare":
                                return new SpawnRarity { Enum = Rarity.Rare };
                            case "Superrare":
                                return new SpawnRarity { Enum = Rarity.Superrare };
                        }
                        break;
                }
                throw new Exception("Cannot unmarshal type SpawnRarity");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (SpawnRarity)untypedValue;
                if (value.Bool != null)
                {
                    serializer.Serialize(writer, value.Bool.Value);
                    return;
                }
                if (value.Enum != null)
                {
                    switch (value.Enum)
                    {
                        case Rarity.Common:
                            serializer.Serialize(writer, "Common");
                            return;
                        case Rarity.NotExist:
                            serializer.Serialize(writer, "Not_exist");
                            return;
                        case Rarity.Rare:
                            serializer.Serialize(writer, "Rare");
                            return;
                        case Rarity.Superrare:
                            serializer.Serialize(writer, "Superrare");
                            return;
                    }
                }
                throw new Exception("Cannot marshal type SpawnRarity");
            }

            public static readonly SpawnRarityConverter Singleton = new SpawnRarityConverter();
        }

        internal class WeapFireTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(WeapFireType) || t == typeof(WeapFireType?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "doublet":
                        return WeapFireType.Doublet;
                    case "fullauto":
                        return WeapFireType.Fullauto;
                    case "single":
                        return WeapFireType.Single;
                }
                throw new Exception("Cannot unmarshal type WeapFireType");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (WeapFireType)untypedValue;
                switch (value)
                {
                    case WeapFireType.Doublet:
                        serializer.Serialize(writer, "doublet");
                        return;
                    case WeapFireType.Fullauto:
                        serializer.Serialize(writer, "fullauto");
                        return;
                    case WeapFireType.Single:
                        serializer.Serialize(writer, "single");
                        return;
                }
                throw new Exception("Cannot marshal type WeapFireType");
            }

            public static readonly WeapFireTypeConverter Singleton = new WeapFireTypeConverter();
        }

        internal class WeapUseTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(WeapUseType) || t == typeof(WeapUseType?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "primary":
                        return WeapUseType.Primary;
                    case "secondary":
                        return WeapUseType.Secondary;
                }
                throw new Exception("Cannot unmarshal type WeapUseType");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (WeapUseType)untypedValue;
                switch (value)
                {
                    case WeapUseType.Primary:
                        serializer.Serialize(writer, "primary");
                        return;
                    case WeapUseType.Secondary:
                        serializer.Serialize(writer, "secondary");
                        return;
                }
                throw new Exception("Cannot marshal type WeapUseType");
            }

            public static readonly WeapUseTypeConverter Singleton = new WeapUseTypeConverter();
        }

        internal class TypeEnumConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Item":
                        return TypeEnum.Item;
                    case "Node":
                        return TypeEnum.Node;
                }
                throw new Exception("Cannot unmarshal type TypeEnum");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (TypeEnum)untypedValue;
                switch (value)
                {
                    case TypeEnum.Item:
                        serializer.Serialize(writer, "Item");
                        return;
                    case TypeEnum.Node:
                        serializer.Serialize(writer, "Node");
                        return;
                }
                throw new Exception("Cannot marshal type TypeEnum");
            }

            public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
        }
    }
}
