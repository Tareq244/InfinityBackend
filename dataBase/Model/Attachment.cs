using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase
{
    public enum AttachmentType
    {
        Image = 1,
        Video = 2
    }
    public class Attachment
    {

        [Key]
        public int Id { get; set; } 

        [Required]
        public string Url { get; set; } 

        [Required]
        public int ProductId { get; set; } 
        public Product Product { get; set; } = null!;

        [Required]
        public AttachmentType Type { get; set; } 

        public bool IsPrimary { get; set; } = false; 
        public int DisplayOrder { get; set; } = 0;
    }
}
