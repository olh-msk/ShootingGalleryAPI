using Microsoft.EntityFrameworkCore;
using ShootingGalleryAPI.Models;

namespace ShootingGalleryAPI.Data
{
    public class DimGalleryDbContext : DbContext
    {
        public DimGalleryDbContext(DbContextOptions<DimGalleryDbContext> options) : base(options)
        {
        }

        public DbSet<DimGallery> DimGallery { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DimGallery>(entity =>
            {
                entity.HasKey(e => e.ShootingGalleryKey);
                entity.Property(e => e.ShootingGalleryId).IsRequired();
                entity.Property(e => e.GalleryName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.GalleryAddress).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CityName).IsRequired().HasMaxLength(100);
            });
        }
    }
}