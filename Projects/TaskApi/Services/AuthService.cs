using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.DTOs;
using TaskApi.interfaces;
using TaskApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using TaskApi.Exceptions;
using Microsoft.AspNetCore.Identity;


namespace TaskApi.Services
{
    public class AuthService : IAuthService
    {
       private readonly IUserRepository _userRepository;
       private readonly ITokenService _tokenService;
       private readonly PasswordHasher<User> _passwordHasher;
       private readonly ILogger<AuthService> _logger;
       public AuthService(IUserRepository userRepository, ITokenService tokenService, PasswordHasher<User> passwordHasher, ILogger<AuthService> logger)
       {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
            _logger = logger;
       }
    
    public async Task RegisterAsync(RegisterDto dto)
    {
        _logger.LogInformation($"Attempting to register user with Username={dto.Username}.");
        if (await _userRepository.UserExistsAsync(dto.Username))
        {
            _logger.LogWarning("User registration failed: User already exists.");
            throw new UserAlreadyExistsException(dto.Username);
        }
        User user = new User
        {
            Username = dto.Username
        };
        user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

        await _userRepository.CreateUserAsync(user);
    }
    public async Task<string?> LoginAsync(LoginDto dto)
    {
        _logger.LogInformation($"Attempting to log in user with Username={dto.Username}.");
        var user = await _userRepository.GetUserByUsernameAsync(dto.Username);
        if (user == null)
        {
            _logger.LogWarning("Login failed: User not found.");
            return null;
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            _logger.LogWarning("Login failed: Invalid password.");
            return null;
        }

        var token = _tokenService.GenerateToken(user);
        _logger.LogInformation($"User with Username={user.Username} logged in successfully.");
        return token;
    }
}
}