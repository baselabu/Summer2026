using System;
using System.Collections.Generic;
using System.Linq;
using Inventory_Manager.Models;
using Inventory_Manager.Interfaces;

namespace Inventory_Manager.SortingTypes
{
    public class SortByQuantity : ISortingWay
    {
        private readonly IOutputWriter _output;

        public SortByQuantity(IOutputWriter output)
        {
            _output = output;
        }

        public List<Item> Sort(List<Item> items)
        {
            return items.OrderBy(item => item.Quantity).ToList();
        }

        public string GetDescription()
        {
            return "Items sorted by quantity (lowest to highest):";
        }
    }
}
