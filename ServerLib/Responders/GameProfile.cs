using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using ServerLib.Web;
using static ServerLib.Web.ResponseControl;

namespace ServerLib.Responders
{
    public static class GameProfile
    {
        public static byte[] ProfileStatus(string SessionId)
        {
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (character == null)
            {
                Debug.PrintError("[ProfileStatus] Character not found!");
            }
            Json.Classes.ProfileStatus.Response response = new()
            {
                maxPveCountExceeded = false,
                profiles = new()
                {
                    new()
                    {
                        profileid = character.Savage,
                        profileToken = null,
                        status = "Free",
                        sid = "",
                        ip = "",
                        port = 0
                    }
                    ,
                    new()
                    {
                        profileid = character.Aid,
                        profileToken = null,
                        status = "Free",
                        sid = "",
                        ip = "",
                        port = 0
                    }

                }
            };
            return CompressRsp(GetBody(JsonConvert.SerializeObject(response)));
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
    }
}
