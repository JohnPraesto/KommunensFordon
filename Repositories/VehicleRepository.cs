using KommunensFordon.DataContext;
using KommunensFordon.Interfaces;
using KommunensFordon.Models;
using Microsoft.EntityFrameworkCore;

namespace KommunensFordon.Repositories
{
    public class VehicleRepository : IVehicle
    {
        private readonly VehicleDbContext _context;

        public VehicleRepository(VehicleDbContext context)
        {
            _context = context;
        }
        public bool DeleteVehicle(string regnr)
        {
            var vehicleToRemove = _context.Vehicles.FirstOrDefault(v => v.LicencePlate == regnr);
            _context.Remove(vehicleToRemove);
            _context.SaveChanges();
            return true;
        }

        public ICollection<Vehicle> GetAllVehicles()
        {
            // Sorterar efter senast service så att man kan se när nästa
            // service för en bil ska beställas
            return _context.Vehicles.OrderBy(f => f.LatestService).ToList();
        }

        public Vehicle GetOneVehicle(string licencePlate)
        {
            var vehicle = _context.Vehicles.Include(f => f.Reports).FirstOrDefault(f => f.LicencePlate == licencePlate);
            return vehicle;
        }

        public Vehicle RegisterNewVehicle(string licencePlate, DateTime latestService)
        {
            Vehicle newVehicle = new Vehicle()
            {
                LicencePlate = licencePlate,
                LatestService = latestService
            };
            _context.Vehicles.Add(newVehicle);
            _context.SaveChanges();
            return newVehicle;
        }
        public bool VehicleExists(string regnr)
        {
            return _context.Vehicles.Any(f => f.LicencePlate == regnr);
        }

        public bool UpdateVehicle(string regnr, DateTime serviced)
        {
            Vehicle vehicleToUpdate = _context.Vehicles.FirstOrDefault(v => v.LicencePlate == regnr);

            vehicleToUpdate.LatestService = serviced;
            _context.SaveChanges();

            return true;
        }
    }
}
