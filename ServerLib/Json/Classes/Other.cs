using EFT;
using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class Other
    {
        public class ProfileStatus
        {
            public string profileid;
            public string status;
            public string ip;
            public int port;
            public string location;
            [JsonProperty("mode")]
            public string gameMode;
            public bool savage;

        }
    }
}
