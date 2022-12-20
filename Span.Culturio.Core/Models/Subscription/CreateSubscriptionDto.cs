using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Span.Culturio.Core.Models.Subscription {
    public class CreateSubscriptionDto {
        public int UserId { get; set; }
        public int PackageId { get; set; }
        public string Name { get; set; }
    }
}
