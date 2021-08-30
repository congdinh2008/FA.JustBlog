using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public interface IPostServices : IBaseService<Post>
    {
        Task<IEnumerable<Post>> GetPublisedPostsAsync(bool published = true);

        Task<IEnumerable<Post>> GetLatestPostAsync(int size);

        Task<IEnumerable<Post>> GetPostsByMonthAsync(DateTime monthYear);

        Task<int> CountPostsForCategoryAsync(string category);

        Task<IEnumerable<Post>> GetPostsByCategoryAsync(string category);

        Task<IEnumerable<Post>> GetPostsByCategoryAsync(Guid categoryId);

        Task<int> CountPostsForTagAsync(string tag);

        Task<IEnumerable<Post>> GetPostsByTagAsync(string tag);
        
        Task<IEnumerable<Post>> GetPostsByTagAsync(Guid tagId);
        
        Task<IEnumerable<Post>> GetMostViewPostsAsync(int size);
        
        Task<IEnumerable<Post>> GetHighestPostsAsync(int size);
    }
}

