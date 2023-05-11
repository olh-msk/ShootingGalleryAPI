using Microsoft.EntityFrameworkCore;
using ShootingGalleryAPI.Models;

namespace ShootingGalleryAPI.Data
{
    public class FactSessionDbContext : DbContext
    {
        public FactSessionDbContext(DbContextOptions<FactSessionDbContext> options) : base(options)
        {
        }

        public DbSet<FactSession> FactSession { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FactSession>(entity =>
            {
                entity.HasKey(e => e.SessionKey);
                entity.Property(e => e.ShootingGalleryKey).IsRequired();
                entity.Property(e => e.GunKey).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CustomerLevelKey).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PeriodStartDayKey).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PeriodEndDayKey).IsRequired().HasMaxLength(100);
                entity.Property(e => e.TotalIncome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Quantity).IsRequired().HasMaxLength(100);
                entity.Property(e => e.IncomeDifference).IsRequired(false);
            });
        }
    }
}