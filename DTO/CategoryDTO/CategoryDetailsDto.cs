namespace InfinityBack.DTO.CategoryDTO
{
    public class CategoryDetailsDto
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string Name { get; set; }
        public List<CategoryDto> SubCategories { get; set; } = new List<CategoryDto>();
    }
}
