using InfinityBack.dataBase;
using InfinityBack.DTO.CategoryDTO;

namespace InfinityBack.Application.Interface
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createDto);
        Task<CategoryDto> UpdateCategoryAsync(int categoryId, UpdateCategoryDto updateDto);
        Task<bool> DeleteCategoryAsync(int categoryId);
        Task<IEnumerable<CategoryDto>> GetTopLevelCategoriesAsync();
        Task<CategoryDetailsDto> GetCategoryWithSubCategoriesAsync(int categoryId);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    }
}
