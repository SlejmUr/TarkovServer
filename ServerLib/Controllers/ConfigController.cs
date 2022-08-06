using Newtonsoft.Json;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class ConfigController
    {
        public static Dictionary<string, Json.Configs> Configs = new(); //Config["server"] = all things in server.json.

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
            if (Configs == null)
            {
                Configs = new();
            }
            RefreshConfigFromBase("server");
            RefreshConfigFromBase("gameplay");
            RefreshConfigFromBase("custom");
            RefreshConfigFromBase("plugin");
            string[] dirs = Directory.GetDirectories("configs");
            foreach (string dir in dirs)
            {
                if (File.Exists(dir))
                {
                    string dataraw = File.ReadAllText(dir);
                    if (dataraw != null && dataraw != "")
                    {
                        dir.Replace("configs\\", "");
                        dir.Replace(".json","");
                        switch (dir)
                        {
                            case "server":
                                Configs[dir].Server = JsonConvert.DeserializeObject<Json.ServerConfig.Base>(dataraw);
                                break;
                            case "gameplay":
                                Configs[dir].Gameplay = JsonConvert.DeserializeObject<Json.GameplayConfig.Base>(dataraw);
                                break;
                            case "custom":
                                Configs[dir].CustomSettings = JsonConvert.DeserializeObject<Json.CustomConfig.Base>(dataraw);
                                break;
                            case "plugin":
                                Configs[dir].Plugins = dataraw;
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
