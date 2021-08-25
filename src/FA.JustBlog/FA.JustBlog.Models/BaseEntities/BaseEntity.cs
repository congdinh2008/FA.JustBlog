using System;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Models.BaseEntities
{
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            IsDeleted = false;  
        }

        public Guid Id { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Inserted At")]
        public DateTime InsertedAt { get; set; }

        [Display(Name = "Updated At")]
        public DateTime UpdatedAt { get; set; }
    }
}