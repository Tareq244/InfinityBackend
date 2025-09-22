using InfinityBack.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBack.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class SizeController : Controller
    {
        #region properties
        private readonly ISizeService _sizeService;
        #endregion

        #region constructor
        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }
        #endregion
        
        #region GetAllSizesAsync
        [HttpGet]
        public async Task<IActionResult> GetAllSizesAsync()
        {
            var sizes = await _sizeService.GetAllSizesAsync();
            if (sizes == null || !sizes.Any())
                return NotFound("No sizes found.");
            return Ok(sizes);
        }
        #endregion
    }
}
