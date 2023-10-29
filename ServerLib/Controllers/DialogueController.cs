using ServerLib.Utilities;
using ServerLib.Json.Classes;
using ServerLib.Utilities.Helpers;
using Newtonsoft.Json;
using ServerLib.Web;

namespace ServerLib.Controllers
{
    public class DialogueController
    {
        public static Dictionary<string, Dictionary<string, Profile.Dialogue>> Dialogs;

        public static void Init()
        {
            Dialogs = new();
            Debug.PrintInfo("Initialization Done!", "DIALOG");
        }

        public static void Reload()
        {
            foreach (var dict in ProfileController.ProfilesDict)
            {
                if (dict.Value.Dialogues == null || dict.Value.Dialogues.Count == 0)
                {
                    dict.Value.Dialogues = new();
                }
                Dialogs.Add(dict.Key, dict.Value.Dialogues);
            }
        }


        /// <summary>
        /// Reload Dialog
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static List<Profile.DialogueInfo> GetDialogs(string SessionId)
        {
            List<Profile.DialogueInfo> ret = new();
            Reload();
            try
            {
                var profile = ProfileController.GetProfile(SessionId);
                if (profile != null)
                {
                    if (profile.Dialogues == null || profile.Dialogues.Count == 0)
                    {
                        profile.Dialogues = new();
                    }
                    else
                    {
                        foreach (var dialogs in profile.Dialogues)
                        {
                            ret.Add(GetDialogInfo(SessionId, dialogs.Key));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

           
            return ret;
        }

        public static Profile.Dialogue GetDialog(string SessionId, string DialogueId)
        {
            Reload();
            Profile.Dialogue ret = new();
            if (Dialogs[SessionId].TryGetValue(DialogueId, out var dialogue))
            {
                return dialogue;
            }
            return ret;
        }

        /// <summary>
        /// Add new Dialog Message
        /// </summary>
        /// <param name="DialogueId">DialogID</param>
        /// <param name="content">MessageContent</param>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="rewards">StashItem</param>
        public static void AddDialogMessage(string SessionId, string DialogueId, Profile.MessageContent content, Profile.MessageItems rewards)
        {
            var dialogData = GetDialog(SessionId, DialogueId);
            var isnewDialog = dialogData._id != DialogueId;

            if (isnewDialog)
            {
                Profile.Dialogue dialog = new()
                {
                    _id = DialogueId,
                    messages = new(),
                    pinned = false,
                    New = 0,
                    attachmentsNew = 0
                };

                dialogData = dialog;
            }

            dialogData.New += 1;

            Profile.MessageItems stashItems = new();

            //Todo, make reward items a new Json thingy
            //rewards = HelperController.ReplaceIDs(null,rewards);

            if (rewards.data.Count > 0)
            {
                string stashId = AIDHelper.CreateNewID();
                stashItems.stash = stashId;
                stashItems.data = new();
                foreach (var reward in rewards.data)
                {

                    if (reward.SlotId.Length == 0 || reward.SlotId == "hideout")
                    {
                        reward.ParentId = stashId;
                        reward.SlotId = "main";

                    }
                    stashItems.data.Add(reward);
                }

                dialogData.attachmentsNew += 1;
            }
            Profile.Message message = new()
            {
                _id = AIDHelper.CreateNewID(),
                uid = DialogueId,
                type = content.type,
                dt = TimeHelper.UnixTimeNow_Int(),
                templateId = content.templateId,
                text = content.text,
                hasRewards = stashItems.data.Count > 0,
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
        public static void RemoveDialog(string SessionId, string DialogueId)
        {
            var profile = ProfileController.GetProfile(SessionId);
            if (profile != null)
                profile.Dialogues.Remove(DialogueId);
        }

        /// <summary>
        /// Set the Dialog as Pinned
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <param name="shouldPin">True | False</param>
        public static void SetDialogPin(string SessionId, string DialogueId, bool shouldPin)
        {
            var dialog = GetDialog(SessionId, DialogueId);
            dialog.pinned = shouldPin;
        }

        /// <summary>
        /// Set the Dialog as Readed
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void SetRead(string SessionId, string DialogueId)
        {
            var dialog = GetDialog(SessionId,DialogueId);
            dialog.New = 0;
            dialog.attachmentsNew = 0;
        }

        /// <summary>
        /// Remove Expired Items from Dialog
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        public static void RemoveExpiredItems(string SessionId, string DialogueId)
        {
            GetDialogs(SessionId);
            int curDt = TimeHelper.UnixTimeNow_Int();

            foreach (var dialog in Dialogs[SessionId].Values)
            {
                foreach (var msg in dialog.messages)
                {
                    if (curDt > msg.dt + msg.maxStorageTime)
                    {
                        msg.items = new();
                    }
                }
            }
        }


        /// <summary>
        /// Generate new Dialog View
        /// </summary>
        /// <param name="dialogueId">DialogID</param>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>Serialized Dialog Messages | null</returns>
        public static GetMailDialogView.Response GenerateDialogView(string SessionId, string DialogueId)
        {
            GetMailDialogView.Response response = new()
            { 
                messages = new(),
            };
            if (!string.IsNullOrEmpty(DialogueId))
            {
                var dialog = GetDialog(SessionId, DialogueId);
                dialog.New = 0;
                int _attachmentsNew = 0;
                int curDt = TimeHelper.UnixTimeNow_Int();

                foreach (var msg in dialog.messages)
                {
                    if (msg == null) { return response; }
                    if (msg.hasRewards && !msg.rewardCollected && curDt < msg.dt + msg.maxStorageTime)
                    {
                        _attachmentsNew++;
                    }
                }
                dialog.attachmentsNew = _attachmentsNew;
                response.messages.AddRange(dialog.messages);
                response.profiles.AddRange(GetProflesFromMail(SessionId, dialog.Users));
                response.hasMessagesWithRewards = HasUncollectedReward(SessionId, DialogueId);
                return response;
            }
            return response;
        }

        /// <summary>
        /// Get all Attachments
        /// </summary>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>Serialized Dialog Messages List</returns>
        public static GetAllAttachments.Response GetAllAttachments(string SessionId, string DialogueId)
        {
            GetAllAttachments.Response response = new()
            { 
                messages = new()
            };
            var dialogs = GetDialog(SessionId,DialogueId);
            dialogs.attachmentsNew = 0;
            var msg = GetActiveMessagesFromDialog(SessionId, DialogueId);
            response.messages.AddRange(GetMessageWithRewards(msg));
            response.hasMessagesWithRewards = HasUncollectedReward(SessionId, DialogueId);
            return response;
        }

        public static List<Profile.Message> GetActiveMessagesFromDialog(string SessionId, string DialogueId)
        {
            int curDt = TimeHelper.UnixTimeNow_Int();
            var dialogs = GetDialog(SessionId, DialogueId);
            return dialogs.messages.Where(x=> curDt < ( x.dt + x.maxStorageTime)).ToList();
        }

        public static bool HasUncollectedReward(string SessionId, string DialogueId)
        {
            var dialogs = GetDialog(SessionId, DialogueId);
            return dialogs.messages.Where(x => x.items != null && x.items.data != null && x.items.data.Count > 0).Any();
        }

        public static List<Profile.Message> GetMessageWithRewards(List<Profile.Message> messages)
        {
            return messages.Where(x => x.items != null && x.items.data != null && x.items.data.Count > 0).ToList();
        }

        public static List<Profile.UserDialogInfo> GetProflesFromMail(string SessionId, List<Profile.UserDialogInfo> users)
        {
            var pmc = CharacterController.GetPmcCharacter(SessionId);
            List<Profile.UserDialogInfo> ret = new();
            if (users != null && users.Count > 0)
            {
                ret.AddRange(users);
                ret.Add(new Profile.UserDialogInfo()
                { 
                    _id = pmc.Id,
                    info = new()
                    { 
                        Nickname = pmc.Info.Nickname,
                        Side = pmc.Info.Side,
                        Level = pmc.Info.Level,
                        MemberCategory = pmc.Info.MemberCategory
                    }
                });
            }

            return ret;
        }




        /// <summary>
        /// Get New Dialog
        /// </summary>
        /// <param name="DialogueId">DialogID</param>
        /// <param name="SessionId">SessionId/AccountId</param>
        /// <returns>New Dialog</returns>
        public static Profile.DialogueInfo GetDialogInfo(string SessionId, string DialogueId, bool IsTrader = false)
        {
            var dialog = ProfileController.GetProfile(SessionId).Dialogues[DialogueId];
            List<object> users = new();
            if (dialog.Users.Count > 0)
            {
                users.AddRange(dialog.Users);
            }
            return new()
            {
                _id = DialogueId,
                type = IsTrader ? dialog.type : ChatShared.EMessageType.NpcTraderMessage,
                message = GetMessagePreview(dialog),
                New = dialog.New,
                attachmentsNew = dialog.attachmentsNew,
                pinned = dialog.pinned,
                Users = users
            };
        }

        /// <summary>
        /// Get New Dialog Message
        /// </summary>
        /// <param name="dialog">DialogID</param>
        /// <returns>New Dialog Messages</returns>
        public static Profile.MessagePreview GetMessagePreview(Profile.Dialogue dialog)
        {
            // The last message of the dialogue should be shown on the preview.
            var message = dialog.messages[dialog.messages.Count - 1];
            var ret = new Profile.MessagePreview()
            {
                dt = message.dt,
                type = message.type,
                templateId = message.templateId,
                uid = dialog._id
            };
            if (!string.IsNullOrEmpty(message.text))
            {
                ret.text = message.text;
            }

            if (message.systemData != null)
            {
                ret.systemData = message.systemData;
            }
            return ret;
        }
    }
}
