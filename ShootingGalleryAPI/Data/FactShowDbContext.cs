using Microsoft.EntityFrameworkCore;
using ShootingGalleryAPI.Models;

namespace ShootingGalleryAPI.Data
{
    public class FactShowDbContext : DbContext
    {
        public FactShowDbContext(DbContextOptions<FactShowDbContext> options) : base(options)
        {
        }

        public DbSet<FactShow> FactShow { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FactShow>(entity =>
            {
                entity.HasKey(e => e.SessionKey);
                entity.Property(e => e.GalleryName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CaliberType).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CustomerLevelName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PeriodStartDay).IsRequired();
                entity.Property(e => e.PeriodEndDay).IsRequired();
                entity.Property(e => e.TotalIncome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Quantity).IsRequired().HasMaxLength(100);
                entity.Property(e => e.IncomeDifference).IsRequired(false);
            });
        }
    }
}