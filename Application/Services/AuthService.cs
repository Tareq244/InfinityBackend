using InfinityBack.API;
using InfinityBack.Application.Interface;
using InfinityBack.dataBase;
using InfinityBack.DTO.UserDTO;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace InfinityBack.Application.Services
{
    public class AuthService : IAuthService
    {
        #region Properties
        private readonly InfinityDBContext _dbContext;
        #endregion

        #region constructor
        public AuthService(InfinityDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region RegisterAsync
        public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            if (await _dbContext.Users.AnyAsync(u => u.Email == registerDto.Email))
            {
                throw new Exception("Email already exists.");
            }
            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                Gender = registerDto.Gender,
                BirthDate = registerDto.BirthDate,
                PhoneNumber = registerDto.PhoneNumber,
                RoleId = (int)RoleDefault.Customer,
                CreatedAt = DateTime.UtcNow
            };


            try
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving user: " + ex.InnerException?.Message ?? ex.Message);
            }


            return new AuthResponseDto
            {
                Token = "", 
                User = new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Role = user.RoleId
                }
            };


        }
        #endregion

        #region LoginAsync
        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null)
            {
                return null;
            }

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                return null;
            }
            

            var response = new AuthResponseDto
            {
                User = new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Role = user.RoleId
                },
            };

            return response;
        }
        #endregion
    }
}
