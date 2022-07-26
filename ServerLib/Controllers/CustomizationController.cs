using Newtonsoft.Json;
using ServerLib.Json;

namespace ServerLib.Controllers
{
    public class CustomizationController
    {

        public static string GetAllCustomizationString()
        {
            return File.ReadAllText("Files/customization/items.json");
        }

        public static Dictionary<string,string> GetAllCustomization()
        {
            return DatabaseController.DataBase.Customization;
        }

        public static List<string> GetAccountCustomization()
        {
            List<string> list = new();
            foreach (var keyValue in DatabaseController.DataBase.Customization)
            {
                string custom = DatabaseController.DataBase.Customization[keyValue.Key];
                var customization = JsonConvert.DeserializeObject<Customization.Base>(custom);

                if (customization.Props.Side.Count == 0)
                {
                    continue;
                }
                else
                {
                    list.Add(customization.Id);
                }
            }
            return list;
        }
        public static string GetCustomizationStorage(string sessionID)
        {
            if (File.Exists($"users/profiles/{sessionID}/storage.json"))
            {
                File.WriteAllText($"users/profiles/{sessionID}/storage.json","{}");
            }
            return File.ReadAllText($"users/profiles/{sessionID}/storage.json");
        }

        public static List<Traders.Suits> GetTraderCustomization()
        {
            var customizationSuits = JsonConvert.DeserializeObject<List<Traders.Suits>>(File.ReadAllText("Files/traders/5ac3b934156ae10c4430e83c/suits.json"));

            var allCustomization = DatabaseController.DataBase.Customization;

            foreach (var keyValue in allCustomization)
            {
                string custom = DatabaseController.DataBase.Customization[keyValue.Key];
                Customization.Base customization = JsonConvert.DeserializeObject<Customization.Base>(custom);

                if (customization.Parent != "" && customizationSuits.FindIndex(x => x.SuiteId == keyValue.Key || x.Id == keyValue.Key) == -1)
                {
                    Traders.Suits newItem = new();
                    newItem.SuiteId = keyValue.Key;
                    newItem.Id = Utilities.Utils.CreateNewProfileID();
                    newItem.Tid = "5ac3b934156ae10c4430e83c";
                    newItem.IsActive = true;
                    newItem.Requirements = new()
                    { 
                        LoyaltyLevel = 0,
                        ProfileLevel = 0,
                        Standing = 0,
                        SkillRequirements = new(),
                        QuestRequirements = new(),
                        ItemRequirements = new()
                    };
                    customizationSuits.Add(newItem);
                }
            }
            return customizationSuits;
        }
    }
}
