using TaskApi.Models;

namespace TaskApi.interfaces
{
    public interface INotificationService
    {
        void NotifyTaskCreated(TaskItem task);
        void NotifyTaskUpdated(TaskItem task);
        void NotifyTaskDeleted(TaskItem task);
    }
}