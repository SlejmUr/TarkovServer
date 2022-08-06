namespace ServerLib.Json
{
    public class Configs
    {
        public CustomConfig.Base CustomSettings { get; set; }
        public ServerConfig.Base Server { get; set; }
        public GameplayConfig.Base Gameplay { get; set; }
        public string Plugins { get; set; }

        public class Plugin
        { 
        
        
        }
        /*
        Plugin config example:
        {
        
        }
        */
    }
}
