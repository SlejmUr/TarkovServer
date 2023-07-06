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
        public static void SaveAll(string SessionId)
        {
            Debug.PrintInfo("Saving started...", "SAVE");
            Save(SessionId, "Account", GetAccountPath(SessionId), JsonConvert.SerializeObject(AccountController.FindAccount(SessionId)));
            Save(SessionId, "Character", GetCharacterPath(SessionId), Converters.ToJson(CharacterController.GetCharacter(SessionId)));
            Debug.PrintInfo("Saving ended!", "SAVE");
        }

        /// <summary>
        /// A separate function for only saving account
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="account">Account</param>
        public static void SaveAccount(string SessionId, Account account)
        {
            Debug.PrintInfo("Saving started...", "SAVE");
            Save(SessionId, "Account", GetAccountPath(SessionId), JsonConvert.SerializeObject(account));
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
            Save(SessionId, "Character", GetCharacterPath(SessionId), Converters.ToJson(character));
            Debug.PrintInfo("Saving ended!", "SAVE");
        }

        /// <summary>
        /// Saving by parameters
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="saveType">Account,Dialog,Storage(Customization),etc</param>
        /// <param name="path">Filepath where to save</param>
        /// <param name="Serialized">Json serilaized object</param>
        public static void Save(string SessionId, string saveType, string path, string Serialized)
        {
            if (!Directory.Exists($"profiles/{SessionId}"))
                Directory.CreateDirectory($"profiles/{SessionId}");

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
        /// Get the Character Path
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>String as PATH</returns>
        public static string GetCharacterPath(string SessionId)
        {
            return $"profiles/{SessionId}/character.json";
        }

        /// <summary>
        /// Get the Account Path
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>String as PATH</returns>
        public static string GetAccountPath(string SessionId)
        {
            return $"profiles/{SessionId}/account.json";
        }

        #endregion
    }
}
