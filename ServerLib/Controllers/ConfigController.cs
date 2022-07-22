using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace ServerLib.Controllers
{
    public class ConfigController
    {
        public static void Init()
        {
            RebuildFromBaseConfigs();
        }
        public static Dictionary<string,string> Configs = new(); //Config["server"] = all things in server.json.
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
        // No idea how the old one worked, made easier
        // WARNING !! : IT WILL REWRITE EVERY CHANGES!
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
