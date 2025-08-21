using InfinityBack.Application.Interface;
using InfinityBack.Application.Services;
using InfinityBack.dataBase;
using InfinityBack.DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBack.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        #region properity
        private readonly IUserService _userService;
        #endregion

        #region constructor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region UpdateUserProfileAsync
        [HttpPost("updateProfile/{userId}")]
        public async Task<IActionResult> UpdateUserProfileAsync(int userId, [FromBody] ProfileUpdateDto updateDto)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound("User not found");

            user.Username = updateDto.Username;
            user.PhoneNumber = updateDto.PhoneNumber;

            var updatedUser = await _userService.UpdateUserProfileAsync(userId, updateDto);

            return Ok(updatedUser);
        }
        #endregion

        #region DeactivateUserAsync
        [HttpDelete("deactivate/{userId}")]
        public async Task<IActionResult> DeactivateUserAsync(int userId)
        {
            try
            {
                var result = await _userService.DeactivateUserAsync(userId);
                if (result)
                {
                    return Ok(new { message = "User deactivated successfully." });
                }
                return NotFound(new { message = "User not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

        #region GetUserByIdAsync
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByIdAsync(int userId)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(userId);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound(new { message = "User not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

        #region GetAllUsersAsync
        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

    }
}
