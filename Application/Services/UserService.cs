using InfinityBack.Application.Interface;
using InfinityBack.dataBase;
using InfinityBack.DTO.UserDTO;
using Microsoft.EntityFrameworkCore;

namespace InfinityBack.Application.Services
{
    public class UserService : IUserService
    {
        #region Properties
        private readonly InfinityDBContext _dbContext;
        #endregion

        #region constructor
        public UserService(InfinityDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region DeactivateUserAsync
        public async Task<bool> DeactivateUserAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null) return false;
            user.IsActive = false; 
            await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region GetAllUsersAsync
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _dbContext.Users
             .Where(u => u.IsActive) // <--  أهم إضافة
             .ToListAsync();

            return users.Select(user => new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.RoleId
            });
        }
        #endregion

        #region GetUserByIdAsync
        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null) return null;

            
            var userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return userDto;
        }
        #endregion

        #region UpdateUserProfileAsync
        public async Task<UserDto> UpdateUserProfileAsync(int userId, ProfileUpdateDto updateDto)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null) return null;

            user.Username = updateDto.Username;
            user.PhoneNumber = updateDto.PhoneNumber;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }
        #endregion

    }
}
