namespace InfinityBack.DTO.OrderDTO
{
    public class OrderDetailItemDto
    {
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }
    }
}
