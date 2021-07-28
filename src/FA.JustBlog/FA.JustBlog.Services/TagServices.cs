using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{

    public class TagServices : BaseServices<Tag>, ITagServices
    {
        public TagServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return _unitOfWork.TagRepository.GetQuery().FirstOrDefault(t => t.UrlSlug == urlSlug);
        }

        public async Task<Tag> GetTagByUrlSlugAsync(string urlSlug)
        {
            return await _unitOfWork.TagRepository.GetQuery().FirstOrDefaultAsync(t => t.UrlSlug == urlSlug);
        }
    }
}

