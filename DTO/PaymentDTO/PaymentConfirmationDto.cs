namespace InfinityBack.DTO.PaymentDTO
{
    public class PaymentConfirmationDto
    {
        public string TransactionId { get; set; } 
        public int OrderId { get; set; }
        public string PaymentStatus { get; set; }
        public decimal AmountPaid { get; set; }
    }
}
