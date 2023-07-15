using AutoMapper;
using FastFood.Service.Helpers;
using FastFood.Data.IRepositories;
using FastFood.Service.Exceptions;
using FastFood.Service.DTOs.Attachment;
using FastFood.Domain.Entities.Attachment;
using FastFood.Service.Interfaces.Attachments;

namespace FastFood.Service.Services.Attachments
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IRepository<Attachment> attachmentRepository;

        public AttachmentService(IRepository<Attachment> attachmentRepository)
        {
            this.attachmentRepository = attachmentRepository;
        }

        public async ValueTask<bool> RemoveAsync(long id)
        {
            var attachment = await this.attachmentRepository.DeleteAsync(a => a.Id == id);
            if (!attachment)
                throw new CustomException(404, "Attachment not found");

            return attachment;
        }

        public async ValueTask<Attachment> UploadAsync(AttachmentForCreationDto dto)
        {
            string path = Path.Combine(EnvironmentHelper.WebRootPath, "Files");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileName = $"{Guid.NewGuid()}{dto.FileExtension}";
            string fullPath = Path.Combine(path, fileName);

            FileStream targetFile = new FileStream(fullPath, FileMode.OpenOrCreate);
            await targetFile.WriteAsync(dto.File);

            Attachment attachment = new Attachment
            {
                FileName = fileName,
                FilePath = fullPath,
                CreatedAt = DateTime.UtcNow,
            };
            var insertedFile = await this.attachmentRepository.InsertAsync(attachment);
            
            return insertedFile;
        }
    }
}
