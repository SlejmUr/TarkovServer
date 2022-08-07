using ServerLib.Utilities;
using ServerLib.Json;
using Newtonsoft.Json;
using ServerLib.Handlers;

namespace ServerLib.Controllers
{
    public class DialogController
    {
        public static Dictionary<string, Dialog> Dialogs;
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
            Utils.PrintDebug("Initialization Done!", "debug", "[DIALOG]");
        }

        /// <summary>
        /// Initalize Dialog
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        public static void InitializeDialog(string sessionID)
        {
            ReloadDialog(sessionID);
            Utils.PrintDebug($"(Re)Loaded dialogues for AID: {sessionID} successfully.");
        }

        /// <summary>
        /// Reload Dialog
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        public static void ReloadDialog(string sessionID)
        {
            if (File.Exists(SaveHandler.GetDialogPath(sessionID)))
            {
                Dialogs[sessionID] = JsonConvert.DeserializeObject<Dialog>(File.ReadAllText(SaveHandler.GetDialogPath(sessionID)));
            }
        }

        /// <summary>
        /// Add new Dialog Message
        /// </summary>
        /// <param name="dialogID">DialogID</param>
        /// <param name="content">MessageContent</param>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <param name="rewards">StashItem</param>
        public static void AddDialogMessage(string dialogID,Dialog.MessagesContent content, string sessionID, Dialog.StashItems rewards)
        {
            ReloadDialog(sessionID);

            if (Dialogs[sessionID] == null)
            {
                InitializeDialog(sessionID);
            }

            var dialogData = Dialogs[sessionID];
            var isnewDialog = dialogData._id != dialogID;

            if (isnewDialog)
            { 
                Dialog dialog = new()
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

            Dialog.StashItems stashItems = new();

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
            Dialog.Messages message = new()
            {
                _id = Utils.CreateNewID(),
                uid = dialogID,
                type = content.type,
                dt = Utils.UnixTimeNow_Int(),
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
        /// <param name="sessionID">SessionId/AccountId</param>
        public static void RemoveDialog(string sessionID)
        {
            ReloadDialog(sessionID);
            Dialogs.Remove(sessionID);
        }

        /// <summary>
        /// Set the Dialog as Pinned
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <param name="shouldPin">True | False</param>
        public static void SetDialogPin(string sessionID, bool shouldPin)
        {
            ReloadDialog(sessionID);
            Dialogs[sessionID].pinned = shouldPin;
        }

        /// <summary>
        /// Set the Dialog as Readed
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        public static void SetRead(string sessionID)
        {
            ReloadDialog(sessionID);
            Dialogs[sessionID].New = 0;
            Dialogs[sessionID].attachmentsNew = 0;
        }

        /// <summary>
        /// Remove Expired Items from Dialog
        /// </summary>
        /// <param name="sessionID">SessionId/AccountId</param>
        public static void RemoveExpiredItems(string sessionID)
        {
            ReloadDialog(sessionID);
            int curDt = Utils.UnixTimeNow_Int();

            foreach (var msg in Dialogs[sessionID].messages)
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
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>Serialized Dialog List</returns>
        public static string GenerateDialogList(string sessionID)
        {
            ReloadDialog(sessionID);

            List<Dialog> data = new();
            var dialogId = Dialogs[sessionID]._id;

            data.Add(GetDialogInfo(dialogId, sessionID));

            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Generate new Dialog View
        /// </summary>
        /// <param name="dialogueId">DialogID</param>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>Serialized Dialog Messages | null</returns>
        public static string GenerateDialogView(string dialogueId, string sessionID)
        {
            ReloadDialog(sessionID);

            var dialog = Dialogs[sessionID];

            if (dialog._id != dialogueId)
            {
                return null;
            }

            dialog.New = 0;
            int _attachmentsNew = 0;
            int curDt = Utils.UnixTimeNow_Int();

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
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>Serialized Dialog Messages List</returns>
        public static string GetAllAttachments(string sessionID)
        {
            ReloadDialog(sessionID);
            List<Dialog.Messages> output = new();
            int curDt = Utils.UnixTimeNow_Int();

            foreach (var msg in Dialogs[sessionID].messages)
            {
                if (curDt < msg.dt + msg.maxStorageTime)
                {
                    output.Add(msg);
                }
            }
            Dialogs[sessionID].attachmentsNew = 0;
            return JsonConvert.SerializeObject(output);
        }

        /// <summary>
        /// Get New Dialog
        /// </summary>
        /// <param name="dialogueId">DialogID</param>
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <returns>New Dialog</returns>
        public static Dialog GetDialogInfo(string dialogueId, string sessionID)
        {
            var dialog = Dialogs[sessionID];
            Dialog dialog_ret = new()
            {
                _id = dialogueId,
                type = (messageTypes)2,
                messages = new() { GetMessagePreview(dialog) },
                New =  dialog.New,
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
        public static Dialog.Messages GetMessagePreview(Dialog dialog)
        {
            // The last message of the dialogue should be shown on the preview.
            var message = dialog.messages[dialog.messages.Count - 1];
            Dialog.Messages message_ret = new()
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
        /// <param name="sessionID">SessionId/AccountId</param>
        /// <param name="messageId">MessageID</param>
        /// <returns>StashItem Data List | null</returns>
        public static List<Dialog.StashItems.StashData> GetMessageItemContents(string sessionID,string messageId)
        {
            ReloadDialog(sessionID);
            foreach (var msg in Dialogs[sessionID].messages)
            {
                if (msg._id == messageId)
                {
                    var atm = Dialogs[sessionID].attachmentsNew;
                    if (atm > 0)
                    {
                        Dialogs[sessionID].attachmentsNew = atm - 1;
                    }
                    msg.rewardCollected = true;
                    return msg.items.data;
                }
            }
            return null;
        }
    }
}
