using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ServerLib.Json.Classes
{
    public class Globals
    {
        public partial class Base
        {
            [JsonProperty("config")]
            public Config Config { get; set; }

            [JsonProperty("time")]
            public long Time { get; set; }
        }

        public partial class Config
        {
            [JsonProperty("content")]
            public Content Content { get; set; }

            [JsonProperty("energy")]
            public Energy Energy { get; set; }

            [JsonProperty("movement")]
            public Movement Movement { get; set; }

            [JsonProperty("exp")]
            public Exp Exp { get; set; }

            [JsonProperty("t_base_looting")]
            public long TBaseLooting { get; set; }

            [JsonProperty("t_base_lockpicking")]
            public long TBaseLockpicking { get; set; }

            [JsonProperty("armor")]
            public Armor Armor { get; set; }
        }

        public partial class Armor
        {
            [JsonProperty("class")]
            public Class[] Class { get; set; }
        }

        public partial class Class
        {
            [JsonProperty("resistance")]
            public long Resistance { get; set; }
        }

        public partial class Content
        {
            [JsonProperty("ip")]
            public string Ip { get; set; }

            [JsonProperty("port")]
            public long Port { get; set; }

            [JsonProperty("root")]
            public string Root { get; set; }
        }

        public partial class Energy
        {
            [JsonProperty("max")]
            public long Max { get; set; }

            [JsonProperty("t_v_decrease")]
            public long TVDecrease { get; set; }

            [JsonProperty("point_v_decrease")]
            public long PointVDecrease { get; set; }
        }

        public partial class Exp
        {
            [JsonProperty("heal")]
            public Heal Heal { get; set; }

            [JsonProperty("match_end")]
            public Dictionary<string, double> MatchEnd { get; set; }

            [JsonProperty("loot")]
            public object Loot { get; set; }

            [JsonProperty("kill")]
            public Kill Kill { get; set; }

            [JsonProperty("level")]
            public Level Level { get; set; }

            [JsonProperty("loot_attempts")]
            public LootAttempt[] LootAttempts { get; set; }

            [JsonProperty("expForLockedDoorOpen")]
            public long ExpForLockedDoorOpen { get; set; }

            [JsonProperty("expForLockedDoorBreach")]
            public long ExpForLockedDoorBreach { get; set; }

            [JsonProperty("triggerMult")]
            public long TriggerMult { get; set; }
        }

        public partial class Heal
        {
            [JsonProperty("bleeding")]
            public long Bleeding { get; set; }

            [JsonProperty("broken")]
            public long Broken { get; set; }

            [JsonProperty("anaesthetic")]
            public long Anaesthetic { get; set; }

            [JsonProperty("expForHeal")]
            public double ExpForHeal { get; set; }

            [JsonProperty("expForHydration")]
            public double ExpForHydration { get; set; }

            [JsonProperty("expForEnergy")]
            public double ExpForEnergy { get; set; }
        }

        public partial class Kill
        {
            [JsonProperty("combo")]
            public Combo[] Combo { get; set; }

            [JsonProperty("victimLevelExp")]
            public long VictimLevelExp { get; set; }

            [JsonProperty("headShotMult")]
            public long HeadShotMult { get; set; }

            [JsonProperty("expOnDamageAllHealth")]
            public long ExpOnDamageAllHealth { get; set; }

            [JsonProperty("longShotDistance")]
            public long LongShotDistance { get; set; }

            [JsonProperty("bloodLossToLitre")]
            public double BloodLossToLitre { get; set; }
        }

        public partial class Combo
        {
            [JsonProperty("percent")]
            public long Percent { get; set; }
        }

        public partial class Level
        {
            [JsonProperty("exp_table")]
            public ExpTable[] ExpTable { get; set; }

            [JsonProperty("trade_level")]
            public long TradeLevel { get; set; }

            [JsonProperty("savage_level")]
            public long SavageLevel { get; set; }

            [JsonProperty("clan_level")]
            public long ClanLevel { get; set; }
        }

        public partial class ExpTable
        {
            [JsonProperty("exp")]
            public long Exp { get; set; }
        }

        public partial class LootAttempt
        {
            [JsonProperty("k_exp")]
            public double KExp { get; set; }
        }

        public partial class Movement
        {
            [JsonProperty("v_mobility")]
            public long VMobility { get; set; }

            [JsonProperty("t_sprint")]
            public long TSprint { get; set; }

            [JsonProperty("t_sprint_restore")]
            public long TSprintRestore { get; set; }

            [JsonProperty("t_pose_change")]
            public double TPoseChange { get; set; }

            [JsonProperty("f_mobility_lay")]
            public double FMobilityLay { get; set; }

            [JsonProperty("f_mobility_sit")]
            public double FMobilitySit { get; set; }

            [JsonProperty("f_mobility_stay")]
            public double FMobilityStay { get; set; }

            [JsonProperty("f_mobility_sprint")]
            public long FMobilitySprint { get; set; }

            [JsonProperty("f_strafe")]
            public double FStrafe { get; set; }

            [JsonProperty("f_backward")]
            public double FBackward { get; set; }

            [JsonProperty("jump")]
            public Dictionary<string, double> Jump { get; set; }
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
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }
    }
}
