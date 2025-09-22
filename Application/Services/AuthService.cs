using InfinityBack.API;
using InfinityBack.Application.Interface;
using InfinityBack.dataBase;
using InfinityBack.DTO.UserDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace InfinityBack.Application.Services
{
    public class AuthService : IAuthService
    {
        #region Properties
        private readonly InfinityDBContext _dbContext;
        private readonly IConfiguration _config;
        #endregion

        #region constructor
        public AuthService(InfinityDBContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }
        #endregion

        #region Token
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["JwtSettings:SecretKey"]); 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.RoleId.ToString())
        }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["JwtSettings:ExpiresInMinutes"])),
                Issuer = _config["JwtSettings:Issuer"],
                Audience = _config["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
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
                Token = GenerateJwtToken(user),
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
                Token = GenerateJwtToken(user),
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
