using System.Reflection;
using ModdableWebServer.Helper;
using ModdableWebServer.Servers;
using NetCoreServer;

namespace ServerLib.Web
{
    public class ServerManager
    {
        public static string IpPort = "ws://127.0.0.1:444/";
        public static string IP = "127.0.0.1:444";
        static WSS_Server? WSS_Server = null;
        static WS_Server? WS_Server = null;
        static bool IsSsl = true;
        public static void Start(string ip, int port, bool ssl = true, bool OnlyWS = false, bool IsCertValidate = false)
        {
            IsSsl = ssl;
            if (ssl)
            {
                SslContext? context = null;

                if (IsCertValidate)
                    context = CertHelper.GetContextNoValidate(System.Security.Authentication.SslProtocols.Tls12, "cert/cert.pfx", "cert");
                else
                    context = CertHelper.GetContext(System.Security.Authentication.SslProtocols.Tls12, "cert/cert.pfx", "cert");
                WSS_Server = new(context, ip, port);
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
                WS_Server.Start();
            }
            IpPort = ssl ? $"wss://{ip}:{port}/socket/" : $"ws://{ip}:{port}/socket/";
            IP = $"{ip}:{port}";
            Console.WriteLine("WebSocket Server started on " + IpPort);
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
                WSS_Server.WS_AttributeToMethods.Merge(assembly);
                WSS_Server.HTTP_AttributeToMethods.Merge(assembly);
            }
            if (!IsSsl && WS_Server != null)
            {
                WS_Server.WS_AttributeToMethods.Merge(assembly);
                WS_Server.HTTP_AttributeToMethods.Merge(assembly);
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
