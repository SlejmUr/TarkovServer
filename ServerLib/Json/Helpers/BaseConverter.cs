using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;

namespace ServerLib.Json.Helpers
{
    public class BaseConverter
    {
        public static class DatabaseConverter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal },
                new StringEnumConverter { AllowIntegerValues = false }
            },
            };
        }
    }
}
