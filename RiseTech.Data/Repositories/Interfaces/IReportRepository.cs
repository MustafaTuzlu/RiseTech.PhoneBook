using RiseTech.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiseTech.Data.Repositories.Interfaces
{
    public interface IReportRepository
    {
        public Task<IEnumerable<Report>> GetAllReportsAsync();
        public Report GetReportById(int reportId);
        public void CreateReport(Report report);
        public void UpdateReport(Report report);
    }
}
