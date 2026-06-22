using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public TaskRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<TaskItem>> GetAllTasks()
        {
            return _dbContext.TaskItems.AsNoTracking().ToListAsync(); 
        }

        public Task<TaskItem> GetTaskById(int id)
        {
            var task = _dbContext.TaskItems.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
            return task!;
        }
        public async Task<TaskItem> CreateTask(CreatTaskItemDto task)
        {
            var newTask = new TaskItem
            {
                Title = task.Title,
                Name = task.Name
            };
            await _dbContext.TaskItems.AddAsync(newTask);
            await _dbContext.SaveChangesAsync();
            return newTask;
        }
        public async Task<bool> DeleteTask(int id)
        {
            var task = await _dbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null) return false;
            _dbContext.TaskItems.Remove(task);
            await _dbContext.SaveChangesAsync();
            return true;

        }
        public async Task<bool> UpdateTask(int id , UpdateTaskItemDto task)
        {
            var existingTask = await _dbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
            if (existingTask == null) return false;

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
                return false;
            }

            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}