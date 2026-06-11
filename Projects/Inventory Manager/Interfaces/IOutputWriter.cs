namespace Inventory_Manager.Interfaces
{
    public interface IOutputWriter
    {
        void WriteLine(string message);
        void WriteError(string message);
        void WriteSuccess(string message);
    }
}
