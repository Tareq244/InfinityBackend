using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase
{
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
