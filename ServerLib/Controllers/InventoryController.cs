using ServerLib.Json;
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
                Debug.PrintError($"Inventory for Character {SessionId} not found!", "[InventoryController]");
                return null;
            }
            return character.Inventory;
        }

        public static string? GetStashContainer(string SessionId)
        {
            var inventory = GetInventory(SessionId);
            if (inventory == null)
            {
                return null;
            }
            return inventory.Stash;
        }

        public static string? GetSortingTableContainer(string SessionId)
        {
            var inventory = GetInventory(SessionId);
            if (inventory == null)
            {
                return null;
            }
            return inventory.SortingTable;
        }

        public static string? GetQuestRaidItemsContainer(string SessionId)
        {
            var inventory = GetInventory(SessionId);
            if (inventory == null)
            {
                return null;
            }
            return inventory.QuestRaidItems;
        }

        public static string? GetQuestStashItemsContainer(string SessionId)
        {
            var inventory = GetInventory(SessionId);
            if (inventory == null)
            {
                return null;
            }
            return inventory.QuestStashItems;
        }

        public static Character.Item? GetInventoryItemByID(string SessionId, string ItemId)
        {
            var inventory = GetInventory(SessionId);
            if (inventory == null)
            {
                return null;
            }
            return inventory.Items.Find(item => item.Id == ItemId);
        }

        public static Character.Item? GetInventoryItemBySlotId(string SessionId, string slotId)
        {
            var inventory = GetInventory(SessionId);
            if (inventory == null)
            {
                return null;
            }
            return inventory.Items.Find(item => item.SlotId == slotId);
        }

        public static List<Character.Item>? GetInventoryItemsByTpl(string SessionId, string itemTpl)
        {
            var inventory = GetInventory(SessionId);
            if (inventory == null)
            {
                return null;
            }
            return inventory.Items.FindAll(item => item.Tpl == itemTpl);
        }

        public static List<Character.Item>? GetInventoryItemsByParent(string SessionId, string parentId)
        {
            var inventory = GetInventory(SessionId);
            if (inventory == null)
            {
                return null;
            }
            return inventory.Items.FindAll(item => item.ParentId == parentId);
        }
    }
}
