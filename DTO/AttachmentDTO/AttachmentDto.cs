namespace InfinityBack.DTO.AttachmentDTO
{
    public class AttachmentDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Type { get; set; } // "Image" or "Video"
        public bool IsPrimary { get; set; }
    }
}
