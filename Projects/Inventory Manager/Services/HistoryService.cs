using System;
using System.Collections.Generic;
using Inventory_Manager.Models;
using Inventory_Manager.Interfaces;

namespace Inventory_Manager.Services
{

    public class HistoryService : IHistoryService
    {
        private readonly Queue<Transaction> _history;
        private readonly IOutputWriter _output;

        public HistoryService(IOutputWriter output)
        {
            _history = new Queue<Transaction>();
            _output = output;
        }

        public void AddToHistory(Transaction transaction)
        {
            transaction.Timestamp = DateTime.Now;
            _history.Enqueue(transaction);
        }

        public void ClearHistory()
        {
            _history.Clear();
            _output.WriteLine("Transaction history cleared.");
        }

        public void DisplayHistory()
        {
            if (_history.Count == 0)
            {
                _output.WriteLine("No transaction history available.");
                return;
            }

            _output.WriteLine("\n=== Transaction History ===");
            foreach (var transaction in _history)
            {
                _output.WriteLine($"{transaction.Timestamp:yyyy-MM-dd HH:mm:ss} | {transaction.Action} {transaction.QuantityChange} of {transaction.ItemName}");
            }
            _output.WriteLine("===========================\n");
        }
    }
}
