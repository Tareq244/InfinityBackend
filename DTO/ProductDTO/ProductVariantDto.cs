namespace InfinityBack.DTO.ProductDTO
{
    public class ProductVariantDto
    {
        public int Id { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Sku { get; set; }
        public IFormFile[]? Images { get; set; }
    }
}
