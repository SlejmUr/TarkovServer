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

        public static Dictionary<string, string> GetAllCustomization()
        {
            return DatabaseController.DataBase.Others.Customization;
        }

        public static List<string> GetAccountCustomization()
        {
            List<string> list = new();
            foreach (var keyValue in DatabaseController.DataBase.Others.Customization)
            {
                string custom = DatabaseController.DataBase.Others.Customization[keyValue.Key];
                var customization = JsonConvert.DeserializeObject<Json.JsonCustomization.Base>(custom);

                if (customization != null)
                {
                    if (customization.Props.Side == null || customization.Props.Side.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.Add(customization.Id);
                    }
                }
            }
            return list;
        }

        public static string GetCustomizationName(string Id)
        {
            foreach (var keyValue in DatabaseController.DataBase.Others.Customization)
            {
                string custom = DatabaseController.DataBase.Others.Customization[keyValue.Key];
                var customization = JsonConvert.DeserializeObject<Json.JsonCustomization.Base>(custom);

                if (customization.Id == Id)
                {
                    return customization.Name;
                }
            }
            return "";
        }

        public static Json.JsonCustomization.Base GetCustomization(string Id)
        {
            foreach (var keyValue in DatabaseController.DataBase.Others.Customization)
            {
                string custom = DatabaseController.DataBase.Others.Customization[keyValue.Key];
                var customization = JsonConvert.DeserializeObject<Json.JsonCustomization.Base>(custom);
                if (customization.Id == Id)
                {
                    return customization;
                }
            }
            return new();
        }

        public static List<Traders.Suits>? GetTraderCustomization()
        {
            var customizationSuits = JsonConvert.DeserializeObject<List<Traders.Suits>>(File.ReadAllText("Files/traders/5ac3b934156ae10c4430e83c/suits.json"));

            var allCustomization = DatabaseController.DataBase.Others.Customization;

            foreach (var keyValue in allCustomization)
            {
                string custom = DatabaseController.DataBase.Others.Customization[keyValue.Key];
                Json.JsonCustomization.Base customization = JsonConvert.DeserializeObject<Json.JsonCustomization.Base>(custom);

                if (customization.Parent != "" && customizationSuits.FindIndex(x => x.SuiteId == keyValue.Key || x.Id == keyValue.Key) == -1)
                {
                    Traders.Suits newItem = new();
                    newItem.SuiteId = keyValue.Key;
                    newItem.Id = Utilities.Utils.CreateNewID();
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
