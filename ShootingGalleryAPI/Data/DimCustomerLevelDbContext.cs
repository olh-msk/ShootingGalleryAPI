using Microsoft.EntityFrameworkCore;
using ShootingGalleryAPI.Models;

namespace ShootingGalleryAPI.Data
{
    public class DimCustomerLevelDbContext : DbContext
    {
        public DimCustomerLevelDbContext(DbContextOptions<DimCustomerLevelDbContext> options) : base(options)
        {
        }

        public DbSet<DimCustomerLevels> DimCustomerLevel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DimCustomerLevels>(entity =>
            {
                entity.HasKey(e => e.CustomerLevelKey);
                entity.Property(e => e.CustomerLevelId).IsRequired();
                entity.Property(e => e.LevelName).IsRequired().HasMaxLength(50);
            });
        }
    }
}