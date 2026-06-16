using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("/tasks")]
    public class TasksController : ControllerBase
    {
        private static List<TaskItem> _tasks = new List<TaskItem>
        {
            new TaskItem { Id = 0, Title = "Task 1" },
            new TaskItem { Id = 1, Title = "Task 2" },
            new TaskItem { Id = 2, Title = "Task 3" }
        };

        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok(_tasks);
        }

        [HttpPost]
        public IActionResult CreateTask(TaskItem task)
        {
            if (task.Id < 0)
            {
                return BadRequest("Task Id must be a non-negative integer.");
            }

            if (task == null || string.IsNullOrWhiteSpace(task.Title))
            {
                return BadRequest("Task title is required.");
            }
            
            // check for existing id
            if (_tasks.Any(t => t.Id == task.Id))
            {
                return BadRequest($"Task with Id {task.Id} already exists.");
            }
            _tasks.Add(task);
            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }
   
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound($"Task with Id {id} not found.");
            }
            _tasks.Remove(task);
            return Ok($"Task with Id {id} deleted successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskItem task)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == id);
            if (existingTask == null)
            {
                return NotFound($"Task with Id {id} not found.");
            }
            if (task == null || string.IsNullOrWhiteSpace(task.Title))
            {
                return BadRequest("Task title is required.");
            }
            existingTask.Title = task.Title;
            return Ok(existingTask);
        }
    }
}