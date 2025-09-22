using InfinityBack.DTO.AttachmentDTO;

namespace InfinityBack.DTO.ProductDTO
{
    public class ProductAddDto
    {
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }

        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int TargetAudienceId { get; set; }
        public List<ProductVariantDto> Variants { get; set; } = new List<ProductVariantDto>();
        public List<IFormFile>? Attachments { get; set; }
    }
}
