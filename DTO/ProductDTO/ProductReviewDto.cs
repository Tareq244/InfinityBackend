namespace InfinityBack.DTO.ProductDTO
{
    public class ProductReviewDto
    {
        public string Username { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
