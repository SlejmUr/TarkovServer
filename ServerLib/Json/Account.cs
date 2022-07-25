namespace ServerLib.Json
{
    public class Account
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Wipe { get; set; } = false;
        public string Edition { get; set; }
        public string Lang { get; set; } = "en";
        public string[] Friends { get; set; } = Array.Empty<string>();
        public MatchingClass Matching { get; set; }
        public class MatchingClass
        {
            public bool LookingForGroup { get; set; } = false;
        }
        public string[] FriendRequestInbox { get; set; } = Array.Empty<string>();
        public string[] FriendRequestOutbox { get; set; } = Array.Empty<string>();
    }
}
