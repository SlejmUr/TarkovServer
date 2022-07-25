using Newtonsoft.Json;

namespace ServerLib.Json
{
    public class Weathers
    {
        [JsonProperty("weather")]
        public WeatherClass Weather { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("acceleration")]
        public int Acceleration { get; set; }

        public class WeatherClass
        {
            [JsonProperty("timestamp")]
            public int Timestamp { get; set; }

            [JsonProperty("cloud")]
            public int Cloud { get; set; }

            [JsonProperty("wind_speed")]
            public int WindSpeed { get; set; }

            [JsonProperty("wind_direction")]
            public int WindDirection { get; set; }

            [JsonProperty("wind_gustiness")]
            public int WindGustiness { get; set; }

            [JsonProperty("rain")]
            public int Rain { get; set; }

            [JsonProperty("rain_intensity")]
            public double RainIntensity { get; set; }

            [JsonProperty("fog")]
            public double Fog { get; set; }

            [JsonProperty("temp")]
            public int Temp { get; set; }

            [JsonProperty("pressure")]
            public int Pressure { get; set; }

            [JsonProperty("date")]
            public string Date { get; set; }

            [JsonProperty("time")]
            public string Time { get; set; }
        }
    }
}
