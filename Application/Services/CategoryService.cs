using InfinityBack.API;
using InfinityBack.Application.Interface;
using InfinityBack.dataBase;
using InfinityBack.DTO.CategoryDTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace InfinityBack.Application.Services
{
    public class CategoryService : ICategoryService
    {
        #region Properties
        private readonly InfinityDBContext _dbContext;
        private readonly IFileService _fileService;
        #endregion

        #region constructor
        public CategoryService(InfinityDBContext dbContext, IFileService fileService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }
        #endregion

        #region CreateCategoryAsync
        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createDto )
        {
            string imageUrl = await _fileService.SaveFileAsync(createDto.Image, "categories");
            if (imageUrl == null)
            {
                throw new ArgumentException("Image file is required.");
            }

            int? parentId = createDto.ParentCategoryId;
            if (parentId == 0)
            {
                parentId = null;
            }
            if (parentId.HasValue)
            {
                var parentExists = await _dbContext.Categories.AnyAsync(c => c.Id == parentId.Value);
                if (!parentExists)
                {
                    throw new KeyNotFoundException($"Parent category with ID '{parentId.Value}' not found.");
                }
            }

            var newCategory = new Category
            {
                CategoryName = createDto.Name,
                ParentCategoryId = parentId,
                ImageUrl = imageUrl
            };
            _dbContext.Categories.Add(newCategory);
            await _dbContext.SaveChangesAsync();

            return new CategoryDto
            {
                Id = newCategory.Id,
                Name = newCategory.CategoryName,
                ParentCategoryId = newCategory.ParentCategoryId,
                ImageUrl = newCategory.ImageUrl
            };
        }
        #endregion

        #region GetCategoryByIdAsync
        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _dbContext.Categories.FindAsync(categoryId);
            if (category == null)
            {
                return null;
            }
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.CategoryName,
                ParentCategoryId = category.ParentCategoryId,
                ImageUrl = category.ImageUrl
            };
        }
        #endregion

        #region DeleteCategoryAsync
        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var category = await _dbContext.Categories.FindAsync(categoryId);

            if (category == null)
            {
                return false;
            }
            
            var hasChildren = await _dbContext.Categories.AnyAsync(c => c.ParentCategoryId == categoryId);
            if (hasChildren)
            {
                throw new InvalidOperationException("Cannot delete category because it has subcategories.");
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();

            return true; 
        }
        #endregion

        #region UpdateCategoryAsync
        public async Task<CategoryDto> UpdateCategoryAsync(int categoryId, UpdateCategoryDto updateDto)
        {
            var category = await _dbContext.Categories.FindAsync(categoryId);
            if (category == null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(updateDto.Name))
            {
                category.CategoryName = updateDto.Name;
            }

            if (updateDto.Image != null)
            {
                string imageUrl = await _fileService.SaveFileAsync(updateDto.Image, "categories");
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    category.ImageUrl = imageUrl;
                }
            }
            if (updateDto.ParentCategoryId.HasValue)
            {
                if (updateDto.ParentCategoryId == 0)
                {
                    category.ParentCategoryId = null; // رجعه كـ top-level
                }
                else
                {
                    // تأكد أن الـ Parent موجود
                    var parentExists = await _dbContext.Categories.AnyAsync(c => c.Id == updateDto.ParentCategoryId.Value);
                    if (!parentExists)
                    {
                        throw new KeyNotFoundException($"Parent category with ID '{updateDto.ParentCategoryId.Value}' not found.");
                    }

                    category.ParentCategoryId = updateDto.ParentCategoryId;
                }
            }
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();


            return new CategoryDto
            {
                Id = category.Id,
                Name = category.CategoryName,
                ParentCategoryId = category.ParentCategoryId,
                ImageUrl = category.ImageUrl
            };

        }
        #endregion

        #region GetAllCategoriesAsync
        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _dbContext.Categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.CategoryName,
                    ParentCategoryId = c.ParentCategoryId,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();
            return categories;
        }
        #endregion

        #region GetSubCategoriesAsync
        public async Task<IEnumerable<CategoryDto>> GetSubCategoriesAsync(int categoryId)
        {
            var subCategories = await _dbContext.Categories
                .Where(c => c.ParentCategoryId == categoryId)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.CategoryName,
                    ImageUrl = c.ImageUrl,
                    ParentCategoryId = c.ParentCategoryId
                })
                .ToListAsync();

            return subCategories;
        }
        #endregion

        #region getMainCategoryAsync
        public async Task<IEnumerable<CategoryDto>> getMainCategoryAsync()
        {
            var categories = await _dbContext.Categories
                .Where(c => c.ParentCategoryId == null)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.CategoryName,
                    ImageUrl = c.ImageUrl,
                    ParentCategoryId = c.ParentCategoryId
                })
                .ToListAsync();

            return categories;
        }
        #endregion

        
    }
}
