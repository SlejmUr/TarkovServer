namespace Tarkov_Server_Csharp
{
    internal class JsonD
    {
        public class JsonProfile
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Edition { get; set; }
            public string Password { get; set; }
        }
        //Depracted
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
    }
}
