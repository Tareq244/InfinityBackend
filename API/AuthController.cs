using InfinityBack.Application.Interface;
using InfinityBack.dataBase;
using InfinityBack.DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBack.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        #region properity
        private readonly IAuthService _authService;
        #endregion

        #region constructor
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        #endregion

        #region Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var user = new RegisterDto
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                Password = registerDto.Password,
                PhoneNumber = registerDto.PhoneNumber,
                Gender = registerDto.Gender,
                BirthDate = registerDto.BirthDate,
            };

            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            try
            {
                var result = await _authService.RegisterAsync(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

        #region Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var log = await _authService.LoginAsync(dto);

            if (log == null)
                return Unauthorized("Invalid credentials");

            return Ok(log);
        }
        #endregion

    }
}
 