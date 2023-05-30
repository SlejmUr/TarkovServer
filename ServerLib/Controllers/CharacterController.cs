using EFT;
using Newtonsoft.Json;
using ServerLib.Generators;
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
            GetCharacters();
            Debug.PrintInfo("Initialization Done!", "CHARACTER");
        }

        public static void GetCharacters()
        {
            ProfileController.ReloadProfiles();
            foreach (var prof in ProfileController.ProfilesDict)
            {
                var val = prof.Value;
                if (val == null)
                    continue;
                var characters = val.Characters;
                if (characters == null)
                    continue;
                Characters.TryAdd(prof.Key + "_pmc", characters.Pmc);
                Characters.TryAdd(prof.Key + "_scav", characters.Scav);

            }
        }

        /// <summary>
        /// Load Character to List
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void LoadCharacter(string SessionId)
        {
            ProfileController.ReloadProfiles();
            var profile = ProfileController.ProfilesDict[SessionId];
            Characters.TryAdd(SessionId + "_pmc", profile.Characters.Pmc);
            Characters.TryAdd(SessionId + "_scav", profile.Characters.Scav);
        }

        public static void CreateCharacter(string SessionId, string JSON)
        {
            var createReq = JsonConvert.DeserializeObject<Create>(JSON);
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

            account.Wipe = false;
            SaveHandler.SaveAccount(SessionId, account);
            var character = DatabaseController.DataBase.Characters.CharacterBase[createReq.Side.ToLower()];
            var ID = Utils.CreateNewID();
            var time = TimeHelper.UnixTimeNow_Int();

            character.Id = "pmc" + ID;
            character.Aid = SessionId;
            character.Savage = "scav" + ID;
            character.Info.Side = createReq.Side;
            character.Info.Nickname = createReq.Nickname;
            character.Info.LowerNickname = createReq.Nickname.ToLower();
            character.Info.Voice = CustomizationController.GetCustomizationName(createReq.VoiceId);
            character.Info.RegistrationDate = time;
            character.Health.UpdateTime = time;
            character.Customization.Head = createReq.HeadId;
            character.Quests = new();
            character.RepeatableQuests = new();
            character.Info.SavageLockTime = 1000000;
            SaveHandler.Save(SessionId, "Character", SaveHandler.GetCharacterPath(SessionId), JsonConvert.SerializeObject(character));
            var storage = DatabaseController.DataBase.Characters.CharacterStorage[createReq.Side.ToLower()];
            SaveHandler.Save(SessionId, "Storage", SaveHandler.GetStoragePath(SessionId), JsonConvert.SerializeObject(storage));
            if (!Characters.ContainsKey(SessionId + "_pmc"))
            {
                Characters.Add(SessionId + "_pmc", character);
            }
            else
            {
                Characters.Remove(SessionId + "_pmc");
                Characters.Add(SessionId + "_pmc", character);
            }           
            /*
            //Generate scav
            var scav = Scav.Generate(SessionId);
            if (!Characters.ContainsKey(SessionId + "_scav"))
            {
                Characters.Add(SessionId + "_scav", scav);
            }
            else
            {
                Characters.Remove(SessionId + "_scav");
                Characters.Add(SessionId + "_scav", scav);
            }
            */
            //Item ReID
            Debug.PrintInfo($"Character Created with Id {SessionId}!", "CHARACTER");
        }

        public static Character.Base? GetPmcCharacter(string SessionId)
        {
            LoadCharacter(SessionId);
            if (Characters.TryGetValue(SessionId + "_pmc", out var character))
            {
                return character;
            }
            Debug.PrintWarn($"Character isnt made for {SessionId}!", "GetPmcCharacter");
            return null;
        }

        public static Character.Base? GetMiniCharacter(string SessionId)
        {
            LoadCharacter(SessionId);
            if (Characters.TryGetValue(SessionId + "_pmc", out var character))
            {
                return new()
                { 
                   Id = character.Aid,
                   Info = new()
                   { 
                        Nickname = character.Info.Nickname,
                        Side = character.Info.Side,
                        Level = character.Info.Level,
                        MemberCategory = character.Info.MemberCategory
                   }               
                };
            }
            Debug.PrintWarn($"Character isnt made for {SessionId}!", "GetPmcCharacter");
            return null;
        }

        public static Character.Base? GetScavCharacter(string SessionId)
        {
            LoadCharacter(SessionId);
            if (Characters.TryGetValue(SessionId + "_scav", out var character))
            {
                return character;
            }
            Debug.PrintWarn($"Character isnt made for {SessionId}!", "GetScavCharacter");
            return null;
        }

        public static string GetCompleteCharacter(string SessionId)
        {
            List<Character.Base> ouptut = new();
            if (!AccountController.IsWiped(SessionId))
            {
                var scav = JsonConvert.DeserializeObject<Character.Base>(File.ReadAllText("Files/bot/playerScav.json"));
                scav.Aid = SessionId;
                scav.Id = "scav" + SessionId;
                scav.Info.RegistrationDate = TimeHelper.UnixTimeNow_Int();
                /*
                var scav = GetScavCharacter(SessionId);
                if (scav != null) 
                {
                    ouptut.Add(scav);
                }*/
                var character = GetPmcCharacter(SessionId);
                if (character != null)
                {
                    ouptut.Add(character);
                    ouptut.Add(scav);
                }

                
            }

            return JsonConvert.SerializeObject(ouptut);
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
            var nick = JsonConvert.DeserializeObject<Nickname>(json);
            if (nick == null) { return "taken"; }
            string output = AccountController.ValidateNickname(nick);

            if (output == "OK")
            {
                var character = GetPmcCharacter(SessionId);
                if (character == null)
                {
                    Debug.PrintWarn($"Character not found, check if {SessionId} is correct", "ChangeNickname");
                    return "taken";
                }

                character.Info.Nickname = nick.nickname;
                character.Info.LowerNickname = nick.nickname.ToLower();
                character.Info.NicknameChangeDate = TimeHelper.UnixTimeNow_Int();

                SaveHandler.Save(SessionId, "Character", SaveHandler.GetCharacterPath(SessionId), JsonConvert.SerializeObject(character));
            }
            return output;
        }

        public static void ChangeVoice(string json, string SessionId)
        {
            var character = GetPmcCharacter(SessionId);
            if (character == null)
            {
                Debug.PrintWarn($"Character not found, check if {SessionId} is correct", "ChangeVoice");
                return;
            }

            var voices = JsonConvert.DeserializeObject<Json.Classes.Voice>(json);
            if (voices == null) { return; }

            character.Info.Voice = voices.voice;
            SaveHandler.Save(SessionId, "Character", SaveHandler.GetCharacterPath(SessionId), JsonConvert.SerializeObject(character));
        }

        public static string GetStashType(string SessionId)
        {
            var character = GetPmcCharacter(SessionId);
            if (character == null)
            {
                Debug.PrintWarn($"Character not found, check if {SessionId} is correct", "GetStashType");
                return "";
            }

            foreach (var item in character.Inventory.Items)
            {
                if (item.Id == character.Inventory.Stash)
                {
                    return item.Tpl;
                }
            }

            Debug.PrintError($"No stash found where stash ID is: {character.Inventory.Stash}");
            return "";
        }

        public static void RaidKilled(string json, string SessionId)
        {
            var raidKilled = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            if (raidKilled == null) { return; }

            if (raidKilled["killedByAID"] != null && raidKilled["killedByAID"] == SessionId)
            {
                var character = GetPmcCharacter(SessionId);
                if (character == null)
                {
                    Debug.PrintWarn($"Character not found, check if {SessionId} is correct", "RaidKilled");
                    return;
                }

                if (raidKilled["diedFaction"] == "Savage" || raidKilled["diedFaction"] == "Scav")
                {
                    character.TradersInfo["_579dc571d53a0658a154fbec"].standing += (int)ConfigController.Configs.Gameplay.Trading.Fence.KillingScavsFenceLevelChange;

                }
                else if (raidKilled["diedFaction"] == "Usec" || raidKilled["diedFaction"] == "Bear")
                {
                    character.TradersInfo["_579dc571d53a0658a154fbec"].standing += (int)ConfigController.Configs.Gameplay.Trading.Fence.KillingPMCsFenceLevelChange;

                }
                SaveHandler.Save(SessionId, "Character", SaveHandler.GetCharacterPath(SessionId), JsonConvert.SerializeObject(character));
            }
        }

        //Move it to raid
        public static int GetLoyality(string SessionId, string TraderId)
        {
            var TraderLoyalityLevels = TraderController.GetBaseByTrader(TraderId).loyaltyLevels;
            var character = GetPmcCharacter(SessionId);
            if (character == null)
            {
                Debug.PrintWarn($"Character not found, check if {SessionId} is correct", "GetLoyality");
                return 0;
            }

            int playerSaleSum = 0, calculatedLoyalty = 0, playerLevel = 0;
            double playerStanding = 0;

            playerLevel = character.Info.Level;
            playerSaleSum = character.TradersInfo[TraderId].salesSum;
            playerStanding = character.TradersInfo[TraderId].standing;

            if (TraderId != "ragfair")
            {
                foreach (var loyaltyLevel in TraderLoyalityLevels)
                {
                    if (playerSaleSum >= loyaltyLevel.minSalesSum &&
                        playerStanding >= loyaltyLevel.minStanding &&
                        playerLevel >= (int)loyaltyLevel.minLevel)
                    {
                        calculatedLoyalty++;
                    }
                    else
                    {
                        if (calculatedLoyalty == 0)
                        {
                            calculatedLoyalty = 1;
                        }
                        break;
                    }
                }
            }
            else
            {
                return 0;
            }
            return (calculatedLoyalty - 1);
        }


        public static void UpdateBackendCounters(string SessionId, string conditionId, string qid, int counter)
        {
            var character = GetPmcCharacter(SessionId);
            var backend = character.BackendCounters[conditionId];
            if (backend != null)
            {
                backend.value += counter;
                return;
            }

            character.BackendCounters[conditionId] = new()
            {
                id = conditionId,
                qid = qid,
                value = counter,
            };
            SaveHandler.SaveCharacter(SessionId, character);
        }
    }
}
