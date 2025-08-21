using InfinityBack.Application.Interface;
using InfinityBack.dataBase;
using InfinityBack.DTO.CategoryDTO;

namespace InfinityBack.Application.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDetailsDto> GetCategoryWithSubCategoriesAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDto>> GetTopLevelCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> UpdateCategoryAsync(int categoryId, UpdateCategoryDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
