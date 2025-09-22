using InfinityBack.dataBase;

namespace InfinityBack.DTO.AttachmentDTO
{
    public class AttachmentDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public AttachmentType Type { get; set; } 
        public bool? IsPrimary { get; set; }
    }
}
