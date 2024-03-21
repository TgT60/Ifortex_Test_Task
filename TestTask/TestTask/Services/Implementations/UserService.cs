using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<User> GetUser()
        {
            return Task.FromResult(_dbContext.Users
                .OrderByDescending(u => u.Orders.Count)
                .FirstOrDefault());
        }

        public Task<List<User>> GetUsers()
        {
            return _dbContext.Users.Where(user => user.Status == UserStatus.Inactive).ToListAsync();
        }
    }
}
