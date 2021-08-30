using FA.JustBlog.Common;
using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.BaseServices
{
    public class BaseServices<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual int Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _unitOfWork.GenericRepository<TEntity>().Add(entity);
            return _unitOfWork.SaveChanges();
        }

        public virtual async Task<int> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _unitOfWork.GenericRepository<TEntity>().Add(entity);
            return await _unitOfWork.SaveChangesAsync();
        }

        public int AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                if (item == null)
                {
                    throw new ArgumentNullException();
                }
                _unitOfWork.GenericRepository<TEntity>().Add(item);
            }
            return _unitOfWork.SaveChanges();

        }

        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                if (item == null)
                {
                    throw new ArgumentNullException();
                }
                _unitOfWork.GenericRepository<TEntity>().Add(item);
            }
            return await _unitOfWork.SaveChangesAsync();
        }

        public bool Delete(Guid id)
        {
            var entity = _unitOfWork.GenericRepository<TEntity>().GetById(id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _unitOfWork.GenericRepository<TEntity>().Delete(entity);
            return _unitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = _unitOfWork.GenericRepository<TEntity>().GetById(id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _unitOfWork.GenericRepository<TEntity>().Delete(entity);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public bool Delete(TEntity entity)
        {
            _unitOfWork.GenericRepository<TEntity>().Delete(entity);
            return _unitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _unitOfWork.GenericRepository<TEntity>().Delete(entity);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public IEnumerable<TEntity> GetAll(bool isIncludeDeleted = false)
        {
            if (isIncludeDeleted == false)
            {
                return _unitOfWork.GenericRepository<TEntity>().GetQuery(x => x.IsDeleted == isIncludeDeleted).ToList();
            }
            return _unitOfWork.GenericRepository<TEntity>().GetQuery().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool isIncludeDeleted = false)
        {
            if (isIncludeDeleted == false)
            {
                return await _unitOfWork.GenericRepository<TEntity>().GetQuery(x => x.IsDeleted == isIncludeDeleted).ToListAsync();
            }
            return await _unitOfWork.GenericRepository<TEntity>().GetQuery().ToListAsync();
        }

        public virtual async Task<Paginated<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10)
        {
            var query = _unitOfWork.GenericRepository<TEntity>().Get(filter: filter, orderBy: orderBy,
                includeProperties: includeProperties);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await Paginated<TEntity>.CreateAsync(query.AsNoTracking(), pageIndex, pageSize);
        }

        public virtual TEntity GetById(Guid id)
        {
            return _unitOfWork.GenericRepository<TEntity>().GetById(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _unitOfWork.GenericRepository<TEntity>().GetByIdAsync(id);
        }

        public virtual bool Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _unitOfWork.GenericRepository<TEntity>().Update(entity);
            return _unitOfWork.SaveChanges() > 0;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _unitOfWork.GenericRepository<TEntity>().Update(entity);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}

