using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Models;
using TaskApi.DTOs;

namespace TaskApi.interfaces
{
    public interface ITaskRepository
    {
        public Task<List<TaskItem>> GetAllTasks();
        public Task<TaskItem> GetTaskById(int id);
        public Task<TaskItem> CreateTask(CreatTaskItemDto task);
        public Task<bool> DeleteTask(int id);
        public Task<bool> UpdateTask(int id , UpdateTaskItemDto task);
    }
}