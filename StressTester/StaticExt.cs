using ComponentAce.Compression.Libs.zlib;
using NetCoreServer;

namespace StressTester
{
    public static class StaticExt
    {
        public static HttpRequest MakePOSTResponse(this HttpsClientEx clientEx,string url, string body, string UserId)
        {
            var req = new HttpRequest();
            req.Clear();
            req.SetBegin("POST", url);
            req.SetHeader("app-version", "EFT Client 0.13.5.3.26535");
            req.SetHeader("cookie", "PHPSESSID=" + UserId);
            req.SetBody(SimpleZlib.CompressToBytes(body, 6));
            return req;
        }
    }
}
