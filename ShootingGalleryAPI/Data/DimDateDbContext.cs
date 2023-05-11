using Microsoft.EntityFrameworkCore;
using ShootingGalleryAPI.Models;

namespace ShootingGalleryAPI.Data
{
    public class DimDateDbContext : DbContext
    {
        public DimDateDbContext(DbContextOptions<DimDateDbContext> options) : base(options)
        {
        }

        public DbSet<DimDate> DimDate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DimDate>(entity =>
            {
                entity.HasKey(e => e.DateKey);
                entity.Property(e => e.Day).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Month).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Year).IsRequired().HasMaxLength(50);
            });
        }
    }
}