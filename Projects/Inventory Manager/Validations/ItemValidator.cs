using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Manager.Models;
using Inventory_Manager.Classes;
using Inventory_Manager.Interfaces;

namespace Inventory_Manager.Validations

{
    public class ItemValidator : IValidator
    {
        public bool ValidateItemId(int id, Dictionary<string, Item> items)
        {
            return items.Values.Any(item => item.Id == id);
        }

        public bool ValidateItemName(string name, Dictionary<string, Item> items)
        {
            return items.ContainsKey(name);
        }
    }
}