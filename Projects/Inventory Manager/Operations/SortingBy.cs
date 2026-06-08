using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Manager.Models;
using Inventory_Manager.Classes;

namespace Inventory_Manager.Operations
{
    public class SortingBy
    {
        public static void SortByName(Dictionary<string, Item> items)
        {
            var sortedItems = items.Values.OrderBy(item => item.Name).ToList();
            Console.WriteLine("Items sorted by name:");
            foreach (var item in sortedItems)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Price: {item.Price}");
            }
        }
        public static void SortByPrice(Dictionary<string, Item> items)
        {
            var sortedItems = items.Values.OrderBy(item => item.Price).ToList();
            Console.WriteLine("Items sorted by price:");
            foreach (var item in sortedItems)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Price: {item.Price}");
            }
        }
        public static void SortByQuantity(Dictionary<string, Item> items)
        {
            var sortedItems = items.Values.OrderBy(item => item.Quantity).ToList();
            Console.WriteLine("Items sorted by quantity:");
            foreach (var item in sortedItems)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Price: {item.Price}");
            }
        }
    }
}