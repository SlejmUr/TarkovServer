using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static EFT.Player;

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
            public double? SpawnChance { get; set; }

            [JsonProperty("CreditsPrice", NullValueHandling = NullValueHandling.Ignore)]
            public long? CreditsPrice { get; set; }

            [JsonProperty("ItemSound", NullValueHandling = NullValueHandling.Ignore)]
            public string ItemSound { get; set; }

            [JsonProperty("Prefab", NullValueHandling = NullValueHandling.Ignore)]
            public Prefab Prefab { get; set; }

            [JsonProperty("UsePrefab", NullValueHandling = NullValueHandling.Ignore)]
            public Prefab UsePrefab { get; set; }

            [JsonProperty("StackObjectsCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? StackObjectsCount { get; set; }

            [JsonProperty("NotShownInSlot", NullValueHandling = NullValueHandling.Ignore)]
            public bool? NotShownInSlot { get; set; }

            [JsonProperty("ExaminedByDefault", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ExaminedByDefault { get; set; }

            [JsonProperty("ExamineTime", NullValueHandling = NullValueHandling.Ignore)]
            public long? ExamineTime { get; set; }

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

            [JsonProperty("QuestItem", NullValueHandling = NullValueHandling.Ignore)]
            public bool? QuestItem { get; set; }

            [JsonProperty("LootExperience", NullValueHandling = NullValueHandling.Ignore)]
            public long? LootExperience { get; set; }

            [JsonProperty("ExamineExperience", NullValueHandling = NullValueHandling.Ignore)]
            public long? ExamineExperience { get; set; }

            [JsonProperty("HideEntrails", NullValueHandling = NullValueHandling.Ignore)]
            public bool? HideEntrails { get; set; }

            [JsonProperty("RepairCost", NullValueHandling = NullValueHandling.Ignore)]
            public long? RepairCost { get; set; }

            [JsonProperty("RepairSpeed", NullValueHandling = NullValueHandling.Ignore)]
            public long? RepairSpeed { get; set; }

            [JsonProperty("ExtraSizeLeft", NullValueHandling = NullValueHandling.Ignore)]
            public long? ExtraSizeLeft { get; set; }

            [JsonProperty("ExtraSizeRight", NullValueHandling = NullValueHandling.Ignore)]
            public long? ExtraSizeRight { get; set; }

            [JsonProperty("ExtraSizeUp", NullValueHandling = NullValueHandling.Ignore)]
            public long? ExtraSizeUp { get; set; }

            [JsonProperty("ExtraSizeDown", NullValueHandling = NullValueHandling.Ignore)]
            public long? ExtraSizeDown { get; set; }

            [JsonProperty("ExtraSizeForceAdd", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ExtraSizeForceAdd { get; set; }

            [JsonProperty("MergesWithChildren", NullValueHandling = NullValueHandling.Ignore)]
            public bool? MergesWithChildren { get; set; }

            [JsonProperty("BannedFromRagfair", NullValueHandling = NullValueHandling.Ignore)]
            public bool? BannedFromRagfair { get; set; }

            [JsonProperty("ConflictingItems", NullValueHandling = NullValueHandling.Ignore)]
            public string[] ConflictingItems { get; set; }

            [JsonProperty("FixedPrice", NullValueHandling = NullValueHandling.Ignore)]
            public bool? FixedPrice { get; set; }

            [JsonProperty("Unlootable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Unlootable { get; set; }

            [JsonProperty("UnlootableFromSlot", NullValueHandling = NullValueHandling.Ignore)]
            public UnlootableFromSlot? UnlootableFromSlot { get; set; }

            [JsonProperty("UnlootableFromSide", NullValueHandling = NullValueHandling.Ignore)]
            public UnlootableFromSide[] UnlootableFromSide { get; set; }

            [JsonProperty("ChangePriceCoef", NullValueHandling = NullValueHandling.Ignore)]
            public long? ChangePriceCoef { get; set; }

            [JsonProperty("AllowSpawnOnLocations", NullValueHandling = NullValueHandling.Ignore)]
            public AllowSpawnOnLocation[] AllowSpawnOnLocations { get; set; }

            [JsonProperty("SendToClient", NullValueHandling = NullValueHandling.Ignore)]
            public bool? SendToClient { get; set; }

            [JsonProperty("DogTagQualities", NullValueHandling = NullValueHandling.Ignore)]
            public bool? DogTagQualities { get; set; }

            [JsonProperty("Grids", NullValueHandling = NullValueHandling.Ignore)]
            public Grid[] Grids { get; set; }

            [JsonProperty("Slots", NullValueHandling = NullValueHandling.Ignore)]
            public Slot[] Slots { get; set; }

            [JsonProperty("KeyIds", NullValueHandling = NullValueHandling.Ignore)]
            public string[] KeyIds { get; set; }

            [JsonProperty("TagColor", NullValueHandling = NullValueHandling.Ignore)]
            public long? TagColor { get; set; }

            [JsonProperty("TagName", NullValueHandling = NullValueHandling.Ignore)]
            public string TagName { get; set; }

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
            public double? Velocity { get; set; }

            [JsonProperty("RaidModdable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? RaidModdable { get; set; }

            [JsonProperty("ToolModdable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ToolModdable { get; set; }

            [JsonProperty("BlocksFolding", NullValueHandling = NullValueHandling.Ignore)]
            public bool? BlocksFolding { get; set; }

            [JsonProperty("BlocksCollapsible", NullValueHandling = NullValueHandling.Ignore)]
            public bool? BlocksCollapsible { get; set; }

            [JsonProperty("IsAnimated", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsAnimated { get; set; }

            [JsonProperty("HasShoulderContact", NullValueHandling = NullValueHandling.Ignore)]
            public bool? HasShoulderContact { get; set; }

            [JsonProperty("SightingRange", NullValueHandling = NullValueHandling.Ignore)]
            public long? SightingRange { get; set; }

            [JsonProperty("ModesCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? ModesCount { get; set; }

            [JsonProperty("muzzleModType", NullValueHandling = NullValueHandling.Ignore)]
            public MuzzleModType? MuzzleModType { get; set; }

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

            [JsonProperty("SightModesCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? SightModesCount { get; set; }

            [JsonProperty("OpticCalibrationDistances")]
            public long[] OpticCalibrationDistances { get; set; }

            [JsonProperty("Intensity", NullValueHandling = NullValueHandling.Ignore)]
            public double? Intensity { get; set; }

            [JsonProperty("Mask", NullValueHandling = NullValueHandling.Ignore)]
            public string Mask { get; set; }

            [JsonProperty("MaskSize", NullValueHandling = NullValueHandling.Ignore)]
            public double? MaskSize { get; set; }

            [JsonProperty("NoiseIntensity", NullValueHandling = NullValueHandling.Ignore)]
            public double? NoiseIntensity { get; set; }

            [JsonProperty("NoiseScale", NullValueHandling = NullValueHandling.Ignore)]
            public long? NoiseScale { get; set; }

            [JsonProperty("Color", NullValueHandling = NullValueHandling.Ignore)]
            public Color Color { get; set; }

            [JsonProperty("DiffuseIntensity", NullValueHandling = NullValueHandling.Ignore)]
            public double? DiffuseIntensity { get; set; }

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

            [JsonProperty("LoadUnloadModifier", NullValueHandling = NullValueHandling.Ignore)]
            public long? LoadUnloadModifier { get; set; }

            [JsonProperty("CheckTimeModifier", NullValueHandling = NullValueHandling.Ignore)]
            public long? CheckTimeModifier { get; set; }

            [JsonProperty("CheckOverride", NullValueHandling = NullValueHandling.Ignore)]
            public long? CheckOverride { get; set; }

            [JsonProperty("ReloadMagType", NullValueHandling = NullValueHandling.Ignore)]
            public ReloadM? ReloadMagType { get; set; }

            [JsonProperty("IsShoulderContact", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsShoulderContact { get; set; }

            [JsonProperty("Foldable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Foldable { get; set; }

            [JsonProperty("Retractable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Retractable { get; set; }

            [JsonProperty("SizeReduceRight", NullValueHandling = NullValueHandling.Ignore)]
            public long? SizeReduceRight { get; set; }

            [JsonProperty("CenterOfImpact", NullValueHandling = NullValueHandling.Ignore)]
            public double? CenterOfImpact { get; set; }

            [JsonProperty("ShotgunDispersion", NullValueHandling = NullValueHandling.Ignore)]
            public double? ShotgunDispersion { get; set; }

            [JsonProperty("IsSilencer", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsSilencer { get; set; }

            [JsonProperty("SearchSound", NullValueHandling = NullValueHandling.Ignore)]
            public string SearchSound { get; set; }

            [JsonProperty("BlocksArmorVest", NullValueHandling = NullValueHandling.Ignore)]
            public bool? BlocksArmorVest { get; set; }

            [JsonProperty("speedPenaltyPercent", NullValueHandling = NullValueHandling.Ignore)]
            public long? SpeedPenaltyPercent { get; set; }

            [JsonProperty("GridLayoutName", NullValueHandling = NullValueHandling.Ignore)]
            public GridLayoutName? GridLayoutName { get; set; }

            [JsonProperty("SpawnFilter", NullValueHandling = NullValueHandling.Ignore)]
            public string[] SpawnFilter { get; set; }

            [JsonProperty("containType", NullValueHandling = NullValueHandling.Ignore)]
            public object[] ContainType { get; set; }

            [JsonProperty("sizeWidth", NullValueHandling = NullValueHandling.Ignore)]
            public long? SizeWidth { get; set; }

            [JsonProperty("sizeHeight", NullValueHandling = NullValueHandling.Ignore)]
            public long? SizeHeight { get; set; }

            [JsonProperty("isSecured", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsSecured { get; set; }

            [JsonProperty("spawnTypes", NullValueHandling = NullValueHandling.Ignore)]
            public string SpawnTypes { get; set; }

            [JsonProperty("lootFilter", NullValueHandling = NullValueHandling.Ignore)]
            public object[] LootFilter { get; set; }

            [JsonProperty("spawnRarity", NullValueHandling = NullValueHandling.Ignore)]
            public string SpawnRarity { get; set; }

            [JsonProperty("minCountSpawn", NullValueHandling = NullValueHandling.Ignore)]
            public long? MinCountSpawn { get; set; }

            [JsonProperty("maxCountSpawn", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxCountSpawn { get; set; }

            [JsonProperty("openedByKeyID", NullValueHandling = NullValueHandling.Ignore)]
            public object[] OpenedByKeyId { get; set; }

            [JsonProperty("RigLayoutName", NullValueHandling = NullValueHandling.Ignore)]
            public string RigLayoutName { get; set; }

            [JsonProperty("MaxDurability", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxDurability { get; set; }

            [JsonProperty("armorZone", NullValueHandling = NullValueHandling.Ignore)]
            public ArmorZone[] ArmorZone { get; set; }

            [JsonProperty("armorClass", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(DecodingChoiceConverter))]
            public long? ArmorClass { get; set; }

            [JsonProperty("mousePenalty", NullValueHandling = NullValueHandling.Ignore)]
            public long? MousePenalty { get; set; }

            [JsonProperty("weaponErgonomicPenalty", NullValueHandling = NullValueHandling.Ignore)]
            public long? WeaponErgonomicPenalty { get; set; }

            [JsonProperty("BluntThroughput", NullValueHandling = NullValueHandling.Ignore)]
            public double? BluntThroughput { get; set; }

            [JsonProperty("ArmorMaterial", NullValueHandling = NullValueHandling.Ignore)]
            public ArmorMaterial? ArmorMaterial { get; set; }

            [JsonProperty("weapClass", NullValueHandling = NullValueHandling.Ignore)]
            public WeapClass? WeapClass { get; set; }

            [JsonProperty("weapUseType", NullValueHandling = NullValueHandling.Ignore)]
            public WeapUseType? WeapUseType { get; set; }

            [JsonProperty("ammoCaliber", NullValueHandling = NullValueHandling.Ignore)]
            public string AmmoCaliber { get; set; }

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

            [JsonProperty("weapFireType", NullValueHandling = NullValueHandling.Ignore)]
            public WeapFireType[] WeapFireType { get; set; }

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

            [JsonProperty("defAmmo", NullValueHandling = NullValueHandling.Ignore)]
            public string DefAmmo { get; set; }

            [JsonProperty("shotgunDispersion", NullValueHandling = NullValueHandling.Ignore)]
            public long? PropsShotgunDispersion { get; set; }

            [JsonProperty("Chambers", NullValueHandling = NullValueHandling.Ignore)]
            public Chamber[] Chambers { get; set; }

            [JsonProperty("CameraRecoil", NullValueHandling = NullValueHandling.Ignore)]
            public double? CameraRecoil { get; set; }

            [JsonProperty("CameraSnap", NullValueHandling = NullValueHandling.Ignore)]
            public double? CameraSnap { get; set; }

            [JsonProperty("ReloadMode", NullValueHandling = NullValueHandling.Ignore)]
            public ReloadM? ReloadMode { get; set; }

            [JsonProperty("AimPlane", NullValueHandling = NullValueHandling.Ignore)]
            public double? AimPlane { get; set; }

            [JsonProperty("DeviationCurve", NullValueHandling = NullValueHandling.Ignore)]
            public long? DeviationCurve { get; set; }

            [JsonProperty("DeviationMax", NullValueHandling = NullValueHandling.Ignore)]
            public long? DeviationMax { get; set; }

            [JsonProperty("TacticalReloadStiffnes", NullValueHandling = NullValueHandling.Ignore)]
            public Blindness TacticalReloadStiffnes { get; set; }

            [JsonProperty("TacticalReloadFixation", NullValueHandling = NullValueHandling.Ignore)]
            public double? TacticalReloadFixation { get; set; }

            [JsonProperty("RecoilCenter", NullValueHandling = NullValueHandling.Ignore)]
            public Blindness RecoilCenter { get; set; }

            [JsonProperty("RotationCenter", NullValueHandling = NullValueHandling.Ignore)]
            public Blindness RotationCenter { get; set; }

            [JsonProperty("RotationCenterNoStock", NullValueHandling = NullValueHandling.Ignore)]
            public Blindness RotationCenterNoStock { get; set; }

            [JsonProperty("FoldedSlot", NullValueHandling = NullValueHandling.Ignore)]
            public FoldedSlot? FoldedSlot { get; set; }

            [JsonProperty("CompactHandling", NullValueHandling = NullValueHandling.Ignore)]
            public bool? CompactHandling { get; set; }

            [JsonProperty("MinRepairDegradation", NullValueHandling = NullValueHandling.Ignore)]
            public long? MinRepairDegradation { get; set; }

            [JsonProperty("MaxRepairDegradation", NullValueHandling = NullValueHandling.Ignore)]
            public double? MaxRepairDegradation { get; set; }

            [JsonProperty("IronSightRange", NullValueHandling = NullValueHandling.Ignore)]
            public long? IronSightRange { get; set; }

            [JsonProperty("MustBoltBeOpennedForExternalReload", NullValueHandling = NullValueHandling.Ignore)]
            public bool? MustBoltBeOpennedForExternalReload { get; set; }

            [JsonProperty("MustBoltBeOpennedForInternalReload", NullValueHandling = NullValueHandling.Ignore)]
            public bool? MustBoltBeOpennedForInternalReload { get; set; }

            [JsonProperty("BoltAction", NullValueHandling = NullValueHandling.Ignore)]
            public bool? BoltAction { get; set; }

            [JsonProperty("HipAccuracyRestorationDelay", NullValueHandling = NullValueHandling.Ignore)]
            public double? HipAccuracyRestorationDelay { get; set; }

            [JsonProperty("HipAccuracyRestorationSpeed", NullValueHandling = NullValueHandling.Ignore)]
            public long? HipAccuracyRestorationSpeed { get; set; }

            [JsonProperty("HipInnaccuracyGain", NullValueHandling = NullValueHandling.Ignore)]
            public double? HipInnaccuracyGain { get; set; }

            [JsonProperty("ManualBoltCatch", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ManualBoltCatch { get; set; }

            [JsonProperty("BlocksEarpiece", NullValueHandling = NullValueHandling.Ignore)]
            public bool? BlocksEarpiece { get; set; }

            [JsonProperty("BlocksEyewear", NullValueHandling = NullValueHandling.Ignore)]
            public bool? BlocksEyewear { get; set; }

            [JsonProperty("BlocksHeadwear", NullValueHandling = NullValueHandling.Ignore)]
            public bool? BlocksHeadwear { get; set; }

            [JsonProperty("BlocksFaceCover", NullValueHandling = NullValueHandling.Ignore)]
            public bool? BlocksFaceCover { get; set; }

            [JsonProperty("foodUseTime", NullValueHandling = NullValueHandling.Ignore)]
            public long? FoodUseTime { get; set; }

            [JsonProperty("foodEffectType", NullValueHandling = NullValueHandling.Ignore)]
            public DEffectType? FoodEffectType { get; set; }

            [JsonProperty("effects_health", NullValueHandling = NullValueHandling.Ignore)]
            public EffectsHealth EffectsHealth { get; set; }

            [JsonProperty("effects_damage", NullValueHandling = NullValueHandling.Ignore)]
            public EffectsDamage EffectsDamage { get; set; }

            [JsonProperty("effects_speed", NullValueHandling = NullValueHandling.Ignore)]
            public EffectsSpeed EffectsSpeed { get; set; }

            [JsonProperty("MaxResource", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxResource { get; set; }

            [JsonProperty("MaximumNumberOfUsage", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaximumNumberOfUsage { get; set; }

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

            [JsonProperty("PrimaryDistance", NullValueHandling = NullValueHandling.Ignore)]
            public double? PrimaryDistance { get; set; }

            [JsonProperty("SecondryDistance", NullValueHandling = NullValueHandling.Ignore)]
            public double? SecondryDistance { get; set; }

            [JsonProperty("SlashPenetration", NullValueHandling = NullValueHandling.Ignore)]
            public long? SlashPenetration { get; set; }

            [JsonProperty("StabPenetration", NullValueHandling = NullValueHandling.Ignore)]
            public long? StabPenetration { get; set; }

            [JsonProperty("PrimaryConsumption", NullValueHandling = NullValueHandling.Ignore)]
            public long? PrimaryConsumption { get; set; }

            [JsonProperty("SecondryConsumption", NullValueHandling = NullValueHandling.Ignore)]
            public long? SecondryConsumption { get; set; }

            [JsonProperty("DeflectionConsumption", NullValueHandling = NullValueHandling.Ignore)]
            public long? DeflectionConsumption { get; set; }

            [JsonProperty("ConfigPathStr", NullValueHandling = NullValueHandling.Ignore)]
            public string ConfigPathStr { get; set; }

            [JsonProperty("MaxMarkersCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxMarkersCount { get; set; }

            [JsonProperty("scaleMin", NullValueHandling = NullValueHandling.Ignore)]
            public double? ScaleMin { get; set; }

            [JsonProperty("scaleMax", NullValueHandling = NullValueHandling.Ignore)]
            public double? ScaleMax { get; set; }

            [JsonProperty("medUseTime", NullValueHandling = NullValueHandling.Ignore)]
            public long? MedUseTime { get; set; }

            [JsonProperty("medEffectType", NullValueHandling = NullValueHandling.Ignore)]
            public DEffectType? MedEffectType { get; set; }

            [JsonProperty("MaxHpResource", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxHpResource { get; set; }

            [JsonProperty("hpResourceRate", NullValueHandling = NullValueHandling.Ignore)]
            public long? HpResourceRate { get; set; }

            [JsonProperty("StimulatorBuffs", NullValueHandling = NullValueHandling.Ignore)]
            public string StimulatorBuffs { get; set; }

            [JsonProperty("MaxEfficiency", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxEfficiency { get; set; }

            [JsonProperty("Addiction", NullValueHandling = NullValueHandling.Ignore)]
            public long? Addiction { get; set; }

            [JsonProperty("Overdose", NullValueHandling = NullValueHandling.Ignore)]
            public long? Overdose { get; set; }

            [JsonProperty("OverdoseRecovery", NullValueHandling = NullValueHandling.Ignore)]
            public long? OverdoseRecovery { get; set; }

            [JsonProperty("AddictionRecovery", NullValueHandling = NullValueHandling.Ignore)]
            public long? AddictionRecovery { get; set; }

            [JsonProperty("Buffs", NullValueHandling = NullValueHandling.Ignore)]
            public BuffsUnion? Buffs { get; set; }

            [JsonProperty("apResource", NullValueHandling = NullValueHandling.Ignore)]
            public long? ApResource { get; set; }

            [JsonProperty("krResource", NullValueHandling = NullValueHandling.Ignore)]
            public long? KrResource { get; set; }

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

            [JsonProperty("PenetrationPowerDiviation", NullValueHandling = NullValueHandling.Ignore)]
            public double? PenetrationPowerDiviation { get; set; }

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

            [JsonProperty("SpeedRetardation", NullValueHandling = NullValueHandling.Ignore)]
            public double? SpeedRetardation { get; set; }

            [JsonProperty("Tracer", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Tracer { get; set; }

            [JsonProperty("TracerColor", NullValueHandling = NullValueHandling.Ignore)]
            public TracerColor? TracerColor { get; set; }

            [JsonProperty("TracerDistance", NullValueHandling = NullValueHandling.Ignore)]
            public double? TracerDistance { get; set; }

            [JsonProperty("ArmorDamage", NullValueHandling = NullValueHandling.Ignore)]
            public long? ArmorDamage { get; set; }

            [JsonProperty("Caliber", NullValueHandling = NullValueHandling.Ignore)]
            public string Caliber { get; set; }

            [JsonProperty("StaminaBurnPerDamage", NullValueHandling = NullValueHandling.Ignore)]
            public double? StaminaBurnPerDamage { get; set; }

            [JsonProperty("StackSlots", NullValueHandling = NullValueHandling.Ignore)]
            public Cartridge[] StackSlots { get; set; }

            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string Type { get; set; }

            [JsonProperty("eqMin", NullValueHandling = NullValueHandling.Ignore)]
            public long? EqMin { get; set; }

            [JsonProperty("eqMax", NullValueHandling = NullValueHandling.Ignore)]
            public long? EqMax { get; set; }

            [JsonProperty("rate", NullValueHandling = NullValueHandling.Ignore)]
            public long? Rate { get; set; }

            [JsonProperty("ThrowType", NullValueHandling = NullValueHandling.Ignore)]
            public string ThrowType { get; set; }

            [JsonProperty("ExplDelay", NullValueHandling = NullValueHandling.Ignore)]
            public long? ExplDelay { get; set; }

            [JsonProperty("MinExplosionDistance", NullValueHandling = NullValueHandling.Ignore)]
            public double? MinExplosionDistance { get; set; }

            [JsonProperty("MaxExplosionDistance", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxExplosionDistance { get; set; }

            [JsonProperty("FragmentsCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? FragmentsCount { get; set; }

            [JsonProperty("FragmentType", NullValueHandling = NullValueHandling.Ignore)]
            public string FragmentType { get; set; }

            [JsonProperty("Strength", NullValueHandling = NullValueHandling.Ignore)]
            public long? Strength { get; set; }

            [JsonProperty("ContusionDistance", NullValueHandling = NullValueHandling.Ignore)]
            public long? ContusionDistance { get; set; }

            [JsonProperty("throwDamMax", NullValueHandling = NullValueHandling.Ignore)]
            public long? ThrowDamMax { get; set; }

            [JsonProperty("explDelay", NullValueHandling = NullValueHandling.Ignore)]
            public double? PropsExplDelay { get; set; }

            [JsonProperty("Blindness", NullValueHandling = NullValueHandling.Ignore)]
            public Blindness Blindness { get; set; }

            [JsonProperty("Contusion", NullValueHandling = NullValueHandling.Ignore)]
            public Blindness Contusion { get; set; }

            [JsonProperty("EmitTime", NullValueHandling = NullValueHandling.Ignore)]
            public long? EmitTime { get; set; }

            [JsonProperty("CanBeHiddenDuringThrow", NullValueHandling = NullValueHandling.Ignore)]
            public bool? CanBeHiddenDuringThrow { get; set; }

            [JsonProperty("Indestructibility", NullValueHandling = NullValueHandling.Ignore)]
            public double? Indestructibility { get; set; }

            [JsonProperty("headSegments", NullValueHandling = NullValueHandling.Ignore)]
            public HeadSegment[] HeadSegments { get; set; }

            [JsonProperty("FaceShieldComponent", NullValueHandling = NullValueHandling.Ignore)]
            public bool? FaceShieldComponent { get; set; }

            [JsonProperty("FaceShieldMask", NullValueHandling = NullValueHandling.Ignore)]
            public FaceShieldMask? FaceShieldMask { get; set; }

            [JsonProperty("HasHinge", NullValueHandling = NullValueHandling.Ignore)]
            public bool? HasHinge { get; set; }

            [JsonProperty("MaterialType", NullValueHandling = NullValueHandling.Ignore)]
            public MaterialType? MaterialType { get; set; }

            [JsonProperty("RicochetParams", NullValueHandling = NullValueHandling.Ignore)]
            public Blindness RicochetParams { get; set; }

            [JsonProperty("DeafStrength", NullValueHandling = NullValueHandling.Ignore)]
            public DeafStrength? DeafStrength { get; set; }

            [JsonProperty("Distortion", NullValueHandling = NullValueHandling.Ignore)]
            public double? Distortion { get; set; }

            [JsonProperty("CompressorTreshold", NullValueHandling = NullValueHandling.Ignore)]
            public long? CompressorTreshold { get; set; }

            [JsonProperty("CompressorAttack", NullValueHandling = NullValueHandling.Ignore)]
            public long? CompressorAttack { get; set; }

            [JsonProperty("CompressorRelease", NullValueHandling = NullValueHandling.Ignore)]
            public long? CompressorRelease { get; set; }

            [JsonProperty("CompressorGain", NullValueHandling = NullValueHandling.Ignore)]
            public long? CompressorGain { get; set; }

            [JsonProperty("CutoffFreq", NullValueHandling = NullValueHandling.Ignore)]
            public long? CutoffFreq { get; set; }

            [JsonProperty("Resonance", NullValueHandling = NullValueHandling.Ignore)]
            public double? Resonance { get; set; }

            [JsonProperty("CompressorVolume", NullValueHandling = NullValueHandling.Ignore)]
            public long? CompressorVolume { get; set; }

            [JsonProperty("AmbientVolume", NullValueHandling = NullValueHandling.Ignore)]
            public long? AmbientVolume { get; set; }

            [JsonProperty("DryVolume", NullValueHandling = NullValueHandling.Ignore)]
            public long? DryVolume { get; set; }
        }

        public partial class Blindness
        {
            [JsonProperty("x")]
            public double X { get; set; }

            [JsonProperty("y")]
            public double Y { get; set; }

            [JsonProperty("z")]
            public double Z { get; set; }
        }

        public partial class Buff
        {
            [JsonProperty("Skill", NullValueHandling = NullValueHandling.Ignore)]
            public string Skill { get; set; }

            [JsonProperty("FadeIn")]
            public long FadeIn { get; set; }

            [JsonProperty("Plato")]
            public long Plato { get; set; }

            [JsonProperty("FadeOut")]
            public long FadeOut { get; set; }

            [JsonProperty("PlatoValue")]
            public long PlatoValue { get; set; }
        }

        public partial class BuffsClass
        {
            [JsonProperty("Vitality")]
            public Buff Vitality { get; set; }
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

            [JsonProperty("_mergeSlotWithChildren")]
            public bool MergeSlotWithChildren { get; set; }

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

        public partial class Color
        {
            [JsonProperty("r")]
            public long R { get; set; }

            [JsonProperty("g")]
            public long G { get; set; }

            [JsonProperty("b")]
            public long B { get; set; }

            [JsonProperty("a")]
            public long A { get; set; }
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

            [JsonProperty("fadeOut", NullValueHandling = NullValueHandling.Ignore)]
            public long? FadeOut { get; set; }

            [JsonProperty("cost", NullValueHandling = NullValueHandling.Ignore)]
            public long? Cost { get; set; }
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
            public NameUnion Name { get; set; }

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

            [JsonProperty("minCount")]
            public long MinCount { get; set; }

            [JsonProperty("maxCount")]
            public long MaxCount { get; set; }

            [JsonProperty("maxWeight")]
            public long MaxWeight { get; set; }
        }

        public partial class Prefab
        {
            [JsonProperty("path")]
            public string Path { get; set; }

            [JsonProperty("rcid")]
            public string Rcid { get; set; }
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

            [JsonProperty("_mergeSlotWithChildren")]
            public bool MergeSlotWithChildren { get; set; }

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
            [JsonProperty("Filter")]
            public string[] Filter { get; set; }

            [JsonProperty("Shift", NullValueHandling = NullValueHandling.Ignore)]
            public long? Shift { get; set; }

            [JsonProperty("AnimationIndex", NullValueHandling = NullValueHandling.Ignore)]
            public long? AnimationIndex { get; set; }
        }

        public enum AllowSpawnOnLocation { Laboratory, Shoreline };

        public enum AmmoSfx { Standart, Tracer, TracerRed };

        public enum AmmoType { Buckshot, Bullet, Grenade };

        public enum ArmorMaterial { Aluminium, Aramid, ArmoredSteel, Ceramic, Combined, Glass, Titan, Uhmwpe };

        public enum ArmorZone { Chest, Head, LeftArm, LeftLeg, RightArm, RightLeg, Stomach };

        public enum BackgroundColor { Black, Blue, Default, Green, Grey, Orange, Violet, Yellow };

        public enum CartridgeName { Cartridges };

        public enum CartridgeProto { The5748538B2459770Af276A261 };

        public enum CasingSounds { PistolSmall, Rifle556, Rifle762, ShotgunBig, The40Mmgrenade };

        public enum ChamberName { PatronInWeapon };

        public enum ChamberProto { The55D30C394Bdc2Dae468B4577, The55D30C4C4Bdc2Db4468B457E, The55D4Af244Bdc2D962F8B4571, The55D721144Bdc2D89028B456F };

        public enum DeafStrength { High, Low, None };

        public enum FaceShieldMask { Narrow, NoMask, Wide };

        public enum FoldedSlot { Empty, ModStock, ModStock001, ModStockAkms };

        public enum DEffectType { AfterUse, DuringUse };

        public enum GridLayoutName { Empty, Paratus };

        public enum NameName { Hideout, Main, Pocket1, Pocket2, Pocket3, Pocket4, Pocket5 };

        public enum GridProto { The55D329C24Bdc2D892F8B4567 };

        public enum HeadSegment { Ears, Eyes, Jaws, Nape, Top };

        public enum MaterialType { BodyArmor, GlassVisor, Helmet };

        public enum MuzzleModType { Brake, Conpensator, MuzzleCombo, Pms, Silencer };

        public enum Rarity { Common, NotExist, Rare, Superrare };

        public enum ReloadM { ExternalMagazine, InternalMagazine };

        public enum SightModType { Hybrid, Iron, Optic, Reflex };

        public enum TracerColor { Green, Red, TracerGreen, TracerRed, TracerYellow };

        public enum UnlootableFromSide { Bear, Savage, Usec };

        public enum UnlootableFromSlot { FirstPrimaryWeapon, Scabbard };

        public enum WeapClass { AssaultCarbine, AssaultRifle, Machinegun, MarksmanRifle, Pistol, Shotgun, Smg, SniperRifle };

        public enum WeapFireType { Burst, Fullauto, Single };

        public enum WeapUseType { Primary, Secondary };

        public enum TypeEnum { Item, Node };

        public partial struct BuffsUnion
        {
            public Buff[] BuffArray;
            public BuffsClass BuffsClass;

            public static implicit operator BuffsUnion(Buff[] BuffArray) => new BuffsUnion { BuffArray = BuffArray };
            public static implicit operator BuffsUnion(BuffsClass BuffsClass) => new BuffsUnion { BuffsClass = BuffsClass };
        }

        public partial struct NameUnion
        {
            public NameName? Enum;
            public long? Integer;

            public static implicit operator NameUnion(NameName Enum) => new NameUnion { Enum = Enum };
            public static implicit operator NameUnion(long Integer) => new NameUnion { Integer = Integer };
        }

        public partial class Base
        {
            public static Dictionary<string, Base> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, Base>>(json, Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                AllowSpawnOnLocationConverter.Singleton,
                ArmorMaterialConverter.Singleton,
                BackgroundColorConverter.Singleton,
                BuffsUnionConverter.Singleton,
                CartridgeNameConverter.Singleton,
                CartridgeProtoConverter.Singleton,
                ChamberNameConverter.Singleton,
                ChamberProtoConverter.Singleton,
                DeafStrengthConverter.Singleton,
                FaceShieldMaskConverter.Singleton,
                FoldedSlotConverter.Singleton,
                GridLayoutNameConverter.Singleton,
                NameUnionConverter.Singleton,
                NameNameConverter.Singleton,
                GridProtoConverter.Singleton,
                MaterialTypeConverter.Singleton,
                RarityConverter.Singleton,
                ReloadMConverter.Singleton,
                TracerColorConverter.Singleton,
                UnlootableFromSideConverter.Singleton,
                UnlootableFromSlotConverter.Singleton,
                AmmoSfxConverter.Singleton,
                AmmoTypeConverter.Singleton,
                ArmorZoneConverter.Singleton,
                CasingSoundsConverter.Singleton,
                DEffectTypeConverter.Singleton,
                HeadSegmentConverter.Singleton,
                MuzzleModTypeConverter.Singleton,
                SightModTypeConverter.Singleton,
                WeapClassConverter.Singleton,
                WeapFireTypeConverter.Singleton,
                WeapUseTypeConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class AllowSpawnOnLocationConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(AllowSpawnOnLocation) || t == typeof(AllowSpawnOnLocation?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Shoreline":
                        return AllowSpawnOnLocation.Shoreline;
                    case "laboratory":
                        return AllowSpawnOnLocation.Laboratory;
                }
                throw new Exception("Cannot unmarshal type AllowSpawnOnLocation");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (AllowSpawnOnLocation)untypedValue;
                switch (value)
                {
                    case AllowSpawnOnLocation.Shoreline:
                        serializer.Serialize(writer, "Shoreline");
                        return;
                    case AllowSpawnOnLocation.Laboratory:
                        serializer.Serialize(writer, "laboratory");
                        return;
                }
                throw new Exception("Cannot marshal type AllowSpawnOnLocation");
            }

            public static readonly AllowSpawnOnLocationConverter Singleton = new AllowSpawnOnLocationConverter();
        }

        internal class ArmorMaterialConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ArmorMaterial) || t == typeof(ArmorMaterial?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Aluminium":
                        return ArmorMaterial.Aluminium;
                    case "Aramid":
                        return ArmorMaterial.Aramid;
                    case "ArmoredSteel":
                        return ArmorMaterial.ArmoredSteel;
                    case "Ceramic":
                        return ArmorMaterial.Ceramic;
                    case "Combined":
                        return ArmorMaterial.Combined;
                    case "Glass":
                        return ArmorMaterial.Glass;
                    case "Titan":
                        return ArmorMaterial.Titan;
                    case "UHMWPE":
                        return ArmorMaterial.Uhmwpe;
                }
                throw new Exception("Cannot unmarshal type ArmorMaterial");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ArmorMaterial)untypedValue;
                switch (value)
                {
                    case ArmorMaterial.Aluminium:
                        serializer.Serialize(writer, "Aluminium");
                        return;
                    case ArmorMaterial.Aramid:
                        serializer.Serialize(writer, "Aramid");
                        return;
                    case ArmorMaterial.ArmoredSteel:
                        serializer.Serialize(writer, "ArmoredSteel");
                        return;
                    case ArmorMaterial.Ceramic:
                        serializer.Serialize(writer, "Ceramic");
                        return;
                    case ArmorMaterial.Combined:
                        serializer.Serialize(writer, "Combined");
                        return;
                    case ArmorMaterial.Glass:
                        serializer.Serialize(writer, "Glass");
                        return;
                    case ArmorMaterial.Titan:
                        serializer.Serialize(writer, "Titan");
                        return;
                    case ArmorMaterial.Uhmwpe:
                        serializer.Serialize(writer, "UHMWPE");
                        return;
                }
                throw new Exception("Cannot marshal type ArmorMaterial");
            }

            public static readonly ArmorMaterialConverter Singleton = new ArmorMaterialConverter();
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

        internal class BuffsUnionConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(BuffsUnion) || t == typeof(BuffsUnion?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<BuffsClass>(reader);
                        return new BuffsUnion { BuffsClass = objectValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<Buff[]>(reader);
                        return new BuffsUnion { BuffArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type BuffsUnion");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (BuffsUnion)untypedValue;
                if (value.BuffArray != null)
                {
                    serializer.Serialize(writer, value.BuffArray);
                    return;
                }
                if (value.BuffsClass != null)
                {
                    serializer.Serialize(writer, value.BuffsClass);
                    return;
                }
                throw new Exception("Cannot marshal type BuffsUnion");
            }

            public static readonly BuffsUnionConverter Singleton = new BuffsUnionConverter();
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
                if (value == "patron_in_weapon")
                {
                    return ChamberName.PatronInWeapon;
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
                if (value == ChamberName.PatronInWeapon)
                {
                    serializer.Serialize(writer, "patron_in_weapon");
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

        internal class DeafStrengthConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(DeafStrength) || t == typeof(DeafStrength?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "High":
                        return DeafStrength.High;
                    case "Low":
                        return DeafStrength.Low;
                    case "None":
                        return DeafStrength.None;
                }
                throw new Exception("Cannot unmarshal type DeafStrength");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (DeafStrength)untypedValue;
                switch (value)
                {
                    case DeafStrength.High:
                        serializer.Serialize(writer, "High");
                        return;
                    case DeafStrength.Low:
                        serializer.Serialize(writer, "Low");
                        return;
                    case DeafStrength.None:
                        serializer.Serialize(writer, "None");
                        return;
                }
                throw new Exception("Cannot marshal type DeafStrength");
            }

            public static readonly DeafStrengthConverter Singleton = new DeafStrengthConverter();
        }

        internal class FaceShieldMaskConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(FaceShieldMask) || t == typeof(FaceShieldMask?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Narrow":
                        return FaceShieldMask.Narrow;
                    case "NoMask":
                        return FaceShieldMask.NoMask;
                    case "Wide":
                        return FaceShieldMask.Wide;
                }
                throw new Exception("Cannot unmarshal type FaceShieldMask");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (FaceShieldMask)untypedValue;
                switch (value)
                {
                    case FaceShieldMask.Narrow:
                        serializer.Serialize(writer, "Narrow");
                        return;
                    case FaceShieldMask.NoMask:
                        serializer.Serialize(writer, "NoMask");
                        return;
                    case FaceShieldMask.Wide:
                        serializer.Serialize(writer, "Wide");
                        return;
                }
                throw new Exception("Cannot marshal type FaceShieldMask");
            }

            public static readonly FaceShieldMaskConverter Singleton = new FaceShieldMaskConverter();
        }

        internal class FoldedSlotConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(FoldedSlot) || t == typeof(FoldedSlot?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "":
                        return FoldedSlot.Empty;
                    case "mod_stock":
                        return FoldedSlot.ModStock;
                    case "mod_stock_001":
                        return FoldedSlot.ModStock001;
                    case "mod_stock_akms":
                        return FoldedSlot.ModStockAkms;
                }
                throw new Exception("Cannot unmarshal type FoldedSlot");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (FoldedSlot)untypedValue;
                switch (value)
                {
                    case FoldedSlot.Empty:
                        serializer.Serialize(writer, "");
                        return;
                    case FoldedSlot.ModStock:
                        serializer.Serialize(writer, "mod_stock");
                        return;
                    case FoldedSlot.ModStock001:
                        serializer.Serialize(writer, "mod_stock_001");
                        return;
                    case FoldedSlot.ModStockAkms:
                        serializer.Serialize(writer, "mod_stock_akms");
                        return;
                }
                throw new Exception("Cannot marshal type FoldedSlot");
            }

            public static readonly FoldedSlotConverter Singleton = new FoldedSlotConverter();
        }

        internal class GridLayoutNameConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(GridLayoutName) || t == typeof(GridLayoutName?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "":
                        return GridLayoutName.Empty;
                    case "Paratus":
                        return GridLayoutName.Paratus;
                }
                throw new Exception("Cannot unmarshal type GridLayoutName");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (GridLayoutName)untypedValue;
                switch (value)
                {
                    case GridLayoutName.Empty:
                        serializer.Serialize(writer, "");
                        return;
                    case GridLayoutName.Paratus:
                        serializer.Serialize(writer, "Paratus");
                        return;
                }
                throw new Exception("Cannot marshal type GridLayoutName");
            }

            public static readonly GridLayoutNameConverter Singleton = new GridLayoutNameConverter();
        }

        internal class NameUnionConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(NameUnion) || t == typeof(NameUnion?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.String:
                    case JsonToken.Date:
                        var stringValue = serializer.Deserialize<string>(reader);
                        switch (stringValue)
                        {
                            case "hideout":
                                return new NameUnion { Enum = NameName.Hideout };
                            case "main":
                                return new NameUnion { Enum = NameName.Main };
                            case "pocket1":
                                return new NameUnion { Enum = NameName.Pocket1 };
                            case "pocket2":
                                return new NameUnion { Enum = NameName.Pocket2 };
                            case "pocket3":
                                return new NameUnion { Enum = NameName.Pocket3 };
                            case "pocket4":
                                return new NameUnion { Enum = NameName.Pocket4 };
                            case "pocket5":
                                return new NameUnion { Enum = NameName.Pocket5 };
                        }
                        long l;
                        if (Int64.TryParse(stringValue, out l))
                        {
                            return new NameUnion { Integer = l };
                        }
                        break;
                }
                throw new Exception("Cannot unmarshal type NameUnion");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (NameUnion)untypedValue;
                if (value.Enum != null)
                {
                    switch (value.Enum)
                    {
                        case NameName.Hideout:
                            serializer.Serialize(writer, "hideout");
                            return;
                        case NameName.Main:
                            serializer.Serialize(writer, "main");
                            return;
                        case NameName.Pocket1:
                            serializer.Serialize(writer, "pocket1");
                            return;
                        case NameName.Pocket2:
                            serializer.Serialize(writer, "pocket2");
                            return;
                        case NameName.Pocket3:
                            serializer.Serialize(writer, "pocket3");
                            return;
                        case NameName.Pocket4:
                            serializer.Serialize(writer, "pocket4");
                            return;
                        case NameName.Pocket5:
                            serializer.Serialize(writer, "pocket5");
                            return;
                    }
                }
                if (value.Integer != null)
                {
                    serializer.Serialize(writer, value.Integer.Value.ToString());
                    return;
                }
                throw new Exception("Cannot marshal type NameUnion");
            }

            public static readonly NameUnionConverter Singleton = new NameUnionConverter();
        }

        internal class NameNameConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(NameName) || t == typeof(NameName?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "hideout":
                        return NameName.Hideout;
                    case "main":
                        return NameName.Main;
                    case "pocket1":
                        return NameName.Pocket1;
                    case "pocket2":
                        return NameName.Pocket2;
                    case "pocket3":
                        return NameName.Pocket3;
                    case "pocket4":
                        return NameName.Pocket4;
                    case "pocket5":
                        return NameName.Pocket5;
                }
                throw new Exception("Cannot unmarshal type NameName");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (NameName)untypedValue;
                switch (value)
                {
                    case NameName.Hideout:
                        serializer.Serialize(writer, "hideout");
                        return;
                    case NameName.Main:
                        serializer.Serialize(writer, "main");
                        return;
                    case NameName.Pocket1:
                        serializer.Serialize(writer, "pocket1");
                        return;
                    case NameName.Pocket2:
                        serializer.Serialize(writer, "pocket2");
                        return;
                    case NameName.Pocket3:
                        serializer.Serialize(writer, "pocket3");
                        return;
                    case NameName.Pocket4:
                        serializer.Serialize(writer, "pocket4");
                        return;
                    case NameName.Pocket5:
                        serializer.Serialize(writer, "pocket5");
                        return;
                }
                throw new Exception("Cannot marshal type NameName");
            }

            public static readonly NameNameConverter Singleton = new NameNameConverter();
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

        internal class MaterialTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(MaterialType) || t == typeof(MaterialType?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "BodyArmor":
                        return MaterialType.BodyArmor;
                    case "GlassVisor":
                        return MaterialType.GlassVisor;
                    case "Helmet":
                        return MaterialType.Helmet;
                }
                throw new Exception("Cannot unmarshal type MaterialType");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (MaterialType)untypedValue;
                switch (value)
                {
                    case MaterialType.BodyArmor:
                        serializer.Serialize(writer, "BodyArmor");
                        return;
                    case MaterialType.GlassVisor:
                        serializer.Serialize(writer, "GlassVisor");
                        return;
                    case MaterialType.Helmet:
                        serializer.Serialize(writer, "Helmet");
                        return;
                }
                throw new Exception("Cannot marshal type MaterialType");
            }

            public static readonly MaterialTypeConverter Singleton = new MaterialTypeConverter();
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

        internal class ReloadMConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ReloadM) || t == typeof(ReloadM?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "ExternalMagazine":
                        return ReloadM.ExternalMagazine;
                    case "InternalMagazine":
                        return ReloadM.InternalMagazine;
                }
                throw new Exception("Cannot unmarshal type ReloadM");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ReloadM)untypedValue;
                switch (value)
                {
                    case ReloadM.ExternalMagazine:
                        serializer.Serialize(writer, "ExternalMagazine");
                        return;
                    case ReloadM.InternalMagazine:
                        serializer.Serialize(writer, "InternalMagazine");
                        return;
                }
                throw new Exception("Cannot marshal type ReloadM");
            }

            public static readonly ReloadMConverter Singleton = new ReloadMConverter();
        }

        internal class TracerColorConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(TracerColor) || t == typeof(TracerColor?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "green":
                        return TracerColor.Green;
                    case "red":
                        return TracerColor.Red;
                    case "tracerGreen":
                        return TracerColor.TracerGreen;
                    case "tracerRed":
                        return TracerColor.TracerRed;
                    case "tracerYellow":
                        return TracerColor.TracerYellow;
                }
                throw new Exception("Cannot unmarshal type TracerColor");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (TracerColor)untypedValue;
                switch (value)
                {
                    case TracerColor.Green:
                        serializer.Serialize(writer, "green");
                        return;
                    case TracerColor.Red:
                        serializer.Serialize(writer, "red");
                        return;
                    case TracerColor.TracerGreen:
                        serializer.Serialize(writer, "tracerGreen");
                        return;
                    case TracerColor.TracerRed:
                        serializer.Serialize(writer, "tracerRed");
                        return;
                    case TracerColor.TracerYellow:
                        serializer.Serialize(writer, "tracerYellow");
                        return;
                }
                throw new Exception("Cannot marshal type TracerColor");
            }

            public static readonly TracerColorConverter Singleton = new TracerColorConverter();
        }

        internal class UnlootableFromSideConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(UnlootableFromSide) || t == typeof(UnlootableFromSide?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Bear":
                        return UnlootableFromSide.Bear;
                    case "Savage":
                        return UnlootableFromSide.Savage;
                    case "Usec":
                        return UnlootableFromSide.Usec;
                }
                throw new Exception("Cannot unmarshal type UnlootableFromSide");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (UnlootableFromSide)untypedValue;
                switch (value)
                {
                    case UnlootableFromSide.Bear:
                        serializer.Serialize(writer, "Bear");
                        return;
                    case UnlootableFromSide.Savage:
                        serializer.Serialize(writer, "Savage");
                        return;
                    case UnlootableFromSide.Usec:
                        serializer.Serialize(writer, "Usec");
                        return;
                }
                throw new Exception("Cannot marshal type UnlootableFromSide");
            }

            public static readonly UnlootableFromSideConverter Singleton = new UnlootableFromSideConverter();
        }

        internal class UnlootableFromSlotConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(UnlootableFromSlot) || t == typeof(UnlootableFromSlot?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "FirstPrimaryWeapon":
                        return UnlootableFromSlot.FirstPrimaryWeapon;
                    case "Scabbard":
                        return UnlootableFromSlot.Scabbard;
                }
                throw new Exception("Cannot unmarshal type UnlootableFromSlot");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (UnlootableFromSlot)untypedValue;
                switch (value)
                {
                    case UnlootableFromSlot.FirstPrimaryWeapon:
                        serializer.Serialize(writer, "FirstPrimaryWeapon");
                        return;
                    case UnlootableFromSlot.Scabbard:
                        serializer.Serialize(writer, "Scabbard");
                        return;
                }
                throw new Exception("Cannot marshal type UnlootableFromSlot");
            }

            public static readonly UnlootableFromSlotConverter Singleton = new UnlootableFromSlotConverter();
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

        internal class DecodingChoiceConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                switch (reader.TokenType)
                {
                    case JsonToken.Integer:
                        var integerValue = serializer.Deserialize<long>(reader);
                        return integerValue;
                    case JsonToken.String:
                    case JsonToken.Date:
                        var stringValue = serializer.Deserialize<string>(reader);
                        long l;
                        if (Int64.TryParse(stringValue, out l))
                        {
                            return l;
                        }
                        break;
                }
                throw new Exception("Cannot unmarshal type long");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (long)untypedValue;
                serializer.Serialize(writer, value);
                return;
            }

            public static readonly DecodingChoiceConverter Singleton = new DecodingChoiceConverter();
        }

        internal class ArmorZoneConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ArmorZone) || t == typeof(ArmorZone?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Chest":
                        return ArmorZone.Chest;
                    case "Head":
                        return ArmorZone.Head;
                    case "LeftArm":
                        return ArmorZone.LeftArm;
                    case "LeftLeg":
                        return ArmorZone.LeftLeg;
                    case "RightArm":
                        return ArmorZone.RightArm;
                    case "RightLeg":
                        return ArmorZone.RightLeg;
                    case "Stomach":
                        return ArmorZone.Stomach;
                }
                throw new Exception("Cannot unmarshal type ArmorZone");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ArmorZone)untypedValue;
                switch (value)
                {
                    case ArmorZone.Chest:
                        serializer.Serialize(writer, "Chest");
                        return;
                    case ArmorZone.Head:
                        serializer.Serialize(writer, "Head");
                        return;
                    case ArmorZone.LeftArm:
                        serializer.Serialize(writer, "LeftArm");
                        return;
                    case ArmorZone.LeftLeg:
                        serializer.Serialize(writer, "LeftLeg");
                        return;
                    case ArmorZone.RightArm:
                        serializer.Serialize(writer, "RightArm");
                        return;
                    case ArmorZone.RightLeg:
                        serializer.Serialize(writer, "RightLeg");
                        return;
                    case ArmorZone.Stomach:
                        serializer.Serialize(writer, "Stomach");
                        return;
                }
                throw new Exception("Cannot marshal type ArmorZone");
            }

            public static readonly ArmorZoneConverter Singleton = new ArmorZoneConverter();
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

        internal class HeadSegmentConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(HeadSegment) || t == typeof(HeadSegment?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Ears":
                        return HeadSegment.Ears;
                    case "Eyes":
                        return HeadSegment.Eyes;
                    case "Jaws":
                        return HeadSegment.Jaws;
                    case "Nape":
                        return HeadSegment.Nape;
                    case "Top":
                        return HeadSegment.Top;
                }
                throw new Exception("Cannot unmarshal type HeadSegment");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (HeadSegment)untypedValue;
                switch (value)
                {
                    case HeadSegment.Ears:
                        serializer.Serialize(writer, "Ears");
                        return;
                    case HeadSegment.Eyes:
                        serializer.Serialize(writer, "Eyes");
                        return;
                    case HeadSegment.Jaws:
                        serializer.Serialize(writer, "Jaws");
                        return;
                    case HeadSegment.Nape:
                        serializer.Serialize(writer, "Nape");
                        return;
                    case HeadSegment.Top:
                        serializer.Serialize(writer, "Top");
                        return;
                }
                throw new Exception("Cannot marshal type HeadSegment");
            }

            public static readonly HeadSegmentConverter Singleton = new HeadSegmentConverter();
        }

        internal class MuzzleModTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(MuzzleModType) || t == typeof(MuzzleModType?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "brake":
                        return MuzzleModType.Brake;
                    case "conpensator":
                        return MuzzleModType.Conpensator;
                    case "muzzleCombo":
                        return MuzzleModType.MuzzleCombo;
                    case "pms":
                        return MuzzleModType.Pms;
                    case "silencer":
                        return MuzzleModType.Silencer;
                }
                throw new Exception("Cannot unmarshal type MuzzleModType");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (MuzzleModType)untypedValue;
                switch (value)
                {
                    case MuzzleModType.Brake:
                        serializer.Serialize(writer, "brake");
                        return;
                    case MuzzleModType.Conpensator:
                        serializer.Serialize(writer, "conpensator");
                        return;
                    case MuzzleModType.MuzzleCombo:
                        serializer.Serialize(writer, "muzzleCombo");
                        return;
                    case MuzzleModType.Pms:
                        serializer.Serialize(writer, "pms");
                        return;
                    case MuzzleModType.Silencer:
                        serializer.Serialize(writer, "silencer");
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

        internal class WeapClassConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(WeapClass) || t == typeof(WeapClass?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "assaultCarbine":
                        return WeapClass.AssaultCarbine;
                    case "assaultRifle":
                        return WeapClass.AssaultRifle;
                    case "machinegun":
                        return WeapClass.Machinegun;
                    case "marksmanRifle":
                        return WeapClass.MarksmanRifle;
                    case "pistol":
                        return WeapClass.Pistol;
                    case "shotgun":
                        return WeapClass.Shotgun;
                    case "smg":
                        return WeapClass.Smg;
                    case "sniperRifle":
                        return WeapClass.SniperRifle;
                }
                throw new Exception("Cannot unmarshal type WeapClass");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (WeapClass)untypedValue;
                switch (value)
                {
                    case WeapClass.AssaultCarbine:
                        serializer.Serialize(writer, "assaultCarbine");
                        return;
                    case WeapClass.AssaultRifle:
                        serializer.Serialize(writer, "assaultRifle");
                        return;
                    case WeapClass.Machinegun:
                        serializer.Serialize(writer, "machinegun");
                        return;
                    case WeapClass.MarksmanRifle:
                        serializer.Serialize(writer, "marksmanRifle");
                        return;
                    case WeapClass.Pistol:
                        serializer.Serialize(writer, "pistol");
                        return;
                    case WeapClass.Shotgun:
                        serializer.Serialize(writer, "shotgun");
                        return;
                    case WeapClass.Smg:
                        serializer.Serialize(writer, "smg");
                        return;
                    case WeapClass.SniperRifle:
                        serializer.Serialize(writer, "sniperRifle");
                        return;
                }
                throw new Exception("Cannot marshal type WeapClass");
            }

            public static readonly WeapClassConverter Singleton = new WeapClassConverter();
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
                    case "burst":
                        return WeapFireType.Burst;
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
                    case WeapFireType.Burst:
                        serializer.Serialize(writer, "burst");
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
