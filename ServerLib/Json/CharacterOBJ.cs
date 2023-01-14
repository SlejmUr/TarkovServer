﻿using Newtonsoft.Json;

namespace ServerLib.Json
{
    public class CharacterOBJ
    {
        public string Id { get; set; }
        public string _id { get; set; }
        public string Nickname { get; set; }
        public int Level { get; set; }
        public bool LookingGroup { get; set; } = false;
        public PlayerVisualRepresentationClass PlayerVisualRepresentation { get; set; } = new();
        public class PlayerVisualRepresentationClass
        {
            public Info Info { get; set; } = new();
            public Character.Customization Customization { get; set; }
        }

        public class Info
        {
            public string Nickname { get; set; }
            public string Side { get; set; }
            public int Level { get; set; }
            public int MemberCategory { get; set; }
            public bool Ignored { get; set; } = false;
            public bool Banned { get; set; } = false;
        }

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
