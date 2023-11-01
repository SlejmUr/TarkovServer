using ModdableWebServer;
using ModdableWebServer.Helper;
using NetCoreServer;
using ServerLib.Web;

namespace LauncherSupporter
{
    public static class CompressionHelper
    {
        public static bool IsCompressed(this ServerStruct serverStruct)
        {
            if (serverStruct.Headers.ContainsKey("content-encoding"))
            {
                var encoding = serverStruct.Headers["content-encoding"];
                if (encoding.ToLower() == "deflate")
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetRequets(this ServerStruct serverStruct, HttpRequest request)
        {
            if (serverStruct.IsCompressed())
                return ResponseControl.DeCompressReq(request.BodyBytes);
            return request.Body;
        }

        public static void SendRSP(this ServerStruct serverStruct, string resp)
        {
            var rc = new ResponseCreator();
            if (serverStruct.IsCompressed())
            {
                rc.SetHeader("Content-Encoding", "deflate");
                rc.SetBody(ResponseControl.CompressRsp(resp));
            }
            else
                rc.SetBody(resp);
            serverStruct.Response = rc.GetResponse();
            serverStruct.SendResponse();
        }

    }
}
