using EFT;
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

        public static void Init()
        {
            Characters = new();
            Characters.Clear();
            Debug.PrintDebug("Initialization Done!", "debug", "[CHARACTER]");
        }

        /// <summary>
        /// Load Character to List
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void LoadCharacter(string SessionId)
        {
            string CHARACTER_PATH = SaveHandler.GetCharacterPath(SessionId);

            if (!File.Exists(CHARACTER_PATH)) { return; }

            var character = JsonConvert.DeserializeObject<Character.Base>(File.ReadAllText(CHARACTER_PATH));
            if (character == null)
            {
                Debug.PrintError($"[LoadCharacter] Character not found, check if {CHARACTER_PATH} is correct");
                return;
            }

            if (!Characters.Contains(character))
            {
                Characters.Add(character);
            }
        }

        public static void CreateCharacter(string SessionId, string JSON)
        {
            var createReq = JsonConvert.DeserializeObject<Create>(JSON);
            if (createReq == null)
            {
                Debug.PrintError($"[CreateCharacter] createReq not found");
                return;
            }

            var account = AccountController.FindAccount(SessionId);
            if (account == null)
            {
                Debug.PrintError($"[CreateCharacter] Account not found");
                return;
            }

            account.Wipe = false;
            SaveHandler.SaveAccount(SessionId, account);
            
            var character = DatabaseController.DataBase.Characters.CharacterBase[createReq.Side.ToLower()];
            var ID = Utils.CreateNewID();
            var Time = Utils.UnixTimeNow_Int();

            character.Id = "pmc" + ID;
            character.Aid = account.Id;
            character.Savage = "scav" + ID;
            character.Info.Side = createReq.Side.ToLower().Contains("bear") ? EPlayerSide.Bear : EPlayerSide.Usec;
            character.Info.Nickname = createReq.Nickname;
            character.Info.LowerNickname = createReq.Nickname.ToLower();
            character.Info.Voice = CustomizationController.GetCustomizationName(createReq.VoiceId);
            character.Info.RegistrationDate = Time;
            character.Health.UpdateTime = Time;
            character.Customization[EBodyModelPart.Head] = createReq.HeadId;
            
            SaveHandler.Save(SessionId, "Character", SaveHandler.GetCharacterPath(SessionId), JsonConvert.SerializeObject(character));
            List<string> storeSave = new();
            var storage = DatabaseController.DataBase.Characters.CharacterStorage;
            switch (createReq.Side.ToLower())
            {
                case "usec":
                    storeSave = storage.usec;
                    break;
                case "bear":
                    storeSave = storage.bear;
                    break;
            }
            SaveStorage(SessionId, storeSave, false);
            if (!Characters.Contains(character))
            {
                Characters.Add(character);
            }
            Debug.PrintDebug("Character Created!");
        }

        public static Character.Base? GetCharacter(string SessionId)
        {
            LoadCharacter(SessionId);
            foreach (Character.Base character in Characters)
            {
                if (character.Aid == SessionId)
                {
                    return character;
                }
            }
            return null;
        }

        public static string GetCompleteCharacter(string SessionId)
        {
            List<Character.Base> ouptut = new();
            if (!AccountController.IsWiped(SessionId))
            {
                var character = GetCharacter(SessionId);
                if (character == null)
                {
                    Debug.PrintError($"[GetCompleteCharacter] Character not found, check if {SessionId} is correct");
                    return JsonConvert.SerializeObject(ouptut);
                }

                ouptut.Add(character);
            }

            return JsonConvert.SerializeObject(ouptut);
        }

        public static string ChangeNickname(string json, string SessionId)
        {
            var nick = JsonConvert.DeserializeObject<NicknameValidate>(json);
            if (nick == null) { return "taken"; }
            string output = AccountController.ValidateNickname(SessionId);

            if (output == "OK")
            {
                var character = GetCharacter(SessionId);
                if (character == null)
                {
                    Debug.PrintError($"[ChangeNickname] Character not found, check if {SessionId} is correct");
                    return "";
                }

                character.Info.Nickname = nick.Nickname;
                character.Info.LowerNickname = nick.Nickname.ToLower();
                character.Info.NicknameChangeDate = Utils.UnixTimeNow_Int();

                SaveHandler.Save(SessionId, "Character", SaveHandler.GetCharacterPath(SessionId), JsonConvert.SerializeObject(character));
            }
            return output;
        }

        public static void ChangeVoice(string json, string SessionId)
        {
            var character = GetCharacter(SessionId);
            if (character == null)
            {
                Debug.PrintError($"[ChangeVoice] Character not found, check if {SessionId} is correct");
                return;
            }

            var voices = JsonConvert.DeserializeObject<Voices>(json);
            if (voices == null) { return; }

            character.Info.Voice = voices.Voice;
            SaveHandler.Save(SessionId, "Character", SaveHandler.GetCharacterPath(SessionId), JsonConvert.SerializeObject(character));
        }

        public static string GetStashType(string SessionId)
        {
            var character = GetCharacter(SessionId);
            if (character == null)
            {
                Debug.PrintError($"[GetStashType] Character not found, check if {SessionId} is correct");
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

        public static void SaveStorage(string SessionId, List<string> suites, bool LoadFromFile = false)
        {
            Storage storage = new();
            string STORAGE_PATH = SaveHandler.GetStoragePath(SessionId);

            if (LoadFromFile)
            {
                var oldstore = JsonConvert.DeserializeObject<Storage>(File.ReadAllText(STORAGE_PATH));
                if (oldstore == null)
                {
                    Debug.PrintError($"Storage unable to be read at path: {STORAGE_PATH}");
                    return;
                }

                storage._id = oldstore._id;
                storage.suites = storage.suites;
                storage.suites.AddRange(suites);
            }
            else
            {
                storage._id = SessionId;
                storage.suites = suites;
            }

            SaveHandler.Save(SessionId, "Storage", STORAGE_PATH, JsonConvert.SerializeObject(storage));
        }

        public static void RaidKilled(string json, string SessionId)
        {
            Json.Other.RaidKilled raidKilled = JsonConvert.DeserializeObject<Json.Other.RaidKilled>(json);
            if (raidKilled == null) { return; }

            if (raidKilled.killedByAID == SessionId)
            {
                var character = GetCharacter(SessionId);
                if (character == null)
                {
                    Debug.PrintError($"[GetStashType] Character not found, check if {SessionId} is correct");
                    return;
                }

                if (raidKilled.diedFaction == "Savage" || raidKilled.diedFaction == "Scav")
                {
                    character.TradersInfo["_579dc571d53a0658a154fbec"].Standing += (double)ConfigController.Configs.Gameplay.Trading.Fence.KillingScavsFenceLevelChange;

                }
                else if (raidKilled.diedFaction == "Usec" || raidKilled.diedFaction == "Bear")
                {
                    character.TradersInfo["_579dc571d53a0658a154fbec"].Standing += (double)ConfigController.Configs.Gameplay.Trading.Fence.KillingPMCsFenceLevelChange;

                }
                SaveHandler.Save(SessionId, "Character", SaveHandler.GetCharacterPath(SessionId), JsonConvert.SerializeObject(character));
            }
        }

        public static int GetLoyality(string SessionId, string TraderId)
        {
            var TraderLoyalityLevels = TraderController.GetBaseByTrader(TraderId).LoyaltyLevels;
            var character = GetCharacter(SessionId);
            if (character == null)
            {
                Debug.PrintError($"[GetStashType] Character not found, check if {SessionId} is correct");
                return 0;
            }

            int playerSaleSum = 0, calculatedLoyalty = 0, playerLevel = 0;
            double playerStanding = 0;

            playerLevel = character.Info.Level;
            playerSaleSum = (int)character.TradersInfo[TraderId].SalesSum;
            playerStanding = character.TradersInfo[TraderId].Standing;

            if (TraderId != "ragfair")
            {
                foreach (var loyaltyLevel in TraderLoyalityLevels)
                {
                    if (playerSaleSum >= loyaltyLevel.MinSalesSum &&
                        playerStanding >= loyaltyLevel.MinStanding &&
                        playerLevel >= (int)loyaltyLevel.MinLevel)
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
            var backend = GetCharacter(SessionId).BackendCounters[conditionId];
            if (backend != null)
            {
                backend.value += counter;
                return;
            }

            GetCharacter(SessionId).BackendCounters[conditionId] = new()
            {
                id = conditionId,
                qid = qid,
                value = counter,
            };
            SaveHandler.SaveAll(SessionId);
        }
    }
}
