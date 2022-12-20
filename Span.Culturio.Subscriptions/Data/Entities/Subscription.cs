using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Span.Culturio.Subscriptions.Data.Entities {
    public class Subscription {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PackageId { get; set; }
        public string Name { get; set; }
        public DateTime? ActiveFrom { get; set; }
        public DateTime? ActiveTO { get; set; }
        public string State { get; set; }
        public int RecordedVisits { get; set; }
    }

    public class SubscriptionsConfiguration : IEntityTypeConfiguration<Subscription> {
        public void Configure(EntityTypeBuilder<Subscription> builder) {
            builder.ToTable("Subscriptions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
