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
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                await _authService.RegisterAsync(dto);
                _logger.LogInformation("User with Username={Username} registered successfully.", dto.Username);
                return Ok("User registered successfully.");
            }
            catch (UserAlreadyExistsException ex)
            {
                return Conflict(new { error = ex.Message });
            }

        
    }
    }
}