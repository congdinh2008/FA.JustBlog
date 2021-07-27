using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;

namespace FA.JustBlog.Services
{
    public class PostServices : BaseServices<Post>, IPostServices
    {
        public PostServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

