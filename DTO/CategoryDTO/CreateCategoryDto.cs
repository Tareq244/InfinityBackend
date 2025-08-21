using System.ComponentModel.DataAnnotations;

namespace InfinityBack.DTO.CategoryDTO
{
    public class CreateCategoryDto
    {
        public IFormFile? Image { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
