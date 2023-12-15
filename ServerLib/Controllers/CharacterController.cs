using JsonLib;
using JsonLib.Classes.ProfileRelated;
using JsonLib.Classes.Request;
using JsonLib.Helpers;
using Newtonsoft.Json;
using ServerLib.Generators;
using ServerLib.Handlers;
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
            ProfileController.ReloadProfiles();
            foreach (var prof in ProfileController.ProfilesDict)
            {
                var val = prof.Value;
                if (val == null)
                    continue;
                var characters = val.Characters;
                if (characters == null)
                    continue;
                Characters.TryAdd($"pmc{prof.Key}", characters.Pmc);
                Characters.TryAdd($"scav{prof.Key}", characters.Scav);

            }
        }

        /// <summary>
        /// Load Character to List
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void LoadCharacter(string SessionId)
        {
            ReloadCharacters();
            if (ProfileController.ProfilesDict.TryGetValue(SessionId, out var profile))
            {
                Characters.TryAdd($"pmc{SessionId}", profile.Characters.Pmc);
                Characters.TryAdd($"scav{SessionId}", profile.Characters.Scav);
            }
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
            var time = TimeHelper.UnixTimeNow_Int();

            character.Id = "pmc" + SessionId;
            character.Aid = AIDHelper.ToAID(SessionId);
            character.Savage = "scav" + SessionId;
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
            character.Inventory = InventoryController.AssingInventory(character.Inventory);
            SaveHandler.Save(SessionId, "Character", SaveHandler.GetCharacterPath(SessionId), JsonHelper.FromCharacterBase(character));
            var storage = DatabaseController.DataBase.Characters.CharacterStorage[createReq.Side.ToLower()];
            SaveHandler.Save(SessionId, "Storage", SaveHandler.GetStoragePath(SessionId), JsonConvert.SerializeObject(storage));
            if (!Characters.ContainsKey(character.Id))
            {
                Characters.Add(character.Id, character);
            }
            else
            {
                Characters.Remove(character.Id);
                Characters.Add(character.Id, character);
            }

            //Generate scav
            var scav = Scav.Generate(SessionId);
            SaveHandler.Save(SessionId, "Scav", SaveHandler.GetScavPath(SessionId), JsonHelper.FromCharacterBase(scav));
            if (!Characters.ContainsKey(scav.Id))
            {
                Characters.Add(scav.Id, scav);
            }
            else
            {
                Characters.Remove(scav.Id);
                Characters.Add(scav.Id, scav);
            }

            //Item ReID
            Debug.PrintInfo($"Character Created with Id {SessionId}!", "CHARACTER");
        }

        public static Character.Base? GetPmcCharacter(string SessionId)
        {
            LoadCharacter(SessionId);
            if (Characters.TryGetValue($"pmc{SessionId}", out var character))
            {
                return character;
            }
            Debug.PrintWarn($"Character isnt made for {SessionId}!", "GetPmcCharacter");
            return null;
        }

        public static Character.Base? GetMiniCharacter(string SessionId)
        {
            LoadCharacter(SessionId);
            if (Characters.TryGetValue($"pmc{SessionId}", out var character))
            {
                return new()
                {
                    Id = character.Id,
                    Aid = character.Aid,
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
            if (Characters.TryGetValue($"scav{SessionId}", out var character))
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
                /*
                var scav = JsonHelper.ToCharacterBase("Files/bot/playerScav.json");
                scav.Aid = AIDHelper.ToAID(SessionId);
                scav.Id = "scav" + SessionId;
                scav.Info.RegistrationDate = TimeHelper.UnixTimeNow_Int();
                */
                
                var scav = GetScavCharacter(SessionId);
                if (scav != null) 
                {
                    ouptut.Add(scav);
                }
                var character = GetPmcCharacter(SessionId);
                if (character != null)
                {
                    ouptut.Add(character);
                    //ouptut.Add(scav);
                }


            }

            return JsonConvert.SerializeObject(ouptut, new JsonConverter[] { Converters.ItemLocationConverter.Singleton });
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

            var voices = JsonConvert.DeserializeObject<Voice>(json);
            if (voices == null) { return; }

            character.Info.Voice = voices.voice;
            SaveHandler.Save(SessionId, "Character", SaveHandler.GetCharacterPath(SessionId), JsonConvert.SerializeObject(character));
        }

        public static void RaidKilled(string json, string SessionId)
        {
            var raidKilled = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            if (raidKilled == null) { return; }

            if (raidKilled["killedByAID"] != null && raidKilled["killedByAID"].ToString() == SessionId)
            {
                var character = GetPmcCharacter(SessionId);
                ArgumentNullException.ThrowIfNull(character);

                if (raidKilled["diedFaction"].ToString() == "Savage" || raidKilled["diedFaction"].ToString() == "Scav")
                {
                    if (ConfigController.Configs.Gameplay.Trading.Fence.KillingScavsFenceLevelChange.HasValue)
                        character.TradersInfo["_579dc571d53a0658a154fbec"].standing += (int)ConfigController.Configs.Gameplay.Trading.Fence.KillingScavsFenceLevelChange;

                }
                else if (raidKilled["diedFaction"].ToString() == "Usec" || raidKilled["diedFaction"].ToString() == "Bear")
                {
                    if (ConfigController.Configs.Gameplay.Trading.Fence.KillingPMCsFenceLevelChange.HasValue)
                        character.TradersInfo["_579dc571d53a0658a154fbec"].standing += (int)ConfigController.Configs.Gameplay.Trading.Fence.KillingPMCsFenceLevelChange;
                }
                SaveHandler.Save(SessionId, "Character", SaveHandler.GetCharacterPath(SessionId), JsonConvert.SerializeObject(character));
            }
        }



        public static void UpdateBackendCounters(string SessionId, string conditionId, string qid, int counter)
        {
            var character = GetPmcCharacter(SessionId);
            if (character == null)
                return;

            if (character.BackendCounters.TryGetValue(conditionId, out var backendCounter))
            {
                backendCounter.value += counter;
            }
            else
            {
                character.BackendCounters.Add(conditionId, new()
                {
                    id = conditionId,
                    qid = qid,
                    value = counter,
                });
            }
            SaveHandler.SaveCharacter(SessionId, character);
        }


        public static bool TryGetCharacter(string Id, out Character.Base? charbase)
        {
            charbase = default;
            if (Id.Contains("scav") || Id.Contains("pmc"))
            {
                return Characters.TryGetValue(Id, out charbase);
            }
            else //Auto Fallback to PMC
            {
                if (Characters.ContainsKey($"pmc{Id}"))
                {
                    charbase = Characters[$"pmc{Id}"];
                    return true;
                }
                else if(Characters.ContainsKey($"scav{Id}"))
                {
                    charbase = Characters[$"scav{Id}"];
                    return true;
                }
            }
            return false;
        }

        public static string GetCharacterSessionId(Character.Base @base)
        { 
            if (@base.Id.Contains("pmc"))
                return @base.Id.Replace("pmc","");
            if (@base.Id.Contains("scav"))
                return @base.Id.Replace("scav", "");
            return string.Empty;
        }

        public static bool IsCharacterPMC(Character.Base @base)
        {
            return @base.Id.Contains("pmc");
        }

        public static bool IsCharacterScav(Character.Base @base)
        {
            return @base.Id.Contains("scav");
        }
    }
}
