using KommunensFordon.Models;

namespace KommunensFordon.Interfaces
{
    public interface IVehicle
    {
        ICollection<Vehicle> GetAllVehicles();
        Vehicle GetOneVehicle(string licencePlate);
        Vehicle RegisterNewVehicle(string licencePlate, DateTime latestService);
        bool DeleteVehicle(string licencePlate);
        bool VehicleExists(string licencePlate);
        bool UpdateVehicle(string licencePlate, DateTime serviced);
    }
}
