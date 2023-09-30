using UESAN.Store.CORE.DTOs;
using UESAN.Store.CORE.Entities;

namespace UESAN.Store.CORE.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> SignIn(UsersLoginDTO usersLoginDTO);
        Task<bool> SignUp(User user);
        Task<User> GetById(int id);
        Task<bool> ExistsEmail(string email);
    }
}