using System;

namespace ShootingGalleryAPI.Models
{
    public class FactShow
    {
        public int SessionKey { get; set; }

        public string GalleryName { get; set; }

        public string CaliberType { get; set; }

        public string CustomerLevelName { get; set; }

        public DateTime PeriodStartDay { get; set; }

        public DateTime PeriodEndDay { get; set; }

        public decimal TotalIncome { get; set; }

        public int Quantity { get; set; }

        public decimal? IncomeDifference { get; set; }
    }
}