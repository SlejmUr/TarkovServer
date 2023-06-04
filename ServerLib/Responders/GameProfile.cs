using Newtonsoft.Json;
using ServerLib.Controllers;
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


            var match = MatchController.GetMatch(SessionId);
            if (match.HasValue)
            {
                response.profiles[0].status = "MatchWait";
                response.profiles[0].profileToken = match.Value.Users.Where(x => x.profileid == SessionId).FirstOrDefault().profileToken;
                response.profiles[0].ip = match.Value.Ip;
                response.profiles[0].port = match.Value.Port;
                response.profiles[0].location = match.Value.Location;
                response.profiles[0].raidMode = match.Value.RaidMode.ToString();
                response.profiles[0].mode = "deathmatch";
                response.profiles[0].shortId = match.Value.Sid;
            }

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

            return GetBody(JsonConvert.SerializeObject(response));
        }

        public static string ProfileNicknameValidate(string Uncompressed)
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
            return resp;
        }

        public static string ProfileList(string SessionId)
        {
            return GetBody(CharacterController.GetCompleteCharacter(SessionId));
        }

        public static string ProfileSearch(string Uncompressed)
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

            return GetBody(JsonConvert.SerializeObject(responses));
        }

        public static string ProfileSelect(string SessionId)
        {
            Json.Classes.SelectProfile.Response response = new()
            { 
                status = "ok",
                notifierServer = ServerLib.IP + "/notifierServer/" + SessionId,
                notifier = GetNotifier(SessionId)
            };
            return GetBody(JsonConvert.SerializeObject(response));
        }

        public static string ProfileCreate(string SessionId, string Uncompressed)
        {
            CharacterController.CreateCharacter(SessionId, Uncompressed);
            Json.Classes.UID rsp = new()
            {
                uid = "pmc" + SessionId
            };
            return GetBody(JsonConvert.SerializeObject(rsp));
        }
    }
}
