using ServerLib.Utilities;
using ServerLib.Json.Classes;

namespace ServerLib.Controllers
{
    public class ItemController
    {
        /// <summary>
        /// Get the ItemBase from Database
        /// </summary>
        /// <param name="ItemId">ItemId</param>
        /// <returns>The item from DataBase</returns>
        public static TemplateItem.Base Get(string ItemId)
        {
            return DatabaseController.DataBase.Others.Items[ItemId];
        }

        /// <summary>
        /// Get All Items from Database
        /// </summary>
        /// <returns>All Items from Database</returns>
        public static Dictionary<string, TemplateItem.Base> GetAll()
        {
            return DatabaseController.DataBase.Others.Items;
        }

        /// <summary>
        /// Get Price of the Item by Id
        /// </summary>
        /// <param name="ItemId">ItemId</param>
        /// <returns>The Price</returns>
        public static int GetItemPrice(string ItemId)
        {
            return DatabaseController.DataBase.Others.ItemPrices[ItemId];
        }

        public static bool IfTplIsMoney(string tpl)
        {
            List<string> moneytpl = new() { "5449016a4bdc2d6f028b456f", "5696686a4bdc2da3298b456a", "569668774bdc2da2298b4568" };
            return moneytpl.Contains(tpl);
        }

        public static Item.Base CreateNew(string ItemId)
        {
            return new Item.Base()
            {
                Id = Utils.CreateNewID(),
                Tpl = ItemId
            };
        }

        public static Item.Base CreateNew(string ItemId, string ParentId)
        {
            return new Item.Base()
            {
                Id = Utils.CreateNewID(),
                Tpl = ItemId,
                ParentId = ParentId
            };
        }

        public static List<Item.Base> GetParentAndChildren(string ItemId, List<Item.Base> items)
        {
            List<Item.Base> childrens = new();
            foreach (var child in items)
            {
                if (child.Id == ItemId)
                {
                    childrens.Insert(0, child);
                    continue;
                }

                if (child.ParentId == ItemId && childrens.Find(item => item.Id == child.Id) != null)
                {
                    childrens.AddRange(GetParentAndChildren(child.Id, items));
                }
            }
            return childrens;
        }

        public static List<Item.Base> GetAllChildItemsInInventory(Item.Base Item, List<Item.Base> items)
        {
            Dictionary<string, List<Item.Base>> parentReference = new();

            foreach (var item in items)
            {
                if (item != null && !string.IsNullOrEmpty(item.ParentId))
                {
                    if (parentReference.ContainsKey(item.ParentId))
                    {
                        parentReference[item.ParentId].Add(item);
                    }
                    else
                    {
                        parentReference[item.ParentId][0] = (item);
                    }
                }
            }

            if (!parentReference.ContainsKey(Item.Id))
            {
                return new();
            }
            else
            {
                List<Item.Base> ret = new();

                ret.AddRange(parentReference[Item.Id]);

                foreach (var item in ret)
                {
                    if (parentReference.ContainsKey(item.Id))
                    {
                        ret.AddRange(parentReference[item.Id]);
                    }
                }

                return ret;
            }
        }

        public static List<Item.Base> PrepareChildrenForAddItem(string parentId, List<Item.Base>? items)
        {
            List<Item.Base> ret = new();

            if (items == null)
                return ret;

            foreach (var item in items)
            {
                if (item.ParentId == parentId)
                {
                    var grandchilds = PrepareChildrenForAddItem(item.Id, items);

                    Item.Base newChild = new()
                    {
                        Tpl = item.Tpl,
                        SlotId = item.SlotId
                    };

                    if (grandchilds.Count > 0 && grandchilds != null)
                        newChild.Children = grandchilds;

                    ret.Add(newChild);
                }
            }

            return ret;
        }

        public static List<Item.Base> HandleAmmoBoxes(string parentId, TemplateItem.Base item)
        {
            List<Item.Base> ret = new();

            var stack = item._props.StackSlots[0];
            var remainder = (int)stack._max_count;
            var ammoId = stack._props.filters[0].Filter[0];

            while (remainder > 0)
            {
                var cartridges = CreateNew(ammoId, parentId);
                cartridges.SlotId = stack._name.ToString();
                cartridges.Upd = CreateFreshBaseItemUpd(ammoId);

                if (cartridges.Upd.StackObjectsCount != null && cartridges.Upd.StackObjectsCount < remainder)
                {
                    remainder -= (int)cartridges.Upd.StackObjectsCount;
                }
                else
                {
                    cartridges.Upd.StackObjectsCount = remainder;
                    remainder--;
                }
                ret.Add(cartridges);
            }

            return ret;
        }

        public static Item._Upd CreateFreshBaseItemUpd(string itemId)
        {
            var _base = Get(itemId);
            switch (_base._parent)
            {
                case "590c745b86f7743cc433c5f2": // "Other"
                    return new()
                    {
                        Resource = new()
                        {
                            Value = (int)_base._props.Resource
                        }
                    };
                case "5448f3ac4bdc2dce718b4569": // Medical
                    return new()
                    {
                        MedKit = new()
                        {
                            HpResource = (int)_base._props.MaxHpResource
                        }
                    };
                case "5448e8d04bdc2ddf718b4569": // Food
                case "5448e8d64bdc2dce718b4568": // Drink
                    return new()
                    {
                        FoodDrink = new()
                        {
                            HpPercent = (int)_base._props.MaxResource
                        }
                    };
                case "5a341c4086f77401f2541505": // Headwear
                case "5448e5284bdc2dcb718b4567": // Vest
                case "57bef4c42459772e8d35a53b": // ArmoredEquipment
                case "5a341c4686f77469e155819e": // FaceCover
                case "5447e1d04bdc2dff2f8b4567": // Knife
                case "5448e54d4bdc2dcc718b4568": // Armor
                case "5448e5724bdc2ddf718b4568": // Visor
                    return new()
                    {
                        Repairable = new()
                        {
                            MaxDurability = (int)_base._props.MaxDurability,
                            Durability = (int)_base._props.Durability
                        }
                    };
                case "55818ae44bdc2dde698b456c": // OpticScope
                case "55818ac54bdc2d5b648b456e": // IronSight
                case "55818acf4bdc2dde698b456b": // CompactCollimator
                case "55818ad54bdc2ddc698b4569": // Collimator
                case "55818add4bdc2d5b648b456f": // AssaultScope
                case "55818aeb4bdc2ddc698b456a": // SpecialScope
                    return new()
                    {
                        Sight = new()
                        {
                            ScopesCurrentCalibPointIndexes = new()
                            {
                                0
                            },
                            ScopesSelectedModes = new()
                            {
                                0
                            },
                            SelectedScope = 0
                        }
                    };
                case "5447bee84bdc2dc3278b4569": // SpecialWeapon
                case "5447bedf4bdc2d87278b4568": // GrenadeLauncher
                case "5447bed64bdc2d97278b4568": // MachineGun
                case "5447b6254bdc2dc3278b4568": // SniperRifle
                case "5447b6194bdc2d67278b4567": // MarksmanRifle
                case "5447b6094bdc2dc3278b4567": // Shotgun
                case "5447b5fc4bdc2d87278b4567": // AssaultCarbine
                case "5447b5f14bdc2d61278b4567": // AssaultRifle
                case "5447b5e04bdc2d62278b4567": // Smg
                case "617f1ef5e8b54b0998387733": // Revolver
                    return new()
                    {
                        Repairable = new()
                        {
                            MaxDurability = (int)_base._props.MaxDurability,
                            Durability = (int)_base._props.Durability,
                        },
                        Foldable =
                        {
                            Folded = false
                        },
                        FireMode =
                        {
                            FireMode = "single"
                        }
                    };
                case "5447b5cf4bdc2d65278b4567": // Pistol
                    return new()
                    {
                        Repairable = new()
                        {
                            MaxDurability = (int)_base._props.MaxDurability,
                            Durability = (int)_base._props.Durability,
                        },
                        FireMode =
                        {
                            FireMode = "single"
                        }
                    };
                case "616eb7aea207f41933308f46": // RepairKits
                    return new()
                    {
                        RepairKit = new()
                        {
                            Resource = (int)_base._props.MaxRepairResource
                        }
                    };
                case "5485a8684bdc2da71d8b4567": // Ammo
                    return new()
                    {
                        StackObjectsCount = (int)_base._props.StackMaxSize
                    };

                case "55818b084bdc2d5b648b4571": // Flashlight
                case "55818b164bdc2ddc698b456c": // TacticalCombo
                    return new()
                    {
                        Light =
                        {
                            IsActive = false,
                            SelectedMode = 0
                        }
                    };
                case "55818a594bdc2db9688b456a": // Stock
                case "55818a104bdc2db9688b4569": // Handguard
                case "55818a684bdc2ddd698b456d": // PistolGrip
                case "555ef6e44bdc2de9068b457e": // Barrel
                case "5448bc234bdc2d3c308b4569": // Magazine
                case "55818b224bdc2dde698b456f": // Mount
                case "557596e64bdc2dc2118b4571": // Pockets
                case "5448bf274bdc2dfc2f8b456a": // MobContainer
                case "5448e53e4bdc2d60728b4567": // Backpack
                case "5645bcb74bdc2ded0b8b4578": // Headphones
                case "55818a304bdc2db5418b457d": // Reciever
                case "550aa4bf4bdc2dd6348b456b": // FlashHider
                case "550aa4cd4bdc2dd8348b456c": // Silencer
                case "55818af64bdc2d5b648b4570": // Foregrip
                case "5a74651486f7744e73386dd1": // AuxilaryMod
                case "55818afb4bdc2dde698b456d": // Bipod
                case "56ea9461d2720b67698b456f": // Gasblock
                case "550aa4dd4bdc2dc9348b4569": // MuzzleCombo
                case "55818a6f4bdc2db9688b456b": // Charge
                case "610720f290b75a49ff2e5e25": // CylinderMagazine
                case "5447e0e74bdc2d3c308b4567": // SpecItem
                case "543be6564bdc2df4348b4568": // ThrowWeap
                default:
                    Debug.PrintError($"Unable to create fresh UPD from parent [{_base._parent}] for item [{_base._id}]");
                    return new();
            }

        }

        public static bool IsFolded(Item.Base item)
        {
            return item.Upd.Foldable.Folded == false;
        }

        public static bool IsSearchableItem(TemplateItem.Base item)
        {
            if (item._parent == "566168634bdc2d144c8b456c")
                return true;
            else
                return Get(item._parent)._parent == "566168634bdc2d144c8b456c";
        }

        public static int GetStackSize(TemplateItem.Base item)
        {
            return item._props.StackMaxSize > 1 ? (int)item._props.StackMaxSize : 1;
        }

        public static List<Item.Base> GetSizeableItems(Item.Base item, TemplateItem.Base itemTemplate, List<Item.Base> items)
        {
            List<Item.Base> ret = new();
            foreach (var child in items)
            {
                if (child.SlotId.IndexOf("mod_") < 0)
                    continue;

                var childItem = Get(child.Tpl);

                if ((itemTemplate._props.Foldable
                    && itemTemplate._props.FoldedSlot.ToString() == child.SlotId
                    && (IsFolded(item) || IsFolded(child)))
                    || (childItem._props.Foldable && IsFolded(item)
                    && IsFolded(child)))
                {
                    continue;
                }

                ret.Add(child);
            }
            return ret;
        }

        public static (Others.Size Size, Others.Forced Forced) GetSizesOfChildItems(List<Item.Base> items, Others.Size size, Others.Forced forced)
        {
            foreach (var child in items)
            {
                var childItem = Get(child.Tpl);

                if (childItem._props.ExtraSizeForceAdd)
                {
                    forced.ForcedUp += (int)childItem._props.ExtraSizeUp;
                    forced.ForcedDown += (int)childItem._props.ExtraSizeDown;
                    forced.ForcedLeft += (int)childItem._props.ExtraSizeLeft;
                    forced.ForcedRight += (int)childItem._props.ExtraSizeRight;
                    continue;
                }

                size.SizeUp = size.SizeUp < childItem._props.ExtraSizeUp ? (int)childItem._props.ExtraSizeUp : size.SizeUp;
                size.SizeDown = size.SizeDown < childItem._props.ExtraSizeDown ? (int)childItem._props.ExtraSizeDown : size.SizeDown;
                size.SizeLeft = size.SizeLeft < childItem._props.ExtraSizeLeft ? (int)childItem._props.ExtraSizeLeft : size.SizeLeft;
                size.SizeRight = size.SizeRight < childItem._props.ExtraSizeRight ? (int)childItem._props.ExtraSizeRight : size.SizeRight;
            }
            return (size, forced);
        }

        public static Others.WidthHeight GetSize(Item.Base item, List<Item.Base>? items)
        {
            var ItemTemplate = Get(item.Tpl);
            var itemWidth = (int)ItemTemplate._props.Width;
            var itemHeight = (int)ItemTemplate._props.Height;

            if (items != null && items.Count > 0)
            {
                Others.Size size = new()
                {
                    SizeUp = 0,
                    SizeDown = 0,
                    SizeLeft = 0,
                    SizeRight = 0
                };

                Others.Forced forced = new()
                {
                    ForcedUp = 0,
                    ForcedDown = 0,
                    ForcedLeft = 0,
                    ForcedRight = 0
                };

                var sizeableItem = GetSizeableItems(item, ItemTemplate, items);
                if (sizeableItem != null && sizeableItem.Count > 0)
                {
                    var childitems = GetSizesOfChildItems(sizeableItem, size, forced);
                    size = childitems.Size;
                    forced = childitems.Forced;
                    itemWidth += (size.SizeLeft + size.SizeRight + forced.ForcedLeft + forced.ForcedRight);
                    itemHeight += (size.SizeUp + size.SizeDown + forced.ForcedUp + forced.ForcedDown);
                }
            }

            if (item.Location.R == 0)
                return new() { Height = itemHeight, Width = itemWidth };
            else
                return new() { Height = itemWidth, Width = itemHeight };
        }

        public static Others.ContainerMap? CreateContainerMap(Item.Base container)
        {
            var containerTemplate = Get(container.Tpl);
            if (containerTemplate == null)
            {
                Debug.PrintError($"{container.Tpl} is invalid!", "CreateContainerMap");
                return null;
            }

            Others.ContainerMap root = new()
            {
                Id = container.Id,
                Map = new(),
            };

            foreach (var gird in containerTemplate._props.Grids)
            {
                root.Map.Add(gird._name,
                    new()
                    {
                        Height = (int)gird._props.cellsH,
                        Width = (int)gird._props.cellsV,
                        Grid = new()
                    }
                );
                for (int row = 0; row < root.Map[gird._name].Height; row++)
                {
                    root.Map[gird._name].Grid.Add(new());
                    for (int column = 0; column < root.Map[gird._name].Width; column++)
                    {
                        root.Map[gird._name].Grid[row].Add("");
                    }
                }
            }
            return root;
        }

        public static Others.ContainerMap? PositionItemsInMap(Others.ContainerMap? container, List<Item.Base> containerItems)
        {
            if (container == null)
            {
                Debug.PrintError("Container is null!", "PositionItemsInMap");
                return null;
            }

            var items = containerItems.Where(item => item.ParentId == container.Id && item.Location != null).ToList();

            foreach (var item in items)
            {
                var itemSize = GetSize(item, GetAllChildItemsInInventory(item, containerItems));
                int sizeh = ((int)(item.Location.Y + itemSize.Height));
                for (int row = item.Location.Y; row < sizeh; row++)
                {
                    int sizew = ((int)(item.Location.X + itemSize.Width));
                    for (int column = item.Location.X; column < sizew; column++)
                    {
                        if (container.Map.TryGetValue(item.SlotId, out var value))
                        {
                            value.Grid[row][column] = item.Id;
                        }
                        else
                        {
                            var error = $"Inventory item occupies invalid slot: _id: {item.Id} _tpl: ${item.Tpl} parentId: ${item.ParentId} slotId: ${item.SlotId} y: ${row} x: ${column} -width: ${itemSize.Width} height: ${itemSize.Height}";
                            Debug.PrintError(error, "PositionItemsInMap");
                            return null;
                        }
                    }
                }


            }
            return container;
        }

        public static Others.ContainerMap? GenerateContainerMap(Item.Base container, List<Item.Base> containerItems)
        {
            var containerMap = CreateContainerMap(container);
            return PositionItemsInMap(containerMap, containerItems);
        }

        public static Others.FreeSlot GetFreeSlot(Others.ContainerMap container, Others.WidthHeight dimensions)
        {
            Others.FreeSlot freeSlot = new();

            foreach (var item in container.Map.Keys)
            {
                if (container.Map[item].Width == dimensions.Width && container.Map[item].Height == dimensions.Height)
                {
                    if (string.IsNullOrEmpty(container.Map[item].Grid[0][0]))
                    {
                        freeSlot = new()
                        {
                            X = 0,
                            Y = 0,
                            R = 0,
                            SlotId = item
                        };
                        break;
                    }
                }

                if (container.Map[item].Height == dimensions.Width && container.Map[item].Width == dimensions.Height)
                {
                    if (string.IsNullOrEmpty(container.Map[item].Grid[0][0]))
                    {
                        freeSlot = new()
                        {
                            X = 0,
                            Y = 0,
                            R = 1,
                            SlotId = item
                        };
                        break;
                    }
                }

                if (container.Map[item].Width >= dimensions.Width && container.Map[item].Height >= dimensions.Height)
                {
                    int sizeh = (int)(container.Map[item].Height - dimensions.Height);
                    for (int row = 0; row < sizeh; row++)
                    {
                        int sizew = (int)(container.Map[item].Width - dimensions.Width);
                        for (int column = 0; column < sizew; column++)
                        {
                            int sizerow = (int)(row + dimensions.Height);
                            for (var searchRow = row; searchRow < sizerow; searchRow++)
                            {
                                int sizec = (int)(column + dimensions.Width);
                                for (var searchColumn = column; searchColumn < sizec; searchColumn++)
                                {
                                    if (string.IsNullOrEmpty(container.Map[item].Grid[searchRow][searchColumn]))
                                    {
                                        freeSlot = new()
                                        {
                                            X = column,
                                            Y = row,
                                            R = 0,
                                            SlotId = item
                                        };
                                        break;
                                    }
                                }

                            }
                        }
                    }
                }



                if (container.Map[item].Width >= dimensions.Height && container.Map[item].Height >= dimensions.Width)
                {
                    int sizeh = (int)(container.Map[item].Height - dimensions.Width);
                    for (int row = 0; row < sizeh; row++)
                    {
                        int sizew = (int)(container.Map[item].Width - dimensions.Height);
                        for (int column = 0; column < sizew; column++)
                        {
                            int sizerow = (int)(row + dimensions.Width);
                            for (var searchRow = row; searchRow < sizerow; searchRow++)
                            {
                                int sizec = (int)(column + dimensions.Height);
                                for (var searchColumn = column; searchColumn < sizec; searchColumn++)
                                {
                                    if (string.IsNullOrEmpty(container.Map[item].Grid[searchRow][searchColumn]))
                                    {
                                        freeSlot = new()
                                        {
                                            X = column,
                                            Y = row,
                                            R = 1,
                                            SlotId = item
                                        };
                                        break;
                                    }
                                }

                            }
                        }
                    }
                }
            }
            return freeSlot;
        }


    }
}
