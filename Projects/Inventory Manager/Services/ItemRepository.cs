using System;
using System.Collections.Generic;
using System.Linq;
using Inventory_Manager.Models;
using Inventory_Manager.Interfaces;
using Inventory_Manager.Validations;

namespace Inventory_Manager.Services
{
    public class ItemRepository : IItemRepository
    {
        private readonly Dictionary<string, Item> _items;
        private readonly IOutputWriter _output;
        private readonly IValidator _validator;

        public ItemRepository(IOutputWriter output, IValidator validator)
        {
            _items = new Dictionary<string, Item>();
            _output = output;
            _validator = validator;
        }

        public void AddItem(Item item)
        {
            if (ItemExists(item.Id))
            {
                _output.WriteError($"Item with ID '{item.Id}' already exists. Please use a unique ID.");
                return;
            }

            _items.Add(item.Name, item);
            _output.WriteSuccess($"Item '{item.Name}' added successfully.");
        }

        public bool RemoveItem(string name)
        {
            if (_items.ContainsKey(name))
            {
                _items.Remove(name);
                return true;
            }

            _output.WriteError($"Item with name '{name}' not found.");
            return false;
        }

        public Item? GetItemByName(string name)
        {
            return _items.ContainsKey(name) ? _items[name] : null;
        }

        public Item? GetItemById(int id)
        {
            return _items.Values.FirstOrDefault(i => i.Id == id);
        }

        public List<Item> GetAllItems()
        {
            return _items.Values.ToList();
        }

        public bool ItemExists(int id)
        {
            return _validator.ValidateItemId(id, _items);
        }

        public bool ItemNameExists(string name)
        {
            return _validator.ValidateItemName(name, _items);
        }

        public List<Item> FindItemsByPartialName(string partialName)
        {
            var matches = new List<Item>();

            foreach (var item in _items.Values)
            {
                FindMatchesRecursive(item, partialName, matches);
            }

            return matches;
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

        public void ClearItems()
        {
            _items.Clear();
        }
    }
}
