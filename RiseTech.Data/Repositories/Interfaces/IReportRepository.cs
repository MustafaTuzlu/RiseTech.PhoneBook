using RiseTech.Data.Entities;
using System.Collections.Generic;

namespace RiseTech.Data.Repositories.Interfaces
{
    public interface IReportRepository
    {
        public IEnumerable<Report> GetAllReports();
        public Report GetReportById(int reportId);
        public void CreateReport(Report report);
        public void UpdateReport(Report report);
    }
}
