using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JsonLib.Classes.Configurations.GameplayConfig;

namespace MTGAPlugin
{
    internal class JSON
    {
        public class ResponseBrandName
        {
            [JsonProperty("name")]
            public string Name { get; set; }
        }
        public class RequestBotDifficulty
        {
            [JsonProperty("name")]
            public string Name { get; set; }
        }
        internal class MPGameConfig
        {
            public bool IsServer { get; set; }
            public bool AllowFriendlyTags { get; set; }
            public bool AllowPlayerList { get; set; }
            public bool OnlyShowMessageWhenYouAreAlone { get; set; }
            public bool DisableProgressionOnThisMatch { get; set; }
            public bool DisableItemChangesOnThisMatch { get; set; }
            public bool AllowRespawnOnThisMatch { get; set; }
            public bool EnableBots { get; set; }
            public string BotAmountSetting { get; set; }
            public string BotDifficultySetting { get; set; }
            public bool AllPlayersSpawnTogether { get; internal set; }
        }

        public class AirdropConfigModel
        {
            [JsonProperty("airdropChancePercent")]
            public AirdropChancePercent AirdropChancePercent { get; set; }

            [JsonProperty("airdropMinStartTimeSeconds")]
            public int AirdropMinStartTimeSeconds { get; set; }

            [JsonProperty("airdropMaxStartTimeSeconds")]
            public int AirdropMaxStartTimeSeconds { get; set; }

            [JsonProperty("planeMinFlyHeight")]
            public int PlaneMinFlyHeight { get; set; }

            [JsonProperty("planeMaxFlyHeight")]
            public int PlaneMaxFlyHeight { get; set; }

            [JsonProperty("planeVolume")]
            public float PlaneVolume { get; set; }

            [JsonProperty("planeSpeed")]
            public float PlaneSpeed { get; set; }

            [JsonProperty("crateFallSpeed")]
            public float CrateFallSpeed { get; set; }

            [JsonProperty("containerIds")]
            public Dictionary<string, string> ContainerIds { get; set; }
        }

        public class AirdropLootResultModel
        {
            [JsonProperty("dropType")]
            public string DropType { get; set; }

            [JsonProperty("loot")]
            public IEnumerable<AirdropLootModel> Loot { get; set; }
        }
        public class AirdropLootModel
        {
            [JsonProperty("tpl")]
            public string Tpl { get; set; }

            [JsonProperty("isPreset")]
            public bool IsPreset { get; set; }

            [JsonProperty("stackCount")]
            public int StackCount { get; set; }

            [JsonProperty("id")]
            public string ID { get; set; }
        }
        public class DifficultyClass
        {
            [JsonProperty("easy")]
            public string Easy { get; set; } = "";
            [JsonProperty("normal")]
            public string Normal { get; set; } = "";
            [JsonProperty("hard")]
            public string Hard { get; set; } = "";
            [JsonProperty("impossible")]
            public string Impossible { get; set; } = "";
        }
    }
}
