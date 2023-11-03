﻿using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class CheckVersionResponse
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public bool isvalid { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string latestVersion { get; set; }
    }
}
