using Newtonsoft.Json;

namespace ServerLib.Json
{
    public class Exfiltration
    {
        [JsonProperty("bigmap")]
        public int Bigmap { get; set; }

        [JsonProperty("develop")]
        public int Develop { get; set; }

        [JsonProperty("factory4_day")]
        public int Factory4Day { get; set; }

        [JsonProperty("factory4_night")]
        public int Factory4Night { get; set; }

        [JsonProperty("interchange")]
        public int Interchange { get; set; }

        [JsonProperty("laboratory")]
        public int Laboratory { get; set; }

        [JsonProperty("lighthouse")]
        public int Lighthouse { get; set; }

        [JsonProperty("rezervbase")]
        public int Rezervbase { get; set; }

        [JsonProperty("shoreline")]
        public int Shoreline { get; set; }

        [JsonProperty("suburbs")]
        public int Suburbs { get; set; }

        [JsonProperty("tarkovstreets")]
        public int Tarkovstreets { get; set; }

        [JsonProperty("terminal")]
        public int Terminal { get; set; }

        [JsonProperty("town")]
        public int Town { get; set; }

        [JsonProperty("woods")]
        public int Woods { get; set; }

        [JsonProperty("privatearea")]
        public int Privatearea { get; set; }
    }
}
