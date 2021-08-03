using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FA.JustBlog.Data;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;

namespace FA.JustBlog.WebMVC.Areas.Admin.Controllers
{
    public class PostManagementController : Controller
    {

        private JustBlogDbContext db = new JustBlogDbContext();
        private readonly IPostServices _postServices;

        public PostManagementController(IPostServices postServices)
        {
            _postServices = postServices;
        }

        // GET: Admin/PostManagement
        public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString,
            int? pageIndex = 1, int pageSize = 2)
        {
            ViewData["CurrentPageSize"] = pageSize;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["TitleSortParm"] = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["UrlSlugSortParm"] = sortOrder == "UrlSlug" ? "urlSlug_desc" : "UrlSlug";
            ViewData["PublishedSortParm"] = sortOrder == "Published" ? "published_desc" : "Published";
            ViewData["PublishedDateSortParm"] = sortOrder == "PublishedDate" ? "publishedDate_desc" : "PublishedDate";
            ViewData["UpdatedAtSortParm"] = sortOrder == "UpdatedAt" ? "updatedAt_desc" : "UpdatedAt";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            // x => x.Name.Contains(searchString)
            Expression<Func<Post, bool>> filter = null;

            if (!string.IsNullOrEmpty(searchString))
            {
                filter = p => p.Title.Contains(searchString) || p.ShortDescription.Contains(searchString);
            }

            // q => q.OrderByDescending(c => c.Name)
            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = null;

            switch (sortOrder)
            {
                case "title_desc":
                    orderBy = q => q.OrderByDescending(c => c.Title);
                    break;
                case "UrlSlug":
                    orderBy = q => q.OrderBy(c => c.UrlSlug);
                    break;
                case "urlSlug_desc":
                    orderBy = q => q.OrderByDescending(c => c.UrlSlug);
                    break;
                case "Published":
                    orderBy = q => q.OrderBy(c => c.Published);
                    break;
                case "published_desc":
                    orderBy = q => q.OrderByDescending(c => c.Published);
                    break;
                case "PublishedDate":
                    orderBy = q => q.OrderBy(c => c.PublishedDate);
                    break;
                case "publishedDate_desc":
                    orderBy = q => q.OrderByDescending(c => c.PublishedDate);
                    break;
                case "UpdatedAt":
                    orderBy = q => q.OrderBy(c => c.UpdatedAt);
                    break;
                case "updatedAt_desc":
                    orderBy = q => q.OrderByDescending(c => c.UpdatedAt);
                    break;
                default:
                    orderBy = q => q.OrderBy(c => c.Title);
                    break;
            }

            var categories = await _postServices.GetAsync(filter: filter, orderBy: orderBy, pageIndex: pageIndex ?? 1, pageSize: pageSize);

            return View(categories);
        }

        // GET: Admin/PostManagement/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/PostManagement/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/PostManagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ShortDescription,ImageUrl,PostContent,UrlSlug,Published,PublishedDate,CategoryId,IsDeleted,InsertedAt,UpdatedAt")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.Id = Guid.NewGuid();
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        // GET: Admin/PostManagement/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        // POST: Admin/PostManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ShortDescription,ImageUrl,PostContent,UrlSlug,Published,PublishedDate,CategoryId,IsDeleted,InsertedAt,UpdatedAt")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        // POST: Admin/PostManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _postServices.DeleteAsync(id);
            if (result)
            {
                TempData["Message"] = "Delete Successful";
            }
            else
            {
                TempData["Message"] = "Delete failed";
            }
            return RedirectToAction("Index");
        }
    }
}
