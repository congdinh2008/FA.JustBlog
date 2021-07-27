using System;

namespace FA.JustBlog.Models.BaseEntities
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}