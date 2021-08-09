using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace FA.JustBlog.WebMVC2.Areas.Admin.ViewModels
{
    public class CategoryViewModel: BaseViewModel
    {

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        [Display(Name = "Url Slug")]
        public string UrlSlug { get; set; }

        [MaxLength(500, ErrorMessage = "The {0} must less than {1} characters")]
        public string Description { get; set; }
    }
}