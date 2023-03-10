using Microsoft.EntityFrameworkCore;
using Span.Culturio.CultureObjects.Data.Entities;

namespace Span.Culturio.CultureObjects.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }

        public DbSet<CultureObject> CultureObjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
