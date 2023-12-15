using JsonLib.Classes.Request;
using JsonLib.Classes.Response;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using static ServerLib.Web.ResponseControl;

namespace ServerLib.Responders
{
    public static class GameProfile
    {
        public static string ProfileNickNameChange(string Uncompressed, string SessionId)
        {
            var nickname = CharacterController.ChangeNickname(Uncompressed, SessionId);
            var resp = GetBody("{\"status\": 0, \"nicknamechangedate\": " + TimeHelper.UnixTimeNow_Int() + "}");
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
        public static string GetProfileStatus(string SessionId)
        {
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (character == null)
            {
                Debug.PrintError("Character not found!", "ProfileStatus");
                ArgumentNullException.ThrowIfNull(character);
            }

            ProfileStatus response = new()
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
            if (match.IsNew)
            {
                MatchController.Matches.Remove(match.matchData.MatchId);
            }
            if (!match.IsNew && !match.matchData.IsScav)
            {
                response.profiles[0].status = "MatchWait";
                response.profiles[0].profileToken = match.matchData.Users.Where(x => x.sessionId == SessionId).FirstOrDefault().profileToken;
                response.profiles[0].ip = match.matchData.Ip;
                response.profiles[0].port = match.matchData.Port;
                response.profiles[0].location = match.matchData.Location;
                response.profiles[0].raidMode = match.matchData.RaidMode.ToString();
                response.profiles[0].mode = "deathmatch";
                response.profiles[0].sid = match.matchData.Sid;
                response.profiles[0].shortId = "VD0ABA";
                response.profiles[0].version = "live";
                response.profiles[0].additional_info = new();
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

                if (!match.IsNew && match.matchData.IsScav)
                {
                    response.profiles[1].status = "MatchWait";
                    response.profiles[1].profileToken = match.matchData.Users.Where(x => x.sessionId == SessionId).FirstOrDefault().profileToken;
                    response.profiles[1].ip = match.matchData.Ip;
                    response.profiles[1].port = match.matchData.Port;
                    response.profiles[1].location = match.matchData.Location;
                    response.profiles[1].raidMode = match.matchData.RaidMode.ToString();
                    response.profiles[1].mode = "deathmatch";
                    response.profiles[1].sid = match.matchData.Sid;
                    response.profiles[1].shortId = "VD0ABA";
                    response.profiles[1].version = "live";
                    response.profiles[1].additional_info = new();
                }
            }

            return GetBody(JsonConvert.SerializeObject(response));
        }

        public static string ProfileNicknameValidate(string Uncompressed)
        {
            var nick = JsonConvert.DeserializeObject<Nickname>(Uncompressed);
            ArgumentNullException.ThrowIfNull(nick);
            var nickname = AccountController.ValidateNickname(nick);
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
            var nickname = JsonConvert.DeserializeObject<Nickname>(Uncompressed);
            ArgumentNullException.ThrowIfNull(nickname);
            var searched = CharacterController.SearchNickname(nickname.nickname);
            List<SearchFriend> responses = new();

            foreach (var search in searched)
            {
                SearchFriend rsp = new()
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
            SelectProfile response = new()
            {
                status = "ok",
                notifierServer = Main.IP + "/notifierServer/" + SessionId,
                notifier = GetNotifier(SessionId)
            };
            return GetBody(JsonConvert.SerializeObject(response));
        }

        public static string ProfileCreate(string SessionId, string Uncompressed)
        {
            CharacterController.CreateCharacter(SessionId, Uncompressed);
            UID rsp = new()
            {
                uid = "pmc" + SessionId
            };
            return GetBody(JsonConvert.SerializeObject(rsp));
        }
    }
}
