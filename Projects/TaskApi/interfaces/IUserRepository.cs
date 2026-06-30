using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.DTOs;


namespace TaskApi.interfaces
{
    
    public interface IUserRepository
    {
        public Task<bool> UserExistsAsync(string username);
        public Task CreateUserAsync(RegisterDto dto);
        
    }
}