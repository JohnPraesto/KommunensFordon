using KommunensFordon.Models;

namespace KommunensFordon.Interfaces
{
    public interface IReport
    {
        ICollection<Report> GetAllHandeledReports();
        ICollection<Report> GetAllUnhandeledReports();
        Report GetOneReport(int id);
        Report RegisterNewReport(string licencePlate, DateTime reported, string description, string reporter);
        bool DeleteReport(int id);
        bool ReportExists(int id);
        bool UpdateReport(int id, bool done);
    }
}
