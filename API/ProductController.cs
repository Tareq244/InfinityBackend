using InfinityBack.Application.Interface;
using InfinityBack.Application.Services;
using InfinityBack.DTO.CategoryDTO;
using InfinityBack.DTO.ProductDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InfinityBack.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        #region properity
        private readonly IProductService _productService;
        #endregion

        #region Constructor
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        #region AddProduct
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromForm] ProductAddDto productAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var createdProduct = await _productService.AddProductAsync(productAddDto, userId);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);

        }
        #endregion

        #region GetAllProducts  
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try{
                var products = await _productService.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

        #region UpdateProduct
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductAddDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            try
            {
                var updatedProduct = await _productService.UpdateProductAsync(id, productDto, userId);
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion

        #region DeleteProduct
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (!result)
            {
                return NotFound("Product not found.");
            }
            return NoContent();
        }
        #endregion

        #region GetProductById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
        #endregion
    }
}
