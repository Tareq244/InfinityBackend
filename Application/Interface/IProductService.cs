using InfinityBack.dataBase;
using InfinityBack.DTO.CategoryDTO;
using InfinityBack.DTO.ProductDTO;

namespace InfinityBack.Application.Interface
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(ProductAddDto dto, int userId);
        Task<IEnumerable<getProductDto>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> UpdateProductAsync(int id, ProductAddDto dto, int userId);
        Task<bool> DeleteProductAsync(int id);
    }
}
