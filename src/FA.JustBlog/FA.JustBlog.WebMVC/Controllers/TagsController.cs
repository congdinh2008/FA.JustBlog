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

        public TagsController(ITagServices tagServices)
        {
            _tagServices = tagServices;
        }

        public ActionResult PopularTags()
        {
            var popularTags = Task.Run(() => _tagServices.GetPopularTags()).Result;
            return PartialView("_PopularTags", popularTags);
        }
    }
}