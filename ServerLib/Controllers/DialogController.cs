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
        public static string GetDialoguePath(string sessionID)
        {
            return $"user/profiles/{sessionID}/dialogue.json";
        }

        public static void ReloadDialogue(string sessionID)
        {
            if (File.Exists(GetDialoguePath(sessionID)))
            {
                Dialogs[sessionID] = JsonConvert.DeserializeObject<Dialog>(File.ReadAllText(GetDialoguePath(sessionID)));
            }
        }
        public static void InitializeDialogue(string sessionID)
        {
            ReloadDialogue(sessionID);
            Utils.PrintDebug($"(Re)Loaded dialogues for AID: {sessionID} successfully.");
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
        public static string GenerateDialogueList(string sessionID)
        {
            // Reload dialogues before continuing.
            ReloadDialogue(sessionID);

            List<Dialog> data = new();
            var dialogueId = Dialogs[sessionID]._id;

           data.Add(GetDialogueInfo(dialogueId, sessionID));

            return JsonConvert.SerializeObject(data);
        }

        public static void dd()
        { 
        
        
        }

    }
}
