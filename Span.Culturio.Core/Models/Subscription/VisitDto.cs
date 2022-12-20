using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Span.Culturio.Core.Models.Subscription {
    public class VisitDto {
        public int SubscriptionId { get; set; }
        public int CultureObjectId { get; set; }
        public int AvailableVisits { get; set; }
    }
}
