using FA.JustBlog.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostServices _postServices;
        private readonly ICategoryServices _categoryServices;

        public PostsController(IPostServices postServices, ICategoryServices categoryServices)
        {
            _postServices = postServices;
            _categoryServices = categoryServices;
        }
        // GET: Posts
        public async Task<ActionResult> Index()
        {
            var lastestPosts = await _postServices.GetLatestPostAsync(5);
            return View(lastestPosts);
        }

        public async Task<ActionResult> LastestPosts()
        {
            var lastestPosts = await _postServices.GetLatestPostAsync(5);
            return PartialView(lastestPosts);
        }
    }
}