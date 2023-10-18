﻿using System.Collections.Generic;
using System.Reflection;
using ModdableWebServer.Helper;
using ModdableWebServer.Servers;
using NetCoreServer;

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
        static Dictionary<string, Dictionary<(string url, string method), MethodInfo>> HTTP_Plugins;
        static Dictionary<string, Dictionary<string, MethodInfo>> WS_Plugins;
        static Dictionary<(string url, string method), MethodInfo> Main_HTTP;
        static Dictionary<string, MethodInfo> Main_WS;
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

                Main_HTTP = AttributeMethodHelper.UrlHTTPLoader(Assembly.GetAssembly(typeof(ServerManager)));
                Main_WS = AttributeMethodHelper.UrlWSLoader(Assembly.GetAssembly(typeof(ServerManager)));

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
            IpPort = ssl ? $"https://{ip}:{port}/" : $"http://{ip}:{port}/";
            IpPort_WS = ssl ? $"wss://{ip}:{port}/socket/" : $"ws://{ip}:{port}/socket/";
            IP = $"{ip}:{port}";
            Console.WriteLine("Server started on " + IpPort + " | " + IpPort_WS);
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
                HTTP_Plugins.Add(assembly.FullName, AttributeMethodHelper.UrlHTTPLoader(assembly));
                WS_Plugins.Add(assembly.FullName, AttributeMethodHelper.UrlWSLoader(assembly));
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
            HTTP_Plugins.Remove(assembly.FullName);
            WS_Plugins.Remove(assembly.FullName);
            if (IsSsl && WSS_Server != null)
            {
                WSS_Server.HTTP_AttributeToMethods = Main_HTTP;
                WSS_Server.WS_AttributeToMethods = Main_WS;
                foreach (var plugin in HTTP_Plugins)
                {
                    if (plugin.Key == assembly.FullName)
                        return;

                    foreach (var item in plugin.Value)
                    {
                        WSS_Server.HTTP_AttributeToMethods.TryAdd(item.Key, item.Value);
                    }
                }
                foreach (var plugin in WS_Plugins)
                {
                    if (plugin.Key == assembly.FullName)
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
                    if (plugin.Key == assembly.FullName)
                        return;

                    foreach (var item in plugin.Value)
                    {
                        WS_Server.HTTP_AttributeToMethods.TryAdd(item.Key, item.Value);
                    }
                }
                foreach (var plugin in WS_Plugins)
                {
                    if (plugin.Key == assembly.FullName)
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
