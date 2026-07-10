using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;

namespace TaskApi.Tests.TestSupport;

public abstract class SqliteTestBase : IDisposable
{
    private readonly SqliteConnection _connection;

    protected AppDbContext Context { get; }

    protected SqliteTestBase()
    {
        _connection = new SqliteConnection("Data Source=:memory:");
        _connection.Open();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(_connection)
            .Options;

        Context = new AppDbContext(options);
        Context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        Context.Dispose();
        _connection.Dispose();
    }
}