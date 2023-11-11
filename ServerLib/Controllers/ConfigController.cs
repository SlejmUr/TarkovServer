using JsonLib.Classes.Configurations;
using Newtonsoft.Json;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class ConfigController
    {
        public static BaseConfig Configs = new();

        /// <summary>
        /// Initialize the configs. 
        /// </summary>
        public static void Init()
        {
            RebuildFromBaseConfigs();
            if (Configs.Server.ServerIPs.Enable)
                Debug.PrintWarn("This function is not working! Please disable it!","CONFIG");
            Debug.PrintInfo("Initialization Done!", "CONFIG");
        }

        /// <summary>
        /// Rebuild Every config from the owns base Json.
        /// </summary>
        public static void RebuildFromBaseConfigs()
        {
            RefreshConfigFromBase("server");
            RefreshConfigFromBase("gameplay");
            RefreshConfigFromBase("custom");
            RefreshConfigFromBase("plugin");
            string[] dirs = Directory.GetFiles("Files/configs");
            foreach (string dir in dirs)
            {

                if (File.Exists(dir))
                {
                    string dataraw = File.ReadAllText(dir);
                    if (dataraw != null && dataraw != "")
                    {
                        var dir_1 = dir.Replace("Files/configs\\", "");
                        dir_1 = dir_1.Replace(".json", "");
                        switch (dir_1)
                        {
                            case "server":
                                Configs.Server = JsonConvert.DeserializeObject<ServerConfig.Base>(dataraw)!;
                                break;
                            case "gameplay":
                                Configs.Gameplay = JsonConvert.DeserializeObject<GameplayConfig.Base>(dataraw)!;
                                break;
                            case "custom":
                                Configs.CustomSettings = JsonConvert.DeserializeObject<CustomConfig.Base>(dataraw)!;
                                break;
                            case "plugin":
                                Configs.Plugins = JsonConvert.DeserializeObject<List<BaseConfig.Plugin>>(dataraw)!;
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }

        public static void Save()
        {
            File.WriteAllText("Files/configs/server.json", JsonConvert.SerializeObject(Configs.Server, Formatting.Indented));
            File.WriteAllText("Files/configs/gameplay.json", JsonConvert.SerializeObject(Configs.Gameplay, Formatting.Indented));
            File.WriteAllText("Files/configs/custom.json", JsonConvert.SerializeObject(Configs.CustomSettings, Formatting.Indented));
            File.WriteAllText("Files/configs/plugin.json", JsonConvert.SerializeObject(Configs.Plugins, Formatting.Indented));
        }

        /// <summary>
        /// Rebuild a Config from base
        /// </summary>
        /// <param name="configname">server|plugin|gameplay</param>
        public static void RefreshConfigFromBase(string configname)
        {
            string configbase = File.ReadAllText($"Files/configs/{configname}_base.json");

            if (!File.Exists($"Files/configs/{configname}.json"))
            {
                File.WriteAllText($"Files/configs/{configname}.json", configbase);
            }

            if (File.Exists($"Files/configs/{configname}.json"))
            {
                if (Handlers.ArgumentHandler.ReloadAllConfigs)
                {
                    File.WriteAllText($"Files/configs/{configname}.json", configbase);
                }
            }
        }
    }
}
