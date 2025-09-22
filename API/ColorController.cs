using InfinityBack.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBack.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorController : Controller
    {
        #region properties
        private readonly IColorService _colorService;
        #endregion

        #region constructor
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }
        #endregion

        #region GetAllColorsAsync
        [HttpGet]
        public async Task<IActionResult> GetAllColorsAsync()
        {
            var colors = await _colorService.GetAllColorsAsync();
            if (colors == null || !colors.Any())
                return NotFound("No colors found.");
            return Ok(colors);
        }
        #endregion
    }
}
