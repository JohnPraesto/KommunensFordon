using KommunensFordon.Interfaces;
using KommunensFordon.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace KommunensFordon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReport _reportRepository;
        private readonly IVehicle _vehicleRepository;

        public ReportController(IReport reportRepository, IVehicle vehicleRepository)
        {
            _reportRepository = reportRepository;
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet("Hämta alla åtgärdade felrapporter")]
        public ActionResult GetAllHandeledReports()
        {
            return Ok(_reportRepository.GetAllHandeledReports());
        }

        [HttpGet("Hämta alla ej åtgärdade felrapporter")]
        public ActionResult GetAllUnhandeledReports()
        {
            return Ok(_reportRepository.GetAllUnhandeledReports());
        }

        [HttpGet("Hämta en felrapport")]
        public ActionResult GetOneReport(int id)
        {
            if (!_reportRepository.ReportExists(id))
                return NotFound("Felrapporten du sökte efter finns inte i databasen.");

            return Ok(_reportRepository.GetOneReport(id));
        }

        [HttpPost]
        public ActionResult RegisterNewReport(string licencePlate, DateTime reported, string description, string reporter)
        {
            if (!_vehicleRepository.VehicleExists(licencePlate))
                return NotFound($"Fordon med registreringsnummer {licencePlate} finns inte i databasen..");

            var newReport = _reportRepository.RegisterNewReport(licencePlate, reported, description, reporter);
            return Ok(newReport);
        }

        [HttpDelete]
        public ActionResult DeleteReport(int id)
        {
            if (!_reportRepository.ReportExists(id))
                return NotFound("Felrapporten du sökte efter finns inte.");

            _reportRepository.DeleteReport(id);

            return Ok($"Felrapporten med id {id} är borttagen.");
        }

        [HttpPut]
        public ActionResult UpdateReport(int id, bool done)
        {
            if (!_reportRepository.ReportExists(id))
                return NotFound($"Rapport med id {id} hittades inte");

            _reportRepository.UpdateReport(id, done);

            return Ok($"Åtgärdad status uppdaterad till {done}");
        }
    }
}
