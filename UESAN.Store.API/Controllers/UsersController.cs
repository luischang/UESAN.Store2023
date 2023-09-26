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

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] UsersLoginDTO usersLoginDTO)
        {
            var result = await _usersService.SignIn(usersLoginDTO);
            if(result==null)
                return NotFound();

            return Ok(result);
        }
    }
}
