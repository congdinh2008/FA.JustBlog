using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using FA.JustBlog.WebMVC.ViewModels;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IPostServices _postServices;
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(IPostServices postServices, ICategoryServices categoryServices)
        {
            _postServices = postServices;
            _categoryServices = categoryServices;
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var category = await _categoryServices.GetByIdAsync(id);
            ViewBag.CategoryName = category.Name;
            var posts = await _postServices.GetPostsByCategoryAsync(id);
            return View(posts);
        }

        public ActionResult CategoryRightMenu()
        {
            var categoryRightMenuViewModels = _categoryServices.GetAll().Select(x => new CategoryRightMenuViewModel
            {
                Id = x.Id,
                Name = x.Name,
                PostCount = x.Posts.Count
            }).OrderByDescending(c=>c.PostCount);
            return PartialView("_CategoryRightMenu", categoryRightMenuViewModels);
        }
    }
}