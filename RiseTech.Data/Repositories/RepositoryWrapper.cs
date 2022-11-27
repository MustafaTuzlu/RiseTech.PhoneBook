using Contact.API.Repositories;
using Contact.Data.Repositories.Interfaces;

namespace Contact.Data.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private PhoneBookContext _phoneBookContext;
        private IPersonRepository _people;
        private IInfoRepository _infos;
        private IReportRepository _report;

        public RepositoryWrapper(PhoneBookContext phoneBookContext)
        {
            _phoneBookContext = phoneBookContext;
        }

        public IPersonRepository People
        {
            get
            {
                if (_people == null)
                {
                    _people = new PersonRepository(_phoneBookContext);
                }
                return _people;
            }
        }

        public IInfoRepository Infos
        {
            get
            {
                if (_infos == null)
                {
                    _infos = new InfoRepository(_phoneBookContext);
                }
                return _infos;
            }
        }

        public IReportRepository Reports
        {
            get
            {
                if (_report == null)
                {
                    _report = new ReportRepository(_phoneBookContext);
                }
                return _report;
            }
        }

        public void Save()
        {
            _phoneBookContext.SaveChanges();
        }
    }
}
