using InfinityBack.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBack.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class TargetAudienceController : Controller
    {
        #region properties
        private readonly ITargetAudienceService _targetAudienceService;
        #endregion

        #region constructor
        public TargetAudienceController(ITargetAudienceService targetAudienceService)
        {
            _targetAudienceService = targetAudienceService;
        }
        #endregion

        #region GetAllAudienceAsync
        [HttpGet]
        public async Task<IActionResult> GetAllAudienceAsync()
        {
            var audiences = await _targetAudienceService.GetAllAudienceAsync();
              if (audiences == null || !audiences.Any())
                return NotFound("No audiences found.");

            return Ok(audiences);
        }
        #endregion

    }
}
