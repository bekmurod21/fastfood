using FastFood.Domain.Entities.Commons;
using System.Linq.Expressions;

namespace FastFood.Service.Interfaces
{
    public interface IAttachmentService
    {
        ValueTask<Attachment> UploadFileAsync(Stream stream, string fileName);
        ValueTask<Attachment> ModifyFieAsync(long id, Stream stream);
        ValueTask<bool> DeleteFileAsync(Expression<Func<Attachment, bool>> expression);
    }
}
