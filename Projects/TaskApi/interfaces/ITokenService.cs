using TaskApi.Models;

namespace TaskApi.interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        
    }
}