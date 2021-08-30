using FA.JustBlog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.BaseServices
{
    public interface IBaseService<TEntity>
    {
        int Add(TEntity entity);

        Task<int> AddAsync(TEntity entity);

        int AddRange(IEnumerable<TEntity> entities);

        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);

        bool Update(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);

        bool Delete(Guid id);

        Task<bool> DeleteAsync(Guid id);

        bool Delete(TEntity entity);

        Task<bool> DeleteAsync(TEntity entity);

        TEntity GetById(Guid id);

        Task<TEntity> GetByIdAsync(Guid id);

        IEnumerable<TEntity> GetAll(bool isIncludeDeleted = false);

        Task<IEnumerable<TEntity>> GetAllAsync(bool isIncludeDeleted = false);

        /// <summary>
        /// Return entities with paging, filtering, ordering
        /// </summary>
        /// <param name="filter">x=>x.Name.Contains("abc")</param>
        /// <param name="orderBy">q => q.OrderByDescending(c => c.Name);</param>
        /// <param name="includeProperties">"Products", "Authors, Category, Publisher"</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<Paginated<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10);
    }
}

