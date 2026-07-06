using TaskApi.DTOs;

namespace TaskApi.interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
        
    }
}