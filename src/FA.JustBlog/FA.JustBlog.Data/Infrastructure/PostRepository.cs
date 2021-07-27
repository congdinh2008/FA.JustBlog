using FA.JustBlog.Data.Infrastructure.BaseRepositories;
using FA.JustBlog.Models.Common;

namespace FA.JustBlog.Data.Infrastructure
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogDbContext context) : base(context)
        {
        }
    }
}