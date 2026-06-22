using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Models;
using TaskApi.DTOs;
using TaskApi.interfaces;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskRepository.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _taskRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound($"Task with Id {id} not found.");
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreatTaskItemDto taskDto)
        {
            var task = await _taskRepository.CreateTask(taskDto);

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _taskRepository.DeleteTask(id);
            if (!task)
            {
                return NotFound($"Task with Id {id} not found.");
            }

            return Ok($"Task with Id {id} deleted successfully.");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskItemDto taskDto)                   
        {
            var updated = await _taskRepository.UpdateTask(id, taskDto);
            if (!updated)
            {
                return NotFound($"Task with Id {id} not found, or no valid fields provided for update.");
            }

            return Ok($"Task with Id {id} updated successfully.");
        }
    }
}