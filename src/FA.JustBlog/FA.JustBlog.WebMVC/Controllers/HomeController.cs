using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostServices _postServices;

        public HomeController(IPostServices postServices)
        {
            _postServices = postServices;
        }
        public async Task<ActionResult> Index(int? pageIndex = 1, int? pageSize = 5)
        {
            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = x => x.OrderByDescending(p => p.PublishedDate);
            var posts = await _postServices.GetAsync(filter: null, orderBy: orderBy, pageIndex: pageIndex ?? 1, pageSize: pageSize ?? 5);
            return View(posts);
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Hello World";
            ViewBag.Message = "Hello Vietnam";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}