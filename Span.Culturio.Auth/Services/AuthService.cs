using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Auth.Helpers;
using Span.Culturio.Core.Models.Auth;
using Span.Culturio.Core.Models.Users;
using Span.Culturio.Auth.Data;

namespace Span.Culturio.Auth.Services {
    public class AuthService : IAuthService{
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(DataContext context, IMapper mapper, IConfiguration configuration) {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<TokenDto> Login(LoginDto loginUserDto) {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == loginUserDto.Username);

            if (user is null) return null;

            if (!AuthHelpers.VerifyPasswordHash(loginUserDto.Password, user.PasswordHash, user.PasswordSalt)) return null;

            var token = AuthHelpers.CreateToken(loginUserDto, _configuration.GetSection("Jwt:Key").Value);

            return new TokenDto { Token = token };
        }

        public async Task<UserDto> CreateUser(CreateUserDto createUserDto) {
            var user = _mapper.Map<Span.Culturio.Auth.Data.Entities.User>(createUserDto);

            if (user is null) return null;

            AuthHelpers.CreatePasswordHash(createUserDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Add(user);
            await _context.SaveChangesAsync();

            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
