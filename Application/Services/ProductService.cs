using InfinityBack.Application.Interface;
using InfinityBack.dataBase;
using InfinityBack.DTO.ProductDTO;
using InfinityBack.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using InfinityBack.dataBase.Model;

namespace InfinityBack.Services
{
    public class ProductService : IProductService
    {
        #region properity
        private readonly InfinityDBContext _context;
        private readonly IFileService _fileService;
        #endregion

        #region constructor
        public ProductService(InfinityDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }
        #endregion

        #region AddProductAsync
        public async Task<Product> AddProductAsync(ProductAddDto dto, int userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var product = new Product
                {
                    ProductName = dto.ProductName,
                    ProductDescription = dto.ProductDescription,
                    CategoryId = dto.CategoryId,
                    TargetAudienceId = dto.TargetAudienceId,
                    CreatedByUserId = userId,
                    CreatedAt = DateTime.Now
                };

                if (dto.Variants != null && dto.Variants.Any())
                {
                    foreach (var variantDto in dto.Variants)
                    {
                        var variant = new ProductVariant
                        {
                            ColorId = variantDto.ColorId,
                            SizeId = variantDto.SizeId,
                            Price = variantDto.Price,
                            TotalQuantity = variantDto.Quantity,
                            Sku = variantDto.Sku
                        };
                        if (variantDto.Images != null && variantDto.Images.Any())
                        {
                            foreach (var file in variantDto.Images)
                            {
                                var imageUrl = await _fileService.SaveFileAsync(file, "variants");
                                if (imageUrl != null)
                                {
                                    variant.Images.Add(new ProductVariantImage
                                    {
                                        ImageUrl = imageUrl
                                    });
                                }
                            }
                        }
                        product.ProductVariants.Add(variant);
                    }
                }

                if (dto.Attachments != null)
                {
                    foreach (var file in dto.Attachments)
                    {
                        var imageUrl = await _fileService.SaveFileAsync(file, "products");
                        if (imageUrl != null)
                        {
                            product.Attachments.Add(new Attachment
                            {
                                ProductId = product.Id,
                                Url = imageUrl,
                                Type = AttachmentType.Image
                            });
                        }
                    }
                }

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return product;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        #endregion

        #region GetAllAsync
        public async Task<IEnumerable<getProductDto>> GetAllAsync()
        {
            var products = await _context.Products
                .Include(p => p.ProductVariants)
                    .ThenInclude(v => v.Size)
                .Include(p => p.ProductVariants)
                    .ThenInclude(v => v.Color)
                .Include(p => p.ProductVariants)
                    .ThenInclude(v => v.Images)
                .Include(p => p.Attachments)
                .ToListAsync();

            var result = products.Select(p => new getProductDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                Price = p.ProductVariants.FirstOrDefault()?.Price,
                ImageUrl = p.Attachments.FirstOrDefault()?.Url
                           ?? p.ProductVariants.FirstOrDefault()?.Images.FirstOrDefault()?.ImageUrl
                           ?? "/images/products/no-image.png",
                Sizes = p.ProductVariants.Select(v => v.Size?.Name)
                                         .Where(s => s != null)
                                         .ToList(),
                Colors = p.ProductVariants.Select(v => v.Color?.HexCode)
                                          .Where(c => c != null)
                                          .ToList(),
                VariantImages = p.ProductVariants.SelectMany(v => v.Images)
                                                 .Select(img => img.ImageUrl)
                                                 .ToList()
            });

            return result;
        }

        #endregion


        #region GetByIdAsync
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.TargetAudience)
                .Include(p => p.ProductVariants)
                .Include(p => p.Attachments)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        #endregion

        #region UpdateProductAsync
        public async Task<Product> UpdateProductAsync(int id, ProductAddDto dto, int userId)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                throw new Exception("Product not found");

            product.ProductName = dto.ProductName;
            product.ProductDescription = dto.ProductDescription;
            product.CategoryId = dto.CategoryId;
            product.TargetAudienceId = dto.TargetAudienceId;
            product.UpdatedByUserId = userId;
            product.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return product;
        }
        #endregion

        #region DeleteProductAsync
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
        #endregion
    }
}
