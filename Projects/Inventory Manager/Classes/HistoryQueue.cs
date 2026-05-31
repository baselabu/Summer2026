using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Manager.Models;

namespace Inventory_Manager.Classes
{
    public class HistoryQueue
    {
        private Queue<Transaction> history;

        public HistoryQueue()
        {
            history = new Queue<Transaction>();
        }

        public void AddTransaction(Transaction item)
        {
            history.Enqueue(item);
        }
        public void ClearHistory()
            {
                history.Clear();
                Console.WriteLine("Transaction history cleared.");
            }
        public void ShowHistory()
        {
            Console.WriteLine("Transaction History:");
            foreach (var transaction in history)
            {
                Console.WriteLine($"{transaction.Timestamp}: {transaction.Action} {transaction.QuantityChange} of {transaction.ItemName}");
            }
        }

    }
}