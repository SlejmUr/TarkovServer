using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class BotConfig
    {
        public class Base
        {
            [JsonProperty("pmcWar")]
            public PmcWar PmcWar { get; set; }

            [JsonProperty("limit")]
            public Limit Limit { get; set; }

            [JsonProperty("spawn")]
            public Spawn Spawn { get; set; }
        }

        public partial class Limit
        {
            [JsonProperty("bossKilla")]
            public int BossKilla { get; set; }

            [JsonProperty("bossBully")]
            public int BossBully { get; set; }

            [JsonProperty("bullyFollowers")]
            public int BullyFollowers { get; set; }

            [JsonProperty("marksman")]
            public int Marksman { get; set; }

            [JsonProperty("pmcBot")]
            public int PmcBot { get; set; }

            [JsonProperty("scav")]
            public int Scav { get; set; }
        }

        public partial class PmcWar
        {
            [JsonProperty("enabled")]
            public bool Enabled { get; set; }

            [JsonProperty("sideUsec")]
            public int SideUsec { get; set; }
        }

        public partial class Spawn
        {
            [JsonProperty("glasses")]
            public int Glasses { get; set; }

            [JsonProperty("faceCover")]
            public int FaceCover { get; set; }

            [JsonProperty("headwear")]
            public int Headwear { get; set; }

            [JsonProperty("backpack")]
            public int Backpack { get; set; }

            [JsonProperty("armorVest")]
            public int ArmorVest { get; set; }

            [JsonProperty("medPocket")]
            public int MedPocket { get; set; }

            [JsonProperty("itemPocket")]
            public int ItemPocket { get; set; }
        }

    }
}
