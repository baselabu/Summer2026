using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using TaskApi.DTOs;

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
        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound($"Task with Id {id} not found.");
            }
            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateTask(TaskItemDto taskDto)
        {
            var task = new TaskItem {
                Id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 0,
                Title = taskDto.Title
            };
            _tasks.Add(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
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
        public IActionResult UpdateTask(int id, TaskItemDto taskDto)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == id);
            if (existingTask == null)
            {
                return NotFound($"Task with Id {id} not found.");
            }

            existingTask.Title = taskDto.Title;
            return Ok(existingTask);
        }
    }
}