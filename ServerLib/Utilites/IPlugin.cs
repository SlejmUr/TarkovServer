namespace ServerLib.Utilities
{
    public interface IPlugin : IDisposable
    {
        string Name { get; }
        string Author { get; }
        string Version { get; }
        string Mode { get; }
        void Initialize();

        void WebOverride(WebServer webServer);
    }
}
