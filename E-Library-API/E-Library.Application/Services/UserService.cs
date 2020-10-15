using E_Library.DAL;
using E_Library.DAL.Enitities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Library.Application.Services
{
    public class UserService : IUserService
    {
        private readonly LibraryDB _dbContext;

        public UserService(LibraryDB dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<User> GetTestUserAsync()
        {
            return _dbContext.Users.FirstOrDefaultAsync(u => u.Id == 1);
        }
    }
}
