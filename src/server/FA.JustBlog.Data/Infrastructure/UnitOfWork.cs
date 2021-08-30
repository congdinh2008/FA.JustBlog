using FA.JustBlog.Data;
using FA.JustBlog.Data.Infrastructure.BaseRepositories;
using FA.JustBlog.Models.BaseEntities;
using FA.JustBlog.Models.Common;
using System.Threading.Tasks;

namespace FA.JustBlog.Data.Infrastructure
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

        private IGenericRepository<Tag> _tagRepository;

        public IGenericRepository<Tag> TagRepository =>
            _tagRepository ?? new GenericRepository<Tag>(_dbContext);

        private IGenericRepository<Post> _postRepository;

        public IGenericRepository<Post> PostRepository =>
            _postRepository ?? new GenericRepository<Post>(_dbContext);

        private IGenericRepository<Comment> _commentRepository;

        public IGenericRepository<Comment> CommentRepository =>
            _commentRepository ?? new GenericRepository<Comment>(_dbContext);

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
            _dbContext.Dispose();
        }
        #endregion
    }
}
