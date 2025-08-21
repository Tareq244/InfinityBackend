using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        [Required, MaxLength(255)]
        public string? Street { get; set; }
        [MaxLength(20)]
        public string? PostalCode { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public bool IsDefault { get; set; } = false;
    }
}
