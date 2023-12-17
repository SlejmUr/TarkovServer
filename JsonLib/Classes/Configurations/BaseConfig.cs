namespace JsonLib.Classes.Configurations
{
    public class BaseConfig
    {
        public CustomConfig.Base CustomSettings { get; set; }
        public ServerConfig.Base Server { get; set; }
        public GameplayConfig.Base Gameplay { get; set; }
    }
}
