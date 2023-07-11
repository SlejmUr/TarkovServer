using ServerLib.Handlers;
using ServerLib.Json;
using ServerLib.Json.Classes;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class InventoryController
    {

        public static Character.Inventory? GetInventory(string SessionId)
        {
            var character = CharacterController.GetCharacter(SessionId);
            if (character == null)
            {
                Debug.PrintError($"Inventory for character {SessionId} not found! This could result in a crash!", "InventoryController");
                return null;
            }
            return character.Inventory;
        }

    }
}
