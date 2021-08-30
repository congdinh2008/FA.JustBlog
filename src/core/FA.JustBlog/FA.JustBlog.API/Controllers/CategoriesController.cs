using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryServices.GetAllAsync();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _categoryServices.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryViewModel categoryViewModel)
        {
            var result = await _categoryServices.AddAsync(category);
            if (result > 0)
            {
                return Ok(category);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CategoryViewModel categoryViewModel)
        {
            var entity = await _categoryServices.GetByIdAsync(category.Id);
            entity.Name = category.Name;
            entity.UrlSlug  = category.UrlSlug;
            var result = await _categoryServices.UpdateAsync(entity);
            
            if (result)
            {
                return Ok(category);
            }
            return BadRequest(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _categoryServices.DeleteAsync(id);
            return Ok(result);
        }
    }
}
