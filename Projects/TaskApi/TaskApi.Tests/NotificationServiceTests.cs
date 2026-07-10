using Microsoft.Extensions.Logging;
using Moq;
using TaskApi.Models;
using TaskApi.Services;

namespace TaskApi.Tests;

public class NotificationServiceTests
{
    [Fact]
    public void NotifyTaskCreated_LogsInformation()
    {
        var loggerMock = new Mock<ILogger<NotificationService>>();
        var service = new NotificationService(loggerMock.Object);
        var task = new TaskItem { Id = 1, Title = "Title", Name = "Name" };

        service.NotifyTaskCreated(task);

        VerifyInformationLog(loggerMock, "Task created", "Title", "Name");
    }

    [Fact]
    public void NotifyTaskUpdated_LogsInformation()
    {
        var loggerMock = new Mock<ILogger<NotificationService>>();
        var service = new NotificationService(loggerMock.Object);
        var task = new TaskItem { Id = 2, Title = "Updated", Name = "Item" };

        service.NotifyTaskUpdated(task);

        VerifyInformationLog(loggerMock, "Task updated", "Updated", "Item");
    }

    [Fact]
    public void NotifyTaskDeleted_LogsInformation()
    {
        var loggerMock = new Mock<ILogger<NotificationService>>();
        var service = new NotificationService(loggerMock.Object);
        var task = new TaskItem { Id = 3, Title = "Deleted", Name = "Item" };

        service.NotifyTaskDeleted(task);

        VerifyInformationLog(loggerMock, "Task deleted", "Deleted", "Item");
    }

    private static void VerifyInformationLog(
        Mock<ILogger<NotificationService>> loggerMock,
        string prefix,
        string title,
        string name)
    {
        loggerMock.Verify(
            logger => logger.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((state, _) =>
                    state.ToString()!.Contains(prefix) &&
                    state.ToString()!.Contains(title) &&
                    state.ToString()!.Contains(name)),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}