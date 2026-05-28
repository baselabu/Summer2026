using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Manager.Classes
{
    public class InventoryManager
    {
        private List<Item> items;

        public InventoryManager()
        {
            items = new List<Item>();
        }
    }
}