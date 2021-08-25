using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.WebAPI.ViewModels
{
    public class CategoryEditViewModel: BasicViewModel
    {
        [Required]
        [MaxLength(255, ErrorMessage = "The {0} is at least {1} characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "The {0} is at least {1} characters")]

        public string UrlSlug { get; set; }

        [MaxLength(1000, ErrorMessage = "The {0} is at least {1} characters")]
        public string Description { get; set; }
    }
}