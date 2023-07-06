using EFT;
using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class Requests
    {
        public class Register
        {
            public string email;
            public string pass;
        }

        public class OnlyMail
        {
            public string email;
        }
        public class Uid
        {
            public string uid;
        }

        public class QuestList
        {
            public bool completed;
        }

        public class ProfileSave
        {
            public object Profile;
            public ExitStatus exitStatus;
        }

        public class MatchJoin
        {
            public string location;
            public string mode;
            public bool develop;
        }

        public class Create
        {
            public string side;
            public string nickname;
        }

        public class Nickname
        {
            public string nickname;
        }

        public class HardwareCode
        {
            public string email;
            public string device_id;
            public string activateCode;
        }

        public class Validate
        {
            public Version version;
            public bool develop;
        }

        public class Version
        {
            public string major;
            public string minor;
            public string game;
            public string backend;
            public string taxonomy;
        }

        public class Login
        {
            public string email;
            public string pass;
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Version version; 
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string device_id;
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool develop;
        }
    }
}
