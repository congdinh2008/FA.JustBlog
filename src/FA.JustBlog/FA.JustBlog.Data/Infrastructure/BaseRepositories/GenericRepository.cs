using FA.JustBlog.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FA.JustBlog.Data.Infrastructure.BaseRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity
    {
        #region Protected Fields

        protected readonly JustBlogDbContext _context;
        private readonly DbSet<T> _dbSet;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T, TDbContext}"/> class.
        /// </summary>
        /// <param name="context">The data context.</param>
        public GenericRepository(JustBlogDbContext context)
        {
            _context = context;
            // Find Property with typeof(T) on dataContext
            var typeOfDbSet = typeof(DbSet<T>);
            foreach (var prop in context.GetType().GetProperties())
            {
                if (typeOfDbSet == prop.PropertyType)
                {
                    _dbSet = prop.GetValue(context, null) as DbSet<T>;
                    break;
                }
            }

            if (_dbSet == null)
            {
                _dbSet = context.Set<T>();
            }
        }

        #region Virtual Methods

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Add(IEnumerable<T> entities)
        {
            // Use AddRange() to improve the performance.
            _dbSet.AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the specified context.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="isHardDelete">is hard delete?</param>
        public virtual void Delete(T entity, bool isHardDelete = false)
        {
            if (isHardDelete)
            {
                _dbSet.Remove(entity);
            }
            else
            {
                entity.IsDeleted = true;
                _context.Entry(entity).State = EntityState.Modified;

            }
        }

        /// <summary>
        /// Deletes the specified context.
        /// </summary>
        /// <param name="entities">List of entity.</param>
        /// <param name="isHardDelete">is hard delete?</param>
        public virtual void Delete(IEnumerable<T> entities, bool isHardDelete = false)
        {
            // Improve performance for hard delete
            if (isHardDelete)
            {
                _dbSet.RemoveRange(entities);
            }
            else
            {
                foreach (var entity in entities)
                {
                    entity.IsDeleted = true;
                }
            }
        }

        /// <summary>
        /// Deletes the specified context.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="isHardDelete">is hard delete?</param>
        public virtual void Delete(Expression<Func<T, bool>> where, bool isHardDelete = false)
        {
            var entities = GetQuery(where).AsEnumerable();

            // Use this overload instead of using foreach to improve performance
            Delete(entities, isHardDelete);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetByPageAsync(Expression<Func<T, bool>> condition, int size, int page)
        {
            return await _dbSet.Where(condition).Skip(size * (page - 1)).Take(size).ToListAsync();
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", bool canLoadDeleted = false)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if(canLoadDeleted == false)
            {
                query = query.Where(x => x.IsDeleted == canLoadDeleted);
            }

            foreach (var includeProperty in
                includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query) : query;
        }

        public virtual IQueryable<T> GetQuery()
        {
            return _dbSet;
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where);
        }

        #endregion
    }
}
