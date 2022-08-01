using Newtonsoft.Json.Linq;

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
            public JObject Customization { get; set; }
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
    }
}
