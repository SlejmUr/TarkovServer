using Newtonsoft.Json;

namespace MTGAPlugin.WSPackets
{
    internal class WeatherPacket : WSBasePacket
    {
        public override string Method { get => "WeatherPacket"; }

        [JsonProperty("CloudinessType")]
        public string CloudinessType;
        [JsonProperty("RainType")]
        public string RainType;
        [JsonProperty("WindType")]
        public string WindType;
        [JsonProperty("FogType")]
        public string FogType;
        [JsonProperty("TimeFlowType")]
        public string TimeFlowType;
        [JsonProperty("HourOfDay")]
        public int HourOfDay;
    }
}
