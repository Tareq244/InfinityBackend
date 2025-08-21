using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase.Model
{
    public class Size
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } 
        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}
