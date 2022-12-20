using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Auth.Services;
using Span.Culturio.Core.Models.Auth;
using Span.Culturio.Core.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Span.Culturio.Auth.Controllers {
    [Tags("Auth")]
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IAuthService _authService;
        private readonly IValidator<CreateUserDto> _validator;
        public AuthController(IAuthService userService, IValidator<CreateUserDto> validator) {
            _authService = userService;
            _validator = validator;
        }
        /// <summary>
        /// Register new user
        /// </summary>
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> CreateUser([Required] CreateUserDto registerUserDto) {
            FluentValidation.Results.ValidationResult result = _validator.Validate(registerUserDto);
            if (!result.IsValid) return BadRequest("Validation error");

            var user = await _authService.CreateUser(registerUserDto);
            if (user is null) return BadRequest("Validation error");

            return Ok("Successful response");
        }
        /// <summary>
        /// Login
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login([Required] LoginDto loginUserDto) {
            var token = await _authService.Login(loginUserDto);
            if (token is null) return BadRequest("Bad username or password");

            return Ok(token);
        }
    }
}
