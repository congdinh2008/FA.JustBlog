using FA.JustBlog.Models.Common;
using System.Collections.Generic;

namespace FA.JustBlog.WebMVC.ViewModels
{
    public class CategoryMenuViewModel
    {
        public IEnumerable<Category> PopularCategory { get; set; }
        public IEnumerable<Category> leftCategories { get; set; }
    }
}