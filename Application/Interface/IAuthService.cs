using InfinityBack.dataBase;
using InfinityBack.DTO.UserDTO;

namespace InfinityBack.Application.Interface
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
        
    }
}
