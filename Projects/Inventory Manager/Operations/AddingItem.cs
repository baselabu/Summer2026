using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Manager.Models;
using Inventory_Manager.Classes;
using Inventory_Manager.Validations;

namespace Inventory_Manager.Operations
    {
    public static class AddingItem
    {
        public static void addItem(Item item, Dictionary<string, Item> items, HistoryQueue history)
        {
            if (IdValidator.IdExists(item.Id, items))
            {
                Console.WriteLine($"Item with ID '{item.Id}' already exists. Please use a unique ID.");
                return;
            }

            items.Add(item.Name, item);
            history.AddToHistory(new Transaction {
                 ItemName = item.Name, 
                 Action = "Added", 
                 QuantityChange = item.Quantity });
        }        
    }
}