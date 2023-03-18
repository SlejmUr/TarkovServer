using Newtonsoft.Json;
using ServerLib.Handlers;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class DialogController
    {
        public static Dictionary<string, Json.Dialog> Dialogs;
        public enum messageTypes
        {
            npcTrader = 2,
            auctionMessage = 3,
            fleamarketMessage = 4,
            insuranceReturn = 8,
            questStart = 10,
            questFail = 11,
            questSuccess = 12,
        };

        public static void Init()
        {
            Dialogs = new();
            Dialogs.Clear();
            Debug.PrintInfo("Initialization Done!", "[DIALOG]");
        }

        /// <summary>
        /// Initalize Dialog
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void InitializeDialog(string SessionId)
        {
            ReloadDialog(SessionId);
            Debug.PrintDebug($"(Re)Loaded dialogues for AID: {SessionId} successfully.");
        }

        /// <summary>
        /// Reload Dialog
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void ReloadDialog(string SessionId)
        {
            if (File.Exists(SaveHandler.GetDialogPath(SessionId)))
            {
                Dialogs[SessionId] = JsonConvert.DeserializeObject<Json.Dialog>(File.ReadAllText(SaveHandler.GetDialogPath(SessionId)));
            }
        }

        /// <summary>
        /// Add new Dialog Message
        /// </summary>
        /// <param name="dialogID">DialogID</param>
        /// <param name="content">MessageContent</param>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="rewards">StashItem</param>
        public static void AddDialogMessage(string dialogID, Json.Dialog.MessagesContent content, string SessionId, Json.Dialog.StashItems rewards)
        {
            ReloadDialog(SessionId);

            if (Dialogs[SessionId] == null)
            {
                InitializeDialog(SessionId);
            }

            var dialogData = Dialogs[SessionId];
            var isnewDialog = dialogData._id != dialogID;

            if (isnewDialog)
            {
                Json.Dialog dialog = new()
                {
                    _id = dialogID,
                    messages = new(),
                    pinned = false,
                    New = 0,
                    attachmentsNew = 0
                };

                dialogData = dialog;
            }

            dialogData.New += 1;

            Json.Dialog.StashItems stashItems = new();

            //Todo, make reward items a new Json thingy
            //rewards = HelperController.ReplaceIDs(null,rewards);

            if (rewards.ToString().Length > 0)
            {
                string stashId = Utils.CreateNewID();
                stashItems.stash = stashId;
                stashItems.data = new();
                foreach (var reward in rewards.data)
                {

                    if (reward.slotId.Length == 0 || reward.slotId == "hideout")
                    {
                        reward.parentId = stashId;
                        reward.slotId = "main";


                    }
                    stashItems.data.Add(reward);
                }

                dialogData.attachmentsNew += 1;
            }
            Json.Dialog.Messages message = new()
            {
                _id = Utils.CreateNewID(),
                uid = dialogID,
                type = content.type,
                dt = Time.UnixTimeNow_Int(),
                templateId = content.templateId,
                text = content.text,
                hasRewards = stashItems.ToString().Length > 0,
                rewardCollected = false,
                items = stashItems,
                maxStorageTime = content.maxStorageTime,
                systemData = content.systemData
            };

            dialogData.messages.Add(message);
        }

        /// <summary>
        /// Remove Dialog
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void RemoveDialog(string SessionId)
        {
            ReloadDialog(SessionId);
            Dialogs.Remove(SessionId);
        }

        /// <summary>
        /// Set the Dialog as Pinned
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="shouldPin">True | False</param>
        public static void SetDialogPin(string SessionId, bool shouldPin)
        {
            ReloadDialog(SessionId);
            Dialogs[SessionId].pinned = shouldPin;
        }

        /// <summary>
        /// Set the Dialog as Readed
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void SetRead(string SessionId)
        {
            ReloadDialog(SessionId);
            Dialogs[SessionId].New = 0;
            Dialogs[SessionId].attachmentsNew = 0;
        }

        /// <summary>
        /// Remove Expired Items from Dialog
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void RemoveExpiredItems(string SessionId)
        {
            ReloadDialog(SessionId);
            int curDt = Time.UnixTimeNow_Int();

            foreach (var msg in Dialogs[SessionId].messages)
            {
                if (curDt > msg.dt + msg.maxStorageTime)
                {
                    msg.items = new();
                }
            }
        }

        /// <summary>
        /// Generate New Dialog List
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>Serialized Dialog List</returns>
        public static string GenerateDialogList(string SessionId)
        {
            ReloadDialog(SessionId);

            List<Json.Dialog> data = new();
            var dialogId = Dialogs[SessionId]._id;

            data.Add(GetDialogInfo(dialogId, SessionId));

            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Generate new Dialog View
        /// </summary>
        /// <param name="dialogueId">DialogID</param>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>Serialized Dialog Messages | null</returns>
        public static string GenerateDialogView(string dialogueId, string SessionId)
        {
            ReloadDialog(SessionId);

            var dialog = Dialogs[SessionId];

            if (dialog._id != dialogueId)
            {
                return null;
            }

            dialog.New = 0;
            int _attachmentsNew = 0;
            int curDt = Time.UnixTimeNow_Int();

            foreach (var msg in dialog.messages)
            {
                if (msg == null) { return null; }
                if (msg.hasRewards && !msg.rewardCollected && curDt < msg.dt + msg.maxStorageTime)
                {
                    _attachmentsNew++;
                }
            }
            dialog.attachmentsNew = _attachmentsNew;
            return JsonConvert.SerializeObject(dialog.messages);
        }

        /// <summary>
        /// Get all Attachments
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>Serialized Dialog Messages List</returns>
        public static string GetAllAttachments(string SessionId)
        {
            ReloadDialog(SessionId);
            List<Json.Dialog.Messages> output = new();
            int curDt = Time.UnixTimeNow_Int();

            foreach (var msg in Dialogs[SessionId].messages)
            {
                if (curDt < msg.dt + msg.maxStorageTime)
                {
                    output.Add(msg);
                }
            }
            Dialogs[SessionId].attachmentsNew = 0;
            return JsonConvert.SerializeObject(output);
        }

        /// <summary>
        /// Get New Dialog
        /// </summary>
        /// <param name="dialogueId">DialogID</param>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>New Dialog</returns>
        public static Json.Dialog GetDialogInfo(string dialogueId, string SessionId)
        {
            var dialog = Dialogs[SessionId];
            Json.Dialog dialog_ret = new()
            {
                _id = dialogueId,
                type = messageTypes.npcTrader,
                messages = new() { GetMessagePreview(dialog) },
                New = dialog.New,
                attachmentsNew = dialog.attachmentsNew,
                pinned = dialog.pinned,
            };
            return dialog_ret;
        }

        /// <summary>
        /// Get New Dialog Message
        /// </summary>
        /// <param name="dialog">DialogID</param>
        /// <returns>New Dialog Messages</returns>
        public static Json.Dialog.Messages GetMessagePreview(Json.Dialog dialog)
        {
            // The last message of the dialogue should be shown on the preview.
            var message = dialog.messages[dialog.messages.Count - 1];
            Json.Dialog.Messages message_ret = new()
            {
                dt = message.dt,
                type = message.type,
                templateId = message.templateId,
                uid = dialog._id
            };
            return message_ret;
        }

        /// <summary>
        /// Get all StashItem Data
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="messageId">MessageID</param>
        /// <returns>StashItem Data List | null</returns>
        public static List<Json.Dialog.StashItems.StashData> GetMessageItemContents(string SessionId, string messageId)
        {
            ReloadDialog(SessionId);
            foreach (var msg in Dialogs[SessionId].messages)
            {
                if (msg._id == messageId)
                {
                    var atm = Dialogs[SessionId].attachmentsNew;
                    if (atm > 0)
                    {
                        Dialogs[SessionId].attachmentsNew = atm - 1;
                    }
                    msg.rewardCollected = true;
                    return msg.items.data;
                }
            }
            return null;
        }
    }
}
