using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase
{
    public class PaymentDetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public decimal Amount { get; set; }
        [MaxLength(50)]
        public string? PaymentMethod { get; set; }
        [MaxLength(50)]
        public string? PaymentStatus { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }
}
