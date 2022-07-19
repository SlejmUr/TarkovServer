using Newtonsoft.Json.Linq;

namespace Tarkov_Server_Csharp
{
    internal class JsonD
    {
        public class Profile
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Edition { get; set; }
            public string Password { get; set; }
        }
        public class Account
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public bool Wipe { get; set; } = false;
            public string Edition { get; set; }
            public string Lang { get; set; } = "en";
            public Array Friends { get; set; } = Array.Empty<string>();
            public MatchingClass Matching { get; set; }
            public class MatchingClass
            {
                public bool LookingForGroup { get; set; } = false;
            }
            public Array FriendRequestInbox { get; set; } = Array.Empty<string>();
            public Array FriendRequestOutbox { get; set; } = Array.Empty<string>();
        }

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
            public class Customization
            {
                public string Body { get; set; }
                public string Feet { get; set; }
                public string Hands { get; set; }
                public string Head { get; set; }
            }

        }
    }
}
