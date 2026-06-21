using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Models;
using TaskApi.DTOs;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public TasksController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _dbContext.TaskItems.AsNoTracking().ToListAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _dbContext.TaskItems.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                return NotFound($"Task with Id {id} not found.");
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskItemDto taskDto)
        {
            var task = new TaskItem
            {
                Title = taskDto.Title,
                Name = taskDto.Name
            };

            _dbContext.TaskItems.Add(task);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _dbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                return NotFound($"Task with Id {id} not found.");
            }

            _dbContext.TaskItems.Remove(task);
            await _dbContext.SaveChangesAsync();

            return Ok($"Task with Id {id} deleted successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskItemDto taskDto)
        {
            var existingTask = await _dbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
            if (existingTask == null)
            {
                return NotFound($"Task with Id {id} not found.");
            }

            existingTask.Title = taskDto.Title;
            existingTask.Name = taskDto.Name;
            await _dbContext.SaveChangesAsync();

            return Ok(existingTask);
        }
    }
}