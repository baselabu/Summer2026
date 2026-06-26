using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Services;     
using TaskApi.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers(); // Registers controller support.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tasks.db"));

builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
        var exception = exceptionHandlerFeature?.Error;

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        var logger = context.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger("GlobalExceptionHandler");
        logger.LogError(exception, "Unhandled exception while processing {Method} {Path}", context.Request.Method, context.Request.Path);

        await context.Response.WriteAsync("{\"error\":\"An unexpected error occurred.\"}");
    });
});

app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        context.Response.Headers["X-App-Version"] = "1.0";
        return Task.CompletedTask;
    });

    await next();

    app.Logger.LogInformation(
        "{Method} {Path} responded with {StatusCode}",
        context.Request.Method,
        context.Request.Path,
        context.Response.StatusCode);
});

app.UseHttpsRedirection();

app.MapControllers(); //Look for controller classes and expose their routes.

app.Run();
