using Microsoft.EntityFrameworkCore;
using ShootingGalleryAPI.Models;

namespace ShootingGalleryAPI.Data 
{
    public class CalibersDbContext : DbContext
    {
        public CalibersDbContext(DbContextOptions<CalibersDbContext> options) : base(options)
        {
        }

        public DbSet<Calibers> Calibers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calibers>(entity =>
            {
                entity.HasKey(e => e.CaliberId);
                entity.Property(e => e.CaliberTypeName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CreateDate).IsRequired().HasMaxLength(50);
                entity.Property(e => e.UpdateDate).IsRequired().HasMaxLength(50);
                // Add additional properties and configurations for any other columns in your table
            });
        }
    }
}