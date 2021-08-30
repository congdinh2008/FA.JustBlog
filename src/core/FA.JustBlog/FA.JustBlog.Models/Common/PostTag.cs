using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Models.Common
{
    public class PostTag
    {
        [ForeignKey("Post")]
        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }

        [ForeignKey("Tag")]
        public Guid TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
