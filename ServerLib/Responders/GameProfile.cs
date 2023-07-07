using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using static ServerLib.Web.ResponseControl;

namespace ServerLib.Responders
{
    public static class GameProfile
    {
        public static string Template(string SessionId)
        {
            return GetBody(JsonConvert.SerializeObject(""));
        }
        public static string ProfileStatus(string SessionId)
        {
            var character = CharacterController.GetCharacter(SessionId);
            if (character == null)
            {
                Debug.PrintError("Character not found!", "ProfileStatus");
            }

            Other.ProfileStatus[] response =
            {
                new()
                {
                    profileid = character.Id,
                    status = "Free",
                    ip = "",
                    port = 0
                }
            };

            var match = MatchController.GetMatch(SessionId);
            if (match.IsNew) 
            {
                MatchController.Matches.Remove(match.matchData.MatchId);
            }
            if (!match.IsNew)
            {
                response[0].status = "MatchWait";
                response[0].ip = match.matchData.Ip;
                response[0].port = match.matchData.Port;
                response[0].location = match.matchData.Location;
                response[0].gameMode = "deathmatch";
            }

            return GetBody(JsonConvert.SerializeObject(response));
        }

        public static string ProfileNicknameValidate(string Uncompressed)
        {
            var nickname = AccountController.ValidateNickname(JsonConvert.DeserializeObject<Json.Classes.Requests.Nickname>(Uncompressed));
            var resp = GetBody("{status: \"ok\"}");
            if (nickname == "taken")
            {
                resp = GetBody("null", 255, "The nickname is already in use");
            }

            if (nickname == "tooshort")
            {
                resp = GetBody("null", 256, "The nickname is too short");
            }
            return resp;
        }

        public static string ProfileList(string SessionId)
        {
            return GetBody(CharacterController.GetCompleteCharacter(SessionId));
        }

        public static string ProfileSelect(string SessionId)
        {
            SelectProfileResponse response = new()
            { 
                status = "ok",
                notifier = new()
                {
                    { "server", ServerLib.ip_port },
                    { "channel_id", SessionId }
                }
            };
            return GetBody(JsonConvert.SerializeObject(response));
        }

        public static string ProfileCreate(string SessionId, string Uncompressed)
        {
            CharacterController.CreateCharacter(SessionId, Uncompressed);
            return GetBody(CharacterController.GetCharacter(SessionId).ToJson());
        }
    }
}
