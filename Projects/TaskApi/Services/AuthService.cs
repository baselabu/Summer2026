using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.DTOs;
using TaskApi.interfaces;
using TaskApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using TaskApi.Exceptions;


namespace TaskApi.Services
{
    public class AuthService : IAuthService
    {
       private readonly IUserRepository _userRepository;
       private readonly ILogger<AuthService> _logger;
       public AuthService(IUserRepository userRepository, ILogger<AuthService> logger)
       {
            _userRepository = userRepository;
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

        await _userRepository.CreateUserAsync(dto);
    }
}
}