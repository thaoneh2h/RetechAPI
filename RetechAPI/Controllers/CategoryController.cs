using Microsoft.AspNetCore.Mvc;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retech.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // GET: api/category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(Guid id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST: api/category
        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] CategoryDTO categoryDTO)
        {
            await _categoryService.AddCategoryAsync(categoryDTO);
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryDTO.CategoryId }, categoryDTO);
        }

        // PUT: api/category/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(Guid id, [FromBody] CategoryDTO categoryDTO)
        {
            await _categoryService.UpdateCategoryAsync(id, categoryDTO);
            return NoContent();
        }

        // DELETE: api/category/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
