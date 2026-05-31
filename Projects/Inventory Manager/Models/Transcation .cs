using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Manager.Models
{
    public class Transaction 
    {
        public string ItemName { get; set; } = "";
        public string Action { get; set; } = "";
        public int QuantityChange { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}