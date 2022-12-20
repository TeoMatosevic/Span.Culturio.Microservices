using Span.Culturio.Core.Models.Auth;
using Span.Culturio.Core.Models.Users;

namespace Span.Culturio.Auth.Services {
    public interface IAuthService{
        Task<UserDto> CreateUser(CreateUserDto createUserDto);
        Task<TokenDto> Login(LoginDto loginDto);
    }
}
