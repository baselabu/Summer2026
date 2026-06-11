using Inventory_Manager.Models;

namespace Inventory_Manager.Interfaces
{
    public interface IItemRepository
    {
        void AddItem(Item item);
        bool RemoveItem(string name);
        Item? GetItemByName(string name);
        Item? GetItemById(int id);
        List<Item> GetAllItems();
        List<Item> FindItemsByPartialName(string partialName);
        void ClearItems();
    }
}
