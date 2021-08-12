using System;

namespace FA.JustBlog.WebMVC.Areas.Admin.ViewModels
{
    public class CommentCreateViewModel
    {
        public Guid PostId { get; set; }
       
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string CommentHeader { get; set; }
        
        public string CommentText { get; set; }
    }

    public class CommentViewModel
    {
        public Guid Id { get; set; }
        
        public Guid PostId { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string CommentHeader { get; set; }

        public string CommentText { get; set; }

        public string CommentTime { get; set; }
    }
}