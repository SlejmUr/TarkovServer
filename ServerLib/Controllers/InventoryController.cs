using EFT.Visual;
using ServerLib.Handlers;
using ServerLib.Json;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using System;
using static ServerLib.Controllers.InventoryController;

namespace ServerLib.Controllers
{
    public class InventoryController
    {
        #region Classes
        public class InventoryContainer
        {
            public Stash Stash;
            public Lookup Lookup;
        }

        public class Lookup
        {
            public Dictionary<string, int> Forward;
            public Dictionary<int, string> Reverse;
        }

        public class Stash
        {
            public string SlotId;
            public Map Container;
        }

        public class Map
        {
            public int Width;
            public int Height;
            public List<string> ContainerMap;
            public Dictionary<string, FlatMapLookup> FlatMap;
        }

        public class FlatMapLookup
        {
            public int Width;
            public int Height;
            public int StartX;
            public int EndX;
            public List<int> Coordinates;
        }
        #endregion

        public static Character.Inventory? GetInventory(string SessionId)
        {
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (character == null)
            {
                Debug.PrintError($"Inventory for Character {SessionId} not found!", "InventoryController");
                return null;
            }
            return character.Inventory;
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

        public static InventoryContainer SetInventoryContainer(Character.Inventory inventory)
        {
            InventoryContainer container = new();
            container = SetInventoryIndex(inventory, container);
            container = SetInventoryStash(inventory, container);
            return container;
        }

        public static InventoryContainer SetInventoryIndex(Character.Inventory inventory, InventoryContainer container)
        {
            container.Lookup = new()
            {
                Forward = new(),
                Reverse = new()
            };
            for (int i = 0; i < inventory.Items.Count; i++)
            {
                var item = inventory.Items[i];
                container.Lookup.Forward.Add(item.Id, i);
                container.Lookup.Reverse.Add(i, item.Id);
            }
            return container;
        }

        public static InventoryContainer SetInventoryStash(Character.Inventory inventory, InventoryContainer ic)
        {
            if (ic.Stash == null)
            {
                ic.Stash = new();
                var grids = ItemController.GetItemGrids(ItemController.Get(inventory.Items[ic.Lookup.Forward[inventory.Stash]].Tpl));
                foreach (var grid in grids)
                {
                    ic.Stash.SlotId = grid.Key;

                    int h = (int)grid.Value._props.cellsV;
                    int w = (int)grid.Value._props.cellsH;

                    var arraySize = h * w;
                    ic.Stash.Container = new() 
                    { 
                        Width = w,
                        Height = h,
                        FlatMap = new(),
                        ContainerMap = new(arraySize)
                    };
                }
            }

            var containerMap = ic.Stash.Container.ContainerMap;
            var containerFlatMap = ic.Stash.Container.FlatMap;
            var stride = ic.Stash.Container.Width;

            foreach (var item in ic.Lookup.Reverse)
            {
                var itemInInventory = inventory.Items[item.Key];

                if (itemInInventory.ParentId == "" || itemInInventory.ParentId != inventory.Stash || itemInInventory.SlotId != "hideout" || itemInInventory.Location.ItemLocation == null)
                    continue;

                var (height, width) = MeasureItemForInventoryMapping(inventory.Items, itemInInventory.Id, ic);

                if (height == -1 && width == -1)
                    continue;

                var flatmap = CreateFlatMapLookup(height, width, itemInInventory, ic);
                containerFlatMap.Add(itemInInventory.Id, new());
                if (flatmap.Height == 0 && flatmap.Width == 0)
                {
                    var itemId = containerMap[flatmap.StartX];
                    if (itemId != null || string.IsNullOrWhiteSpace(itemId))
                        throw new Exception("Flat Map Index of " + flatmap.StartX + " is trying to be filled by " + itemInInventory.Id + " but is occupied by " + ic.Stash.Container.ContainerMap[flatmap.StartX]);
                    containerMap[flatmap.StartX] = itemInInventory.Id;
                    flatmap.Coordinates.Add(flatmap.StartX);
                    containerFlatMap[itemInInventory.Id] = flatmap;
                    continue;
                }

                for (int column = flatmap.StartX; column <= flatmap.EndX; column++)
                {
                    var itemId = containerMap[column];
                    if (itemId != null || string.IsNullOrWhiteSpace(itemId))
                        throw new Exception("Flat Map Index of X position " + column + " is trying to be filled by " + itemInInventory.Id + " but is occupied by " + ic.Stash.Container.ContainerMap[column]);

                    containerMap[column] = itemInInventory.Id;
                    flatmap.Coordinates.Add(column);


                    for (int row = 1; row <= flatmap.Height; row++)
                    {
                        var coordinate = row * stride + column;
                        itemId = containerMap[coordinate];
                        if (itemId != null || string.IsNullOrWhiteSpace(itemId))
                            throw new Exception("Flat Map Index of Y position " + column + " is trying to be filled by " + itemInInventory.Id + " but is occupied by " + ic.Stash.Container.ContainerMap[column]);

                        containerMap[coordinate] = itemInInventory.Id;
                        flatmap.Coordinates.Add(coordinate);
                    }
                }
                containerFlatMap[itemInInventory.Id] = flatmap;
            }


            ic.Stash.Container.ContainerMap = containerMap;
            ic.Stash.Container.FlatMap = containerFlatMap;
            return ic;
        }

        public static (int height, int width) MeasureItemForInventoryMapping(List<Item.Base> items, string parent, InventoryContainer container)
        {
            var id = container.Lookup.Forward[parent];
            var itemInInventory = items[id];
            var itemInDatabase = ItemController.Get(itemInInventory.Tpl);
            var size = ItemController.GetItemSize(itemInDatabase);
            int height = (int)size.Height;
            int width = (int)size.Width;
            if (itemInDatabase._parent == "5448e53e4bdc2d60728b4567" || itemInDatabase._parent == "566168634bdc2d144c8b456c" || itemInDatabase._parent == "5795f317245977243854e041")
                return (height, width);

            bool parentFolded = ItemController.IsFolded(itemInInventory);

            var canFold = itemInDatabase._props.Foldable;
            var foldedSlotID = itemInDatabase._props.FoldedSlot;
            if ((canFold != null && canFold) && foldedSlotID != null && parentFolded)
            {
                var sizeReduceRight = itemInDatabase._props.SizeReduceRight;
                if (sizeReduceRight != null)
                    width -= (int)sizeReduceRight;
            }

            var family = GetInventoryItemFamilyTreeIDs(items, parent);
            var famL = family.Count - 1;
            if (famL == 1)
                return (height, width);

            Others.Sizes sizes = new()
            { 
                ForcedDown = 0,
                ForcedLeft = 0,
                ForcedUp = 0,
                ForcedRight = 0,
                SizeDown = 0,
                SizeLeft = 0,
                SizeRight = 0,
                SizeUp = 0
            };

            for (int i = 0; i < famL; i++)
            {
                var member = family[i];
                var index = container.Lookup.Forward[member];
                itemInInventory = items[index];
                var childFolded  = ItemController.IsFolded(itemInInventory);
                if (parentFolded || childFolded)
                    continue;
                else if ((canFold != null && canFold) && foldedSlotID != null && itemInInventory.SlotId == foldedSlotID && (parentFolded || childFolded))
                    continue;

                sizes = ItemController.GetItemForcedSize(ItemController.Get(itemInInventory.Tpl), sizes);
            }

            height += sizes.SizeUp + sizes.SizeDown + sizes.ForcedDown + sizes.ForcedUp;
            width += sizes.SizeLeft + sizes.SizeRight + sizes.ForcedRight + sizes.ForcedLeft;
            return (height, width);
        }

        public static FlatMapLookup CreateFlatMapLookup(int height, int width, Item.Base item, InventoryContainer container)
        {
            FlatMapLookup ret = new();

            if (width != 0) width--;
            if (height != 0) height--;

            if (item.Location.ItemLocation.R == 1)
            {
                ret.Height = width;
                ret.Width = height;
            }
            else
            {
                ret.Height = height;
                ret.Width = width;
            }
            int row = item.Location.ItemLocation.Y * container.Stash.Container.Width;
            ret.StartX = item.Location.ItemLocation.X + row;
            ret.EndX = ret.StartX + ret.Width;
            return ret;
        }


        public static List<string> GetInventoryItemFamilyTreeIDs(List<Item.Base> items, string parent)
        {
            List<string> ret = new();

            foreach (var item in items)
            {
                if (item.ParentId == "" || string.IsNullOrEmpty(item.ParentId))
                    continue;

                if (item.ParentId == parent)
                {
                    ret.AddRange(GetInventoryItemFamilyTreeIDs(items, item.Id));
                }
            }
            ret.Add(parent);
            return ret;
        }


        /*
         TODO:
        ResetItemSizeInContainer
        GenerateCoordinatesFromLocation
        UpdateItemFlatMapLookup
        ClearItemFromContainerMap
        AddItemFromContainerMap
        ClearItemFromContainer
        GetValidLocationForItem
        ConvertAssortItemsToInventoryItem
        AssignNewIDs
        AddItemToContainer
        SetSingleInventoryIndex
        GetIndexOfItemByUID
        MeasurePurchaseForInventoryMapping
         */
    }
}
