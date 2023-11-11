using static JsonLib.Classes.Response.ProfileStatus;

namespace JsonLib.Websocket
{
    public class UserConfirmed : ProfileData, IWSBase
    {
        public string type { get => "userConfirmed"; }
        public string eventId { get; set; }
    }
}
