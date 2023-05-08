using System;

namespace ShootingGalleryAPI.Models
{
    public class Calibers
    {
        public int CaliberId { get; set; }

        public string CaliberTypeName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
