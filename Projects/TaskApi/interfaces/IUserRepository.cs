using TaskApi.Models;


namespace TaskApi.interfaces
{
    
    public interface IUserRepository
    {
        public Task<bool> UserExistsAsync(string username);
        public Task CreateUserAsync(User user);
        public Task<User?> GetUserByUsernameAsync(string username);
        
    }
}