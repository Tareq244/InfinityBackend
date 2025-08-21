namespace InfinityBack.DTO.PaymentDTO
{
    public class PaymentDetailsDto
    {
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } 
        public string PaymentStatus { get; set; } 
        public DateTime TransactionDate { get; set; }
    }
}
