using HttpServerLite;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ServerLib.Utilities;

namespace ServerLib
{
    public class WebServer
    {
        public Webserver _Server;

        public void MainStart(string IP, int Port)
        {
            WebserverSettings webserverSettings = new WebserverSettings(IP,Port);
            //webserverSettings.Ssl.SslCertificate = CertHelper.GetCert();
            webserverSettings.Ssl.PfxCertificateFile = "cert/cert.pfx";
            webserverSettings.Ssl.Enable = true;
            // Turn this off when Doing real one, not debug!
            if (Handlers.ArgumentHandler.Debug)
            {
                webserverSettings.Debug.Responses = true;
                webserverSettings.Debug.Requests = true;
                webserverSettings.Debug.Routing = true;
            }
            _Server = new Webserver(webserverSettings);
            _Server.Settings.Headers.Host = $"https://{IP}:{Port}";
            if (Handlers.ArgumentHandler.Debug)
            {
                _Server.Events.Logger = Console.WriteLine;
            }
            _Server.Routes.Default = DefaultRoute;
            _Server.Start();
            Console.WriteLine("Http Server listening on " + $"https://{IP}:{Port}");
        }

        public void StopServer(string Reason = "None")
        {
            _Server.Stop();
            Console.WriteLine("Server Stopped, Reason: " + Reason);
        }

        public async Task DefaultRoute(HttpContext ctx)
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
            Utils.PrintRequest(ctx.Request);
            string resp = "[]"; //Need better handling on bundles
            var rsp = Web.ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            ctx.Response.Headers.Add("Content-Encoding", "deflate");
            await ctx.Response.SendWithoutCloseAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.GET, "/test")]
        public async Task Test(HttpContext ctx)
        {
            Console.WriteLine("TEST");
            string resp = "TEST";
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = resp.Length;
            await ctx.Response.SendWithoutCloseAsync(resp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.GET, "/ServerInternalIPAddress")]
        public async Task ServerInternalIPAddress(HttpContext ctx)
        {
            string resp = ConfigController.Configs.Server.Ip;
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = resp.Length;
            await ctx.Response.SendWithoutCloseAsync(resp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.GET, "/ServerExternalIPAddress")]
        public async Task ServerExternalIPAddress(HttpContext ctx)
        {
            string resp = ConfigController.Configs.Server.Ip;
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = resp.Length;
            await ctx.Response.SendWithoutCloseAsync(resp);
            return;
        }
    }
}
