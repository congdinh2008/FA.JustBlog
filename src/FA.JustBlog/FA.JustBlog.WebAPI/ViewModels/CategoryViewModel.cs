using System;

namespace FA.JustBlog.WebAPI.ViewModels
{

    public class CategoryViewModel : BasicViewModel
    {
        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}