using Microsoft.EntityFrameworkCore;
using RiseTech.Data.Entities;
using RiseTech.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiseTech.Data.Repositories
{
    public class ReportRepository : RepositoryBase<Report>, IReportRepository
    {
        public ReportRepository(PhoneBookContext phoneBookContext) : base(phoneBookContext) { }

        public void CreateReport(Report report) => Create(report);

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await Task.FromResult(PhoneBookContext.Reports.AsNoTracking().ToList());
        }

        public Report GetReportById(int reportId) => FindByCondition(r => r.Id == reportId).FirstOrDefault();
        public void UpdateReport(Report report) => Update(report);

    }
}
