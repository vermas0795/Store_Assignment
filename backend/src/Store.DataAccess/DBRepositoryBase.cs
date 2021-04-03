using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Store.DataAccess.Repository;

namespace Store.DataAccess
{
    public abstract class DBRepositoryBase<T> : IRepository<T> where T : class
    {
        public virtual bool Delete(long entityId)
        {
            throw new NotImplementedException();
        }
        public virtual Task DeleteAsync(long entityId)
        {
            throw new NotImplementedException();
        }

        public virtual T Insert(T entity)
        {
            throw new NotImplementedException();
        }
        public virtual List<T> Insert(List<T> entity)
        {
            throw new NotImplementedException();
        }
        public virtual Task<T> InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual T Update(T entity)
        {
            throw new NotImplementedException();
        }
        public virtual List<T> Update(List<T> entity)
        {
            throw new NotImplementedException();
        }
        public virtual T UpdateCustom(dynamic entity)
        {
            throw new NotImplementedException();
        }
        public virtual Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }
        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public virtual T GetByCustom(string json)
        {
            throw new NotImplementedException();
        }
        public virtual IEnumerable<T> GetListByCustom(string json)
        {
            throw new NotImplementedException();
        }
        public virtual Task<T> GetByCustomAsync(T result)
        {
            throw new NotImplementedException();
        }
        public virtual T GetById(long? id)
        {
            throw new NotImplementedException();
        }
        public virtual T GetByName(string name)
        {
            throw new NotImplementedException();
        }
        public virtual IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

    }
}
