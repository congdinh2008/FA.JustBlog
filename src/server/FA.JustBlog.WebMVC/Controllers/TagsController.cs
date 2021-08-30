using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagServices _tagServices;
        private readonly IPostServices _postServices;

        public TagsController(ITagServices tagServices, IPostServices postServices)
        {
            _tagServices = tagServices;
            _postServices = postServices;
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var tag =  await _tagServices.GetByIdAsync(id);
            var posts = await _postServices.GetPostsByTagAsync(id);
            ViewBag.TagName = tag.Name;
            return View(posts);
        }

        public ActionResult PopularTags()
        {
            var popularTags = Task.Run(() => _tagServices.GetPopularTags()).Result;
            return PartialView("_PopularTags", popularTags);
        }
    }
}