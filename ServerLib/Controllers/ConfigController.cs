using Newtonsoft.Json;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class ConfigController
    {
        public static Json.Configs Configs = new();

        /// <summary>
        /// Initialize the configs. 
        /// <br>Same as Controllers/ConfigController.js@func=Init()</br>
        /// </summary>
        public static void Init()
        {
            RebuildFromBaseConfigs();
            Utils.PrintDebug("Initialization Done!", "debug", "[CONFIG]");
        }

        /// <summary>
        /// Rebuild Every config from the owns base Json.
        /// <br>Same as Controllers/ConfigController.js@func=RebuildFromBaseConfigs()</br>
        /// </summary>
        public static void RebuildFromBaseConfigs()
        {
            RefreshConfigFromBase("server");
            RefreshConfigFromBase("gameplay");
            RefreshConfigFromBase("custom");
            RefreshConfigFromBase("plugin");
            string[] dirs = Directory.GetFiles("configs");
            foreach (string dir in dirs)
            {

                if (File.Exists(dir))
                {
                    string dataraw = File.ReadAllText(dir);
                    if (dataraw != null && dataraw != "")
                    {
                        var dir_1 = dir.Replace("configs\\", "");
                        dir_1 = dir_1.Replace(".json", "");
                        switch (dir_1)
                        {
                            case "server":
                                Configs.Server = JsonConvert.DeserializeObject<Json.ServerConfig.Base>(dataraw);
                                break;
                            case "gameplay":
                                Configs.Gameplay = JsonConvert.DeserializeObject<Json.GameplayConfig.Base>(dataraw);
                                break;
                            case "custom":
                                Configs.CustomSettings = JsonConvert.DeserializeObject<Json.CustomConfig.Base>(dataraw);
                                break;
                            case "plugin":
                                Configs.Plugins = dataraw;
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Rebuild a Config from base
        /// </summary>
        /// <param name="configname">server|plugin|gameplay</param>
        public static void RefreshConfigFromBase(string configname)
        {
            string configbase = File.ReadAllText($"Files/configs/{configname}_base.json");

            if (!File.Exists($"configs/{configname}.json"))
            {
                File.WriteAllText($"configs/{configname}.json", configbase);
            }

            if (File.Exists($"configs/{configname}.json"))
            {
                if (Handlers.ArgumentHandler.ReloadAllConfigs)
                {
                    File.WriteAllText($"configs/{configname}.json", configbase);
                }
            }
        }
    }
}
