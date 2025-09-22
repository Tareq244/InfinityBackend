using InfinityBack.dataBase;
using InfinityBack.DTO.CategoryDTO;

namespace InfinityBack.Application.Interface
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createDto);
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
        Task<CategoryDto> UpdateCategoryAsync(int categoryId, UpdateCategoryDto updateDto);
        Task<bool> DeleteCategoryAsync(int categoryId);
        Task <IEnumerable<CategoryDto>> getMainCategoryAsync();
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<IEnumerable<CategoryDto>> GetSubCategoriesAsync(int parentCategoryId);
    }
}
