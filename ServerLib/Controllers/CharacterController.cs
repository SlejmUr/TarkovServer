using Newtonsoft.Json;
using ServerLib.Handlers;
using ServerLib.Json;
using ServerLib.Utilities;
using static ServerLib.Json.CharacterOBJ;

namespace ServerLib.Controllers
{
    public class CharacterController
    {
        public static List<Character.Base> Characters;
        public static List<Character.Base> ScavCharacters;

        public static void Init()
        {
            Characters = new();
            Characters.Clear();
            ScavCharacters = new();
            ScavCharacters.Clear();
            Utils.PrintDebug("Initialization Done!", "debug", "[CHARACTER]");
        }
        public static Character.Base GetCharacter(string sessionID)
        {
            foreach (Character.Base character in Characters)
            {
                if (character.Aid == sessionID)
                {
                    return character;
                }
            }
            return null;
        }

        public static Character.Base GetScavCharacter(string sessionID)
        {
            foreach (Character.Base character in ScavCharacters)
            {
                if (character.Aid == sessionID)
                {
                    return character;
                }
            }
            return null;
        }
        public static string GetCompleteCharacter(string sessionID)
        {
            List<Character.Base> ouptut = new();
            if (!AccountController.IsWiped(sessionID))
            {
                ouptut.Add(GetCharacter(sessionID));
                ouptut.Add(GetScavCharacter(sessionID));
            }

            return JsonConvert.SerializeObject(ouptut);
        }

        public static string ChangeNickname(string json, string sessionID)
        {
            var nick = JsonConvert.DeserializeObject<NicknameValidate>(json);
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

        public static void ChangeVoice(string json, string sessionID)
        {
            var voices = JsonConvert.DeserializeObject<Voices>(json);
            if (voices == null) { return; }
            var character = GetCharacter(sessionID);
            character.Info.Voice = voices.Voice;
            Handlers.SaveHandler.Save(sessionID, "Character", Handlers.SaveHandler.GetCharacterPath(sessionID), JsonConvert.SerializeObject(character));
        }

        public static string GetStashType(string sessionID)
        {
            var character = GetCharacter(sessionID);

            foreach (var item in character.Inventory.Items)
            {
                if (item.Id == character.Inventory.Stash)
                {
                    return item.Tpl;
                }
            }

            Utils.PrintError($"No stash found where stash ID is: {character.Inventory.Stash}");
            return "";
        }

        public static void ProcessStorage(string sessionID, List<string> suites, bool LoadFromFile = false)
        {
            Storage storage = new();
            if (LoadFromFile)
            {
                var oldstore = JsonConvert.DeserializeObject<Storage>(File.ReadAllText(SaveHandler.GetStoragePath(sessionID)));

                storage._id = oldstore._id;
                storage.suites = storage.suites;
                storage.suites.AddRange(suites);
            }
            else
            {
                storage._id = sessionID;
                storage.suites = suites;
            }

            SaveHandler.Save(sessionID, "Storage", SaveHandler.GetStoragePath(sessionID), JsonConvert.SerializeObject(storage));
        }

        public static void RaidKilled(string json, string sessionID)
        {
            Other.RaidKilled raidKilled = JsonConvert.DeserializeObject<Other.RaidKilled>(json);
            if (raidKilled == null) { return; }

            if (raidKilled.killedByAID == sessionID)
            {
                var character = GetCharacter(sessionID);

                if (raidKilled.diedFaction == "Savage" || raidKilled.diedFaction == "Scav")
                {
                    character.TradersInfo._579dc571d53a0658a154fbec.Standing += ConfigController.Configs.Gameplay.Fence.KillingScavsFenceLevelChange;

                }
                else if (raidKilled.diedFaction == "Usec" || raidKilled.diedFaction == "Bear")
                {
                    character.TradersInfo._579dc571d53a0658a154fbec.Standing += ConfigController.Configs.Gameplay.Fence.KillingPMCsFenceLevelChange;

                }
                Handlers.SaveHandler.Save(sessionID, "Character", Handlers.SaveHandler.GetCharacterPath(sessionID), JsonConvert.SerializeObject(character));
            }
        }
    }
}
