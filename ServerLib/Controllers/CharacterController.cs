using Newtonsoft.Json;
using ServerLib.Handlers;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Controllers
{
    public class CharacterController
    {
        static CharacterController()
        {
            Characters = new();
            Characters.Clear();
        }
        public static Dictionary<string, Character.Base> Characters;

        public static void Init()
        {
            ReloadCharacters();
            Debug.PrintInfo("Initialization Done!", "CHARACTER");
        }

        public static void ReloadCharacters()
        {
            foreach (var dir in Directory.GetDirectories("profiles"))
            {
                foreach (var file in Directory.GetFiles(dir))
                {
                    if (file.Contains("character.json"))
                    {
                        var character = Character.Base.FromJson(File.ReadAllText(file));
                        if (character != null)
                        {
                            Characters.TryAdd(character.Aid, character);
                        }
                    }
                }
            }
        }

        public static void CreateCharacter(string SessionId, string JSON)
        {
            var createReq = JsonConvert.DeserializeObject<Requests.Create>(JSON);
            Debug.PrintDebug(JSON);
            if (createReq == null)
            {
                Debug.PrintError($"createReq not found", "CreateCharacter");
                return;
            }

            var account = AccountController.FindAccount(SessionId);
            if (account == null)
            {
                Debug.PrintError($"Account not found", "CreateCharacter");
                return;
            }

            var character = DatabaseController.DataBase.Characters.CharacterBase[createReq.side.ToLower()];
            var ID = Utils.CreateNewID();
            var time = TimeHelper.UnixTimeNow_Int();

            character.Id = ID;
            character.Aid = SessionId;
            character.Info.Side = createReq.side;
            character.Info.Nickname = createReq.nickname;
            character.Info.RegistrationDate = time;
            
            SaveHandler.Save(SessionId, "Character", SaveHandler.GetCharacterPath(SessionId), Converters.ToJson(character));
            if (!Characters.ContainsKey(SessionId))
            {
                Characters.Add(SessionId, character);
            }
            Debug.PrintInfo($"Character Created with Id {ID}!", "CHARACTER");
        }

        public static Character.Base? GetCharacter(string SessionId)
        {
            ReloadCharacters();
            if (Characters.TryGetValue(SessionId, out var character))
            {
                return character;
            }
            Debug.PrintWarn($"Character isnt made for {SessionId}!", "GetCharacter");
            return null;
        }

        public static string GetCompleteCharacter(string SessionId)
        {
            List<Character.Base> ouptut = new();
            var character = GetCharacter(SessionId);
            if (character != null)
            {
                ouptut.Add(character);
            }
            return JsonConvert.SerializeObject(ouptut, Character.Converter.Settings);
        }

        public static List<Character.Base> SearchNickname(string Nickname)
        {
            List<Character.Base> ret = new();
            foreach (var profile in Characters.Values)
            {
                if (profile != null)
                {
                    if (profile.Info.Nickname.ToLower() == Nickname.ToLower())
                    {
                        ret.Add(profile);
                    }
                }
            }
            return ret;
        
        }


        public static string ChangeNickname(string json, string SessionId)
        {
            var nick = JsonConvert.DeserializeObject<Requests.Nickname>(json);
            if (nick == null) { return "taken"; }
            string output = AccountController.ValidateNickname(nick);

            if (output == "OK")
            {
                var character = GetCharacter(SessionId);
                if (character == null)
                {
                    Debug.PrintWarn($"Character not found, check if {SessionId} is correct", "ChangeNickname");
                    return "taken";
                }

                character.Info.Nickname = nick.nickname;
                SaveHandler.Save(SessionId, "Character", SaveHandler.GetCharacterPath(SessionId), JsonConvert.SerializeObject(character));
            }
            return output;
        }
    }
}
