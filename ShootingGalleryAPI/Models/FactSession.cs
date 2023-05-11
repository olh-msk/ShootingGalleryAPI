namespace ShootingGalleryAPI.Models
{
    public class FactSession
    {
        public int SessionKey { get; set; }

        public int ShootingGalleryKey { get; set; }

        public int GunKey { get; set; }

        public int CustomerLevelKey { get; set; }

        public int PeriodStartDayKey { get; set; }

        public int PeriodEndDayKey { get; set; }

        public decimal TotalIncome { get; set; }

        public int Quantity { get; set; }

        public decimal? IncomeDifference { get; set; }
    }
}