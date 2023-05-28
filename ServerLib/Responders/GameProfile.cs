using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using static ServerLib.Web.ResponseControl;

namespace ServerLib.Responders
{
    public static class GameProfile
    {
        public static byte[] Template(string SessionId)
        {
            return CompressRsp(GetBody(JsonConvert.SerializeObject("")));
        }
        public static byte[] ProfileStatus(string SessionId)
        {
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (character == null)
            {
                Debug.PrintError("Character not found!", "ProfileStatus");
            }
            Json.Classes.ProfileStatus.Response response = new()
            {
                maxPveCountExceeded = false,
                profiles = new()
                {
                    new()
                    {
                        profileid = character.Id,
                        profileToken = null,
                        status = "Free",
                        sid = "",
                        ip = "",
                        port = 0
                    }
                }
            };

            if (!string.IsNullOrEmpty(character.Savage))
            {
                response.profiles.Add(new()
                {
                    profileid = character.Savage,
                    profileToken = null,
                    status = "Free",
                    sid = "",
                    ip = "",
                    port = 0
                });
            }
            
            var body = GetBody(JsonConvert.SerializeObject(response));
            return CompressRsp(body);
        }

        public static byte[] ProfileNicknameValidate(string Uncompressed)
        {
            var nickname = AccountController.ValidateNickname(JsonConvert.DeserializeObject<Json.Classes.Nickname>(Uncompressed));
            var resp = GetBody("{status: \"ok\"}");
            if (nickname == "taken")
            {
                resp = GetBody("null", 255, "The nickname is already in use");
            }

            if (nickname == "tooshort")
            {
                resp = GetBody("null", 256, "The nickname is too short");
            }
            return CompressRsp(resp);
        }

        public static byte[] ProfileList(string SessionId)
        {
            string resp = CharacterController.GetCompleteCharacter(SessionId);
            return CompressRsp(GetBody(resp));
        }

        public static byte[] ProfileSearch(string Uncompressed)
        {
            var nickname = JsonConvert.DeserializeObject<Json.Classes.Nickname>(Uncompressed);
            var searched = CharacterController.SearchNickname(nickname.nickname);
            List<Json.Classes.SearchFriend.Response> responses = new();

            foreach (var search in searched)
            {
                Json.Classes.SearchFriend.Response rsp = new()
                {
                    _id = search.Id,
                    Info = new()
                    { 
                        Side = search.Info.Side,
                        Level = search.Info.Level,
                        Nickname = search.Info.Nickname
                    }
                };
                responses.Add(rsp);
            }

            return CompressRsp(GetBody(JsonConvert.SerializeObject(responses)));
        }

        public static byte[] ProfileSelect(string SessionId)
        {
            Json.Classes.SelectProfile.Response response = new()
            { 
                status = "ok",
                notifierServer = "",
                notifier = GetNotifier(SessionId)
            };
            return CompressRsp(GetBody(JsonConvert.SerializeObject(response)));
        }

        public static byte[] ProfileCreate(string SessionId, string Uncompressed)
        {
            CharacterController.CreateCharacter(SessionId, Uncompressed);
            Json.Classes.UID rsp = new()
            {
                uid = "pmc" + SessionId
            };
            return CompressRsp(GetBody(JsonConvert.SerializeObject(rsp)));
        }
    }
}
