using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Store.CORE.DTOs;
using UESAN.Store.CORE.Interfaces;

namespace UESAN.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UsersLoginDTO usersLoginDTO)
        {
            var result = await _usersService.SignIn(usersLoginDTO);
            if(result==null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UsersRegisterDTO usersRegisterDTO)
        {
            var result = await _usersService.SignUp(usersRegisterDTO);
            if(!result)
                return BadRequest();
            return Ok(result);

        }
    }
}
