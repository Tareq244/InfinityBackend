using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }

        public int ShippingAddressId { get; set; }
        public Address ShippingAddress { get; set; }

        public int? OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public PaymentDetail PaymentDetail { get; set; }
    }
}
