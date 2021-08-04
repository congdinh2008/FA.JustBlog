using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public class PostServices : BaseServices<Post>, IPostServices
    {
        public PostServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override int Add(Post entity)
        {
            if (entity.Published)
            {
                entity.PublishedDate = DateTime.Now;
            }
            return base.Add(entity);
        }

        public override Task<int> AddAsync(Post entity)
        {
            if (entity.Published)
            {
                entity.PublishedDate = DateTime.Now;
            }
            return base.AddAsync(entity);
        }

        public async Task<int> CountPostsForCategoryAsync(string category)
        {
            return await _unitOfWork.PostRepository.GetQuery().CountAsync(p => p.Category.Name == category);
        }

        public async Task<int> CountPostsForTagAsync(string tag)
        {
            return await _unitOfWork.PostRepository.GetQuery().CountAsync(p => p.Tags.Any(t => t.Name == tag));
        }

        public async Task<IEnumerable<Post>> GetHighestPostsAsync(int size)
        {
            return await _unitOfWork.PostRepository.GetQuery().OrderByDescending(p => p.Rate).Take(size).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetLatestPostAsync(int size)
        {
            return await _unitOfWork.PostRepository.GetQuery().OrderByDescending(p => p.PublishedDate).Take(size).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetMostViewPostsAsync(int size)
        {
            return await _unitOfWork.PostRepository.GetQuery().OrderByDescending(p => p.ViewCount).Take(size).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByCategoryAsync(string category)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(p => p.Category.Name == category).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByCategoryAsync(Guid categoryId)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByMonthAsync(DateTime monthYear)
        {
            return await _unitOfWork.PostRepository.GetQuery()
                .Where(p => p.PublishedDate.Year == monthYear.Year && p.PublishedDate.Month == monthYear.Month)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByTagAsync(string tag)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(p => p.Tags.Any(t => t.Name == tag)).ToListAsync();
            //return _unitOfWork.TagRepository.GetQuery().FirstOrDefaultAsync(t => t.Name == tag).Result.Posts;
        }

        public async Task<IEnumerable<Post>> GetPostsByTagAsync(Guid tagId)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(p => p.Tags.Any(t => t.Id == tagId)).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPublisedPostsAsync(bool published = true)
        {
            return await _unitOfWork.PostRepository.GetQuery().Where(p => p.Published == published).ToListAsync();
        }
    }
}

