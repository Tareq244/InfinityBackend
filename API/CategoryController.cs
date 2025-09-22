using InfinityBack.Application.Interface;
using InfinityBack.dataBase;
using InfinityBack.DTO.CategoryDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Threading.Tasks;

namespace InfinityBack.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region properties
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _env;
        #endregion

        #region constructor
        public CategoryController(ICategoryService categoryService, IWebHostEnvironment env)
        {
            _categoryService = categoryService;
            _env = env;
        }
        #endregion

        #region createCategory
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdCategory = await _categoryService.CreateCategoryAsync(createDto);

            return CreatedAtRoute("GetCategoryById",
                                  new { categoryId = createdCategory.Id },
                                  createdCategory);
        }
        #endregion

        #region GetCategoryByIdAsync
        [HttpGet("{categoryId}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);

            if (category == null)
            {
                return NotFound(); 
            }

            return Ok(category);
        }
        #endregion

        #region UpdateCategoryAsync
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromForm] UpdateCategoryDto updateDto)
        {
            var result = await _categoryService.UpdateCategoryAsync(id, updateDto);
            if (result == null) return NotFound();
            return Ok(result);
        }
        #endregion

        #region GetAllCategoriesAsync
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }
        #endregion

        #region DeleteCategoryAsync
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var success = await _categoryService.DeleteCategoryAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
        #endregion

        #region getsubcategories
        [HttpGet("{parentId}/subcategories")]
        public async Task<IActionResult> GetSubCategories(int parentId)
        {
            var subCategories = await _categoryService.GetSubCategoriesAsync(parentId);
            if(subCategories == null || !subCategories.Any())
            {
                return NotFound();
            }
            return Ok(subCategories);
        }
        #endregion

        #region getMainCategories
        [HttpGet("GetMainCategories")]
        public async Task<IActionResult> GetMainCategories()
        {
            var mainCategories = await _categoryService.getMainCategoryAsync();
            if (mainCategories == null || !mainCategories.Any())
            {
                return NotFound();
            }
            return Ok(mainCategories);
        }
        #endregion

        
    }
}
