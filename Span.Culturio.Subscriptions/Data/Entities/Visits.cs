﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Span.Culturio.Subscriptions.Data.Entities {
    public class Visits {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public int CultureObjectId { get; set; }
        public int AvailableVisits { get; set; }

    }

    public class VisitsConfiguration : IEntityTypeConfiguration<Visits> {
        public void Configure(EntityTypeBuilder<Visits> builder) {
            builder.ToTable("Visits");
            builder.HasKey(x => x.Id);
        }
    }
}
