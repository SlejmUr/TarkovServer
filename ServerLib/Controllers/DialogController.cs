using ServerLib.Utilities;
using ServerLib.Json;
using Newtonsoft.Json;

namespace ServerLib.Controllers
{
    public class DialogController
    {
        public static Dictionary<string, Dialog> Dialogs;
        public static Dictionary<string, DateTime> DialogFileAge;
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
            DialogFileAge = new();
            DialogFileAge.Clear();
            Utils.PrintDebug("Initialization Done!", "debug", "[DIALOG]");
        }
        public static void InitializeDialogue(string sessionID)
        {
            ReloadDialogue(sessionID);
            Utils.PrintDebug($"(Re)Loaded dialogues for AID: {sessionID} successfully.");
        }
        public static void ReloadDialogue(string sessionID)
        {
            if (File.Exists(GetDialoguePath(sessionID)))
            {
                Dialogs[sessionID] = JsonConvert.DeserializeObject<Dialog>(File.ReadAllText(GetDialoguePath(sessionID)));
            }
        }
        public static void SaveToDisk(string sessionID)
        {
            string path = GetDialoguePath(sessionID);
            if (Dialogs[sessionID] != null)
            {
                if (File.Exists(path))
                {
                    var time = File.GetLastWriteTime(path);
                    if (DialogFileAge[sessionID] == time)
                    {
                        var dialog = JsonConvert.SerializeObject(Dialogs[sessionID]);
                        var saved = File.ReadAllText(GetDialoguePath(sessionID));

                        if (dialog != saved)
                        {
                            File.WriteAllText(path, JsonConvert.SerializeObject(Dialogs[sessionID]));
                            time = File.GetLastWriteTime(path);
                            DialogFileAge[sessionID] = time;
                            Utils.PrintDebug($"Dialogues for AID {sessionID} was saved.");
                        }
                    }
                    else
                    {
                        Dialogs[sessionID] = JsonConvert.DeserializeObject<Dialog>(File.ReadAllText(GetDialoguePath(sessionID)));
                        DialogFileAge[sessionID] = time;
                        Utils.PrintDebug($"Dialogues for AID {sessionID} were modified elsewhere. Dialogue was reloaded successfully.");
                    }
                }
                else
                {
                    File.WriteAllText(path, JsonConvert.SerializeObject(Dialogs[sessionID]));
                    var time = File.GetLastWriteTime(path);
                    DialogFileAge[sessionID] = time;
                    Utils.PrintDebug($"Dialogues for AID {sessionID} was created and saved.");
                }
            }
        }
        public static void AddDialogueMessage(string dialogueID,Dialog.MessagesContent content, string sessionID, Dialog.StashItems rewards)
        {
            ReloadDialogue(sessionID);

            if (Dialogs[sessionID] == null)
            {
                InitializeDialogue(sessionID);
            }

            var dialogData = Dialogs[sessionID];
            var isnewDialog = dialogData._id != dialogueID;

            if (isnewDialog)
            { 
                Dialog dialog = new()
                { 
                    _id = dialogueID,
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
                uid = dialogueID,
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
        public static void RemoveDialogue(string sessionID)
        {
            ReloadDialogue(sessionID);
            Dialogs.Remove(sessionID);
        }
        public static void SetDialoguePin(string sessionID, bool shouldPin)
        {
            ReloadDialogue(sessionID);
            Dialogs[sessionID].pinned = shouldPin;
        }
        public static void SetRead(string sessionID)
        {
            ReloadDialogue(sessionID);
            Dialogs[sessionID].New = 0;
            Dialogs[sessionID].attachmentsNew = 0;
        }
        public static void RemoveExpiredItems(string sessionID)
        {
            ReloadDialogue(sessionID);
            int curDt = Utils.UnixTimeNow_Int();

            foreach (var msg in Dialogs[sessionID].messages)
            {
                if (curDt > msg.dt + msg.maxStorageTime)
                {
                    msg.items = new();
                }
            }
        }
        public static string GenerateDialogueList(string sessionID)
        {
            // Reload dialogues before continuing.
            ReloadDialogue(sessionID);

            List<Dialog> data = new();
            var dialogueId = Dialogs[sessionID]._id;

            data.Add(GetDialogueInfo(dialogueId, sessionID));

            return JsonConvert.SerializeObject(data);
        }
        public static string GetDialoguePath(string sessionID)
        {
            return $"user/profiles/{sessionID}/dialogue.json";
        }
        public static string GenerateDialogueView(string dialogueId, string sessionID)
        {
            ReloadDialogue(sessionID);

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
            ReloadDialogue(sessionID);

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
        public static Dialog GetDialogueInfo(string dialogueId, string sessionID)
        {
            var dialogue = Dialogs[sessionID];
            Dialog dialog = new()
            {
                _id = dialogueId,
                type = (messageTypes)2,
                messages = new() { GetMessagePreview(dialogue) },
                New =  dialogue.New,
                attachmentsNew = dialogue.attachmentsNew,
                pinned = dialogue.pinned,
            };
            return dialog;
        }
        public static Dialog.Messages GetMessagePreview(Dialog dialogue)
        {
            // The last message of the dialogue should be shown on the preview.
            var message = dialogue.messages[dialogue.messages.Count - 1];
            Dialog.Messages message_ret = new()
            {
                dt = message.dt,
                type = message.type,
                templateId = message.templateId,
                uid = dialogue._id
            };
            return message_ret;
        }
        public static List<Dialog.StashItems.StashData> GetMessageItemContents(string sessionID,string messageId)
        {
            ReloadDialogue(sessionID);
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
