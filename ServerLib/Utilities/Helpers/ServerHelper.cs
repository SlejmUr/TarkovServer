using ModdableWebServer;
using ModdableWebServer.Helper;
using NetCoreServer;
using ServerLib.Web;

namespace ServerLib.Utilities.Helpers
{
    public class ServerHelper
    {
        internal static int ReqId = 0;
        public static bool SendUnityResponse(HttpRequest req, ServerStruct serverStruct, string resp)
        {
            var url = req.Url.Replace("/", "_");
            string SessionId = serverStruct.Headers.GetSessionId();
            File.WriteAllText("ServerResponses/" + ReqId + "_" + SessionId + url + ".json", resp);
            ReqId++;
            return SendUnityResponse(serverStruct, ResponseControl.CompressRsp(resp));
        }

        public static bool SendUnityResponse(ServerStruct serverStruct, byte[] resp)
        {
            string SessionId = serverStruct.Headers.GetSessionId();
            ResponseCreator response = new();
            response.SetHeader("Content-Type", "application/json");
            response.SetBody(resp);
            serverStruct.Response = response.GetResponse();
            serverStruct.SendResponse();
            Debug.PrintDebug("WE SENT UNITY RESPONSE!");
            return true;
        }

        public static void PrintRequest(HttpRequest req, ServerStruct serverStruct)
        {
            /*
            foreach (var hd in serverStruct.Headers)
            {
                Console.WriteLine(hd.Key + " | " + hd.Value);
            }
            */
            string time = DateTime.UtcNow.ToString();
            string fullurl = req.Url;
            string from_ip = GetFromIP(serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            Console.WriteLine("[" + time + "] " + from_ip + " | " + SessionId + " = " + fullurl);
        }

#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public static string GetFromIP(ServerStruct serverStruct)
        {
            return serverStruct.Enum switch
            {
                ServerEnum.HTTP => serverStruct.HTTP_Session.Socket.RemoteEndPoint.ToString(),
                ServerEnum.HTTPS => serverStruct.HTTPS_Session.Socket.RemoteEndPoint.ToString(),
                ServerEnum.WS => serverStruct.WS_Session.Socket.RemoteEndPoint.ToString(),
                ServerEnum.WSS => serverStruct.WSS_Session.Socket.RemoteEndPoint.ToString(),
                _ => "NoIP",
            };
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
    }
}
