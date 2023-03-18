using Newtonsoft.Json;

namespace ServerLib.Controllers
{
    public class CustomizationController
    {

        public static string GetAllCustomizationString()
        {
            return File.ReadAllText("Files/others/customization.json");
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
    }
}
