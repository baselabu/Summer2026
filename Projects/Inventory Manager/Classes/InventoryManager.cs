using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Manager.Models;
using System.Text.Json;
using Inventory_Manager.Operations;
using Inventory_Manager.Validations;

namespace Inventory_Manager.Classes
{
    public class InventoryManager
    {
        private Dictionary<string, Item> items;
        private HistoryQueue history;

        public InventoryManager()
        {
            items = new Dictionary<string, Item>();
            history = new HistoryQueue();
        }

        public void AddItem(Item item)
        {
            AddingItem.addItem(item, items, history);
        }
        public void RemoveItemByName(string name)
        {
            RemoveItem.removeItem(name, items, history);
        }
        public void lookupItem(string name)
        {
            if (!items.ContainsKey(name))
            {
                Console.WriteLine($"Item with name '{name}' not found.");
            }
            else
            {
                Console.WriteLine($"Found item: {items[name]?.Name}, Quantity: {items[name]?.Quantity}, Price: {items[name]?.Price}");
            }
        }

        public void lookupItemRecursive(string partialName)
        {
            var matches = new List<Item>();

            foreach (var item in items.Values)
            {
                FindMatchesRecursive(item, partialName, matches);
            }

            if (matches.Count == 0)
            {
                Console.WriteLine($"No items matching '{partialName}' were found.");
                return;
            }

            Console.WriteLine($"Found {matches.Count} item(s) matching '{partialName}':");
            foreach (var item in matches)
            {
                Console.WriteLine($"Item: {item.Name}, Quantity: {item.Quantity}, Price: {item.Price}");
            }
        }

        private static void FindMatchesRecursive(Item item, string partialName, ICollection<Item> matches)
        {
            if (item.Name.Contains(partialName, StringComparison.OrdinalIgnoreCase))
            {
                matches.Add(item);
            }

            foreach (var child in item.Children)
            {
                FindMatchesRecursive(child, partialName, matches);
            }
        }

        public void lookupItem(int id)
        {
            var item = items.Values.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                Console.WriteLine($"Item with ID '{id}' not found.");
            }
            else
            {
                Console.WriteLine($"Found item: {item.Name}, Quantity: {item.Quantity}, Price: {item.Price}");
            }
        }
        public void showHistory()
        {
            history.ShowHistory();
        }
        public void clearHistory()
        {
            history.ClearHistory();
        }

        public void SaveItemsToJson(string filePath)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };
            var json = JsonSerializer.Serialize(items.Values.ToList(), options);
            File.WriteAllText(filePath, json);
        }

        public void LoadItemsFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' not found.");
                return;
            }

            var json = File.ReadAllText(filePath);
            var loadedItems = JsonSerializer.Deserialize<List<Item>>(json);

            if (loadedItems != null)
            {
                items.Clear();
                foreach (var item in loadedItems)
                {
                    items.Add(item.Name, item);
                }
                Console.WriteLine($"Loaded {loadedItems.Count} items from '{filePath}'.");
            }
            else
            {
                Console.WriteLine($"Failed to load items from '{filePath}'.");
            }
        }
    
    public void SortInventoryByName()
    {
        SortingBy.SortByName(items);
    }
    public void SortInventoryByPrice()
    {
        SortingBy.SortByPrice(items);
    }
    public void SortInventoryByQuantity()
    {
        SortingBy.SortByQuantity(items);
    }
    }
}