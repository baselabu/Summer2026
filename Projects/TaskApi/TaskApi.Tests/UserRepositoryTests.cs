using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using TaskApi.Models;
using TaskApi.Services;
using TaskApi.Tests.TestSupport;

namespace TaskApi.Tests;

public class UserRepositoryTests : SqliteTestBase
{
    private readonly UserRepository _repository;

    public UserRepositoryTests()
    {
        _repository = new UserRepository(Context);
    }

    [Fact]
    public async Task UserExistsAsync_ReturnsTrueWhenUserExists()
    {
        Context.Users.Add(new User { Username = "alice", PasswordHash = "hash" });
        await Context.SaveChangesAsync();

        var exists = await _repository.UserExistsAsync("alice");

        Assert.True(exists);
    }

    [Fact]
    public async Task UserExistsAsync_ReturnsFalseWhenUserMissing()
    {
        var exists = await _repository.UserExistsAsync("missing");

        Assert.False(exists);
    }

    [Fact]
    public async Task CreateUserAsync_SavesUser()
    {
        var user = new User { Username = "alice", PasswordHash = "hash" };

        await _repository.CreateUserAsync(user);

        Assert.Equal(1, await Context.Users.CountAsync());
        var savedUser = await Context.Users.FirstAsync();
        Assert.Equal(user.Username, savedUser.Username);
        Assert.Equal(user.PasswordHash, savedUser.PasswordHash);
    }

    [Fact]
    public async Task GetUserByUsernameAsync_ReturnsUser()
    {
        Context.Users.Add(new User { Username = "alice", PasswordHash = "hash" });
        await Context.SaveChangesAsync();

        var user = await _repository.GetUserByUsernameAsync("alice");

        Assert.NotNull(user);
        Assert.Equal("alice", user!.Username);
    }

    [Fact]
    public async Task GetUserByUsernameAsync_ReturnsNullWhenMissing()
    {
        var user = await _repository.GetUserByUsernameAsync("missing");

        Assert.Null(user);
    }
}