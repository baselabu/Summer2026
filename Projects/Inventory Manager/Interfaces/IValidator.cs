using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Manager.Models;

namespace Inventory_Manager.Interfaces
{
    public interface IValidator
    {
        bool ValidateItemId(int id, Dictionary<string, Item> items);
        bool ValidateItemName(string name, Dictionary<string, Item> items);        
    }
}