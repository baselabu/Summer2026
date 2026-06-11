using Inventory_Manager.Models;

namespace Inventory_Manager.Interfaces
{
    public interface IPersistenceService
    {
        void SaveItems(List<Item> items, string filePath);
        List<Item> LoadItems(string filePath);
    }
}
