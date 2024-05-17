using KommunensFordon.DataContext;
using KommunensFordon.Interfaces;
using KommunensFordon.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;

namespace KommunensFordon.Repositories
{
    public class ReportRepository : IReport
    {
        private readonly VehicleDbContext _context;

        public ReportRepository(VehicleDbContext context)
        {
            _context = context;
        }
        public bool DeleteReport(int id)
        {
            var reportToDelete = _context.Reports.FirstOrDefault(f => f.ReportId == id);
            _context.Remove(reportToDelete);
            _context.SaveChanges();
            return true;
        }

        public ICollection<Report> GetAllHandeledReports()
        {
            return _context.Reports.Where(r => r.Done == true).ToList();
            //return _context.Reports.Where(f => f.Done == true).ToList();
        }

        public ICollection<Report> GetAllUnhandeledReports()
        {
            return _context.Reports.Where(f => f.Done == false).ToList();
        }

        public Report GetOneReport(int id)
        {
            return _context.Reports.FirstOrDefault(f => f.ReportId == id);
        }

        public Report RegisterNewReport(string licencePlate, DateTime reported, string description, string reporter)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(f => f.LicencePlate == licencePlate);

            Report newReport = new Report()
            {
                Reported = reported,
                Description = description,
                Reporter = reporter,
                VehicleId = vehicle.VehicleId,
                Vehicle = vehicle,
                Done = false
            };
            _context.Reports.Add(newReport);
            _context.SaveChanges();
            return newReport;
    }

        public bool ReportExists(int id)
        {
            return _context.Reports.Any(f => f.ReportId == id);
        }

        public bool UpdateReport(int id, bool done)
        {
            Report reportToUpdate = _context.Reports.FirstOrDefault(v => v.ReportId == id);

            reportToUpdate.Done = done;
            _context.SaveChanges();

            return true;
        }
    }
}
