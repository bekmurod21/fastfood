using FastFood.Service.DTOs.Attachment;

namespace FastFood.WebApi.Extensions
{
    public static class FileExtensions
    {
        public async static Task<AttachmentForCreationDto> ToAttachmentAsync(this IFormFile file)
        {
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                bytes = ms.ToArray();
            }
            return new AttachmentForCreationDto()
            {
                File = bytes,
                FileName = file.FileName,
                FileExtension = Path.GetExtension(file.FileName)
            };
        }
    }
}
