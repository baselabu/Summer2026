using Inventory_Manager.Models;

namespace Inventory_Manager.Interfaces
{
    public interface IHistoryService
    {
        void AddToHistory(Transaction transaction);
        void ClearHistory();
        void DisplayHistory();
    }
}
