using HttpServerLite;

namespace Tarkov_Server_Csharp
{
    internal class WebServer
    {
        Webserver _Server;
        public void MainStart(string IP, int Port)
        {
            WebserverSettings webserverSettings = new WebserverSettings(IP,Port);
            //webserverSettings.Ssl.SslCertificate = CertHelper.GetCert();
            webserverSettings.Ssl.PfxCertificateFile = "cert/cert.pfx";
            webserverSettings.Ssl.Enable = true;
            webserverSettings.Debug.Responses = true;
            webserverSettings.Debug.Requests = true;
            webserverSettings.Debug.Routing = true;
            _Server = new Webserver(webserverSettings);
            _Server.Settings.Headers.Host = $"https://{IP}:{Port}";
            _Server.Events.Logger = Console.WriteLine;
            _Server.Routes.Default = DefaultRoute;
            _Server.Start();
            Console.WriteLine("Http Server listening on " + $"https://{IP}:{Port}");
            Console.WriteLine("ENTER to exit");
            Console.ReadLine();
        }
        async Task DefaultRoute(HttpContext ctx)
        {
            string resp = "Hello from WebServer!";
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentLength = resp.Length;
            ctx.Response.ContentType = "text/plain";
            await ctx.Response.SendAsync(resp);
        }

        [StaticRoute(HttpServerLite.HttpMethod.GET, "/getBundleList")]
        public async Task GetBundeList(HttpContext ctx)
        {
            string resp = "[]";
            var rsp = Web.ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }
    }
}
