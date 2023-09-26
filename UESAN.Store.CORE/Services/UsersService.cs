using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Store.CORE.DTOs;
using UESAN.Store.CORE.Interfaces;

namespace UESAN.Store.CORE.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<UsersAuthenticationDTO> SignIn(UsersLoginDTO usersLoginDTO)
        {
            var user = await _usersRepository.SignIn(usersLoginDTO);

            var userDTO = new UsersAuthenticationDTO();
            userDTO.Id = user.Id;
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.Email = user.Email;
            userDTO.Address = user.Address;
            userDTO.Country = user.Country;
            userDTO.DateOfBirth = user.DateOfBirth;
            userDTO.Type = user.Type;

            return userDTO;

        }
    }
}
