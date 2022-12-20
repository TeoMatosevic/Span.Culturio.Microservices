using Microsoft.EntityFrameworkCore;
using Span.Culturio.Subscriptions.Data.Entities;

namespace Span.Culturio.Subscriptions.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Visits> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
