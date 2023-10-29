using ServerLib.Utilities.Helpers;
using static ServerLib.Json.Classes.ProfileStatus;

namespace ServerLib.Json.Classes.Websocket
{
    public interface Basic
    {
        public string type { get; }
        public string eventId { get; }
    }

    public class UserConfirmed : ProfileData, Basic
    {
        public string type { get => "userConfirmed"; }
        public string eventId { get => AIDHelper.CreateNewID(); }
    }
}
