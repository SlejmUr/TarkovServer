using Newtonsoft.Json;

namespace MTGAPlugin.WSPackets
{
    internal class WeatherPacket : WSBasePacket
    {
        public override string Method { get => "WeatherPacket"; }

        [JsonProperty("CloudinessType")]
        public string CloudinessType = string.Empty;
        [JsonProperty("RainType")]
        public string RainType = string.Empty;
        [JsonProperty("WindType")]
        public string WindType = string.Empty;
        [JsonProperty("FogType")]
        public string FogType = string.Empty;
        [JsonProperty("TimeFlowType")]
        public string TimeFlowType = string.Empty;
        [JsonProperty("HourOfDay")]
        public int HourOfDay = 0;
    }
}
