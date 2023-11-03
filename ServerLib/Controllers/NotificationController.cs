using ModdableWebServer.Helper;
using Newtonsoft.Json;
using ServerLib.Json.Classes;
using ServerLib.Json.Enums;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using ServerLib.Web;

namespace ServerLib.Controllers
{
    public class NotificationController
    {
        public static Profile.Dialogue GetDialog(string SessionId, EMessageType messageType, Profile.UserDialogInfo dialogInfo)
        {
            var key = (dialogInfo.info.MemberCategory == 4) ? dialogInfo._id : dialogInfo.info.Nickname;
            if (!DialogueController.Dialogs[SessionId].TryGetValue(key, out var dialog))
            {
                List<Profile.UserDialogInfo> users = new();
                if (dialogInfo.info.MemberCategory != 4)
                {
                    users.Add(dialogInfo);
                }
                Profile.Dialogue dialogue = new()
                {
                    _id = key,
                    type = messageType,
                    messages = new(),
                    pinned = false,
                    attachmentsNew = 0,
                    New = 0,
                    Users = users
                };
                DialogueController.Dialogs[SessionId].Add(key, dialogue);
                return dialogue;
            }
            return dialog;
        }

        public static void SendMessageToPlayer(string SessionId, EMessageType messageType, Profile.UserDialogInfo dialogInfo, string messageText)
        {
            var dialog = GetDialog(SessionId, messageType, dialogInfo);
            dialog.New += 1;
            Profile.Message message = new()
            {
                _id = AIDHelper.CreateNewID(),
                uid = dialog._id,
                type = messageType,
                dt = TimeHelper.UnixTimeNow_Int(),
                text = messageText
            };
            dialog.messages.Add(message);
            SendNotificationMessage(SessionId, message);
        }


        public static Json.Classes.Notification DefaultNotification()
        {
            return new()
            {
                type = "ping",
                eventId = "ping",
            };
        }

        public static Json.Classes.Notification CreateNewNotification(Profile.Message message)
        {
            return new()
            {
                type = "new_message",
                eventId = message._id,
                dialogId = message.uid,
                message = message
            };
        }

        public static bool Send(string SessionId, Json.Classes.Notification notification)
        {
            var user = WebSocket.GetUser(SessionId);
            if (user != null)
            {
                Debug.PrintInfo("Notification Sent!", "Notification");
                user?.MulticastWebSocketText(JsonConvert.SerializeObject(notification, Formatting.Indented));
                return true;

            }
            else
            {
                return false;
            }
        }

        public static void SendNotificationMessage(string SessionId, Profile.Message message)
        {
            var notification = CreateNewNotification(message);
            Send(SessionId, notification);
        }




    }
}
