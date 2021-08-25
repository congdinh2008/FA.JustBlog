using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using FA.JustBlog.WebAPI.ViewModels;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace FA.JustBlog.WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // GET: api/Categories
        public async Task<IHttpActionResult> GetCategories()
        {
            return Ok(await _categoryServices.GetAllAsync());
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> GetCategory(Guid id)
        {
            var category = await _categoryServices.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategory(Guid id, CategoryEditViewModel categoryEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoryServices.GetByIdAsync(id);
            if (category == null)
            {
                return BadRequest();
            }

            category.Name = categoryEditViewModel.Name;
            category.UrlSlug = categoryEditViewModel.UrlSlug;
            category.Description = categoryEditViewModel.Description;

            var result = await _categoryServices.UpdateAsync(category);
            if (!result)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> PostCategory(CategoryEditViewModel categoryEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = new Category()
            {
                Id = categoryEditViewModel.Id,
                Name = categoryEditViewModel.Name,
                UrlSlug = categoryEditViewModel.UrlSlug,
                Description = categoryEditViewModel.Description,
            };

            var result = await _categoryServices.AddAsync(category);
            if (result <= 0)
            {
                return BadRequest(ModelState);
            }

            var categoryViewModel = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                UrlSlug = category.UrlSlug,
                Description = category.Description,
                IsDeleted = category.IsDeleted,
                InsertedAt = category.InsertedAt,
                UpdatedAt = category.UpdatedAt,
            };

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, categoryViewModel);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> DeleteCategory(Guid id)
        {
            var category = await _categoryServices.GetByIdAsync(id);
            if (category == null)
            {
                NotFound();
            }
            var result = await _categoryServices.DeleteAsync(category);

            if (result)
            {
                return Ok(category);
            }
            return BadRequest();
        }
    }
}