using ModdableWebServer;
using ModdableWebServer.Attributes;
using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities.Helpers;
using static JsonLib.Classes.Request.Dialog;

namespace ServerLib.Web
{
    public class ClientMail
    {
        [HTTP("POST", "/client/mail/dialog/list")]
        public static bool MailDialogList(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = serverStruct.Headers.GetSessionId();
            ServerHelper.PrintRequest(request, serverStruct);
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(DialogueController.GetDialogs(SessionId)));
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/mail/dialog/view")]
        public static bool MailDialogView(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = serverStruct.Headers.GetSessionId();
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            Console.WriteLine(Uncompressed);
            var mailView = JsonConvert.DeserializeObject<GetMailView>(Uncompressed);
            ArgumentNullException.ThrowIfNull(mailView);
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(DialogueController.GenerateDialogView(SessionId, mailView.dialogId)));
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }

        [HTTP("POST", "/client/mail/dialog/getAllAttachments")]
        public static bool MailDialogGetAllAttachments(HttpRequest request, ServerStruct serverStruct)
        {
            //REQ stuff
            string SessionId = serverStruct.Headers.GetSessionId();
            ServerHelper.PrintRequest(request, serverStruct);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            Console.WriteLine(Uncompressed);
            var dialogId = JsonConvert.DeserializeObject<DialogId>(Uncompressed);
            ArgumentNullException.ThrowIfNull(dialogId);
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(DialogueController.GetAllAttachments(SessionId, dialogId.dialogId)));
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }
    }
}
