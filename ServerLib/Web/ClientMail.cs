using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ModdableWebServer;
using ModdableWebServer.Attributes;
using ServerLib.Utilities.Helpers;

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
            var mailView = JsonConvert.DeserializeObject<Json.Classes.Dialog.GetMailView>(Uncompressed);
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
            var dialogId = JsonConvert.DeserializeObject<Json.Classes.Dialog.DialogId>(Uncompressed);
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(DialogueController.GetAllAttachments(SessionId, dialogId.dialogId)));
            ServerHelper.SendUnityResponse(request, serverStruct, rsp);
            return true;
        }
    }
}
