using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class CharacterController 
    {
        public static List<Json.Character.Base> Characters;
        public static List<Json.Character.Base> ScavCharacters;

        public static void Init()
        {
            Characters = new();
            Characters.Clear();
            ScavCharacters = new();
            ScavCharacters.Clear();
            Utils.PrintDebug("Initialization Done!", "debug", "[CHARACTER]");
        }

        public static string GetCompleteCharacter(string sessionID)
        {
            List<Json.Character> ouptut = new();
            if (!AccountController.IsWiped(sessionID))
            {
                //ouptut.Add(JsonConvert.SerializeObject(Character[sessionID].ToString()));
                //ouptut.Add(JsonConvert.SerializeObject(ScavCharacter[sessionID].ToString()));
            }

            return JsonConvert.SerializeObject(ouptut);
        }
        public static Json.Character.Base GetCharacter(string sessionID)
        {
            foreach (Json.Character.Base character in Characters)
            {
                if (character.Aid == sessionID)
                {
                    return character;
                }
            }
            return null;

        }
        public static string ChangeNickname(string json, string sessionID)
        { 
            var nick = JsonConvert.DeserializeObject<Json.NicknameValidate>(json);
            if (nick == null) { return "taken"; }
            string output = AccountController.ValidateNickname(sessionID);

            if (output == "OK")
            {
                var character = GetCharacter(sessionID);
                character.Info.Nickname = nick.Nickname;
                character.Info.LowerNickname = nick.Nickname.ToLower();
                character.Info.NicknameChangeDate = Utils.UnixTimeNow_Int();
                Handlers.SaveHandler.Save(sessionID, "Character", Handlers.SaveHandler.GetCharacterPath(sessionID), JsonConvert.SerializeObject(character));
            }
            return output;
        }
    }
}
