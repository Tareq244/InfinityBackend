using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase.Model
{
    public class Color
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } // e.g., "أحمر"
        [MaxLength(7)]
        public string? HexCode { get; set; } // e.g., "#FF0000"
        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}
