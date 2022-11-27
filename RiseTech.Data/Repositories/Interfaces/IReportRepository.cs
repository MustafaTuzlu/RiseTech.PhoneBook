using Contact.Data.Entities;
using System.Collections.Generic;

namespace Contact.Data.Repositories.Interfaces
{
    public interface IReportRepository
    {
        public IEnumerable<Report> GetAllReports();
        public Report GetReportById(int reportId);
        public void CreateReport(Report report);
        public void UpdateReport(Report report);
    }
}
