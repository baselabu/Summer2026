using Inventory_Manager.Main;
using Inventory_Manager.Models;
using Inventory_Manager.Interfaces;
using Inventory_Manager.Services;
using Inventory_Manager.Validations;

IOutputWriter outputWriter = new ConsoleOutputWriter();
IValidator validator = new ItemValidator();
IItemRepository itemRepository = new ItemRepository(outputWriter, validator);
IHistoryService historyService = new HistoryService(outputWriter);
IPersistenceService persistenceService = new JsonPersistenceService(outputWriter);

InventoryManager inventory = new InventoryManager(itemRepository, historyService, persistenceService, outputWriter);


outputWriter.WriteLine("=== Inventory Management System ===\n");

Item item1 = new Item(1, "Snickers", 10, 1.99);
Item item2 = new Item(2, "Gadget", 5, 9.99);
Item nestedItem = new Item(3, "Mini Gadget", 2, 4.99);

item2.Children.Add(nestedItem);

inventory.AddItem(item1);
inventory.AddItem(item2);

outputWriter.WriteLine("\n--- Lookup by Name ---");
inventory.LookupItem("Snickers");

outputWriter.WriteLine("\n--- Lookup by ID ---");
inventory.LookupItem(2);

outputWriter.WriteLine("\n--- Recursive Search ---");
inventory.LookupItemRecursive("Gadget");

outputWriter.WriteLine("\n--- Saving Inventory ---");
inventory.SaveItems("inventory.json");

outputWriter.WriteLine("\n--- Transaction History ---");
inventory.ClearHistory();
inventory.ShowHistory();

outputWriter.WriteLine("\n--- Sorting Examples ---");
inventory.SortInventoryByName();
inventory.SortInventoryByPrice();
inventory.SortInventoryByQuantity();