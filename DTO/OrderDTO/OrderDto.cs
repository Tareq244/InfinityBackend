namespace InfinityBack.DTO.OrderDTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public List<OrderDetailItemDto> OrderItems { get; set; }
    }
}
