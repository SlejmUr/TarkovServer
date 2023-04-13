namespace ServerLib.Json.Classes
{
    public class Configs
    {
        public CustomConfig.Base CustomSettings { get; set; }
        public ServerConfig.Base Server { get; set; }
        public GameplayConfig.Base Gameplay { get; set; }
        public string Plugins { get; set; }

        public class Plugin
        {
            public string file { get; set; }
            public bool ignore { get; set; }
            public Dependencies? dependencies { get; set; }
            public LoadTypes loadtype { get; set; }
            public class Dependencies
            {
                public string file { get; set; }
            }
        }

        public enum LoadTypes
        {
            start,
            beforeWeb,
            afterWeb,
            shutdown
        }
        /*
        Plugin config example:
        {
            file: "TestPlugin.dll",
            ignore: false,
            dependencies: 
            {
                file: "MyFirsOne.dll"
            },
            loadtype: (enum),
        }
        */
    }
}
