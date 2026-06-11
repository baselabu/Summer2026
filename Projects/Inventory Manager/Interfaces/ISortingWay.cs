using Inventory_Manager.Models;

namespace Inventory_Manager.Interfaces
{
    public interface ISortingWay
    {
        List<Item> Sort(List<Item> items);
        string GetDescription();
    }
}
