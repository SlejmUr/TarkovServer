using Newtonsoft.Json;
using ServerLib.Utilities;
using ServerLib.Controllers;

namespace ServerLib.Handlers
{
    public class SaveHandler
    {
        #region Save
        /// <summary>
        /// Save all Session related stuff at once
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        public static void SaveAll(string sessionID)
        {
            Utils.PrintDebug("Saving started...", "info","[SAVE]");
            Save(sessionID, "Account", GetAccountPath(sessionID), JsonConvert.SerializeObject(AccountController.FindAccount(sessionID)));
            Save(sessionID, "Dialog", GetDialogPath(sessionID), JsonConvert.SerializeObject(DialogController.Dialogs[sessionID]));
            Save(sessionID, "Character", GetCharacterPath(sessionID), "{}");
            Save(sessionID, "Storage", GetStoragePath(sessionID), "{}");
            Utils.PrintDebug("Saving ended!", "info", "[SAVE]");
        }

        /// <summary>
        /// A separate function for only saving account
        /// <br>Soon will be removed?</br>
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <param name="account">Account</param>
        public static void SaveAccount(string sessionID, Json.Account account)
        {
            Utils.PrintDebug("Saving started...", "info", "[SAVE]");
            Save(sessionID, "Account", GetAccountPath(sessionID), JsonConvert.SerializeObject(account));
            Utils.PrintDebug("Saving ended!", "info", "[SAVE]");
        }

        /// <summary>
        /// Saving by parameters
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <param name="saveType">Account,Dialog,Storage(Customization),etc</param>
        /// <param name="path">Filepath where to save</param>
        /// <param name="Serialized">Json serilaized object</param>
        public static void Save(string sessionID, string saveType, string path, string Serialized)
        {
            DatabaseController.FileAges[sessionID + "_" + saveType] = File.GetLastWriteTime(path);
            if (File.Exists(path))
            {
                var time = File.GetLastWriteTime(path);
                if (DatabaseController.FileAges[sessionID + "_" + saveType] == time)
                {
                    var fromMemory = Serialized;
                    var saved = File.ReadAllText(path);

                    if (fromMemory != saved)
                    {
                        File.WriteAllText(path, Serialized);
                        time = File.GetLastWriteTime(path);
                        DatabaseController.FileAges[sessionID + "_" + saveType] = time;
                        Utils.PrintDebug($"{saveType} file for account {sessionID} was saved to disk.");
                    }
                }
                else
                {
                    DatabaseController.FileAges[sessionID + "_Account"] = time;
                    Utils.PrintDebug($"{saveType} file for account  {sessionID} was modified, reloaded.");
                }
            }
            else
            {
                File.WriteAllText(path, Serialized);
                var time = File.GetLastWriteTime(path);
                DatabaseController.FileAges[sessionID + "_" + saveType] = time;
                Utils.PrintDebug($"New {saveType} {sessionID} registered and was saved to disk.");
            }

        }
        #endregion
        #region Paths
        /// <summary>
        /// Get the Character Path
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>String as PATH</returns>
        public static string GetCharacterPath(string sessionID)
        {
            return $"user/profiles/{sessionID}/character.json";
        }

        /// <summary>
        /// Get the Account Path
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>String as PATH</returns>
        public static string GetAccountPath(string sessionID)
        {
            return $"user/profiles/{sessionID}/account.json";
        }

        /// <summary>
        /// Get the Storage Path
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>String as PATH</returns>
        public static string GetStoragePath(string sessionID)
        {
            return $"user/profiles/{sessionID}/storage.json";
        }

        /// <summary>
        /// Get the Dialog Path
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>String as PATH</returns>
        public static string GetDialogPath(string sessionID)
        {
            return $"user/profiles/{sessionID}/dialog.json";
        }
        #endregion
        #region Delete
        /// <summary>
        /// Delete everything FileAge related for Session
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        public static void DeleteAll(string sessionID)
        {
            Delete(sessionID, "Account");
            Delete(sessionID, "Dialog");
            Delete(sessionID, "Character");
            Delete(sessionID, "Storage");
        }

        /// <summary>
        /// Delete FileAge by Parameters
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <param name="saveType">Account,Dialog,Storage(Customization),etc</param>
        public static void Delete(string sessionID,string saveType)
        {
            DatabaseController.FileAges.Remove(sessionID + "_" + saveType);
        }
        #endregion
    }
}
