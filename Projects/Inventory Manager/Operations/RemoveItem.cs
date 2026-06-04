using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Manager.Models;
using Inventory_Manager.Classes;

namespace Inventory_Manager.Operations
{
    public static class RemoveItem
    {
        public static void removeItem(string name , Dictionary<string, Item> items, HistoryQueue history)
        {
            if (items.ContainsKey(name))
            {
                var item = items[name];
                items.Remove(name);
                history.AddToHistory(new Transaction {
                    ItemName = item.Name, 
                    Action = "Removed", 
                    QuantityChange = -item.Quantity });
            }
            else            {
                Console.WriteLine($"Item with name '{name}' not found.");
            }
        }        
    }
}