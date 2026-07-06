using TaskApi.interfaces;
using TaskApi.Models;

namespace TaskApi.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(ILogger<NotificationService> logger)
        {
            _logger = logger;
        }

        public void NotifyTaskCreated(TaskItem task)
        {
            _logger.LogInformation("Task created: Id={TaskId}, Title={TaskTitle}, Name={TaskName}", task.Id, task.Title, task.Name);
        }

        public void NotifyTaskUpdated(TaskItem task)
        {
            _logger.LogInformation("Task updated: Id={TaskId}, Title={TaskTitle}, Name={TaskName}", task.Id, task.Title, task.Name);
        }

        public void NotifyTaskDeleted(TaskItem task)
        {
            _logger.LogInformation("Task deleted: Id={TaskId}, Title={TaskTitle}, Name={TaskName}", task.Id, task.Title, task.Name);
        }
    }
}