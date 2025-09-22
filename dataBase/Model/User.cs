using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinityBack.dataBase
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Username { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(255)]
        public string PasswordHash { get; set; }
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        public bool? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public Cart? Cart { get; set; } 
        public ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
        public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
        [InverseProperty("CreatedByUser")]
        public ICollection<Product> CreatedProducts { get; set; } = new List<Product>();

        [InverseProperty("UpdatedByUser")]
        public ICollection<Product> UpdatedProducts { get; set; } = new List<Product>();
        public bool IsActive { get; set; } = true;
    }
}
