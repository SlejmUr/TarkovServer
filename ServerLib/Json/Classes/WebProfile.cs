namespace ServerLib.Json
{
    public class WebProfile
    {
        public class WebWipe
        {
            public string AccountId { get; set; }
            public string? Reason { get; set; }
        }

        public class WebAccount
        {
            public string Name { get; set; }
            public string AccountId { get; set; }
        }
    }
}
