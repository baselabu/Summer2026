using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.DTOs;

namespace TaskApi.interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
        
    }
}