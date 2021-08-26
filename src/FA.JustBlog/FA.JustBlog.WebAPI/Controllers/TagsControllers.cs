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
    public class TagsController : ApiController
    {
        private readonly ITagServices _tagServices;

        public TagsController(ITagServices tagServices)
        {
            _tagServices = tagServices;
        }

        // GET: api/Categories
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _tagServices.GetAllAsync());
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Tag))]
        public async Task<IHttpActionResult> GetById(Guid id)
        {
            var tag = await _tagServices.GetByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }

        // PUT: api/Categories/5
        [HttpPost]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> CreateUpdate(TagEditViewModel tagEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tagEditViewModel.IsEdit)
            {
                var tagEdit = await Update(tagEditViewModel);
                if(tagEdit == null)
                {
                    return BadRequest(ModelState);
                }
                return Ok(tagEdit);
            }
            var tagCreated = await Create(tagEditViewModel);
            if(tagCreated == null)
            {
                return BadRequest();
            }
            return Ok(tagCreated);
        }

        private async Task<Tag> Create(TagEditViewModel tagEditViewModel)
        {
            var tag = new Tag()
            {
                Id = tagEditViewModel.Id,
                Name = tagEditViewModel.Name,
                UrlSlug = tagEditViewModel.UrlSlug,
                Description = tagEditViewModel.Description,
            };

            var result = await _tagServices.AddAsync(tag);
            if(result > 0)
            {
                return tag;
            }
            else
            {
                return null;
            }
        }

        private async Task<Tag> Update(TagEditViewModel tagEditViewModel)
        {
            var category = await _tagServices.GetByIdAsync(tagEditViewModel.Id);
            if (category == null)
            {
                return null;
            }

            category.Name = tagEditViewModel.Name;
            category.UrlSlug = tagEditViewModel.UrlSlug;
            category.Description = tagEditViewModel.Description;
            var result = await _tagServices.UpdateAsync(category);
            if (result)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Tag))]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var tag = await _tagServices.GetByIdAsync(id);
            if (tag == null)
            {
                NotFound();
            }
            var result = await _tagServices.DeleteAsync(tag);

            if (result)
            {
                return Ok(tag);
            }
            return BadRequest();
        }
    }
}