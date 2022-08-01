using Newtonsoft.Json;

namespace ServerLib.Json
{
    public class CustomConfig
    {
        public class Base
        {
            [JsonProperty("Account")]
            public Account Account { get; set; }

            [JsonProperty("Locale")]
            public Locale Locale { get; set; }
        }
        public class Account
        {
            [JsonProperty("checkTakenNickname")]
            public bool CheckTakenNickname { get; set; }
        }
        public class Locale
        {
            [JsonProperty("baseReplace")]
            public string BaseReplace { get; set; }

            [JsonProperty("customLocale")]
            public CustomLocale CustomLocale { get; set; }

            [JsonProperty("customMenu")]
            public CustomMenu CustomMenu { get; set; }

            [JsonProperty("useCustomLocale")]
            public bool UseCustomLocale { get; set; }

            [JsonProperty("useCustomMenu")]
            public bool UseCustomMenu { get; set; }
        }
        public class CustomLocale
        {
            [JsonProperty("fromReplace")]
            public List<string> FromReplace { get; set; }

            [JsonProperty("toReplace")]
            public List<string> ToReplace { get; set; }
        }
        public class CustomMenu
        {
            [JsonProperty("fromReplace")]
            public List<string> FromReplace { get; set; }

            [JsonProperty("toReplace")]
            public List<string> ToReplace { get; set; }
        }
    }
}
