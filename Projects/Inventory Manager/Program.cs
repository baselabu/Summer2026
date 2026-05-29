using Inventory_Manager.Classes;

Item item1 = new Item { Id = 1, Name = "Snickers", Quantity = 10, Price = 2.99 };
Item item2 = new Item { Id = 2, Name = "Gadget", Quantity = 5, Price = 9.99 };

InventoryManager inventory = new InventoryManager();
inventory.addItem(item1);
inventory.addItem(item2);
inventory.lookupItem("Snickerss");