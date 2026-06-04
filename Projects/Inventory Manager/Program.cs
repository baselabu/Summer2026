using Inventory_Manager.Classes;
using Inventory_Manager.Models;

Item item1 = new Item { Id = 1, Name = "Snickers", Quantity = 10, Price = 2.99 };
Item item2 = new Item { Id = 2, Name = "Gadget", Quantity = 5, Price = 9.99 };
Item nestedItem = new Item { Id = 3, Name = "Mini Gadget", Quantity = 2, Price = 4.99 };

item2.Children.Add(nestedItem);

InventoryManager inventory = new InventoryManager();
inventory.AddItem(item1);
inventory.AddItem(item2);
inventory.lookupItem("Snickers");
inventory.lookupItem(2);
inventory.lookupItemRecursive("Gadget");
inventory.SaveItemsToJson("inventory.json");
inventory.RemoveItemByName("Gadget");
inventory.showHistory();