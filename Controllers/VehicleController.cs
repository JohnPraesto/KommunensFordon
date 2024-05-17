using AutoMapper;
using KommunensFordon.DTOs;
using KommunensFordon.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KommunensFordon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicle _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleController(IVehicle vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        [HttpGet("Hämta alla fordon")]
        public ActionResult GetAllVehicles()
        {
            return Ok(_mapper.Map<List<VehicleDTO>>(_vehicleRepository.GetAllVehicles()));
        }

        [HttpGet("Hämta ett fordon")]
        public ActionResult GetOneVehicle(string licencePlate)
        {
            if (!_vehicleRepository.VehicleExists(licencePlate))
                return NotFound("Fordonet du sökte efter finns inte i databasen.");

            return Ok(_vehicleRepository.GetOneVehicle(licencePlate));
        }

        [HttpPost]
        public ActionResult RegisterNewVehicle(string licencePlate, DateTime latestService)
        {
            var newVehicle = _vehicleRepository.RegisterNewVehicle(licencePlate, latestService);
            return Ok(newVehicle);
        }

        [HttpDelete]
        public ActionResult DeleteVehicle(string licencePlate)
        {
            if (!_vehicleRepository.VehicleExists(licencePlate))
                return NotFound("Fordonet du sökte efter finns inte i databasen.");

            _vehicleRepository.DeleteVehicle(licencePlate);

            return Ok($"Fordon med registreringsnummer {licencePlate} borttaget.");
        }

        [HttpPut]
        public ActionResult RegisterService(string licencePlate, DateTime serviced)
        {
            if (!_vehicleRepository.VehicleExists(licencePlate))
                return NotFound("Fordonet du sökte efter finns inte i databasen.");

            _vehicleRepository.UpdateVehicle(licencePlate, serviced);

            return Ok($"Fordon med registreringsnummer {licencePlate} senaste service {serviced}");
        }
    }
}
