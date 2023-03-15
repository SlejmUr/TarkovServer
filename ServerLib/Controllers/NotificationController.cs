using Newtonsoft.Json;
using ServerLib.Utilities;
using ServerLib.Web;

namespace ServerLib.Controllers
{
    public class NotificationController
    {

        public static Json.Notification CreateNewNotification(Json.Dialog.Messages message)
        {
            return new Json.Notification()
            {
                type = "new_message",
                EventId = message._id,
                DialogId = message.uid,
                Message = message

            };
        }
        public static bool Send(string SessionId, Json.Notification notification)
        {
            if (WebSocket.ConnectedSessions.TryGetValue(SessionId, out var ip))
            {
                Debug.PrintDebug("Notification Sent!", "info", "[Notification]");
                return WebSocket.SendToClient(ip, JsonConvert.SerializeObject(notification, Formatting.Indented));

            }
            else
            {
                return false;
            }
        }

        public static void SendNotificationMessage(string SessionId, Json.Dialog.Messages message)
        {
            var notification = CreateNewNotification(message);
            Send(SessionId, notification);
        }




    }
}
