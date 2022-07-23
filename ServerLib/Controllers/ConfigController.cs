using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class ConfigController
    {
        public static Dictionary<string, string> Configs = new(); //Config["server"] = all things in server.json.
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

            RefreshGameplayConfigFromBase();
            RefreshServerConfigFromBase();

            string[] dirs = Directory.GetDirectories("Files/configs");
            foreach (string dir in dirs)
            {
                if (File.Exists(dir))
                {
                    string dataraw = File.ReadAllText(dir);
                    if (dataraw != null && dataraw != "")
                    {
                        dir.Replace("Files/configs\\", "");
                        dir.Replace(".json","");
                        Configs.Add(dir, dataraw);
                    }
                }
            }
        }

        /// <summary>
        /// Rebuild Gameplay config from that base Json.
        /// <br>Same as Controllers/ConfigController.js@func=RefreshGameplayConfigFromBase()</br>
        /// </summary>
        public static void RefreshGameplayConfigFromBase()
        {
            string configbase = File.ReadAllText("Files/configs/gameplay_base.json");

            if (!File.Exists("Files/configs/gameplay.json"))
            {
                File.WriteAllText("Files/configs/gameplay.json", configbase);
            }

            if (File.Exists("Files/configs/gameplay.json"))
            {
                string gameplay = File.ReadAllText("Files/configs/gameplay.json");
                bool changesMade = CheckIfSame(gameplay, configbase);
                if (changesMade)
                {
                    File.WriteAllText("Files/configs/gameplay.json", configbase);
                }
            }
        }

        /// <summary>
        /// Rebuild Server config from that base Json.
        /// <br>Same as Controllers/ConfigController.js@func=RefreshServerConfigFromBase()</br>
        /// </summary>
        public static void RefreshServerConfigFromBase()
        {
            string configbase = File.ReadAllText("Files/configs/server_base.json");

            if (!File.Exists("Files/configs/server.json"))
            {
                File.WriteAllText("Files/configs/server.json", configbase);
            }

            if (File.Exists("Files/configs/server.json"))
            {
                string server = File.ReadAllText("Files/configs/server.json");
                bool changesMade = CheckIfSame(server, configbase);
                if (changesMade)
                {
                    File.WriteAllText("Files/configs/server.json", configbase);
                }
            }
        }

        /// <summary>
        /// Check if the the target and Source is same
        /// </summary>
        /// <param name="target">Target String</param>
        /// <param name="src">Source String</param>
        /// <returns>True if Not, False is Same</returns>
        public static bool CheckIfSame(string target, string src)
        {
            bool changesMade = false;
            if (target != src)
            {
                changesMade = true;
            }
            return changesMade;
        }
    }
}
