using Contact.Data.Entities;
using System.Collections.Generic;

namespace Contact.Data.Repositories.Interfaces
{
    public interface IInfoRepository
    {
        public IEnumerable<Info> GetAllInfo();
        public IEnumerable<Info> GetAllInfoOfPerson(int personId);
        public Info GetInfoById(int infoId);
        public void CreateInfo(Info info);
        public void UpdateInfo(Info info);
        public void DeleteInfo(Info ınfo);
    }
}
