using ComponentAce.Compression.Libs.zlib;
using NetCoreServer;
using System.Net.Mime;

namespace StressTester
{
    public static class StaticExt
    {
        public static HttpRequest MakePOSTResponse(string url, string body, string UserId)
        {
            var req = new HttpRequest();
            req.Clear();
            req.SetBegin("POST", url);
            req.SetHeader("app-version", "EFT Client 0.14.1.0.28744");
            req.SetHeader("Content-Type", "application/json");
            req.SetHeader("cookie", "PHPSESSID=" + UserId);
            req.SetBody(SimpleZlib.CompressToBytes(body, 6));
            return req;
        }
    }
}
