using NetCoreServer;
using ServerLib.Controllers;
using ServerLib.Handlers;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Authentication;

namespace ServerLib.Web
{
    public class HTTPServer
    {
        static Dictionary<string, MethodInfo> HttpServerThingy = new();

        static HttpsBackendServer? server = null;
        public static void Start(string IP, int Port)
        {
            HttpServerThingy.Clear();
            var context = new SslContext(SslProtocols.Tls12, CertHelper.GetCert());
            server = new HttpsBackendServer(context, IPAddress.Parse(IP), Port);
            Console.WriteLine("[HTTPS] Server Started on https://" + IP + ":" + Port);
            server.Start();
            var methods = Assembly.GetExecutingAssembly().GetTypes().SelectMany(x => x.GetMethods()).ToArray();
            var basemethods = methods.Where(x => x.GetCustomAttribute<HTTPAttribute>() != null && x.ReturnType == typeof(bool)).ToArray();
            methods = basemethods.Where(x => x.GetCustomAttribute<HTTPAttribute>().method.Contains("GET")).ToArray();
            foreach (var method in methods)
            {
                if (method == null)
                    continue;
                var url = method.GetCustomAttribute<HTTPAttribute>().url;
                Debug.PrintDebug(method.Name + $" ({url}) is added as an URL", "HTTPServer");
                HttpServerThingy.Add(url, method);
            }
            methods = basemethods.Where(x => x.GetCustomAttribute<HTTPAttribute>().method.Contains("POST")).ToArray();
            foreach (var method in methods)
            {
                if (method == null)
                    continue;
                var url = method.GetCustomAttribute<HTTPAttribute>().url;
                Debug.PrintDebug(method.Name + $" ({url}) is added as an URL", "HTTPServer");
                HttpServerThingy.Add(url, method);
            }
        }

        public static void Stop()
        {
            server?.Stop();
            server?.Dispose();
            server = null;
            Console.WriteLine("[HTTPS] Server Stopped");

        }

        [HTTP("GET", "/test/{thing}")]
        public static bool TestParam(HttpRequest request, HttpsBackendSession session)
        {
            string resp = "test param: " + session.HttpParam["thing"];
            session.SendResponse(session.Response.MakeGetResponse(resp));
            return true;
        }

        [HTTP("GET", "/test")]
        public static bool Test(HttpRequest request, HttpsBackendSession session)
        {
            string resp = "test";
            session.SendResponse(session.Response.MakeGetResponse(resp));
            return true;
        }

        [HTTP("GET", "/getBundleList")]
        public static bool GetBundeList(HttpRequest request, HttpsBackendSession session)
        {
            Utils.PrintRequest(request, session);
            string resp = "[]"; //Need better handling on bundles
            return Utils.SendUnityResponse(session, resp);
        }

        [HTTP("GET", "/ServerInternalIPAddress")]
        public static bool ServerInternalIPAddress(HttpRequest request, HttpsBackendSession session)
        {
            string resp = ConfigController.Configs.Server.Ip;
            session.SendResponse(session.Response.MakeGetResponse(resp));
            return true;
        }

        [HTTP("GET", "/ServerExternalIPAddress")]
        public static bool ServerExternalIPAddress(HttpRequest request, HttpsBackendSession session)
        {
            string resp = ConfigController.Configs.Server.Ip;
            session.SendResponse(session.Response.MakeGetResponse(resp));
            return true;
        }

        public static HttpsBackendServer? GetServer()
        {
            return server;
        }

        public class HttpsBackendServer : HttpsServer
        {
            public HttpsBackendServer(SslContext context, IPAddress address, int port) : base(context, address, port) { }

            HttpsBackendSession? session;

            public HttpsBackendSession? GetSession()
            {
                return session;
            }

            protected override SslSession CreateSession()
            {
                session = new HttpsBackendSession(this);

                return session;
            }

            protected override void OnError(SocketError error)
            {
                Console.WriteLine($"HTTPS server caught an error: {error}");
            }

        }

        public class HttpsBackendSession : HttpsSession
        {
            public Dictionary<string, string> HttpParam = new();
            public Dictionary<string, string> Headers = new();
            public HttpsBackendSession(HttpsServer server) : base(server) { }

            HttpRequest? _request;

            public HttpRequest? LastRequest()
            {
                return _request;
            }

            protected override void OnReceivedRequest(HttpRequest request)
            {
                Headers.Clear();
                for (int i = 0; i < request.Headers; i++)
                {
                    var headerpart = request.Header(i);
                    Headers.Add(headerpart.Item1, headerpart.Item2);
                }
                string url = request.Url;
                url = Uri.UnescapeDataString(url);
                Debug.PrintDebug(url);
                var ret = PluginLoader.PluginHttpRequest(request, this);
                if (ret.Contains(true))
                    return;

                if (url.Contains("?retry="))
                {
                    var retry = url.Split("?retry=");
                    Debug.PrintDebug("Retreid: " + retry[1]);
                    url = retry[0];
                }

                _request = request;
                bool Sent = false;
                foreach (var item in HttpServerThingy)
                {
                    if (UrlHelper.Match(url, item.Key, out HttpParam) || item.Key == url)
                    {
                        Debug.PrintDebug("Url Called function: " + item.Value.Name);
                        item.Value.Invoke(this, new object[] { request, this });
                        Sent = true;
                    }

                }

                if (!Sent)
                {
                    File.AppendAllText("REQUESTED.txt", url + "\n" + request.Body + "\n");
                }

                SendResponse(Response.MakeOkResponse());
            }

            protected override void OnReceivedRequestError(HttpRequest request, string error)
            {
                Console.WriteLine($"Request error: {error}");
            }

            protected override void OnError(SocketError error)
            {
                Console.WriteLine($"HTTPS session caught an error: {error}");
            }
        }
    }
}
