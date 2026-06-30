using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.interfaces;
using TaskApi.Models;
using TaskApi.Data;
using Microsoft.EntityFrameworkCore;
using TaskApi.DTOs;
using Microsoft.AspNetCore.Identity;


namespace TaskApi.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;
        public UserRepository(AppDbContext context, PasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        public async Task CreateUserAsync(RegisterDto dto)
        {
            var user = new User
            {
                Username = dto.Username
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password); // Store the hashed password

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }  
    }
}