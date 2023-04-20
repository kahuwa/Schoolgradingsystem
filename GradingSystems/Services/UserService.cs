using GradingSystems.Models;
using Microsoft.EntityFrameworkCore;

namespace GradingSystems.Services
{
    public class UserService : IUserService
    {
        private readonly SchoolgradingsystemContext schoolgradingsystemContext;

        public UserService(SchoolgradingsystemContext schoolgradingsystemContext)
        {
            this.schoolgradingsystemContext = schoolgradingsystemContext;
        }
        public async Task AddUser(User user)
        {
            this.schoolgradingsystemContext.Add(user);
            await this.schoolgradingsystemContext.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
            this.schoolgradingsystemContext.Remove(user);
            await this.schoolgradingsystemContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await this.schoolgradingsystemContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await this.schoolgradingsystemContext.Users.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateUser(User user)
        {
            this.schoolgradingsystemContext.Update(user);
            await this.schoolgradingsystemContext.SaveChangesAsync();
        }
    }
}
