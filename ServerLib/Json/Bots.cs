using Newtonsoft.Json;

namespace ServerLib.Json
{
    public class Bots
    {
        #region BotCore
        public class BotCore
        {
            [JsonProperty("SAVAGE_KILL_DIST")]
            public int SAVAGEKILLDIST { get; set; }

            [JsonProperty("SOUND_DOOR_BREACH_METERS")]
            public double SOUNDDOORBREACHMETERS { get; set; }

            [JsonProperty("SOUND_DOOR_OPEN_METERS")]
            public double SOUNDDOOROPENMETERS { get; set; }

            [JsonProperty("STEP_NOISE_DELTA")]
            public double STEPNOISEDELTA { get; set; }

            [JsonProperty("JUMP_NOISE_DELTA")]
            public double JUMPNOISEDELTA { get; set; }

            [JsonProperty("GUNSHOT_SPREAD")]
            public int GUNSHOTSPREAD { get; set; }

            [JsonProperty("GUNSHOT_SPREAD_SILENCE")]
            public int GUNSHOTSPREADSILENCE { get; set; }

            [JsonProperty("BASE_WALK_SPEREAD2")]
            public double BASEWALKSPEREAD2 { get; set; }

            [JsonProperty("MOVE_SPEED_COEF_MAX")]
            public double MOVESPEEDCOEFMAX { get; set; }

            [JsonProperty("SPEED_SERV_SOUND_COEF_A")]
            public double SPEEDSERVSOUNDCOEFA { get; set; }

            [JsonProperty("SPEED_SERV_SOUND_COEF_B")]
            public double SPEEDSERVSOUNDCOEFB { get; set; }

            [JsonProperty("G")]
            public double G { get; set; }

            [JsonProperty("STAY_COEF")]
            public double STAYCOEF { get; set; }

            [JsonProperty("SIT_COEF")]
            public double SITCOEF { get; set; }

            [JsonProperty("LAY_COEF")]
            public double LAYCOEF { get; set; }

            [JsonProperty("MAX_ITERATIONS")]
            public int MAXITERATIONS { get; set; }

            [JsonProperty("START_DIST_TO_COV")]
            public double STARTDISTTOCOV { get; set; }

            [JsonProperty("MAX_DIST_TO_COV")]
            public double MAXDISTTOCOV { get; set; }

            [JsonProperty("STAY_HEIGHT")]
            public double STAYHEIGHT { get; set; }

            [JsonProperty("CLOSE_POINTS")]
            public double CLOSEPOINTS { get; set; }

            [JsonProperty("COUNT_TURNS")]
            public int COUNTTURNS { get; set; }

            [JsonProperty("SIMPLE_POINT_LIFE_TIME_SEC")]
            public double SIMPLEPOINTLIFETIMESEC { get; set; }

            [JsonProperty("DANGER_POINT_LIFE_TIME_SEC")]
            public double DANGERPOINTLIFETIMESEC { get; set; }

            [JsonProperty("DANGER_POWER")]
            public double DANGERPOWER { get; set; }

            [JsonProperty("COVER_DIST_CLOSE")]
            public double COVERDISTCLOSE { get; set; }

            [JsonProperty("GOOD_DIST_TO_POINT")]
            public double GOODDISTTOPOINT { get; set; }

            [JsonProperty("COVER_TOOFAR_FROM_BOSS")]
            public double COVERTOOFARFROMBOSS { get; set; }

            [JsonProperty("COVER_TOOFAR_FROM_BOSS_SQRT")]
            public double COVERTOOFARFROMBOSSSQRT { get; set; }

            [JsonProperty("MAX_Y_DIFF_TO_PROTECT")]
            public double MAXYDIFFTOPROTECT { get; set; }

            [JsonProperty("FLARE_POWER")]
            public double FLAREPOWER { get; set; }

            [JsonProperty("MOVE_COEF")]
            public double MOVECOEF { get; set; }

            [JsonProperty("PRONE_POSE")]
            public double PRONEPOSE { get; set; }

            [JsonProperty("LOWER_POSE")]
            public double LOWERPOSE { get; set; }

            [JsonProperty("MAX_POSE")]
            public double MAXPOSE { get; set; }

            [JsonProperty("FLARE_TIME")]
            public double FLARETIME { get; set; }

            [JsonProperty("MAX_REQUESTS__PER_GROUP")]
            public int MAXREQUESTSPERGROUP { get; set; }

            [JsonProperty("UPDATE_GOAL_TIMER_SEC")]
            public double UPDATEGOALTIMERSEC { get; set; }

            [JsonProperty("DIST_NOT_TO_GROUP")]
            public double DISTNOTTOGROUP { get; set; }

            [JsonProperty("DIST_NOT_TO_GROUP_SQR")]
            public double DISTNOTTOGROUPSQR { get; set; }

            [JsonProperty("LAST_SEEN_POS_LIFETIME")]
            public double LASTSEENPOSLIFETIME { get; set; }

            [JsonProperty("DELTA_GRENADE_START_TIME")]
            public double DELTAGRENADESTARTTIME { get; set; }

            [JsonProperty("DELTA_GRENADE_END_TIME")]
            public double DELTAGRENADEENDTIME { get; set; }

            [JsonProperty("DELTA_GRENADE_RUN_DIST")]
            public int DELTAGRENADERUNDIST { get; set; }

            [JsonProperty("DELTA_GRENADE_RUN_DIST_SQRT")]
            public double DELTAGRENADERUNDISTSQRT { get; set; }

            [JsonProperty("PATROL_MIN_LIGHT_DIST")]
            public double PATROLMINLIGHTDIST { get; set; }

            [JsonProperty("HOLD_MIN_LIGHT_DIST")]
            public double HOLDMINLIGHTDIST { get; set; }

            [JsonProperty("STANDART_BOT_PAUSE_DOOR")]
            public double STANDARTBOTPAUSEDOOR { get; set; }

            [JsonProperty("ARMOR_CLASS_COEF")]
            public double ARMORCLASSCOEF { get; set; }

            [JsonProperty("SHOTGUN_POWER")]
            public double SHOTGUNPOWER { get; set; }

            [JsonProperty("RIFLE_POWER")]
            public double RIFLEPOWER { get; set; }

            [JsonProperty("PISTOL_POWER")]
            public double PISTOLPOWER { get; set; }

            [JsonProperty("SMG_POWER")]
            public double SMGPOWER { get; set; }

            [JsonProperty("SNIPE_POWER")]
            public double SNIPEPOWER { get; set; }

            [JsonProperty("GESTUS_PERIOD_SEC")]
            public double GESTUSPERIODSEC { get; set; }

            [JsonProperty("GESTUS_AIMING_DELAY")]
            public double GESTUSAIMINGDELAY { get; set; }

            [JsonProperty("GESTUS_REQUEST_LIFETIME")]
            public double GESTUSREQUESTLIFETIME { get; set; }

            [JsonProperty("GESTUS_FIRST_STAGE_MAX_TIME")]
            public double GESTUSFIRSTSTAGEMAXTIME { get; set; }

            [JsonProperty("GESTUS_SECOND_STAGE_MAX_TIME")]
            public double GESTUSSECONDSTAGEMAXTIME { get; set; }

            [JsonProperty("GESTUS_MAX_ANSWERS")]
            public int GESTUSMAXANSWERS { get; set; }

            [JsonProperty("GESTUS_FUCK_TO_SHOOT")]
            public int GESTUSFUCKTOSHOOT { get; set; }

            [JsonProperty("GESTUS_DIST_ANSWERS")]
            public double GESTUSDISTANSWERS { get; set; }

            [JsonProperty("GESTUS_DIST_ANSWERS_SQRT")]
            public double GESTUSDISTANSWERSSQRT { get; set; }

            [JsonProperty("GESTUS_ANYWAY_CHANCE")]
            public double GESTUSANYWAYCHANCE { get; set; }

            [JsonProperty("TALK_DELAY")]
            public double TALKDELAY { get; set; }

            [JsonProperty("CAN_SHOOT_TO_HEAD")]
            public bool CANSHOOTTOHEAD { get; set; }

            [JsonProperty("CAN_TILT")]
            public bool CANTILT { get; set; }

            [JsonProperty("TILT_CHANCE")]
            public double TILTCHANCE { get; set; }

            [JsonProperty("MIN_BLOCK_DIST")]
            public double MINBLOCKDIST { get; set; }

            [JsonProperty("MIN_BLOCK_TIME")]
            public double MINBLOCKTIME { get; set; }

            [JsonProperty("COVER_SECONDS_AFTER_LOSE_VISION")]
            public double COVERSECONDSAFTERLOSEVISION { get; set; }

            [JsonProperty("MIN_ARG_COEF")]
            public double MINARGCOEF { get; set; }

            [JsonProperty("MAX_ARG_COEF")]
            public double MAXARGCOEF { get; set; }

            [JsonProperty("DEAD_AGR_DIST")]
            public double DEADAGRDIST { get; set; }

            [JsonProperty("MAX_DANGER_CARE_DIST_SQRT")]
            public double MAXDANGERCAREDISTSQRT { get; set; }

            [JsonProperty("MAX_DANGER_CARE_DIST")]
            public double MAXDANGERCAREDIST { get; set; }

            [JsonProperty("MIN_MAX_PERSON_SEARCH")]
            public int MINMAXPERSONSEARCH { get; set; }

            [JsonProperty("PERCENT_PERSON_SEARCH")]
            public double PERCENTPERSONSEARCH { get; set; }

            [JsonProperty("LOOK_ANYSIDE_BY_WALL_SEC_OF_ENEMY")]
            public double LOOKANYSIDEBYWALLSECOFENEMY { get; set; }

            [JsonProperty("CLOSE_TO_WALL_ROTATE_BY_WALL_SQRT")]
            public double CLOSETOWALLROTATEBYWALLSQRT { get; set; }

            [JsonProperty("SHOOT_TO_CHANGE_RND_PART_MIN")]
            public int SHOOTTOCHANGERNDPARTMIN { get; set; }

            [JsonProperty("SHOOT_TO_CHANGE_RND_PART_MAX")]
            public int SHOOTTOCHANGERNDPARTMAX { get; set; }

            [JsonProperty("SHOOT_TO_CHANGE_RND_PART_DELTA")]
            public double SHOOTTOCHANGERNDPARTDELTA { get; set; }

            [JsonProperty("FORMUL_COEF_DELTA_DIST")]
            public double FORMULCOEFDELTADIST { get; set; }

            [JsonProperty("FORMUL_COEF_DELTA_SHOOT")]
            public double FORMULCOEFDELTASHOOT { get; set; }

            [JsonProperty("FORMUL_COEF_DELTA_FRIEND_COVER")]
            public double FORMULCOEFDELTAFRIENDCOVER { get; set; }

            [JsonProperty("SUSPETION_POINT_DIST_CHECK")]
            public double SUSPETIONPOINTDISTCHECK { get; set; }

            [JsonProperty("MAX_BASE_REQUESTS_PER_PLAYER")]
            public int MAXBASEREQUESTSPERPLAYER { get; set; }

            [JsonProperty("MAX_HOLD_REQUESTS_PER_PLAYER")]
            public int MAXHOLDREQUESTSPERPLAYER { get; set; }

            [JsonProperty("MAX_GO_TO_REQUESTS_PER_PLAYER")]
            public int MAXGOTOREQUESTSPERPLAYER { get; set; }

            [JsonProperty("MAX_COME_WITH_ME_REQUESTS_PER_PLAYER")]
            public int MAXCOMEWITHMEREQUESTSPERPLAYER { get; set; }

            [JsonProperty("CORE_POINT_MAX_VALUE")]
            public double COREPOINTMAXVALUE { get; set; }

            [JsonProperty("CORE_POINTS_MAX")]
            public int COREPOINTSMAX { get; set; }

            [JsonProperty("CORE_POINTS_MIN")]
            public int COREPOINTSMIN { get; set; }

            [JsonProperty("BORN_POISTS_FREE_ONLY_FAREST_BOT")]
            public bool BORNPOISTSFREEONLYFARESTBOT { get; set; }

            [JsonProperty("BORN_POINSTS_FREE_ONLY_FAREST_PLAYER")]
            public bool BORNPOINSTSFREEONLYFARESTPLAYER { get; set; }

            [JsonProperty("SCAV_GROUPS_TOGETHER")]
            public bool SCAVGROUPSTOGETHER { get; set; }

            [JsonProperty("LAY_DOWN_ANG_SHOOT")]
            public double LAYDOWNANGSHOOT { get; set; }

            [JsonProperty("HOLD_REQUEST_TIME_SEC")]
            public double HOLDREQUESTTIMESEC { get; set; }

            [JsonProperty("TRIGGERS_DOWN_TO_RUN_WHEN_MOVE")]
            public int TRIGGERSDOWNTORUNWHENMOVE { get; set; }

            [JsonProperty("MIN_DIST_TO_RUN_WHILE_ATTACK_MOVING")]
            public double MINDISTTORUNWHILEATTACKMOVING { get; set; }

            [JsonProperty("MIN_DIST_TO_RUN_WHILE_ATTACK_MOVING_OTHER_ENEMIS")]
            public double MINDISTTORUNWHILEATTACKMOVINGOTHERENEMIS { get; set; }

            [JsonProperty("MIN_DIST_TO_STOP_RUN")]
            public double MINDISTTOSTOPRUN { get; set; }

            [JsonProperty("JUMP_SPREAD_DIST")]
            public double JUMPSPREADDIST { get; set; }

            [JsonProperty("LOOK_TIMES_TO_KILL")]
            public int LOOKTIMESTOKILL { get; set; }

            [JsonProperty("COME_INSIDE_TIMES")]
            public int COMEINSIDETIMES { get; set; }

            [JsonProperty("TOTAL_TIME_KILL")]
            public double TOTALTIMEKILL { get; set; }

            [JsonProperty("TOTAL_TIME_KILL_AFTER_WARN")]
            public double TOTALTIMEKILLAFTERWARN { get; set; }

            [JsonProperty("MOVING_AIM_COEF")]
            public double MOVINGAIMCOEF { get; set; }

            [JsonProperty("VERTICAL_DIST_TO_IGNORE_SOUND")]
            public double VERTICALDISTTOIGNORESOUND { get; set; }

            [JsonProperty("DEFENCE_LEVEL_SHIFT")]
            public double DEFENCELEVELSHIFT { get; set; }

            [JsonProperty("MIN_DIST_CLOSE_DEF")]
            public double MINDISTCLOSEDEF { get; set; }

            [JsonProperty("USE_ID_PRIOR_WHO_GO")]
            public bool USEIDPRIORWHOGO { get; set; }

            [JsonProperty("SMOKE_GRENADE_RADIUS_COEF")]
            public double SMOKEGRENADERADIUSCOEF { get; set; }

            [JsonProperty("GRENADE_PRECISION")]
            public int GRENADEPRECISION { get; set; }

            [JsonProperty("MAX_WARNS_BEFORE_KILL")]
            public int MAXWARNSBEFOREKILL { get; set; }

            [JsonProperty("CARE_ENEMY_ONLY_TIME")]
            public double CAREENEMYONLYTIME { get; set; }

            [JsonProperty("MIDDLE_POINT_COEF")]
            public double MIDDLEPOINTCOEF { get; set; }

            [JsonProperty("MAIN_TACTIC_ONLY_ATTACK")]
            public bool MAINTACTICONLYATTACK { get; set; }

            [JsonProperty("LAST_DAMAGE_ACTIVE")]
            public double LASTDAMAGEACTIVE { get; set; }

            [JsonProperty("SHALL_DIE_IF_NOT_INITED")]
            public bool SHALLDIEIFNOTINITED { get; set; }

            [JsonProperty("CHECK_BOT_INIT_TIME_SEC")]
            public double CHECKBOTINITTIMESEC { get; set; }

            [JsonProperty("WEAPON_ROOT_Y_OFFSET")]
            public double WEAPONROOTYOFFSET { get; set; }

            [JsonProperty("DELTA_SUPRESS_DISTANCE_SQRT")]
            public double DELTASUPRESSDISTANCESQRT { get; set; }

            [JsonProperty("DELTA_SUPRESS_DISTANCE")]
            public double DELTASUPRESSDISTANCE { get; set; }

            [JsonProperty("WAVE_COEF_LOW")]
            public double WAVECOEFLOW { get; set; }

            [JsonProperty("WAVE_COEF_MID")]
            public double WAVECOEFMID { get; set; }

            [JsonProperty("WAVE_COEF_HIGH")]
            public double WAVECOEFHIGH { get; set; }

            [JsonProperty("WAVE_COEF_HORDE")]
            public double WAVECOEFHORDE { get; set; }

            [JsonProperty("WAVE_ONLY_AS_ONLINE")]
            public bool WAVEONLYASONLINE { get; set; }

            [JsonProperty("LOCAL_BOTS_COUNT")]
            public int LOCALBOTSCOUNT { get; set; }

            [JsonProperty("AXE_MAN_KILLS_END")]
            public int AXEMANKILLSEND { get; set; }
        }
        #endregion
        #region BotNames
        public class BotNames
        {
            [JsonProperty("bossgluhar")]
            public List<string> Bossgluhar { get; set; }

            [JsonProperty("bosskilla")]
            public List<string> Bosskilla { get; set; }

            [JsonProperty("bossbully")]
            public List<string> Bossbully { get; set; }

            [JsonProperty("followerbully")]
            public List<string> Followerbully { get; set; }

            [JsonProperty("followergluhar")]
            public List<string> Followergluhar { get; set; }

            [JsonProperty("bosskojany")]
            public List<string> Bosskojany { get; set; }

            [JsonProperty("followerkojany")]
            public List<string> Followerkojany { get; set; }

            [JsonProperty("bosssanitar")]
            public List<string> Bosssanitar { get; set; }

            [JsonProperty("followersanitar")]
            public List<string> Followersanitar { get; set; }

            [JsonProperty("tagilla")]
            public List<string> Tagilla { get; set; }

            [JsonProperty("gifter")]
            public List<string> Gifter { get; set; }

            [JsonProperty("sectantpriest")]
            public List<string> Sectantpriest { get; set; }

            [JsonProperty("sectantwarrior")]
            public List<string> Sectantwarrior { get; set; }

            [JsonProperty("normal")]
            public List<string> Normal { get; set; }

            [JsonProperty("scav")]
            public List<string> Scav { get; set; }
        }
        #endregion
        #region BotBase
        public class BotBase
        {
            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("aid")]
            public int Aid { get; set; }

            [JsonProperty("savage")]
            public object Savage { get; set; }

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
            public object Encyclopedia { get; set; }

            [JsonProperty("ConditionCounters")]
            public ConditionCounters ConditionCounters { get; set; }

            [JsonProperty("BackendCounters")]
            public BackendCounters BackendCounters { get; set; }

            [JsonProperty("InsuredItems")]
            public List<object> InsuredItems { get; set; }

            [JsonProperty("Hideout")]
            public Hideout Hideout { get; set; }

            [JsonProperty("Bonuses")]
            public List<object> Bonuses { get; set; }
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

            [JsonProperty("NicknameChangeDate")]
            public int NicknameChangeDate { get; set; }

            [JsonProperty("NeedWipeOptions")]
            public List<object> NeedWipeOptions { get; set; }

            [JsonProperty("lastCompletedWipe")]
            public object LastCompletedWipe { get; set; }

            [JsonProperty("BannedState")]
            public bool BannedState { get; set; }

            [JsonProperty("BannedUntil")]
            public int BannedUntil { get; set; }

            [JsonProperty("IsStreamerModeAvailable")]
            public bool IsStreamerModeAvailable { get; set; }
        }
        public class Settings
        {
            [JsonProperty("Role")]
            public string Role { get; set; }

            [JsonProperty("BotDifficulty")]
            public string BotDifficulty { get; set; }

            [JsonProperty("Experience")]
            public int Experience { get; set; }

            [JsonProperty("StandingForKill")]
            public double StandingForKill { get; set; }

            [JsonProperty("AggressorBonus")]
            public double AggressorBonus { get; set; }
        }
        public class Customization
        {
            [JsonProperty("Head")]
            public string Head { get; set; }

            [JsonProperty("Body")]
            public string Body { get; set; }

            [JsonProperty("Feet")]
            public string Feet { get; set; }

            [JsonProperty("Hands")]
            public string Hands { get; set; }
        }
        public class Health
        {
        }
        public class Inventory
        {
            [JsonProperty("items")]
            public List<object> Items { get; set; }

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
        public class FastPanel
        {
        }
        public class Skills
        {
            [JsonProperty("Common")]
            public List<object> Common { get; set; }

            [JsonProperty("Mastering")]
            public List<object> Mastering { get; set; }

            [JsonProperty("Points")]
            public int Points { get; set; }
        }
        public class Stats
        {
            [JsonProperty("SessionCounters")]
            public SessionCounters SessionCounters { get; set; }

            [JsonProperty("OverallCounters")]
            public OverallCounters OverallCounters { get; set; }
        }
        public class SessionCounters
        {
            [JsonProperty("Items")]
            public List<object> Items { get; set; }
        }
        public class OverallCounters
        {
            [JsonProperty("Items")]
            public List<object> Items { get; set; }
        }
        public class ConditionCounters
        {
            [JsonProperty("Counters")]
            public List<object> Counters { get; set; }
        }
        public class BackendCounters
        {
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
            public object LastRecipe { get; set; }
        }
        #endregion
        #region BotAppearance
        public class BotAppearance
        {
            [JsonProperty("body")]
            public List<string> Body { get; set; }

            [JsonProperty("feet")]
            public List<string> Feet { get; set; }

            [JsonProperty("hands")]
            public List<string> Hands { get; set; }

            [JsonProperty("head")]
            public List<string> Head { get; set; }

            [JsonProperty("voice")]
            public List<string> Voice { get; set; }
        }
        #endregion
        #region BotChances
        public class BotChances
        {
            [JsonProperty("equipment")]
            public Equipment Equipment { get; set; }

            [JsonProperty("mods")]
            public Mods Mods { get; set; }
        }
        public class Equipment
        {
            [JsonProperty("Headwear")]
            public int Headwear { get; set; }

            [JsonProperty("Earpiece")]
            public int Earpiece { get; set; }

            [JsonProperty("FaceCover")]
            public int FaceCover { get; set; }

            [JsonProperty("ArmorVest")]
            public int ArmorVest { get; set; }

            [JsonProperty("Eyewear")]
            public int Eyewear { get; set; }

            [JsonProperty("ArmBand")]
            public int ArmBand { get; set; }

            [JsonProperty("TacticalVest")]
            public int TacticalVest { get; set; }

            [JsonProperty("Backpack")]
            public int Backpack { get; set; }

            [JsonProperty("FirstPrimaryWeapon")]
            public int FirstPrimaryWeapon { get; set; }

            [JsonProperty("SecondPrimaryWeapon")]
            public int SecondPrimaryWeapon { get; set; }

            [JsonProperty("Holster")]
            public int Holster { get; set; }

            [JsonProperty("Scabbard")]
            public int Scabbard { get; set; }
        }

        public class Mods
        {
            [JsonProperty("mod_pistol_grip")]
            public int ModPistolGrip { get; set; }

            [JsonProperty("mod_magazine")]
            public int ModMagazine { get; set; }

            [JsonProperty("mod_reciever")]
            public int ModReciever { get; set; }

            [JsonProperty("mod_stock")]
            public int ModStock { get; set; }

            [JsonProperty("mod_charge")]
            public int ModCharge { get; set; }

            [JsonProperty("mod_barrel")]
            public int ModBarrel { get; set; }

            [JsonProperty("mod_handguard")]
            public int ModHandguard { get; set; }

            [JsonProperty("mod_mount_001")]
            public int ModMount001 { get; set; }

            [JsonProperty("mod_mount_000")]
            public int ModMount000 { get; set; }

            [JsonProperty("mod_scope")]
            public int ModScope { get; set; }

            [JsonProperty("mod_sight_rear")]
            public int ModSightRear { get; set; }

            [JsonProperty("mod_tactical")]
            public int ModTactical { get; set; }

            [JsonProperty("mod_muzzle")]
            public int ModMuzzle { get; set; }

            [JsonProperty("mod_bipod")]
            public int ModBipod { get; set; }

            [JsonProperty("mod_gas_block")]
            public int ModGasBlock { get; set; }

            [JsonProperty("mod_mount")]
            public int ModMount { get; set; }

            [JsonProperty("mod_tactical_2")]
            public int ModTactical2 { get; set; }

            [JsonProperty("mod_foregrip")]
            public int ModForegrip { get; set; }

            [JsonProperty("mod_tactical_003")]
            public int ModTactical003 { get; set; }

            [JsonProperty("mod_tactical_000")]
            public int ModTactical000 { get; set; }

            [JsonProperty("mod_tactical_001")]
            public int ModTactical_001 { get; set; }

            [JsonProperty("mod_tactical_002")]
            public int ModTactical_002 { get; set; }

            [JsonProperty("mod_tactical001")]
            public int ModTactical001 { get; set; }

            [JsonProperty("mod_tactical002")]
            public int ModTactical002 { get; set; }

            [JsonProperty("mod_sight_front")]
            public int ModSightFront { get; set; }

            [JsonProperty("mod_launcher")]
            public int ModLauncher { get; set; }

            [JsonProperty("mod_equipment")]
            public int ModEquipment { get; set; }

            [JsonProperty("mod_stock_000")]
            public int ModStock000 { get; set; }

            [JsonProperty("mod_mount_004")]
            public int ModMount004 { get; set; }

            [JsonProperty("mod_mount_003")]
            public int ModMount003 { get; set; }

            [JsonProperty("mod_flashlight")]
            public int ModFlashlight { get; set; }

            [JsonProperty("mod_mount_002")]
            public int ModMount002 { get; set; }

            [JsonProperty("mod_pistol_grip_akms")]
            public int ModPistolGripAkms { get; set; }

            [JsonProperty("mod_stock_akms")]
            public int ModStockAkms { get; set; }

            [JsonProperty("mod_equipment_000")]
            public int ModEquipment000 { get; set; }

            [JsonProperty("mod_nvg")]
            public int ModNvg { get; set; }

            [JsonProperty("mod_equipment_001")]
            public int ModEquipment001 { get; set; }

            [JsonProperty("mod_equipment_002")]
            public int ModEquipment002 { get; set; }

            [JsonProperty("mod_scope_000")]
            public int ModScope000 { get; set; }

            [JsonProperty("mod_scope_001")]
            public int ModScope001 { get; set; }

            [JsonProperty("mod_scope_002")]
            public int ModScope002 { get; set; }

            [JsonProperty("mod_scope_003")]
            public int ModScope003 { get; set; }

            [JsonProperty("mod_pistolgrip")]
            public int ModPistolgrip { get; set; }

            [JsonProperty("mod_mount_005")]
            public int ModMount005 { get; set; }

            [JsonProperty("mod_stock_001")]
            public int ModStock001 { get; set; }

            [JsonProperty("mod_mount_006")]
            public int ModMount006 { get; set; }

            [JsonProperty("mod_muzzle_000")]
            public int ModMuzzle000 { get; set; }

            [JsonProperty("mod_muzzle_001")]
            public int ModMuzzle001 { get; set; }

            [JsonProperty("mod_stock_axis")]
            public int ModStockAxis { get; set; }

            [JsonProperty("mod_trigger")]
            public int ModTrigger { get; set; }

            [JsonProperty("mod_hammer")]
            public int ModHammer { get; set; }

            [JsonProperty("mod_catch")]
            public int ModCatch { get; set; }
        }
        #endregion
        #region BotExperience
        public class BotExperience
        {
            [JsonProperty("level")]
            public Level Level { get; set; }

            [JsonProperty("reward")]
            public Reward Reward { get; set; }
        }
        public class Level
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        public class Reward
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        #endregion
        #region BotGeneration
        public class BotGeneration
        {
            [JsonProperty("items")]
            public Items Items { get; set; }
        }
        public class Items
        {
            [JsonProperty("specialItems")]
            public SpecialItems SpecialItems { get; set; }

            [JsonProperty("healing")]
            public Healing Healing { get; set; }

            [JsonProperty("looseLoot")]
            public LooseLoot LooseLoot { get; set; }

            [JsonProperty("magazines")]
            public Magazines Magazines { get; set; }

            [JsonProperty("grenades")]
            public Grenades Grenades { get; set; }
        }
        public class SpecialItems
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        public class Healing
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        public class LooseLoot
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        public class Magazines
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        public class Grenades
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        #endregion
        #region BotHealth
        public class BotHealth
        {
            [JsonProperty("Hydration")]
            public Hydration Hydration { get; set; }

            [JsonProperty("Energy")]
            public Energy Energy { get; set; }

            [JsonProperty("Temperature")]
            public Temperature Temperature { get; set; }

            [JsonProperty("BodyParts")]
            public BodyParts BodyParts { get; set; }
        }
        public class Hydration
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        public class Energy
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        public class Temperature
        {
            [JsonProperty("min")]
            public double Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
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
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        public class Chest
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        public class Stomach
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        public class LeftArm
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        public class RightArm
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        public class LeftLeg
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        public class RightLeg
        {
            [JsonProperty("min")]
            public int Min { get; set; }

            [JsonProperty("max")]
            public int Max { get; set; }
        }
        #endregion
        #region BotName
        public class BotName
        {
            public List<string> NameList { get; set; }
        }
        #endregion
    }
}
