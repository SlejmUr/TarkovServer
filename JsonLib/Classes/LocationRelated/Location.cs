using JsonLib.Enums;
using Newtonsoft.Json;

namespace JsonLib.Classes.LocationRelated
{
    public class Location
    {
        #region LocationBase
        public class Base
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> AccessKeys { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<AirdropParameter> AirdropParameters { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float Area { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int AveragePlayTime { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int AveragePlayerLevel { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Banner> Banners { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<BossLocationSpawn> BossLocationSpawn { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotAssault { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotEasy { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotHard { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotImpossible { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public BotLocationModifier BotLocationModifier { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotMarksman { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotMax { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotMaxPlayer { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotMaxTimePlayer { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotNormal { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotSpawnCountStep { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotSpawnPeriodCheck { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotSpawnTimeOffMax { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotSpawnTimeOffMin { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotSpawnTimeOnMax { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotSpawnTimeOnMin { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotStart { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BotStop { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Description { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool DisabledForScav { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string DisabledScavExits { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool Enabled { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool EnableCoop { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float IconX { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float IconY { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool Insurance { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool IsSecret { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool Locked { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<object> Loot { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int MaxBotPerZone { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int MaxDistToFreePoint { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int MaxPlayers { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int MinDistToExitPoint { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int MinDistToFreePoint { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<MinMaxBot> MinMaxBots { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int MinPlayers { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int MaxCoopGroup { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public NonWaveGroupScenario NonWaveGroupScenario { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool NewSpawn { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool OcculsionCullingEnabled { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool OldSpawn { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string OpenZones { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Preview Preview { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int PlayersRequestCount { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int RequiredPlayerLevelMin { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int RequiredPlayerLevelMax { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int MinPlayerLvlAccessKeys { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int PmcMaxPlayersInGroup { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int ScavMaxPlayersInGroup { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Rules { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool SafeLocation { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Scene Scene { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<SpawnPointParam> SpawnPointParams { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public long UnixDateTime { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string _Id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<object> doors { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int EscapeTimeLimit { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int EscapeTimeLimitCoop { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int exit_access_time { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int exit_count { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int exit_time { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Exit> exits { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> filter_ex { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Limit> limits { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int matching_min_seconds { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool GenerateLocalLootCache { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<MaxItemCountInLocation> maxItemCountInLocation { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int sav_summon_seconds { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int tmp_location_field_remove_me { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int users_gather_seconds { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int users_spawn_seconds_n { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int users_spawn_seconds_n2 { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int users_summon_seconds { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Wave> waves { get; set; }

        }
        public class NonWaveGroupScenario
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public float Chance { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public bool Enabled { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public int MaxToBeGroup { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public int MinToBeGroup { get; set; }

        }
        public class Limit : MinMax

        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<object> items { get; set; }

        }
        public class AirdropParameter
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int AirdropPointDeactivateDistance { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int MinPlayersCountToSpawnAirdrop { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float PlaneAirdropChance { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int PlaneAirdropCooldownMax { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int PlaneAirdropCooldownMin { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int PlaneAirdropEnd { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int PlaneAirdropMax { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int PlaneAirdropStartMax { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int PlaneAirdropStartMin { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int UnsuccessfulTryPenalty { get; set; }

        }
        public class Banner
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Pic pic { get; set; }

        }
        public class Pic
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string path { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string rcid { get; set; }

        }
        public class BossLocationSpawn
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float BossChance { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string BossDifficult { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string BossEscortAmount { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string BossEscortDifficult { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string BossEscortType { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string BossName { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool BossPlayer { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string BossZone { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool RandomTimeSpawn { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float Time { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string TriggerId { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string TriggerName { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float Delay { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<BossSupport> Supports { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string sptId { get; set; }

        }
        public class BossSupport

        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int BossEscortAmount { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> BossEscortDifficult { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string BossEscortType { get; set; }

        }
        public class BotLocationModifier
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float AccuracySpeed { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float DistToActivate { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float DistToPersueAxemanCoef { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float DistToSleep { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float GainSight { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float KhorovodChance { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float MagnetPower { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float MarksmanAccuratyCoef { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float Scattering { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float VisibleDistance { get; set; }

        }
        public class MinMaxBot : MinMax
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public WildSpawnType WildSpawnType { get; set; }



        }
        public class Preview
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string path { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string rcid { get; set; }

        }
        public class Scene
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string path { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string rcid { get; set; }

        }
        public class SpawnPointParam
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string BotZoneName { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Categories { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public ColliderParams ColliderParams { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float DelayToCanSpawnSec { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Infiltration { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public xyz Position { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float Rotation { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Sides { get; set; }

        }
        public class ColliderParams
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string _parent { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Props _props { get; set; }

        }
        public class Props
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public xyz Center { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double Radius { get; set; }

        }
        public class xyz
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double x { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double y { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double z { get; set; }

        }
        public class Exit
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float Chance { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int Count { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string EntryPodoubles { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float ExfiltrationTime { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string ExfiltrationType { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string RequiredSlot { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float MaxTime { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public float MinTime { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string PassageRequirement { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int PlayersCount { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string RequirementTip { get; set; }

        }
        public class MaxItemCountInLocation
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string TemplateId { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int Value { get; set; }

        }
        public class Wave
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string BotPreset { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string BotSide { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string SpawnPoints { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public WildSpawnType WildSpawnType { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool isPlayers { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double number { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double slots_max { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double slots_min { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double time_max { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public double time_min { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public float ChanceGroup { get; set; }
        }
        #endregion
    }
}
