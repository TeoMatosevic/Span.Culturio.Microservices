using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Span.Culturio.Core.Models.Users {
    public class UsersDto {
        public IEnumerable<UserDto> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
