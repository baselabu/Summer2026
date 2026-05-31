using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Manager.Models;

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

        public void addItem(Item item)
        {
            if (IdExists(item.Id))
            {
                Console.WriteLine($"Item with ID '{item.Id}' already exists. Please use a unique ID.");
                return;
            }
            
            items.Add(item.Name, item);
            history.AddTransaction(new Transaction {
                 ItemName = item.Name, 
                 Action = "Added", 
                 QuantityChange = item.Quantity });
        }
        public void removeItem(string name)
        {
            if (items.ContainsKey(name))
            {
                var item = items[name];
                items.Remove(name);
                history.AddTransaction(new Transaction {
                    ItemName = item.Name, 
                    Action = "Removed", 
                    QuantityChange = -item.Quantity });
            }
            else            {
                Console.WriteLine($"Item with name '{name}' not found.");
            }
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
    public bool IdExists(int id)
        {
            return items.Values.Any(item => item.Id == id);
        }
    }
    
}