using FA.JustBlog.Models.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Models.Common
{
    [Table("Comments", Schema = "common")]
    public class Comment : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string CommentHeader { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentTime { get; set; }

        [ForeignKey("Post")]
        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}