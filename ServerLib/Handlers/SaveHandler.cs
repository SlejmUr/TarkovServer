using Newtonsoft.Json;
using ServerLib.Controllers;
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
            Debug.PrintInfo("Saving started...", "[SAVE]");
            Save(SessionId, "Account", GetAccountPath(SessionId), JsonConvert.SerializeObject(AccountController.FindAccount(SessionId)));
            Save(SessionId, "Dialog", GetDialogPath(SessionId), JsonConvert.SerializeObject(Controllers.DialogController.Dialogs[SessionId]));
            Save(SessionId, "Character", GetCharacterPath(SessionId), JsonConvert.SerializeObject(CharacterController.GetCharacter(SessionId)));
            Save(SessionId, "Storage", GetStoragePath(SessionId), "{}");
            Debug.PrintInfo("Saving ended!", "[SAVE]");
        }

        /// <summary>
        /// A separate function for only saving account
        /// <br>Soon will be removed?</br>
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="account">Account</param>
        public static void SaveAccount(string SessionId, Json.Account account)
        {
            Debug.PrintInfo("Saving started...", "[SAVE]");
            Save(SessionId, "Account", GetAccountPath(SessionId), JsonConvert.SerializeObject(account));
            Debug.PrintInfo("Saving ended!", "[SAVE]");
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
            DatabaseController.FileAges[SessionId + "_" + saveType] = File.GetLastWriteTime(path);
            if (File.Exists(path))
            {
                var time = File.GetLastWriteTime(path);
                if (DatabaseController.FileAges[SessionId + "_" + saveType] == time)
                {
                    var fromMemory = Serialized;
                    var saved = File.ReadAllText(path);

                    if (fromMemory != saved)
                    {
                        File.WriteAllText(path, Serialized);
                        time = File.GetLastWriteTime(path);
                        DatabaseController.FileAges[SessionId + "_" + saveType] = time;
                        Debug.PrintDebug($"{saveType} file for account {SessionId} was saved to disk.");
                    }
                }
                else
                {
                    DatabaseController.FileAges[SessionId + "_Account"] = time;
                    Debug.PrintDebug($"{saveType} file for account  {SessionId} was modified, reloaded.");
                }
            }
            else
            {
                File.WriteAllText(path, Serialized);
                var time = File.GetLastWriteTime(path);
                DatabaseController.FileAges[SessionId + "_" + saveType] = time;
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
        #endregion
        #region Delete
        /// <summary>
        /// Delete everything FileAge related for Session
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void DeleteAll(string SessionId)
        {
            Delete(SessionId, "Account");
            Delete(SessionId, "Dialog");
            Delete(SessionId, "Character");
            Delete(SessionId, "Storage");
        }

        /// <summary>
        /// Delete FileAge by Parameters
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="saveType">Account,Dialog,Storage(Customization),etc</param>
        public static void Delete(string SessionId, string saveType)
        {
            DatabaseController.FileAges.Remove(SessionId + "_" + saveType);
        }
        #endregion
    }
}
