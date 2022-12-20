using Span.Culturio.Core.Models.Auth;
using Span.Culturio.Core.Models.Users;

namespace Span_Culturio.Users.Services {
    public interface IUserService {
        Task<UserDto> GetUserAsync(int id);
        Task<UsersDto> GetUsersAsync(int pageSize, int pageIndex);
    }
}
