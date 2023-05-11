using Microsoft.EntityFrameworkCore;
using ShootingGalleryAPI.Models;

namespace ShootingGalleryAPI.Data
{
    public class DimGunDbContext : DbContext
    {
        public DimGunDbContext(DbContextOptions<DimGunDbContext> options) : base(options)
        {
        }

        public DbSet<DimGun> DimGun { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DimGun>(entity =>
            {
                entity.HasKey(e => e.GunKey);
                entity.Property(e => e.GunId).IsRequired();
                entity.Property(e => e.ManufacturerName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CaliberTypeName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.GunName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PricePerHour).IsRequired().HasMaxLength(100);
            });
        }
    }
}