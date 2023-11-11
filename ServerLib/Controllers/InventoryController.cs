using JsonLib.Classes.InventoryRelated;
using JsonLib.Classes.ItemRelated;
using JsonLib.Classes.ProfileRelated;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using static JsonLib.Classes.Others;

namespace ServerLib.Controllers
{
    public class InventoryController
    {

        public static Character.Inventory GetInventory(string SessionId)
        {
            var character = CharacterController.GetPmcCharacter(SessionId);
            if (character == null)
            {
                Debug.PrintError($"Inventory for Character {SessionId} not found!", "InventoryController");
                ArgumentNullException.ThrowIfNull(character);
            }
            return character.Inventory;
        }

        public static Item.Base? GetInventoryItemByID(string SessionId, string ItemId)
        {
            var inventory = GetInventory(SessionId);
            return inventory.Items.Find(item => item.Id == ItemId);
        }

        public static Item.Base? GetInventoryItemBySlotId(string SessionId, string slotId)
        {
            var inventory = GetInventory(SessionId);
            return inventory.Items.Find(item => item.SlotId == slotId);
        }

        public static List<Item.Base>? GetInventoryItemsByTpl(string SessionId, string itemTpl)
        {
            var inventory = GetInventory(SessionId);
            return inventory.Items.FindAll(item => item.Tpl == itemTpl);
        }

        public static List<Item.Base>? GetInventoryItemsByParent(string SessionId, string parentId)
        {
            var inventory = GetInventory(SessionId);
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
                var item = ItemController.Get(inventory.Items[ic.Lookup.Forward[inventory.Stash]].Tpl);
                ArgumentNullException.ThrowIfNull(item);
                var grids = ItemController.GetItemGrids(item);
                ArgumentNullException.ThrowIfNull(grids);
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
            ArgumentNullException.ThrowIfNull(itemInDatabase);
            var (Height, Width) = ItemController.GetItemSize(itemInDatabase);
            int height = (int)Height;
            int width = (int)Width;
            if (itemInDatabase._parent == "5448e53e4bdc2d60728b4567" || itemInDatabase._parent == "566168634bdc2d144c8b456c" || itemInDatabase._parent == "5795f317245977243854e041")
                return (height, width);

            bool parentFolded = ItemController.IsFolded(itemInInventory);

            var canFold = itemInDatabase._props.Foldable;
            var foldedSlotID = itemInDatabase._props.FoldedSlot;
            if ((canFold.HasValue && canFold.Value) && foldedSlotID != null && parentFolded)
            {
                var sizeReduceRight = itemInDatabase._props.SizeReduceRight;
                if (sizeReduceRight != null)
                    width -= (int)sizeReduceRight;
            }

            var family = GetInventoryItemFamilyTreeIDs(items, parent);
            var famL = family.Count - 1;
            if (famL == 1)
                return (height, width);

            Sizes sizes = new()
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
                var childFolded = ItemController.IsFolded(itemInInventory);
                if (parentFolded || childFolded)
                    continue;
                else if ((canFold.HasValue && canFold.Value) && foldedSlotID != null && itemInInventory.SlotId == foldedSlotID && (parentFolded || childFolded))
                    continue;
                var item = ItemController.Get(itemInInventory.Tpl);
                ArgumentNullException.ThrowIfNull(item);
                sizes = ItemController.GetItemForcedSize(item, sizes);
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


        public static InventoryContainer ResetItemSizeInContainer(Item.Base item, Character.Inventory inventory, InventoryContainer ic)
        {
            var (height, width) = MeasureItemForInventoryMapping(inventory.Items, item.Id, ic);
            var flatMap = CreateFlatMapLookup(height, width, item, ic);
            var itemFlatMap = ic.Stash.Container.FlatMap[item.Id];
            List<int> ToDel = new();
            List<int> ToAdd = new();

            if (flatMap.EndX < itemFlatMap.EndX)
            {
                for (int column = flatMap.EndX + 1; column <= itemFlatMap.EndX; column++)
                {
                    ic.Stash.Container.ContainerMap[column] = "";
                    ToDel.Add(column);
                    if (flatMap.Height < itemFlatMap.Height)
                    {
                        for (int row = flatMap.Height + 1; row < itemFlatMap.Height; row++)
                        {
                            var coordinate = row * ic.Stash.Container.Width + itemFlatMap.EndX;
                            ic.Stash.Container.ContainerMap[coordinate] = "";
                            ToDel.Add(coordinate);
                        }
                    }
                }
            }
            else if (flatMap.EndX > itemFlatMap.EndX)
            {
                for (int column = itemFlatMap.EndX + 1; column <= flatMap.EndX; column++)
                {
                    ic.Stash.Container.ContainerMap[column] = item.Id;
                    ToAdd.Add(column);
                    if (flatMap.Height > itemFlatMap.Height)
                    {
                        for (int row = itemFlatMap.Height + 1; row < flatMap.Height; row++)
                        {
                            var coordinate = row * ic.Stash.Container.Width + itemFlatMap.EndX;
                            ic.Stash.Container.ContainerMap[coordinate] = item.Id;
                            ToAdd.Add(coordinate);
                        }
                    }
                }
            }

            if (ToDel.Count != 0)
            {
                List<int> coords = new();
                foreach (var coord in itemFlatMap.Coordinates)
                {
                    if (ToDel.Contains(coord))
                        continue;
                    coords.Add(coord);
                }
                flatMap.Coordinates = coords;
            }
            else if (ToAdd.Count != 0)
            {
                List<int> coords = new();
                coords.AddRange(flatMap.Coordinates);
                coords.AddRange(ToAdd);
                flatMap.Coordinates = coords;
            }
            ic.Stash.Container.FlatMap[item.Id] = flatMap;
            if (!ic.Lookup.Forward.ContainsKey(item.Id))
                ic = SetInventoryIndex(inventory,ic);
            return ic;
        }

        public static List<int> GenerateCoordinatesFromLocation(InventoryContainer ic, FlatMapLookup flatMap)
        {
            List<int> ret = new();

            for (int i = flatMap.StartX; i <= flatMap.EndX; i++)
            {
                ret.Add(i);
                for (int c = 1; c <= flatMap.Height; c++)
                {
                    var coordinate = c * ic.Stash.Container.Width + c;
                    ret.Add(coordinate);
                }
            }
            return ret;
        }

        public static InventoryContainer UpdateItemFlatMapLookup(InventoryContainer ic, List<Item.Base> items)
        {

            var (height, width) = MeasurePurchaseForInventoryMapping(items);
            var itemInInventory = items[items.Count - 1];
            var flatMap = CreateFlatMapLookup(height, width, itemInInventory, ic);
            flatMap.Coordinates = GenerateCoordinatesFromLocation(ic, flatMap);
            ic.Stash.Container.FlatMap[itemInInventory.Id] = flatMap;
            return ic;
        }

        public static InventoryContainer ClearItemFromContainerMap(InventoryContainer ic, string Id)
        {
            foreach (var item in ic.Stash.Container.FlatMap[Id].Coordinates)
            {
                ic.Stash.Container.ContainerMap[item] = "";
            }
            return ic;
        }

        public static InventoryContainer AddItemFromContainerMap(InventoryContainer ic, string Id)
        {
            foreach (var item in ic.Stash.Container.FlatMap[Id].Coordinates)
            {
                ic.Stash.Container.ContainerMap[item] = Id;
            }
            return ic;
        }

        public static InventoryContainer ClearItemFromContainer(InventoryContainer ic, string Id)
        {
            foreach (var item in ic.Stash.Container.FlatMap[Id].Coordinates)
            {
                ic.Stash.Container.ContainerMap[item] = "";
            }
            if (ic.Lookup.Forward.ContainsKey(Id))
            {
                ic.Lookup.Reverse.Remove(ic.Lookup.Forward[Id]);
                ic.Lookup.Forward.Remove(Id);
            }
            ic.Stash.Container.FlatMap.Remove(Id);
            return ic;
        }

        public static (int height, int width) MeasurePurchaseForInventoryMapping(List<Item.Base> items)
        {
            var parentItem = items[items.Count - 1];
            var itemInDatabase = ItemController.Get(parentItem.Tpl);
            ArgumentNullException.ThrowIfNull(itemInDatabase);
            var (Height, Width) = ItemController.GetItemSize(itemInDatabase);
            int height = (int)Height;
            int width = (int)Width;
            if (itemInDatabase._parent == "5448e53e4bdc2d60728b4567" || itemInDatabase._parent == "566168634bdc2d144c8b456c" || itemInDatabase._parent == "5795f317245977243854e041")
                return (height, width);

            bool parentFolded = ItemController.IsFolded(parentItem);

            var canFold = itemInDatabase._props.Foldable;
            var foldedSlotID = itemInDatabase._props.FoldedSlot;
            if ((canFold.HasValue && canFold.Value) && foldedSlotID != null && parentFolded)
            {
                var sizeReduceRight = itemInDatabase._props.SizeReduceRight;
                if (sizeReduceRight != null)
                    width -= (int)sizeReduceRight;
            }

            if (items.Count == 1)
                return (height, width);
            Sizes sizes = new()
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

            foreach (var item in items)
            {
                bool childFolded = ItemController.IsFolded(item);
                if (parentFolded || childFolded)
                    continue;
                else if ((canFold.HasValue && canFold.Value) && item.SlotId == foldedSlotID && (parentFolded || childFolded))
                    continue;
                var tpl_item = ItemController.Get(item.Tpl);
                ArgumentNullException.ThrowIfNull(tpl_item);
                sizes = ItemController.GetItemForcedSize(tpl_item, sizes);
            }
            height += sizes.SizeUp + sizes.SizeDown + sizes.ForcedDown + sizes.ForcedUp;
            width += sizes.SizeLeft + sizes.SizeRight + sizes.ForcedRight + sizes.ForcedLeft;
            return (height, width);

        }

        public static InventoryContainer AddItemToContainer(InventoryContainer ic, string ItemId, FlatMapLookup flatMap)
        {
            foreach (var item in flatMap.Coordinates)
            {
                ic.Stash.Container.ContainerMap[item] = ItemId;
            }
            ic.Stash.Container.FlatMap[ItemId] = flatMap;
            return ic;
        }

        public static InventoryContainer SetSingleInventoryIndex(InventoryContainer ic, string ItemId, int Index)
        {
            ic.Lookup.Forward[ItemId] = Index;
            ic.Lookup.Reverse[Index] = ItemId;
            return ic;
        }

        public static int GetIndexOfItemByUID(InventoryContainer ic, string ItemId)
        {
            if (ic.Lookup.Forward.TryGetValue(ItemId, out var index))
            {
                return index;
            }
            return -1;
        }

        public static List<Item.Base> AssignNewIDs(List<Item.Base> items)
        {
            List<Item.Base> ret = new();
            Dictionary<string, string> ConvertedIds = new();

            foreach (var item in items)
            {
                string newId = AIDHelper.CreateNewID();
                ConvertedIds.Add(item.Id, newId);
                item.Id = newId;
                ret.Add(item);
            }

            foreach (var item in ret)
            {
                if (ConvertedIds.TryGetValue(item.ParentId, out var CID))
                {
                    item.ParentId = CID;
                }
            }
            return ret;
        }



        //If null means no valid location
        public static ValidLocation? GetValidLocationForItem(InventoryContainer ic, int Height, int Width)
        {
            if (Height != 0)
                Height--;

            if (Width != 0)
                Width--;

            var location = new ValidLocation()
            { 
                MapInfo = new()
            };
            int counter = 0;
            var stride = ic.Stash.Container.Width;
            for (int column = 0; column < ic.Stash.Container.ContainerMap.Count; column++)
            {
                if (ic.Stash.Container.ContainerMap[column] == "")
                {
                    location.MapInfo = new();
                    counter = 0;
                    continue;
                }
                location.MapInfo.Add(column);
               

                for (int row = 1; row  < Height; row ++)
                {
                    int coordinate = row * stride + column;
                    if (ic.Stash.Container.ContainerMap[column] == "")
                    {
                        location.MapInfo = new();
                        counter = 0;
                        break;
                    }
                    location.MapInfo.Add(coordinate);
                }

                if (counter == Width)
                {
                    location.Y = location.MapInfo[0] / stride;
                    location.X = location.MapInfo[0] % stride;

                    return location;
                }
                counter++;
            }

            return null;
        }

        public static Character.Inventory ClearInventoryMods(Character.Inventory inventory)
        {
            List<Item.Base> cleared = new();
            int cleaned_count = 0;
            foreach (var item in inventory.Items)
            {
                if (ItemController.Get(item.Tpl) == null)
                {
                    cleaned_count++;
                    continue;
                }
                cleared.Add(item);
            }
            if (cleaned_count != 0)
            {
                inventory.Items = cleared;
            }
            return inventory;
        }
    }
}
