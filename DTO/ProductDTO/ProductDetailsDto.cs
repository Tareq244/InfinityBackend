using InfinityBack.DTO.AttachmentDTO;

namespace InfinityBack.DTO.ProductDTO
{
    public class ProductDetailsDto
    {
        public int Id { get; set; }

        public List<AttachmentDto> Attachments { get; set; } = new List<AttachmentDto>();
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryName { get; set; }
        public List<ProductVariantDto> Variant { get; set; } = new List<ProductVariantDto>();
        public List<ProductReviewDto> Review { get; set; } = new List<ProductReviewDto>();
        public string TargetAudienceName { get; set; }
    }
}
