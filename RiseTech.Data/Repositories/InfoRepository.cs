using Contact.Data.Entities;
using Contact.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Contact.Data.Repositories
{
    public class InfoRepository : RepositoryBase<Info>, IInfoRepository
    {
        public InfoRepository(PhoneBookContext phoneBookContext) : base(phoneBookContext) { }

        public IEnumerable<Info> GetAllInfo() => FindAll();

        public void CreateInfo(Info info) => Create(info);

        public IEnumerable<Info> GetAllInfoOfPerson(int personId) => FindByCondition(i => i.PersonId == personId).ToList();

        public Info GetInfoById(int infoId) => FindByCondition(i => i.Id == infoId).FirstOrDefault();

        public void UpdateInfo(Info info) => Update(info);

        public void DeleteInfo(Info info) => Delete(info);

    }
}
