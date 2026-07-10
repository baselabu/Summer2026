using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using TaskApi.DTOs;
using TaskApi.Exceptions;
using TaskApi.Models;
using TaskApi.Services;
using TaskApi.Tests.TestSupport;
using TaskApi.interfaces;

namespace TaskApi.Tests;

public class TaskRepositoryTests : SqliteTestBase
{
    private readonly Mock<INotificationService> _notificationServiceMock = new();
    private readonly TaskRepository _repository;

    public TaskRepositoryTests()
    {
        _repository = new TaskRepository(Context, _notificationServiceMock.Object, NullLogger<TaskRepository>.Instance);
    }

    [Fact]
    public async Task GetAllTasks_ReturnsAllTasks()
    {
        Context.TaskItems.AddRange(
            new TaskItem { Title = "First", Name = "One" },
            new TaskItem { Title = "Second", Name = "Two" });
        await Context.SaveChangesAsync();

        var tasks = await _repository.GetAllTasks();

        Assert.Equal(2, tasks.Count);
        Assert.Contains(tasks, task => task.Title == "First" && task.Name == "One");
        Assert.Contains(tasks, task => task.Title == "Second" && task.Name == "Two");
    }

    [Fact]
    public async Task GetTaskById_ReturnsMatchingTask()
    {
        var task = new TaskItem { Title = "First", Name = "One" };
        Context.TaskItems.Add(task);
        await Context.SaveChangesAsync();

        var found = await _repository.GetTaskById(task.Id);

        Assert.Equal(task.Id, found.Id);
        Assert.Equal(task.Title, found.Title);
        Assert.Equal(task.Name, found.Name);
    }

    [Fact]
    public async Task GetTaskById_WhenMissing_ThrowsNotFoundException()
    {
        var exception = await Assert.ThrowsAsync<NotFoundException>(() => _repository.GetTaskById(999));

        Assert.Equal("Task with Id 999 not found.", exception.Message);
    }

    [Fact]
    public async Task CreateTask_SavesTaskAndNotifies()
    {
        var dto = new CreatTaskItemDto
        {
            Title = "New Title",
            Name = "New Name"
        };

        var created = await _repository.CreateTask(dto);

        Assert.True(created.Id > 0);
        Assert.Equal(dto.Title, created.Title);
        Assert.Equal(dto.Name, created.Name);
        Assert.Equal(1, await Context.TaskItems.CountAsync());
        _notificationServiceMock.Verify(x => x.NotifyTaskCreated(It.Is<TaskItem>(task => task.Id == created.Id && task.Title == dto.Title && task.Name == dto.Name)), Times.Once);
    }

    [Fact]
    public async Task DeleteTask_RemovesTaskAndNotifies()
    {
        var task = new TaskItem { Title = "To delete", Name = "Delete Me" };
        Context.TaskItems.Add(task);
        await Context.SaveChangesAsync();

        var result = await _repository.DeleteTask(task.Id);

        Assert.True(result);
        Assert.Empty(Context.TaskItems);
        _notificationServiceMock.Verify(x => x.NotifyTaskDeleted(It.Is<TaskItem>(deleted => deleted.Id == task.Id)), Times.Once);
    }

    [Fact]
    public async Task DeleteTask_WhenMissing_ThrowsNotFoundException()
    {
        var exception = await Assert.ThrowsAsync<NotFoundException>(() => _repository.DeleteTask(123));

        Assert.Equal("Task with Id 123 not found.", exception.Message);
        _notificationServiceMock.Verify(x => x.NotifyTaskDeleted(It.IsAny<TaskItem>()), Times.Never);
    }

    [Fact]
    public async Task UpdateTask_UpdatesFieldsAndNotifies()
    {
        var task = new TaskItem { Title = "Old Title", Name = "Old Name" };
        Context.TaskItems.Add(task);
        await Context.SaveChangesAsync();

        var result = await _repository.UpdateTask(task.Id, new UpdateTaskItemDto
        {
            Title = "New Title",
            Name = "New Name"
        });

        Assert.True(result);
        var updated = await Context.TaskItems.FirstAsync(item => item.Id == task.Id);
        Assert.Equal("New Title", updated.Title);
        Assert.Equal("New Name", updated.Name);
        _notificationServiceMock.Verify(x => x.NotifyTaskUpdated(It.Is<TaskItem>(updatedTask => updatedTask.Id == task.Id && updatedTask.Title == "New Title" && updatedTask.Name == "New Name")), Times.Once);
    }

    [Fact]
    public async Task UpdateTask_WhenNoValidFields_ThrowsValidationException()
    {
        var task = new TaskItem { Title = "Old Title", Name = "Old Name" };
        Context.TaskItems.Add(task);
        await Context.SaveChangesAsync();

        var exception = await Assert.ThrowsAsync<ValidationException>(() => _repository.UpdateTask(task.Id, new UpdateTaskItemDto()));

        Assert.Equal("At least one valid field must be provided for update.", exception.Message);
        _notificationServiceMock.Verify(x => x.NotifyTaskUpdated(It.IsAny<TaskItem>()), Times.Never);
    }

    [Fact]
    public async Task UpdateTask_WhenMissing_ThrowsNotFoundException()
    {
        var exception = await Assert.ThrowsAsync<NotFoundException>(() => _repository.UpdateTask(123, new UpdateTaskItemDto { Title = "Anything" }));

        Assert.Equal("Task with Id 123 not found.", exception.Message);
        _notificationServiceMock.Verify(x => x.NotifyTaskUpdated(It.IsAny<TaskItem>()), Times.Never);
    }
}