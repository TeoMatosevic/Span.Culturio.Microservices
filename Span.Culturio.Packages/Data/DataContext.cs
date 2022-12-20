using Microsoft.EntityFrameworkCore;
using Span.Culturio.Packages.Data.Entites;

namespace Span.Culturio.Packages.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }

        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageItem> PackageItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
