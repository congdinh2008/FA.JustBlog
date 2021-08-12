using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using FA.JustBlog.WebMVC.Areas.Admin.ViewModels;
using Newtonsoft.Json;
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
        private readonly ICommentServices _commentServices;

        public PostsController(IPostServices postServices,
            ICategoryServices categoryServices,
            ICommentServices commentServices)
        {
            _postServices = postServices;
            _categoryServices = categoryServices;
            _commentServices = commentServices;
        }
        // GET: Posts
        public async Task<ActionResult> Index()
        {
            var allPosts = await _postServices.GetAllAsync();
            return View(allPosts);
        }

        public ActionResult LastestPosts()
        {
            var lastestPosts = Task.Run(() => _postServices.GetLatestPostAsync(5)).Result;
            ViewBag.PartialViewTitle = "Lastest Posts";
            return PartialView("_ListPost", lastestPosts);
        }

        public ActionResult MostViewPosts()
        {
            var lastestPosts = Task.Run(() => _postServices.GetMostViewPostsAsync(5)).Result;
            ViewBag.PartialViewTitle = "Most View Posts";
            return PartialView("_PopularPosts", lastestPosts);
        }

        public ActionResult HighestPosts()
        {
            var lastestPosts = Task.Run(() => _postServices.GetMostViewPostsAsync(5)).Result;
            ViewBag.PartialViewTitle = "Highest Posts";
            return PartialView("_ListPost", lastestPosts);
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

        [HttpPost]
        public async Task<ActionResult> Comment(CommentCreateViewModel commentCreateViewModel)
        {
            var comment = new Comment()
            {
                Id = Guid.NewGuid(),
                Name = commentCreateViewModel.Name,
                Email = commentCreateViewModel.Email,
                CommentHeader = commentCreateViewModel.CommentHeader,
                CommentText = commentCreateViewModel.CommentText,
                PostId = commentCreateViewModel.PostId
            };
            var result = await _commentServices.AddAsync(comment);
            if (result < 0)
            {
                return Json(new { errorMessage = "Create comment failed" });
            }
            var commentViewModel = new CommentViewModel()
            {
                Id = comment.Id,
                Name = commentCreateViewModel.Name,
                Email = commentCreateViewModel.Email,
                CommentHeader = commentCreateViewModel.CommentHeader,
                CommentText = commentCreateViewModel.CommentText,
                PostId = commentCreateViewModel.PostId,
                CommentTime = comment.CommentTime.ToString("MMM dd yyyy")
            };
            return Json(commentViewModel);
        }
    }
}