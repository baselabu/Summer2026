using Microsoft.EntityFrameworkCore;
using TaskApi.interfaces;
using TaskApi.Models;
using TaskApi.Data;
using TaskApi.DTOs;

namespace TaskApi.Services
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly INotificationService _notificationService;
        private readonly ILogger<TaskRepository> _logger;

        public TaskRepository(AppDbContext dbContext, INotificationService notificationService, ILogger<TaskRepository> logger)
        {
            _dbContext = dbContext;
            _notificationService = notificationService;
            _logger = logger;
        }
        public Task<List<TaskItem>> GetAllTasks()
        {
            _logger.LogInformation("Retrieving all tasks.");
            return _dbContext.TaskItems.AsNoTracking().ToListAsync(); 
        }

        public Task<TaskItem> GetTaskById(int id)
        {
            _logger.LogInformation("Retrieving task by Id={TaskId}.", id);
            var task = _dbContext.TaskItems.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
            return task!;
        }
        public async Task<TaskItem> CreateTask(CreatTaskItemDto task)
        {
            _logger.LogInformation("Creating task with Title={TaskTitle}, Name={TaskName}.", task.Title, task.Name);
            var newTask = new TaskItem
            {
                Title = task.Title,
                Name = task.Name
            };
            await _dbContext.TaskItems.AddAsync(newTask);
            await _dbContext.SaveChangesAsync();
            _notificationService.NotifyTaskCreated(newTask);
            return newTask;
        }
        public async Task<bool> DeleteTask(int id)
        {
            _logger.LogInformation("Deleting task with Id={TaskId}.", id);
            var task = await _dbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                _logger.LogWarning("Task with Id={TaskId} was not found for deletion.", id);
                return false;
            }

            _dbContext.TaskItems.Remove(task);
            await _dbContext.SaveChangesAsync();
            _notificationService.NotifyTaskDeleted(task);
            return true;

        }
        public async Task<bool> UpdateTask(int id , UpdateTaskItemDto task)
        {
            _logger.LogInformation("Updating task with Id={TaskId}.", id);
            var existingTask = await _dbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
            if (existingTask == null)
            {
                _logger.LogWarning("Task with Id={TaskId} was not found for update.", id);
                return false;
            }

            bool hasUpdates = false;

            if (!string.IsNullOrEmpty(task.Title))
            {
                existingTask.Title = task.Title;
                hasUpdates = true;
            }
            if (!string.IsNullOrEmpty(task.Name))
            {
                existingTask.Name = task.Name;
                hasUpdates = true;
            }

            if (!hasUpdates)
            {
                _logger.LogWarning("Task with Id={TaskId} had no valid fields to update.", id);
                return false;
            }

            await _dbContext.SaveChangesAsync();
            _notificationService.NotifyTaskUpdated(existingTask);
            return true;
        }

    }
}