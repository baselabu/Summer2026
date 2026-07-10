using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using TaskApi.DTOs;
using TaskApi.Exceptions;
using TaskApi.Models;
using TaskApi.Services;
using TaskApi.interfaces;

namespace TaskApi.Tests;

public class AuthServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new();
    private readonly Mock<ITokenService> _tokenServiceMock = new();
    private readonly PasswordHasher<User> _passwordHasher = new();

    [Fact]
    public async Task RegisterAsync_CreatesUserWithHashedPassword()
    {
        var dto = new RegisterDto
        {
            Username = "alice",
            Password = "P@ssw0rd!"
        };

        _userRepositoryMock.Setup(x => x.UserExistsAsync(dto.Username)).ReturnsAsync(false);

        User? createdUser = null;
        _userRepositoryMock
            .Setup(x => x.CreateUserAsync(It.IsAny<User>()))
            .Callback<User>(user => createdUser = user)
            .Returns(Task.CompletedTask);

        var service = new AuthService(
            _userRepositoryMock.Object,
            _tokenServiceMock.Object,
            _passwordHasher,
            NullLogger<AuthService>.Instance);

        await service.RegisterAsync(dto);

        Assert.NotNull(createdUser);
        Assert.Equal(dto.Username, createdUser!.Username);
        Assert.False(string.IsNullOrWhiteSpace(createdUser.PasswordHash));
        Assert.NotEqual(dto.Password, createdUser.PasswordHash);
        _userRepositoryMock.Verify(x => x.CreateUserAsync(It.IsAny<User>()), Times.Once);
        _tokenServiceMock.Verify(x => x.GenerateToken(It.IsAny<User>()), Times.Never);
    }

    [Fact]
    public async Task RegisterAsync_WhenUserExists_Throws()
    {
        var dto = new RegisterDto
        {
            Username = "alice",
            Password = "P@ssw0rd!"
        };

        _userRepositoryMock.Setup(x => x.UserExistsAsync(dto.Username)).ReturnsAsync(true);

        var service = new AuthService(
            _userRepositoryMock.Object,
            _tokenServiceMock.Object,
            _passwordHasher,
            NullLogger<AuthService>.Instance);

        var exception = await Assert.ThrowsAsync<UserAlreadyExistsException>(() => service.RegisterAsync(dto));

        Assert.Contains(dto.Username, exception.Message);
        _userRepositoryMock.Verify(x => x.CreateUserAsync(It.IsAny<User>()), Times.Never);
    }

    [Fact]
    public async Task LoginAsync_WhenUserMissing_ReturnsNull()
    {
        var dto = new LoginDto
        {
            Username = "missing",
            Password = "secret"
        };

        _userRepositoryMock.Setup(x => x.GetUserByUsernameAsync(dto.Username)).ReturnsAsync((User?)null);

        var service = new AuthService(
            _userRepositoryMock.Object,
            _tokenServiceMock.Object,
            _passwordHasher,
            NullLogger<AuthService>.Instance);

        var token = await service.LoginAsync(dto);

        Assert.Null(token);
        _tokenServiceMock.Verify(x => x.GenerateToken(It.IsAny<User>()), Times.Never);
    }

    [Fact]
    public async Task LoginAsync_WhenPasswordInvalid_ReturnsNull()
    {
        var user = new User { Id = 1, Username = "alice" };
        user.PasswordHash = _passwordHasher.HashPassword(user, "correct-password");

        _userRepositoryMock.Setup(x => x.GetUserByUsernameAsync(user.Username)).ReturnsAsync(user);

        var service = new AuthService(
            _userRepositoryMock.Object,
            _tokenServiceMock.Object,
            _passwordHasher,
            NullLogger<AuthService>.Instance);

        var token = await service.LoginAsync(new LoginDto
        {
            Username = user.Username,
            Password = "wrong-password"
        });

        Assert.Null(token);
        _tokenServiceMock.Verify(x => x.GenerateToken(It.IsAny<User>()), Times.Never);
    }

    [Fact]
    public async Task LoginAsync_WhenCredentialsValid_ReturnsToken()
    {
        var user = new User { Id = 7, Username = "alice" };
        user.PasswordHash = _passwordHasher.HashPassword(user, "correct-password");

        _userRepositoryMock.Setup(x => x.GetUserByUsernameAsync(user.Username)).ReturnsAsync(user);
        _tokenServiceMock.Setup(x => x.GenerateToken(user)).Returns("jwt-token");

        var service = new AuthService(
            _userRepositoryMock.Object,
            _tokenServiceMock.Object,
            _passwordHasher,
            NullLogger<AuthService>.Instance);

        var token = await service.LoginAsync(new LoginDto
        {
            Username = user.Username,
            Password = "correct-password"
        });

        Assert.Equal("jwt-token", token);
        _tokenServiceMock.Verify(x => x.GenerateToken(user), Times.Once);
    }
}