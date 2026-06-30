using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskApi.Data;
using TaskApi.Models;
using TaskApi.DTOs;
using TaskApi.interfaces;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("/tasks")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ITaskRepository taskRepository, ILogger<TasksController> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            _logger.LogInformation("HTTP GET /tasks requested.");
            var tasks = await _taskRepository.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            _logger.LogInformation("HTTP GET /tasks/{TaskId} requested.", id);
            var task = await _taskRepository.GetTaskById(id);
            if (task == null)
            {
                _logger.LogWarning("Task with Id={TaskId} was not found.", id);
                return NotFound($"Task with Id {id} is not found.");
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreatTaskItemDto taskDto)
        {
            _logger.LogInformation("HTTP POST /tasks requested.");
            var task = await _taskRepository.CreateTask(taskDto);

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            _logger.LogInformation("HTTP DELETE /tasks/{TaskId} requested.", id);
            var task = await _taskRepository.DeleteTask(id);
            if (!task)
            {
                _logger.LogWarning("Delete request for task Id={TaskId} could not be completed.", id);
                return NotFound($"Task with Id {id} not found.");
            }

            return Ok($"Task with Id {id} deleted successfully.");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskItemDto taskDto)
        {
            _logger.LogInformation("HTTP PATCH /tasks/{TaskId} requested.", id);
            var updated = await _taskRepository.UpdateTask(id, taskDto);
            if (!updated)
            {
                _logger.LogWarning("Update request for task Id={TaskId} could not be completed.", id);
                return NotFound($"Task with Id {id} not found, or no valid fields provided for update.");
            }

            return Ok($"Task with Id {id} updated successfully.");
        }
    }
}