using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public interface ICommentServices : IBaseService<Comment>
    {
        Task<int> AddCommentAsync(int postId, string commentName, string commentEmail, 
            string commentTitle, string commentBody);

        Task<IEnumerable<Comment>> GetCommentForPostAsync(Post post);
        
        Task<IEnumerable<Comment>> GetCommentForPostAsync(Guid postId);
    }

    public class CommentServices : BaseServices<Comment>, ICommentServices
    {
        public CommentServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<int> AddCommentAsync(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Comment()
            {
                Id = Guid.NewGuid(),
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody,
                CommentTime = DateTime.Now
            };
            _unitOfWork.CommentRepository.Add(comment);
            return await _unitOfWork.SaveChangesAsync();
        }

        public override int Add(Comment entity)
        {
            entity.CommentTime = DateTime.Now;
            return base.Add(entity);
        }

        public override Task<int> AddAsync(Comment entity)
        {
            entity.CommentTime = DateTime.Now;
            return base.AddAsync(entity);
        }

        public Task<IEnumerable<Comment>> GetCommentForPostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetCommentForPostAsync(Guid postId)
        {
            throw new NotImplementedException();
        }
    }
}

