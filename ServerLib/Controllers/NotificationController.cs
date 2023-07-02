using Newtonsoft.Json;
using ServerLib.Utilities;
using ServerLib.Json.Classes;
using ServerLib.Web;
using ChatShared;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Controllers
{
    public class NotificationController
    {
        public static Character.Dialogue GetDialog(string SessionId, EMessageType messageType, Character.UserDialogInfo dialogInfo)
        {
            var key = (dialogInfo.info.MemberCategory == EMemberCategory.Trader) ? dialogInfo._id : dialogInfo.info.Nickname;
            if (!DialogueController.Dialogs[SessionId].TryGetValue(key, out var dialog))
            {
                List<Character.UserDialogInfo> users = new();
                if (dialogInfo.info.MemberCategory != EMemberCategory.Trader)
                {
                    users.Add(dialogInfo);
                }
                Character.Dialogue dialogue = new()
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

        public static void SendMessageToPlayer(string SessionId, EMessageType messageType, Character.UserDialogInfo dialogInfo, string messageText )
        { 
            var dialog = GetDialog( SessionId, messageType, dialogInfo );
            dialog.New += 1;
            Character.Message message = new()
            { 
                _id = Utils.CreateNewID(),
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

        public static Json.Classes.Notification CreateNewNotification(Character.Message message)
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
            if (WebSocket.ConnectedSessions.TryGetValue(SessionId, out var ip))
            {
                Debug.PrintInfo("Notification Sent!", "Notification");
                return WebSocket.GetServer().MulticastText(JsonConvert.SerializeObject(notification, Formatting.Indented));

            }
            else
            {
                return false;
            }
        }

        public static void SendNotificationMessage(string SessionId, Character.Message message)
        {
            var notification = CreateNewNotification(message);
            Send(SessionId, notification);
        }




    }
}
