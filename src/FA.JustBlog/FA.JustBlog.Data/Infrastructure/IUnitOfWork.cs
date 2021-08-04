using FA.JustBlog.Data.Infrastructure.BaseRepositories;
using FA.JustBlog.Models.BaseEntities;
using FA.JustBlog.Models.Common;
using System;
using System.Threading.Tasks;

namespace FA.JustBlog.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        JustBlogDbContext DataContext { get; }

        #region Master Data

        IGenericRepository<Category> CategoryRepository { get; }

        IGenericRepository<Tag> TagRepository { get; }

        IGenericRepository<Post> PostRepository { get; }
        IGenericRepository<Comment> CommentRepository { get; }

        #endregion

        int SaveChanges();

        Task<int> SaveChangesAsync();

        IGenericRepository<T> GenericRepository<T>() where T : BaseEntity;
    }
}
