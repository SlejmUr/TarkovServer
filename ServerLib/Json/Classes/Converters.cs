using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public static class Converters
    {
        public static string ToJson(this Character.Base self) => JsonConvert.SerializeObject(self, Character.Converter.Settings);

        public static string ToJson(this Globals.Base self) => JsonConvert.SerializeObject(self, Globals.Converter.Settings);

        public static string ToJson(this Item.Base self) => JsonConvert.SerializeObject(self, Item.Converter.Settings);
    }
}
