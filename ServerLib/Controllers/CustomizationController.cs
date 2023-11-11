using JsonLib.Classes.ItemRelated;

namespace ServerLib.Controllers
{
    public class CustomizationController
    {
        public static string GetAllCustomizationString()
        {
            return File.ReadAllText("Files/others/customization.json");
        }

        public static Dictionary<string, CustomizationItem.Base> GetAllCustomization()
        {
            return DatabaseController.DataBase.Others.Customization;
        }

        public static List<string> GetAccountCustomization()
        {
            List<string> list = new();
            foreach (var keyValue in GetAllCustomization())
            {
                var customization = keyValue.Value;

                if (customization._props.Side == null || customization._props.Side.Count == 0)
                {
                    continue;
                }
                else
                {
                    list.Add(keyValue.Key);
                }
            }
            return list;
        }

        public static string GetCustomizationName(string Id)
        {
            var custom = GetCustomization(Id);
            if (custom != null)
                return custom._name;
            return "";
        }

        public static CustomizationItem.Base? GetCustomization(string Id)
        {
            if (GetAllCustomization().TryGetValue(Id, out var value))
            {
                return value;
            }
            return null;
        }


        public static void AddCustomization(CustomizationItem.Base @base)
        {
            DatabaseController.DataBase.Others.Customization.Add(@base._id, @base);
        }
    }
}
