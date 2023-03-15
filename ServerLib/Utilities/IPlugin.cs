using NetCoreServer;
using static ServerLib.Web.HTTPServer;

namespace ServerLib.Utilities
{
    public interface IPlugin : IDisposable
    {
        string Name { get; }
        string Author { get; }
        string Version { get; }
        string Mode { get; }
        string Description { get; }
        void Initialize();
        bool HttpRequest(HttpRequest request, HttpsBackendSession session);
        void ShutDown();
    }
}
