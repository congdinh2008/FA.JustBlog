using System;

namespace FA.JustBlog.WebMVC.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string  Description { get; set; }
    }
}