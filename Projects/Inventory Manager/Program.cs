using Inventory_Manager.Classes;
using Inventory_Manager.Models;

Item item1 = new Item(0, "Snickers", 10, 1.99);
Item item2 = new Item(1, "Gadget", 5, 9.99);
Item nestedItem = new Item(2, "Mini Gadget", 2, 4.99);

item2.Children.Add(nestedItem);

InventoryManager inventory = new InventoryManager();
inventory.AddItem(item1);
inventory.AddItem(item2);
inventory.lookupItem("Snickers");
inventory.lookupItem(2);
inventory.lookupItemRecursive("Gadget");
inventory.SaveItemsToJson("inventory.json");
//inventory.RemoveItemByName("Gadget");
inventory.showHistory();
inventory.SortInventoryByName();
inventory.SortInventoryByPrice();
inventory.SortInventoryByQuantity();