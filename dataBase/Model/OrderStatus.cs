using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string? StatusName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
