using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    internal class Response
    {
        public class LoginRSP
        {
            [JsonProperty("token")]
            public string Token { get; set; }

            [JsonProperty("aid")]
            public string Aid { get; set; }

            [JsonProperty("lang")]
            public string Lang { get; set; }

            [JsonProperty("queued")]
            public bool Queued { get; set; }

            [JsonProperty("taxonomy")]
            public string Taxonomy { get; set; }

            [JsonProperty("activeProfileId")]
            public string ActiveProfileId { get; set; }

            [JsonProperty("backend")]
            public Backend Backend { get; set; }

            [JsonProperty("utc_time")]
            public double UtcTime { get; set; }

            [JsonProperty("totalInGame")]
            public long TotalInGame { get; set; }
        }

        public class notif
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("notifier")]
            public Dictionary<string, string> Notifier { get; set; }
        }
        public class notif2
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("notifierServer")]
            public string notifierServer { get; set; }
        }
        public class WeatherData
        {
            [JsonProperty("weather")]
            public Weather Weather { get; set; }

            [JsonProperty("date")]
            public string Date { get; set; }

            [JsonProperty("time")]
            public string Time { get; set; }

            [JsonProperty("acceleration")]
            public int Acceleration { get; set; }
        }

        public class Weather
        {
            [JsonProperty("timestamp")]
            public long Timestamp { get; set; }

            [JsonProperty("cloud")]
            public double Cloud { get; set; }

            [JsonProperty("wind_speed")]
            public int WindSpeed { get; set; }

            [JsonProperty("wind_direction")]
            public int WindDirection { get; set; }

            [JsonProperty("wind_gustiness")]
            public double WindGustiness { get; set; }

            [JsonProperty("rain")]
            public int Rain { get; set; }

            [JsonProperty("rain_intensity")]
            public int RainIntensity { get; set; }

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
