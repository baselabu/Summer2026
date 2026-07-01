using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskApi.DTOs;
using TaskApi.Data;
using TaskApi.Models;
using TaskApi.interfaces;
using TaskApi.Exceptions;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<UserController> _logger;
        public UserController(IAuthService authService, ILogger<UserController> logger)
        {
            _authService = authService;
            _logger = logger;
        }   

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto UserRegisterDto)
        {
            _logger.LogInformation("Received registration request for Username={Username}.", UserRegisterDto.Username);
            try
            {
                await _authService.RegisterAsync(UserRegisterDto);
                _logger.LogInformation("User with Username={Username} registered successfully.", UserRegisterDto.Username);
                return Ok("User registered successfully.");
            }
            catch (UserAlreadyExistsException ex)
            {
                _logger.LogWarning("User registration failed: {ErrorMessage}", ex.Message);
                return Conflict(new { error = ex.Message });
            }
        }  
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            _logger.LogInformation("Received login request for Username={Username}.", loginDto.Username);
            var token = await _authService.LoginAsync(loginDto);
            if (token == null)
            {
                _logger.LogWarning("Login failed: Invalid credentials.");
                return Unauthorized(new { error = "Invalid credentials." });
            }
            _logger.LogInformation("User with Username={Username} logged in successfully.", loginDto.Username);
            return Ok(new { token });
        }
    }
}