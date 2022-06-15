using Microsoft.EntityFrameworkCore;
using Rihal.DataAccess.SeedingData;
using Rihal.Domain.Entities;

namespace Rihal.DataAccess.DbContext
{
    public class RihalDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public RihalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Country> Countries { get; set; }

        public override  int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreationDate = DateTime.Now;
                }
            }

            return  base.SaveChanges();
        }
    }
}
