using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using Inventory_Manager.Models;
using Inventory_Manager.Interfaces;

namespace Inventory_Manager.Services
{
    public class JsonPersistenceService : IPersistenceService
    {
        private readonly IOutputWriter _output;

        public JsonPersistenceService(IOutputWriter output)
        {
            _output = output;
        }

        public void SaveItems(List<Item> items, string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true
                };

                var json = JsonSerializer.Serialize(items, options);
                File.WriteAllText(filePath, json);
                _output.WriteSuccess($"Inventory saved to '{filePath}'.");
            }
            catch (Exception ex)
            {
                _output.WriteError($"Error saving inventory: {ex.Message}");
            }
        }

        public List<Item> LoadItems(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    _output.WriteError($"File '{filePath}' not found.");
                    return new List<Item>();
                }

                var json = File.ReadAllText(filePath);
                var items = JsonSerializer.Deserialize<List<Item>>(json);

                if (items != null)
                {
                    _output.WriteSuccess($"Loaded {items.Count} items from '{filePath}'.");
                    return items;
                }
                else
                {
                    _output.WriteError($"Failed to deserialize items from '{filePath}'.");
                    return new List<Item>();
                }
            }
            catch (Exception ex)
            {
                _output.WriteError($"Error loading inventory: {ex.Message}");
                return new List<Item>();
            }
        }
    }
}
