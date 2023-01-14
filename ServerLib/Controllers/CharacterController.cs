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
            Utils.PrintDebug("Initialization Done!", "debug", "[CHARACTER]");
        }

        /// <summary>
        /// Load Character to List
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        public static void LoadCharacter(string sessionID)
        {
            if (!File.Exists(SaveHandler.GetCharacterPath(sessionID))) { return; }
            var character = JsonConvert.DeserializeObject<Character.Base>(File.ReadAllText(SaveHandler.GetCharacterPath(sessionID)));
            if (!Characters.Contains(character))
            {
                Characters.Add(character);
            }
        }

        public static void CreateCharacter(string sessionID, string JSON)
        {
            var createReq = JsonConvert.DeserializeObject<Create>(JSON);
            var account = AccountController.FindAccount(sessionID);
            account.Wipe = false;
            SaveHandler.SaveAccount(sessionID, account);

            var character = DatabaseController.DataBase.Characters.CharacterBase[createReq.Side];
            var ID = Utils.CreateNewID();
            var Time = Utils.UnixTimeNow_Int();

            character.Id = "pmc" + ID;
            character.Aid = account.Id;
            character.Savage = "scav" + ID;
            character.Info.Side = createReq.Side.ToUpperInvariant();
            character.Info.Nickname = createReq.Nickname;
            character.Info.LowerNickname = createReq.Nickname.ToLower();
            character.Info.Voice = CustomizationController.GetCustomizationName(createReq.VoiceId);
            character.Info.RegistrationDate = Time;
            character.Health.UpdateTime = Time;
            character.Customization.Head = createReq.HeadId;

            SaveHandler.Save(sessionID, "Character", SaveHandler.GetCharacterPath(sessionID), JsonConvert.SerializeObject(character));
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
            SaveStorage(sessionID, storeSave, false);
        }

        public static Character.Base? GetCharacter(string sessionID)
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

        public static string GetCompleteCharacter(string sessionID)
        {
            List<Character.Base> ouptut = new();
            if (!AccountController.IsWiped(sessionID))
            {
                ouptut.Add(GetCharacter(sessionID));
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
                SaveHandler.Save(sessionID, "Character", SaveHandler.GetCharacterPath(sessionID), JsonConvert.SerializeObject(character));
            }
            return output;
        }

        public static void ChangeVoice(string json, string sessionID)
        {
            var voices = JsonConvert.DeserializeObject<Voices>(json);
            if (voices == null) { return; }
            var character = GetCharacter(sessionID);
            character.Info.Voice = voices.Voice;
            SaveHandler.Save(sessionID, "Character", SaveHandler.GetCharacterPath(sessionID), JsonConvert.SerializeObject(character));
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

        public static void SaveStorage(string sessionID, List<string> suites, bool LoadFromFile = false)
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
                SaveHandler.Save(sessionID, "Character", SaveHandler.GetCharacterPath(sessionID), JsonConvert.SerializeObject(character));
            }
        }

        public static int GetLoyality(string SessionId, string TraderId)
        {
            var TraderLoyalityLevels = TraderController.GetBaseByTrader(TraderId).LoyaltyLevels;
            var character = GetCharacter(SessionId);

            int playerSaleSum = 0, calculatedLoyalty = 0, playerLevel = 0;
            double playerStanding = 0;

            playerLevel = character.Info.Level;
            switch (TraderId)
            {
                case "54cb50c76803fa8b248b4571":
                    playerSaleSum = character.TradersInfo._54cb50c76803fa8b248b4571.SalesSum;
                    playerStanding = character.TradersInfo._54cb50c76803fa8b248b4571.Standing;
                    break;
                case "54cb57776803fa99248b456e":
                    playerSaleSum = character.TradersInfo._54cb57776803fa99248b456e.SalesSum;
                    playerStanding = character.TradersInfo._54cb57776803fa99248b456e.Standing;
                    break;
                case "579dc571d53a0658a154fbec":
                    playerSaleSum = character.TradersInfo._579dc571d53a0658a154fbec.SalesSum;
                    playerStanding = character.TradersInfo._579dc571d53a0658a154fbec.Standing;
                    break;
                case "58330581ace78e27b8b10cee":
                    playerSaleSum = character.TradersInfo._58330581ace78e27b8b10cee.SalesSum;
                    playerStanding = character.TradersInfo._58330581ace78e27b8b10cee.Standing;
                    break;
                case "5935c25fb3acc3127c3d8cd9":
                    playerSaleSum = character.TradersInfo._5935c25fb3acc3127c3d8cd9.SalesSum;
                    playerStanding = character.TradersInfo._5935c25fb3acc3127c3d8cd9.Standing;
                    break;
                case "5a7c2eca46aef81a7ca2145d":
                    playerSaleSum = character.TradersInfo._5a7c2eca46aef81a7ca2145d.SalesSum;
                    playerStanding = character.TradersInfo._5a7c2eca46aef81a7ca2145d.Standing;
                    break;
                case "5ac3b934156ae10c4430e83c":
                    playerSaleSum = character.TradersInfo._5ac3b934156ae10c4430e83c.SalesSum;
                    playerStanding = character.TradersInfo._5ac3b934156ae10c4430e83c.Standing;
                    break;
                case "5c0647fdd443bc2504c2d371":
                    playerSaleSum = character.TradersInfo._5c0647fdd443bc2504c2d371.SalesSum;
                    playerStanding = character.TradersInfo._5c0647fdd443bc2504c2d371.Standing;
                    break;
                default:
                    break;
            }

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
    }
}
