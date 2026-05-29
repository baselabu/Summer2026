using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Manager.Classes
{
    public class InventoryManager
    {
        private Dictionary<string, Item> items;

        public InventoryManager()
        {
            items = new Dictionary<string, Item>();
        }

        public void addItem(Item item)
        {

            items.Add(item.Name, item);
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
    }
    
}