using AutoMapper;
using Span.Culturio.Core.Models.Auth;
using Span.Culturio.Core.Models.Users;
using Span.Culturio.Users.Data.Entities;

namespace Span_Culturio.Users.Profiles {
    public class UserProfile : Profile {
        public UserProfile() {
            CreateMap<User, UserDto>();
        }
    }
}
