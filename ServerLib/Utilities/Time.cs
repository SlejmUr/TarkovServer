namespace ServerLib.Utilities
{
    public class Time
    {
        public static double UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return timeSpan.TotalSeconds;
        }

        public static int UnixTimeNow_Int()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (int)(timeSpan.TotalSeconds);
        }

        public static string GetTime()
        {
            return FormatTime(DateTime.Now);
        }

        public static string GetTimeWrite()
        {
            string timestring = DateTime.Now.ToString();
            string[] timesplit = timestring.Split(". ");
            return timesplit[0] + "-" + timesplit[1] + "-" + timesplit[2];
        }

        public static string FormatTime(DateTime time)
        {
            string timestring = time.ToString();
            string[] timesplit = timestring.Split(". ");
            return timesplit[0] + "-" + timesplit[1] + "-" + timesplit[2] + "_" + timesplit[3].Replace(":", "-");
        }
    }
}
