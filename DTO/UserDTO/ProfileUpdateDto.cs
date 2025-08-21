using System.ComponentModel.DataAnnotations;

namespace InfinityBack.DTO.UserDTO
{
    public class ProfileUpdateDto
    {
        public string? Username { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
