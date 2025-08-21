using InfinityBack.DTO.AttachmentDTO;

namespace InfinityBack.DTO.ProductDTO
{
    public class ProductDetailsDto
    {
        public int Id { get; set; }
        /*public IFormFile ImageONE { get; set; }
        public IFormFile? ImageTWO { get; set; }
        public IFormFile? ImageTHREE { get; set; }
        public IFormFile? ImageFOUR { get; set; }
        public IFormFile? ImageFIVE { get; set; }*/
        public List<AttachmentDto> Attachments { get; set; } = new List<AttachmentDto>();
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryName { get; set; }
        public List<ProductVariantDto> Variants { get; set; } 
        public List<ProductReviewDto> Reviews { get; set; }
    }
}
