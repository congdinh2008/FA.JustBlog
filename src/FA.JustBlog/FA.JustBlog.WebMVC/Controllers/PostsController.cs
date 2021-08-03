using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using System;
using System.Linq;
using System.Linq.Expressions;
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
        public async Task<ActionResult> Index(int? pageIndex = 1, int? pageSize = 3)
        {
            Expression<Func<Post, bool>> filter = null;

            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = o => o.OrderBy(p => p.Title);
            var posts = await _postServices.GetAsync(filter: filter, orderBy: orderBy,
                pageIndex: pageIndex ?? 1, pageSize: pageSize ?? 3);
            return View(posts);
        }

        public ActionResult LastestPosts()
        {
            var lastestPosts = Task.Run(()=> _postServices.GetLatestPostAsync(5)).Result ;
            return PartialView("_LastestPost", lastestPosts);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var post = await _postServices.GetByIdAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
    }
}