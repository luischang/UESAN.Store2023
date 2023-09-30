using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Store.CORE.DTOs;
using UESAN.Store.CORE.Entities;
using UESAN.Store.CORE.Interfaces;

namespace UESAN.Store.CORE.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJWTService _jwtService;

        public UsersService(IUsersRepository usersRepository, IJWTService jwtService)
        {
            _usersRepository = usersRepository;
            _jwtService = jwtService;
        }

        public async Task<UsersAuthenticationDTO> SignIn(UsersLoginDTO usersLoginDTO)
        {
            var user = await _usersRepository.SignIn(usersLoginDTO);

            if (user == null)
                return null;

            var token = _jwtService.GenerateJWToken(user);

            var userDTO = new UsersAuthenticationDTO();
            userDTO.Id = user.Id;
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.Email = user.Email;
            userDTO.Address = user.Address;
            userDTO.Country = user.Country;
            userDTO.DateOfBirth = user.DateOfBirth;
            userDTO.Type = user.Type;
            userDTO.Token = token;

            return userDTO;

        }

        public async Task<bool> SignUp(UsersRegisterDTO usersRegisterDTO)
        {
            var exists = await _usersRepository.ExistsEmail(usersRegisterDTO.Email);
            if (exists) return false;

            var user = new User()
            {
                FirstName = usersRegisterDTO.FirstName,
                LastName = usersRegisterDTO.LastName,
                Email = usersRegisterDTO.Email,
                Address = usersRegisterDTO.Address,
                Country = usersRegisterDTO.Country,
                Password = usersRegisterDTO.Password,
                DateOfBirth = usersRegisterDTO.DateOfBirth,
                IsActive = true,
                Type = "U"
            };


            var result = await _usersRepository.SignUp(user);
            return result;
        }
    }
}
