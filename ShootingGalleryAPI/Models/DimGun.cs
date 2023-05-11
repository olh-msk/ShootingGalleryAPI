namespace ShootingGalleryAPI.Models
{
    public class DimGun
    {
        public int GunKey { get; set; }

        public int GunId { get; set; }

        public string ManufacturerName { get; set; }

        public string CaliberTypeName { get; set; }

        public string GunName { get; set; }

        public decimal PricePerHour { get; set; }
    }
}