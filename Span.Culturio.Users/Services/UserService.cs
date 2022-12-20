using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Core.Models.Auth;
using Span.Culturio.Core.Models.Users;
using Span.Culturio.Users.Data;

namespace Span_Culturio.Users.Services {
    public class UserService : IUserService {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(DataContext context, IMapper mapper, IConfiguration configuration) {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<UserDto> GetUserAsync(int id) {
            var user = await _context.Users.FindAsync(id);
            if (user == null) {
                return null;
            }
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<UsersDto> GetUsersAsync(int pageSize, int pageIndex) {
            var users = await _context.Users.Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();

            var usersDtos = _mapper.Map<IEnumerable<UserDto>>(users);

            return new UsersDto {
                Data = usersDtos,
                TotalCount = usersDtos.Count()
            };
        }
    }
}
