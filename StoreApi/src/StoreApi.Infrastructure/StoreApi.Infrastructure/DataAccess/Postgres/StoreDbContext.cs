using Microsoft.EntityFrameworkCore;
using StoreApi.Domain.Entities;

namespace StoreApi.Infrastructure.DataAccess.Postgres
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}
