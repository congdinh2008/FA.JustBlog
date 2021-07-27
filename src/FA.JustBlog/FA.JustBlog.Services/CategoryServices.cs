using BookStore.Data.Infrastructure;
using BookStore.Models;
using FA.JustBlog.Services;
using FA.JustBlog.Services.BaseServices;

namespace BookStore.Business
{
    public class CategoryServices : BaseServices<Category>, ICategoryServices
    {
        public CategoryServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

