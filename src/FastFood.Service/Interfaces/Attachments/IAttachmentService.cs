using FastFood.Domain.Entities.Attachments;
using FastFood.Service.DTOs.Attachment;

namespace FastFood.Service.Interfaces.Attachments
{
    public interface IAttachmentService
    {
        ValueTask<Attachment> UploadAsync(AttachmentForCreationDto dto);
        ValueTask<bool> RemoveAsync(long id);
    }
}
