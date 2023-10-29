namespace ServerLib.Utilities.Helpers
{
    public static class HeadersHelper
    {
        public static string GetSessionId(this Dictionary<string, string> HttpHeaders)
        {
            if (HttpHeaders.ContainsKey("Cookie"))
            {
                var Cookie = HttpHeaders["Cookie"];
                var SessionId = Cookie.Split("=")[1];
                return SessionId;
            }
            return "";
        }
        public static string GetVersion(this Dictionary<string, string> HttpHeaders)
        {
            if (HttpHeaders.ContainsKey("App-Version"))
            {
                var AppVersion = HttpHeaders["App-Version"];
                var Version = AppVersion.Replace("EFT Client ", "");
                return Version;
            }
            return "";
        }
    }
}
