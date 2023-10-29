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
            serverStruct.Response.MakeGetResponse(resp, "application/json");
            serverStruct.SendResponse();
            Debug.PrintDebug("WE SENT UNITY RESPONSE!");
            return true;
        }

        public static void PrintRequest(HttpRequest req, ServerStruct serverStruct)
        {
            string time = DateTime.UtcNow.ToString();
            string fullurl = req.Url;
            string from_ip = GetFromIP(serverStruct);
            string SessionId = serverStruct.Headers.GetSessionId();
            Console.WriteLine("[" + time + "] " + from_ip + " | " + SessionId + " = " + fullurl);
        }


        public static string GetFromIP(ServerStruct serverStruct)
        {
            switch (serverStruct.Enum)
            {
                case ServerEnum.HTTP:
                    return serverStruct.HTTP_Session.Socket.RemoteEndPoint.ToString();
                case ServerEnum.HTTPS:
                    return serverStruct.HTTPS_Session.Socket.RemoteEndPoint.ToString();
                case ServerEnum.WS:
                    return serverStruct.WS_Session.Socket.RemoteEndPoint.ToString();
                case ServerEnum.WSS:
                    return serverStruct.WSS_Session.Socket.RemoteEndPoint.ToString();
                default:
                    return "NoIP";
            }
        }
    }
}
