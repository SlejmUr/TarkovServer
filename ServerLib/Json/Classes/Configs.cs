namespace ServerLib.Json.Classes
{
    public class Configs
    {
        public CustomConfig.Base CustomSettings { get; set; }
        public ServerConfig.Base Server { get; set; }
        public GameplayConfig.Base Gameplay { get; set; }
        public List<Plugin> Plugins { get; set; }

        public class Plugin
        {
            public string file { get; set; }
            public bool ignore { get; set; }
            public List<string> dependencies = new();
        }
        /*
        Plugin config example:
        {
            file: "TestPlugin.dll",
            ignore: false,
            dependencies: 
            [
               "MyFirsOne.dll"
            ],
            loadtype: (enum),
        }
        */
    }
}
