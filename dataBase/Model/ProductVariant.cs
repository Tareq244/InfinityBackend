using InfinityBack.dataBase.Model;
using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase
{
    public class ProductVariant
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; } = null!;

        public int SizeId { get; set; }
        public Size Size { get; set; } = null!;

        public decimal Price { get; set; }
        public int TotalQuantity { get; set; }
        public string? Sku { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<ProductVariantImage> Images { get; set; } = new List<ProductVariantImage>();
    }
}
