using Newtonsoft.Json;
using ServerLib.Controllers;
using JsonLib.Classes.LocationRelated;
using ServerLib.Utilities.Helpers;
using JsonLib;

namespace ServerLib.Generators
{
    public class Loot
    {

        public static List<LootBase> GenerateLoot(string Location)
        {
            var locationLoot = JsonConvert.DeserializeObject<List<List<LootBase>>>(DatabaseController.DataBase.Location.Locations[$"{Location}_loot"]);
            ArgumentNullException.ThrowIfNull(locationLoot, nameof(locationLoot));
            var Pre_Defined_Loots = RandomHelper.GetArrayValue(locationLoot);

            foreach (var item in Pre_Defined_Loots)
            {
                item.Items = InventoryController.AssignNewIDs(item.Items);
                var baseID = item.Items[0].Id;
                item.Root = baseID;
            }
            //More and Better Lootgen?


            return Pre_Defined_Loots;
        }
    }
}
