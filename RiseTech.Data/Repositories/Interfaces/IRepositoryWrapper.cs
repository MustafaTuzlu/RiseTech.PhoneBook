using Contact.API.Repositories;

namespace Contact.Data.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IPersonRepository People { get; }
        IInfoRepository Infos { get; }
        IReportRepository Reports { get; }
        void Save();
    }
}
