using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<CartItem> CartItems { get; set; }
    }
}
