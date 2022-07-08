using HttpServerLite;
using Ionic.Zlib;

namespace Tarkov_Server_Csharp
{
    internal class WebServer
    {
        static Webserver _Server;
        public static void MainStart(string IP, int Port)
        {
            WebserverSettings webserverSettings = new WebserverSettings(IP,Port);
            //webserverSettings.Ssl.SslCertificate = CertHelper.GetCert();
            webserverSettings.Ssl.PfxCertificateFile = "cert/cert.pfx";
            webserverSettings.Ssl.Enable = true;
            webserverSettings.Debug.Responses = true;
            webserverSettings.Debug.Requests = true;
            _Server = new Webserver(webserverSettings);
            _Server.Settings.Headers.Host = $"https://{IP}:{Port}";
            _Server.Events.Logger = Console.WriteLine;
            _Server.Routes.Default = DefaultRoute;
            _Server.Start();
            Console.WriteLine("Http Server listening on " + $"https://{IP}:{Port}");
            Console.WriteLine("ENTER to exit");
            Console.ReadLine();
        }
        static async Task DefaultRoute(HttpContext ctx)
        {
            string resp = "Hello from WebServer!";
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentLength = resp.Length;
            ctx.Response.ContentType = "text/plain";
            await ctx.Response.SendAsync(resp);
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/getBundleList")]
        public static async Task GetBundeList(HttpContext ctx)
        {
            //REQ stuff
            Console.WriteLine(ctx.Request.ContentType);
            string Uncompressed = ZlibStream.UncompressString(ctx.Request.DataAsBytes);
            Console.WriteLine(Uncompressed);
            Console.WriteLine("Headers:\n" + string.Join("\n", ctx.Request.Headers.Select(pair => $"{pair.Key} => {pair.Value}")));

            // RPS
            string resp = "{}";
            var rsp = ZlibStream.CompressString(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }
    }
}
