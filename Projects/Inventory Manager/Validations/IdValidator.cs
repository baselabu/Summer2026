using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Manager.Models;
using Inventory_Manager.Classes;

namespace Inventory_Manager.Validations

{
    public class IdValidator
    {
    internal static bool IdExists(int id , Dictionary<string, Item> items)
        {
            return items.Values.Any(item => item.Id == id);
        }        
    }
}