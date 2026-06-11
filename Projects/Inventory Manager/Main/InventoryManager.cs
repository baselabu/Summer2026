using System;
using System.Collections.Generic;
using System.Linq;
using Inventory_Manager.Models;
using Inventory_Manager.Interfaces;
using Inventory_Manager.SortingTypes;

namespace Inventory_Manager.Main
{
    public class InventoryManager
    {
        private readonly IItemRepository _itemRepository;
        private readonly IHistoryService _historyService;
        private readonly IPersistenceService _persistenceService;
        private readonly IOutputWriter _output;

        public InventoryManager(
            IItemRepository itemRepository,
            IHistoryService historyService,
            IPersistenceService persistenceService,
            IOutputWriter output)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _historyService = historyService ?? throw new ArgumentNullException(nameof(historyService));
            _persistenceService = persistenceService ?? throw new ArgumentNullException(nameof(persistenceService));
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void AddItem(Item item)
        {
            _itemRepository.AddItem(item);
            _historyService.AddToHistory(new Transaction
            {
                ItemName = item.Name,
                Action = "Added",
                QuantityChange = item.Quantity
            });
        }

        public void RemoveItemByName(string name)
        {
            var item = _itemRepository.GetItemByName(name);
            if (item != null && _itemRepository.RemoveItem(name))
            {
                _historyService.AddToHistory(new Transaction
                {
                    ItemName = item.Name,
                    Action = "Removed",
                    QuantityChange = -item.Quantity
                });
                _output.WriteSuccess($"Item '{name}' removed successfully.");
            }
        }

        public void LookupItem(string name)
        {
            var item = _itemRepository.GetItemByName(name);
            if (item == null)
            {
                _output.WriteError($"Item with name '{name}' not found.");
            }
            else
            {
                DisplayItem(item);
            }
        }

        public void LookupItem(int id)
        {
            var item = _itemRepository.GetItemById(id);
            if (item == null)
            {
                _output.WriteError($"Item with ID '{id}' not found.");
            }
            else
            {
                DisplayItem(item);
            }
        }

        public void LookupItemRecursive(string partialName)
        {
            var matches = _itemRepository.FindItemsByPartialName(partialName);

            if (matches.Count == 0)
            {
                _output.WriteError($"No items matching '{partialName}' were found.");
                return;
            }

            _output.WriteLine($"\nFound {matches.Count} item(s) matching '{partialName}':");
            foreach (var item in matches)
            {
                DisplayItem(item);
            }
            _output.WriteLine("");
        }

        private void DisplayItem(Item item)
        {
            _output.WriteLine($"  ID: {item.Id} | Name: {item.Name} | Qty: {item.Quantity} | Price: ${item.Price:F2}");
        }
   
        public void ShowHistory()
        {
            _historyService.DisplayHistory();
        }

        public void ClearHistory()
        {
            _historyService.ClearHistory();
        }

        public void SaveItems(string filePath)
        {
            var items = _itemRepository.GetAllItems();
            _persistenceService.SaveItems(items, filePath);
        }

        public void LoadItems(string filePath)
        {
            var items = _persistenceService.LoadItems(filePath);
            
            _itemRepository.ClearItems();
            foreach (var item in items)
            {
                _itemRepository.AddItem(item);
            }
        }

        public void SortInventoryByName()
        {
            var SortingType = new SortByName(_output);
            DisplaySortedItems(SortingType);
        }

        public void SortInventoryByPrice()
        {
            var SortingType = new SortByPrice(_output);
            DisplaySortedItems(SortingType);
        }
 
        public void SortInventoryByQuantity()
        {
            var SortingType = new SortByQuantity(_output);
            DisplaySortedItems(SortingType);
        }

 
        private void DisplaySortedItems(ISortingWay strategy)
        {
            var items = _itemRepository.GetAllItems();
            var sortedItems = strategy.Sort(items);

            _output.WriteLine($"\n{strategy.GetDescription()}");
            foreach (var item in sortedItems)
            {
                DisplayItem(item);
            }
            _output.WriteLine("");        }
    }
}