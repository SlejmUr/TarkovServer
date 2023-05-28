using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Json.Classes;
using ServerLib.Utilities;

namespace ServerLib.Handlers
{
    public class SaveHandler
    {
        #region Save
        /// <summary>
        /// Save all Session related stuff at once
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void SaveAll(string SessionId,bool IsAki = false)
        {
            Debug.PrintInfo("Saving started...", "SAVE");
            if (IsAki)
            {
                Save(SessionId, "Aki", GetAkiPath(SessionId), JsonConvert.SerializeObject(ProfileController.ProfilesDict[SessionId]), IsAki);
            }
            else
            {
                Save(SessionId, "Account", GetAccountPath(SessionId), JsonConvert.SerializeObject(AccountController.FindAccount(SessionId)));
                Save(SessionId, "Dialog", GetDialogPath(SessionId), JsonConvert.SerializeObject(Controllers.DialogueController.Dialogs[SessionId]));
                Save(SessionId, "Character", GetCharacterPath(SessionId), JsonConvert.SerializeObject(CharacterController.GetPmcCharacter(SessionId)));
                Save(SessionId, "Storage", GetStoragePath(SessionId), JsonConvert.SerializeObject(ProfileController.ProfilesDict[SessionId].Suits));

            }
            Debug.PrintInfo("Saving ended!", "SAVE");
        }

        /// <summary>
        /// A separate function for only saving account
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="account">Account</param>
        public static void SaveAccount(string SessionId, Profile.Info account)
        {
            Debug.PrintInfo("Saving started...", "SAVE");
            Save(SessionId, "Account", GetAccountPath(SessionId), JsonConvert.SerializeObject(account));
            Debug.PrintInfo("Saving ended!", "SAVE");
        }

        public static void SaveAddon(string SessionId, ProfileAddon account)
        {
            Debug.PrintInfo("Saving started...", "SAVE");
            Save(SessionId, "Others", GetOthersPath(SessionId), JsonConvert.SerializeObject(account));
            Debug.PrintInfo("Saving ended!", "SAVE");
        }

        /// <summary>
        ///  A separate function for only saving character
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="character">Character</param>
        public static void SaveCharacter(string SessionId, Character.Base character)
        {
            Debug.PrintInfo("Saving started...", "SAVE");
            Save(SessionId, "Character", GetCharacterPath(SessionId), JsonConvert.SerializeObject(character));
            Debug.PrintInfo("Saving ended!", "SAVE");
        }

        /// <summary>
        /// Saving by parameters
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="saveType">Account,Dialog,Storage(Customization),etc</param>
        /// <param name="path">Filepath where to save</param>
        /// <param name="Serialized">Json serilaized object</param>
        public static void Save(string SessionId, string saveType, string path, string Serialized, bool isAki = false)
        {
            if (!Directory.Exists($"user/profiles/{SessionId}") && !isAki) { Directory.CreateDirectory($"user/profiles/{SessionId}"); }
            if (File.Exists(path))
            {
                var saved = File.ReadAllText(path);
                if (Serialized != saved)
                {
                    File.WriteAllText(path, Serialized);
                    Debug.PrintDebug($"{saveType} file for account {SessionId} was saved to disk.");
                }
            }
            else
            {
                File.WriteAllText(path, Serialized);
                Debug.PrintDebug($"New {saveType} {SessionId} registered and was saved to disk.");
            }
        }
        #endregion
        #region Paths

        /// <summary>
        /// Get the Aki Profile Path
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>String as PATH</returns>
        public static string GetAkiPath(string SessionId)
        {
            return $"user/profiles/{SessionId}.json";
        }

        /// <summary>
        /// Get the Character Path
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>String as PATH</returns>
        public static string GetCharacterPath(string SessionId)
        {
            return $"user/profiles/{SessionId}/character.json";
        }

        /// <summary>
        /// Get the Account Path
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>String as PATH</returns>
        public static string GetAccountPath(string SessionId)
        {
            return $"user/profiles/{SessionId}/account.json";
        }

        /// <summary>
        /// Get the Storage Path
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>String as PATH</returns>
        public static string GetStoragePath(string SessionId)
        {
            return $"user/profiles/{SessionId}/storage.json";
        }

        /// <summary>
        /// Get the Dialog Path
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>String as PATH</returns>
        public static string GetDialogPath(string SessionId)
        {
            return $"user/profiles/{SessionId}/dialog.json";
        }

        /// <summary>
        /// Get the Others Path
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>String as PATH</returns>
        public static string GetOthersPath(string SessionId)
        {
            return $"user/profiles/{SessionId}/others.json";
        }

        /// <summary>
        /// Get the Scav Path
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>String as PATH</returns>
        public static string GetScavPath(string SessionId)
        {
            return $"user/profiles/{SessionId}/scav.json";
        }

        #endregion
    }
}
