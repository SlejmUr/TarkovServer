using ServerLib.Json.Classes;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;
using static ServerLib.Json.Classes.Others;

namespace ServerLib.Controllers
{
    public class ItemController
    {
        public static List<string> CurrencyTPL = new()
        {
            "5449016a4bdc2d6f028b456f", "5696686a4bdc2da3298b456a", "569668774bdc2da2298b4568"
        };

        public static Dictionary<string, string> CurrencyDict = new()
        {
            { "RUB", "5449016a4bdc2d6f028b456f" },
            { "EUR", "569668774bdc2da2298b4568" },
            { "USD", "5696686a4bdc2da3298b456a" }
        };

        public static TemplateItem.Base? Get(string ItemId)
        {
            if (DatabaseController.DataBase.Others.Items.TryGetValue(ItemId, out var value))
                return value;

            return null;
        }

        public static bool AddToTemplateItems(TemplateItem.Base item)
        {
            return DatabaseController.DataBase.Others.Items.TryAdd(item._id, item);
        }

        public static Dictionary<string, TemplateItem.Base> GetAll()
        {
            return DatabaseController.DataBase.Others.Items;
        }


        public static int GetItemPrice(string ItemId)
        {
            if (DatabaseController.DataBase.Others.ItemPrices.TryGetValue(ItemId, out var value))
                return value;

            return -1;
        }

        public static bool IsCurrency(string tpl)
        {
            return CurrencyTPL.Contains(tpl);
        }

        public static Item.Base CreateNew(string ItemId)
        {
            return new Item.Base()
            {
                Id = AIDHelper.CreateNewID(),
                Tpl = ItemId
            };
        }

        public static Item.Base CreateNew(string ItemId, string ParentId)
        {
            return new Item.Base()
            {
                Id = AIDHelper.CreateNewID(),
                Tpl = ItemId,
                ParentId = ParentId
            };
        }

        public static Item._Upd CreateNewUDP(TemplateItem.Base item)
        {
            switch (item._parent)
            {
                case "590c745b86f7743cc433c5f2": // "Other"
                    return new()
                    {
                        Resource = new()
                        {
                            Value = (int)item._props.Resource
                        }
                    };
                case "5448f3ac4bdc2dce718b4569": // Medical
                    return new()
                    {
                        MedKit = new()
                        {
                            HpResource = (int)item._props.MaxHpResource
                        }
                    };
                case "5448e8d04bdc2ddf718b4569": // Food
                case "5448e8d64bdc2dce718b4568": // Drink
                    return new()
                    {
                        FoodDrink = new()
                        {
                            HpPercent = (int)item._props.MaxResource
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
                            MaxDurability = (int)item._props.MaxDurability,
                            Durability = (int)item._props.Durability
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
                            MaxDurability = (int)item._props.MaxDurability,
                            Durability = (int)item._props.Durability,
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
                            MaxDurability = (int)item._props.MaxDurability,
                            Durability = (int)item._props.Durability,
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
                            Resource = (int)item._props.MaxRepairResource
                        }
                    };
                case "5485a8684bdc2da71d8b4567": // Ammo
                    return new()
                    {
                        StackObjectsCount = (int)item._props.StackMaxSize
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
                default:
                    Debug.PrintError($"Unable to create fresh UPD from parent [{item._parent}] for item [{item._id}]");
                    return new();
            }

        }

        public static bool IsFolded(Item.Base item)
        {
            if (item.Upd == null)
                return false;

            if (item.Upd.Foldable == null)
                return false;

            return item.Upd.Foldable.Folded;
        }

        public static bool IsSearchableItem(TemplateItem.Base item)
        {
            return (item._parent == "566168634bdc2d144c8b456c");
        }

        public static int GetStackSize(TemplateItem.Base item)
        {
            return item._props.StackMaxSize > 1 ? (int)item._props.StackMaxSize : 1;
        }

        public static (double Height, double Width) GetItemSize(TemplateItem.Base item)
        {
            return (item._props.Height, item._props.Width);
        }

        public static Sizes GetItemForcedSize(TemplateItem.Base item, Sizes sizes)
        {
            if (item._props.ExtraSizeForceAdd)
            {
                sizes.ForcedDown = (int)item._props.ExtraSizeDown;
                sizes.ForcedUp = (int)item._props.ExtraSizeUp;
                sizes.ForcedLeft = (int)item._props.ExtraSizeLeft;
                sizes.ForcedRight = (int)item._props.ExtraSizeRight;
            }
            else
            {
                sizes.SizeUp = (int)Math.Max(sizes.SizeUp, item._props.ExtraSizeUp);
                sizes.SizeDown = (int)Math.Max(sizes.SizeDown, item._props.ExtraSizeDown);
                sizes.SizeLeft = (int)Math.Max(sizes.SizeLeft, item._props.ExtraSizeLeft);
                sizes.SizeRight = (int)Math.Max(sizes.SizeRight, item._props.ExtraSizeRight);
            }
            return sizes;
        }

        public static Dictionary<string, TemplateItem.Grid>? GetItemGrids(TemplateItem.Base item)
        {
            Dictionary<string, TemplateItem.Grid> ret = new();
            var list = item._props.Grids;
            if (list == null || list.Count == 0)
                return null;

            foreach (var grid in list)
            {
                ret.Add(grid._name, grid);
            }
            return ret;
        }

        public static Dictionary<string, TemplateItem.Slot>? GetItemSlots(TemplateItem.Base item)
        {
            Dictionary<string, TemplateItem.Slot> ret = new();
            var list = item._props.Slots;
            if (list == null || list.Count == 0)
                return null;

            foreach (var slot in list)
            {
                ret.Add(slot._name, slot);
            }
            return ret;
        }

        public static int GetStackMaxSize(TemplateItem.Base item)
        {
            return (int)item._props.StackMaxSize;
        }
    }
}
