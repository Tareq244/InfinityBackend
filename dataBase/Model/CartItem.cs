using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int? ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }

        public int? Quantity { get; set; }
    }
}
