using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Core.Models.Auth;
using Span.Culturio.Core.Models.Users;
using Span_Culturio.Users.Services;
using System.ComponentModel.DataAnnotations;

namespace Span_Culturio.Users.Controllers {
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) {
            _userService = userService;
        }
        /// <summary>
        /// Get users
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<UsersDto>> GetUsersAsync([FromQuery][Required] int pageSize, [FromQuery][Required] int pageIndex) {
            var users = await _userService.GetUsersAsync(pageSize, pageIndex);
            return Ok(users);
        }
        /// <summary>
        /// Get single user by Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserByIdAsync([Required] int id) {
            var user = await _userService.GetUserAsync(id);
            if (user is null) return NotFound();
            return Ok(user);
        }
    }
}
