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




    }
}
