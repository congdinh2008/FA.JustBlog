using FA.JustBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC2.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagServices _tagServices;

        public TagsController(ITagServices tagServices)
        {
            _tagServices = tagServices;
        }
        // GET: Tags
        public async Task<ActionResult> Details(string urlSlug)
        {
            var tag = await _tagServices.GetTagByUrlSlugAsync(urlSlug);
            return View("_ListPosts", tag);
        }
    }
}