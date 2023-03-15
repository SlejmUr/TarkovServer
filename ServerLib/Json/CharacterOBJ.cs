using EFT;
using Newtonsoft.Json;

namespace ServerLib.Json
{
    public class CharacterOBJ
    {
        public string Id { get; set; }
        public string _id { get; set; }
        public string Nickname { get; set; }
        public int Level { get; set; }
        public bool LookingGroup { get; set; } = false;
        public PlayerVisualRepresentation PlayerVisualRepresentation { get; set; } = new();

        public class Storage
        {
            public string _id { get; set; }
            public List<string> suites { get; set; } = new();
        }

        public class CharacterStorage
        {
            public List<string> bear { get; set; } = new();
            public List<string> usec { get; set; } = new();
        }
        public class DefaultCustomization
        {
            [JsonProperty("Usec")]
            public Usec Usec;

            [JsonProperty("Bear")]
            public Bear Bear;
        }
        public class Bear
        {
            [JsonProperty("Body")]
            public string Body;

            [JsonProperty("Feet")]
            public string Feet;

            [JsonProperty("Hands")]
            public string Hands;
        }

        public class Usec
        {
            [JsonProperty("Body")]
            public string Body;

            [JsonProperty("Feet")]
            public string Feet;

            [JsonProperty("Hands")]
            public string Hands;
        }

    }
}
