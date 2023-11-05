namespace ServerLib.Utilities.Helpers
{
    public static class HeadersHelper
    {
        public static string GetSessionId(this Dictionary<string, string> HttpHeaders)
        {
            if (HttpHeaders.ContainsKey("cookie"))
            {
                var Cookie = HttpHeaders["cookie"];
                var SessionId = "";
                if (Cookie.Contains(";"))
                {
                    var splittedCookie = Cookie.Split("; ");
                    foreach (var splCookie in splittedCookie)
                    {
                        var splitted = splCookie.Split('=');
                        if (splitted[0] == "PHPSESSID")
                            return splitted[1];
                    }
                }
                else
                    SessionId = Cookie.Split("=")[1];
                return SessionId;
            }
            return "";
        }
        public static string GetVersion(this Dictionary<string, string> HttpHeaders)
        {
            if (HttpHeaders.ContainsKey("app-version"))
            {
                var AppVersion = HttpHeaders["app-version"];
                var Version = AppVersion.Replace("EFT Client ", "");
                return Version;
            }
            return "";
        }
    }
}
