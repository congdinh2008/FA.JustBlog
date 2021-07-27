using FA.JustBlog.Data;
using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Data.Infrastructure.BaseRepositories;
using FA.JustBlog.Models.BaseEntities;
using FA.JustBlog.Models.Common;
using System.Threading.Tasks;

namespace BookStore.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogDbContext _dbContext;

        public JustBlogDbContext DataContext => _dbContext;

        public UnitOfWork(JustBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        private IGenericRepository<Category> _categoryRepository;

        public IGenericRepository<Category> CategoryRepository =>
            _categoryRepository ?? new GenericRepository<Category>(_dbContext);

        private IPostRepository _bookRepository;

        public IPostRepository PostRepository =>
            _bookRepository ?? new PostRepository(_dbContext);

        #region Methods
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();

        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public IGenericRepository<T> GenericRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_dbContext);
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
        #endregion
    }
}
