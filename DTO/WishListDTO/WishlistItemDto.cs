namespace InfinityBack.DTO.WishListDTO
{
    public class WishlistItemDto
    {
        public int WishlistItemId { get; set; } 
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public IFormFile ImageUrl { get; set; } 

        public int? ProductVariantId { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
    }
}
