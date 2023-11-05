using ModdableWebServer.Helper;
using ModdableWebServer.Servers;
using NetCoreServer;
using ServerLib.Utilities;
using System.Reflection;

namespace ServerLib.Web
{
    public class ServerManager
    {
        public static string IpPort = "http://127.0.0.1:443/";
        public static string IpPort_WS = "ws://127.0.0.1:443/";
        public static string IP = "127.0.0.1:443";
        static WSS_Server? WSS_Server = null;
        static WS_Server? WS_Server = null;
        static bool IsSsl = true;
        static Dictionary<string, Dictionary<(string url, string method), MethodInfo>> HTTP_Plugins = new();
        static Dictionary<string, Dictionary<string, MethodInfo>> WS_Plugins = new();
        static Dictionary<(string url, string method), MethodInfo> Main_HTTP = new();
        static Dictionary<string, MethodInfo> Main_WS = new();
        public static void Start(string ip, int port, bool ssl = true, bool OnlyWS = false, bool IsCertValidate = false)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            IsSsl = ssl;
            if (ssl)
            {
                SslContext? context = null;

                if (IsCertValidate)
                    context = CertHelper.GetContextNoValidate(System.Security.Authentication.SslProtocols.Tls12, "cert/cert.pfx", "cert");
                else
                    context = CertHelper.GetContext(System.Security.Authentication.SslProtocols.Tls12, "cert/cert.pfx", "cert");
                WSS_Server = new(context, ip, port);

                Main_HTTP = AttributeMethodHelper.UrlHTTPLoader(Assembly.GetAssembly(typeof(ServerManager)));
                Main_WS = AttributeMethodHelper.UrlWSLoader(Assembly.GetAssembly(typeof(ServerManager)));
                WSS_Server.DoReturn404IfFail = false;
                WSS_Server.ReceivedFailed += Failed;
                WSS_Server.WS_AttributeToMethods.Merge(Assembly.GetAssembly(typeof(ServerManager)));
                if (!OnlyWS)
                    WSS_Server.HTTP_AttributeToMethods.Merge(Assembly.GetAssembly(typeof(ServerManager)));
                WSS_Server.Start();
            }
            else
            {
                WS_Server = new(ip, port);
                WS_Server.WS_AttributeToMethods.Merge(Assembly.GetAssembly(typeof(ServerManager)));
                if (!OnlyWS)
                    WS_Server.HTTP_AttributeToMethods.Merge(Assembly.GetAssembly(typeof(ServerManager)));
                WS_Server.DoReturn404IfFail = false;
                WS_Server.ReceivedFailed += Failed;
                WS_Server.Start();
            }
            IpPort = ssl ? $"https://{ip}:{port}/" : $"http://{ip}:{port}/";
            IpPort_WS = ssl ? $"wss://{ip}:{port}/socket/" : $"ws://{ip}:{port}/socket/";
            IP = $"{ip}:{port}";
            Console.WriteLine("Server started on " + IpPort + " | " + IpPort_WS);
            Debug.PrintTime($"ServerManager Taken {sw.ElapsedMilliseconds}ms");
        }

        public static void Failed(object? sender, HttpRequest request)
        {
            Debug.PrintWarn("REQUEST FAILED");
            Debug.PrintWarn(request.Method + " " + request.Url);
            Debug.PrintWarn(request.Body);
            File.WriteAllText("REQUESTED.txt", request.Method + " " + request.Url + "\n" + request.Body + "\n" + request.ToString());
        }


        public static void Stop()
        {
            if (WS_Server != null)
            {
                WS_Server.Stop();
                WS_Server = null;
            }
            if (WSS_Server != null)
            {
                WSS_Server.Stop();
                WSS_Server = null;
            }
        }

        public static void AddRoutes(Assembly assembly)
        {
            if (IsSsl && WSS_Server != null)
            {
                var name = assembly.GetName().FullName;
                HTTP_Plugins.Add(name, AttributeMethodHelper.UrlHTTPLoader(assembly));
                WS_Plugins.Add(name, AttributeMethodHelper.UrlWSLoader(assembly));
                WSS_Server.WS_AttributeToMethods.Merge(assembly);
                WSS_Server.HTTP_AttributeToMethods.Merge(assembly);
            }
            if (!IsSsl && WS_Server != null)
            {
                WS_Server.WS_AttributeToMethods.Merge(assembly);
                WS_Server.HTTP_AttributeToMethods.Merge(assembly);
            }
        }

        public static void RemoveRoutes(Assembly assembly)
        {
            var name = assembly.GetName().FullName;
            HTTP_Plugins.Remove(name);
            WS_Plugins.Remove(name);
            if (IsSsl && WSS_Server != null)
            {
                WSS_Server.HTTP_AttributeToMethods = Main_HTTP;
                WSS_Server.WS_AttributeToMethods = Main_WS;
                foreach (var plugin in HTTP_Plugins)
                {
                    if (plugin.Key == name)
                        return;

                    foreach (var item in plugin.Value)
                    {
                        WSS_Server.HTTP_AttributeToMethods.TryAdd(item.Key, item.Value);
                    }
                }
                foreach (var plugin in WS_Plugins)
                {
                    if (plugin.Key == name)
                        return;

                    foreach (var item in plugin.Value)
                    {
                        WSS_Server.WS_AttributeToMethods.TryAdd(item.Key, item.Value);
                    }
                }
            }
            if (!IsSsl && WS_Server != null)
            {
                WS_Server.HTTP_AttributeToMethods = Main_HTTP;
                WS_Server.WS_AttributeToMethods = Main_WS;
                foreach (var plugin in HTTP_Plugins)
                {
                    if (plugin.Key == name)
                        return;

                    foreach (var item in plugin.Value)
                    {
                        WS_Server.HTTP_AttributeToMethods.TryAdd(item.Key, item.Value);
                    }
                }
                foreach (var plugin in WS_Plugins)
                {
                    if (plugin.Key == name)
                        return;

                    foreach (var item in plugin.Value)
                    {
                        WS_Server.WS_AttributeToMethods.TryAdd(item.Key, item.Value);
                    }
                }
            }
        }

        public static void OverrideRoutes(Assembly assembly)
        {
            if (IsSsl && WSS_Server != null)
            {
                WSS_Server.WS_AttributeToMethods.Override(assembly);
                WSS_Server.HTTP_AttributeToMethods.Override(assembly);
            }
            if (!IsSsl && WS_Server != null)
            {
                WS_Server.WS_AttributeToMethods.Override(assembly);
                WS_Server.HTTP_AttributeToMethods.Override(assembly);
            }
        }
    }
}
