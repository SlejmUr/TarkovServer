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
        public static void InitializeDialog(string sessionID)
        {
            ReloadDialog(sessionID);
            Utils.PrintDebug($"(Re)Loaded dialogues for AID: {sessionID} successfully.");
        }
        public static void ReloadDialog(string sessionID)
        {
            if (File.Exists(SaveHandler.GetDialogPath(sessionID)))
            {
                Dialogs[sessionID] = JsonConvert.DeserializeObject<Dialog>(File.ReadAllText(SaveHandler.GetDialogPath(sessionID)));
            }
        }
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
                string stashId = Utils.CreateNewProfileID();
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
                _id = Utils.CreateNewProfileID(),
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
        public static void RemoveDialog(string sessionID)
        {
            ReloadDialog(sessionID);
            Dialogs.Remove(sessionID);
        }
        public static void SetDialogPin(string sessionID, bool shouldPin)
        {
            ReloadDialog(sessionID);
            Dialogs[sessionID].pinned = shouldPin;
        }
        public static void SetRead(string sessionID)
        {
            ReloadDialog(sessionID);
            Dialogs[sessionID].New = 0;
            Dialogs[sessionID].attachmentsNew = 0;
        }
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
        public static string GenerateDialogList(string sessionID)
        {
            // Reload dialogues before continuing.
            ReloadDialog(sessionID);

            List<Dialog> data = new();
            var dialogId = Dialogs[sessionID]._id;

            data.Add(GetDialogInfo(dialogId, sessionID));

            return JsonConvert.SerializeObject(data);
        }
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

            return new();
        }
    }
}
