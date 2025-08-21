using InfinityBack.DTO.UserDTO;

namespace InfinityBack.Application.Interface
{
    public interface IUserService
    {
        Task<UserDto> UpdateUserProfileAsync(int userId, ProfileUpdateDto updateDto);
        Task<bool> DeactivateUserAsync(int userId);
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }
}
