using UESAN.Store.CORE.DTOs;

namespace UESAN.Store.CORE.Interfaces
{
    public interface IUsersService
    {
        Task<UsersAuthenticationDTO> SignIn(UsersLoginDTO usersLoginDTO);
        Task<bool> SignUp(UsersRegisterDTO usersRegisterDTO);
    }
}