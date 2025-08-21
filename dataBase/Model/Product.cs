using InfinityBack.dataBase.Model;
using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TargetAudienceId { get; set; }
        public TargetAudience TargetAudience { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
        public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
        public ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
    }
}
