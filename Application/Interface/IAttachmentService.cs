using InfinityBack.dataBase;

namespace InfinityBack.Application.Interface
{
    public interface IAttachmentService
    {
        Task <Attachment> AddAttachment (Attachment attachment);
    }
}
