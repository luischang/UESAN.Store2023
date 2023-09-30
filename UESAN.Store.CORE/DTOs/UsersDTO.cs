using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Store.CORE.DTOs
{
    public class UsersDTO
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Country { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public bool? IsActive { get; set; }

        public string? Type { get; set; }
    }

    public class UsersLoginDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class UsersAuthenticationDTO
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Country { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; } 

        public string? Type { get; set; }
        public string? Token { get; set; }
    }

    public class UsersRegisterDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

}
