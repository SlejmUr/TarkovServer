using ServerLib.Handlers;
using ServerLib.Json.Classes;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class InventoryController
    {

        public static Character.Inventory? GetInventory(string SessionId)
        {
            var character = CharacterController.GetPmcCharacter(SessionId);
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

        public static Item.Base? GetInventoryItemByID(string SessionId, string ItemId)
        {
            var inventory = GetInventory(SessionId);
            if (inventory == null)
            {
                return null;
            }
            return inventory.Items.Find(item => item.Id == ItemId);
        }

        public static Item.Base? GetInventoryItemBySlotId(string SessionId, string slotId)
        {
            var inventory = GetInventory(SessionId);
            if (inventory == null)
            {
                return null;
            }
            return inventory.Items.Find(item => item.SlotId == slotId);
        }

        public static List<Item.Base>? GetInventoryItemsByTpl(string SessionId, string itemTpl)
        {
            var inventory = GetInventory(SessionId);
            if (inventory == null)
            {
                return null;
            }
            return inventory.Items.FindAll(item => item.Tpl == itemTpl);
        }

        public static List<Item.Base>? GetInventoryItemsByParent(string SessionId, string parentId)
        {
            var inventory = GetInventory(SessionId);
            if (inventory == null)
            {
                return null;
            }
            return inventory.Items.FindAll(item => item.ParentId == parentId);
        }

        public static List<Item.Base> AddItemToInventory(string SessionId, Item.Base container, string ParentId, TemplateItem.Base itemData, int amountToBeAdded, List<Item.Base>? childrens)
        {
            List<Item.Base> ret = new();
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (character == null)
                return ret;
            while (amountToBeAdded > 0)
            {
                var containerMap = ItemController.GenerateContainerMap(container, character.Inventory.Items);

                var item = CreateItemForPurchase(itemData, container);

                var adjust = AdjustStackSize(item, itemData, amountToBeAdded);

                amountToBeAdded = adjust.stackSize;
                item = adjust.item;

                var itemSize = ItemController.GetSize(item, childrens);
                var freeslot = ItemController.GetFreeSlot(containerMap, itemSize);

                if (freeslot == null && freeslot.Equals(new Others.FreeSlot()))
                {
                    Debug.PrintError($"Unable to add item {item.Tpl}. No space!", "[AddItemToInventory]");
                    return ret;
                }

                item.SlotId = freeslot.SlotId;
                item.Location = new()
                {
                    X = freeslot.X,
                    Y = freeslot.Y,
                    R = freeslot.R
                };

                if (ItemController.IsSearchableItem(itemData))
                {
                    item.Location.IsSearched = (bool)ConfigController.Configs.Gameplay.Items.AllExamined.Enabled;
                }

                ret = (AdjustItemForPurchase(ret, item, itemData, ItemController.PrepareChildrenForAddItem(ParentId, childrens)));
            }
            character.Inventory.Items.AddRange(ret);
            SaveHandler.SaveCharacter(SessionId, character);
            return ret;
        }

        public static List<Item.Base> AdjustItemForPurchase(List<Item.Base> newItemsToBeAdded, Item.Base item, TemplateItem.Base itemData, List<Item.Base>? childrens)
        {
            List<Item.Base> ret = newItemsToBeAdded;
            if (itemData._parent == "543be5cb4bdc2deb348b4568")
            {
                if (itemData._props.StackSlots == null)
                    Debug.PrintWarn($"AmmoBox {item.Tpl} does not have StackSlots", "[AdjustItemForPurchase]");

                ret.AddRange(ItemController.HandleAmmoBoxes(item.Id, itemData));
            }

            if (childrens != null && childrens.Count > 0)
            {
                foreach (var child in childrens)
                {
                    ret.AddRange(AddItemToParent(item, child.Tpl, child.SlotId, 1, child.Upd, child.Children));
                }
            }

            ret.Add(item);
            return ret;
        }

        public static List<Item.Base> AddItemToParent(Item.Base parent, string ItemId, string SlotId, int amount, Item._Upd? customupd, List<Item.Base>? childrens)
        {
            List<Item.Base> ret = new();

            var itemTemplate = ItemController.Get(ItemId);
            if (itemTemplate == null)
                return ret;

            var newItem = ItemController.CreateNew(ItemId, parent.Id);
            newItem.SlotId = SlotId;

            if (customupd != null)
                newItem.Upd = customupd;
            else
                newItem.Upd = new();

            newItem.Upd.StackObjectsCount = (amount > 1 && amount <= itemTemplate._props.StackMaxSize) ? amount : (int)itemTemplate._props.StackMaxSize;

            if (childrens != null && childrens.Count > 0)
            {
                foreach (var child in childrens)
                {
                    ret.AddRange(AddItemToParent(newItem, child.Tpl, child.SlotId, 1, child.Upd, child.Children));
                }
            }

            ret.Add(newItem);
            return ret;
        }

        public static Item.Base CreateItemForPurchase(TemplateItem.Base itemData, Item.Base container)
        {
            var Item = ItemController.CreateNew(itemData._parent, container.Id);
            var freshupd = ItemController.CreateFreshBaseItemUpd(itemData._id);
            Item.Upd = freshupd;
            Item.Upd.SpawnedInSession = (bool)ConfigController.Configs.Gameplay.Trading.TradePurchasedIsFoundInRaid;
            return Item;
        }

        public static (int stackSize, Item.Base item) AdjustStackSize(Item.Base item, TemplateItem.Base itemData, int itemStackToAdd)
        {
            if (itemStackToAdd >= (int)itemData._props.StackMaxSize)
            {
                itemStackToAdd -= (int)itemData._props.StackMaxSize;
                if (itemData._props.StackMaxSize > 1)
                {
                    item.Upd.StackObjectsCount = (int)itemData._props.StackMaxSize;
                }
            }
            else
            {
                item.Upd.StackObjectsCount = itemStackToAdd;
                itemStackToAdd -= itemStackToAdd;
            }

            return (itemStackToAdd, item);
        }

        public static List<Item.Base> RemoveInventoryItemByID(string SessionId, string itemId)
        {
            List<Item.Base> ret = new();
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (character == null)
                return ret;

            var item = GetInventoryItemByID(SessionId, itemId);
            character.Inventory.Items.Remove(item);
            SaveHandler.SaveCharacter(SessionId, character);
            return ret;
        }


        /*
        removeItem
        moveItems
        retrieveRewardItems //Not exist??
        moveItemIntoProfile
        moveItem
        moveItemWithinProfile
        splitItem
        tagItem
        mergeItem
        removeItems
        toggleItem
        bindItem
        swapItem
        foldItem
        transferItem
        examineItem
         */
    }
}
