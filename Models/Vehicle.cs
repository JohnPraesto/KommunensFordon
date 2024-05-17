namespace KommunensFordon.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string LicencePlate { get; set; }
        public DateTime LatestService { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
