using Contact.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace Contact.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected PhoneBookContext PhoneBookContext { get; set; }
        public RepositoryBase(PhoneBookContext phoneBookContext)
        {
            PhoneBookContext = phoneBookContext;
        }
        public IQueryable<T> FindAll() => PhoneBookContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            PhoneBookContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => PhoneBookContext.Set<T>().Add(entity);
        public void Update(T entity) => PhoneBookContext.Set<T>().Update(entity);
        public void Delete(T entity) => PhoneBookContext.Set<T>().Remove(entity);
    }
}
