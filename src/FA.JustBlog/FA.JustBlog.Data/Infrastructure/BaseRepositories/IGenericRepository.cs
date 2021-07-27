using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FA.JustBlog.Data.Infrastructure.BaseRepositories
{
    public interface IGenericRepository<T>
    {
        T GetById(Guid id);

        Task<T> GetByIdAsync(Guid id);

        void Add(T entity);

        void Add(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity, bool isHardDelete = false);

        void Delete(IEnumerable<T> entities, bool isHardDelete = false);

        void Delete(Expression<Func<T, bool>> where, bool isHardDelete = false);

        IQueryable<T> GetQuery();

        IQueryable<T> GetQuery(Expression<Func<T, bool>> where);

        IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
    }
}
