using KommunensFordon.Models;

namespace KommunensFordon.DTOs
{
    public class VehicleDTO
    {
        public int VehicleId { get; set; }
        public string LicencePlate { get; set; }
        public DateTime LatestService { get; set; }
    }
}
