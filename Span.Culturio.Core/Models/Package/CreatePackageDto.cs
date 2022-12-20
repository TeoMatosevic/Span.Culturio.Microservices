using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Span.Culturio.Core.Models.Package {
    public class CreatePackageDto {
        public string Name { get; set; }
        public IEnumerable<CreatePackageItemDto> CultureObjects { get; set; }
        public int ValidDays { get; set; }
    }
}
