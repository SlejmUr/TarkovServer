namespace TestServer.Jsons
{
    public class RegisterServer
    {
        public string GUID;
        public string IP;
        public int Port;
        public string Location;
        public string Version;
    }

    public class UnregisterServer
    {
        public string GUID;
    }
}
