using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Web
{
    public class ClientMail
    {
        [HTTP("POST", "/client/mail/dialog/list")]
        public static bool MailDialogList(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(DialogueController.GetDialogs(SessionId)));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/mail/dialog/view")]
        public static bool MailDialogView(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            Console.WriteLine(Uncompressed);
            var mailView = JsonConvert.DeserializeObject<Json.Classes.Dialog.GetMailView>(Uncompressed);
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(DialogueController.GenerateDialogView(SessionId, mailView.dialogId)));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }

        [HTTP("POST", "/client/mail/dialog/getAllAttachments")]
        public static bool MailDialogGetAllAttachments(HttpRequest request, HttpsBackendSession session)
        {
            //REQ stuff
            string SessionId = Utils.GetSessionId(session.Headers);
            Utils.PrintRequest(request, session);
            string Uncompressed = ResponseControl.DeCompressReq(request.BodyBytes);
            Console.WriteLine(Uncompressed);
            var dialogId = JsonConvert.DeserializeObject<Json.Classes.Dialog.DialogId>(Uncompressed);
            var rsp = ResponseControl.GetBody(JsonConvert.SerializeObject(DialogueController.GetAllAttachments(SessionId, dialogId.dialogId)));
            Utils.SendUnityResponse(session, rsp);
            return true;
        }
    }
}
