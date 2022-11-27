using Contact.Data.Entities;
using Contact.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Contact.Data.Repositories
{
    public class ReportRepository : RepositoryBase<Report>, IReportRepository
    {
        public ReportRepository(PhoneBookContext phoneBookContext) : base(phoneBookContext) { }

        public void CreateReport(Report report) => Create(report);
        public IEnumerable<Report> GetAllReports() => FindAll().ToList();
        public Report GetReportById(int reportId) => FindByCondition(r => r.Id == reportId).FirstOrDefault();
        public void UpdateReport(Report report) => Update(report);
    }
}
