using Newtonsoft.Json;

namespace JsonLib.Classes.Response
{
    public class GameKeepAlive
    {
        public string msg { get; set; }
        public int utc_time { get; set; }
    }
}
