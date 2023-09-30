using Microsoft.EntityFrameworkCore;
using UESAN.Store.CORE.DTOs;
using UESAN.Store.CORE.Entities;
using UESAN.Store.CORE.Interfaces;
using UESAN.Store.INFRASTRUCTURE.Data;

namespace UESAN.Store.INFRASTRUCTURE.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly StoreDbContext _dbContext;

        public UsersRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> SignIn(UsersLoginDTO usersLoginDTO)
        {
            var result = await _dbContext
                .User
                .Where(z => z.Email == usersLoginDTO.Email
                        && z.Password == usersLoginDTO.Password)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> SignUp(User user)
        {
            await _dbContext.User.AddAsync(user);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.User.FindAsync(id);
        }

        public async Task<bool> ExistsEmail(string email)
        {
            return await _dbContext.User.Where(x => x.Email == email).AnyAsync();
        }


    }
}
