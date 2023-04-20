using GradingSystems.Models;

namespace GradingSystems.Services
{
    public interface IUserService
    {
        Task AddUser(User user);
        Task DeleteUser(User user);
        Task UpdateUser(User user);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
    }
}
