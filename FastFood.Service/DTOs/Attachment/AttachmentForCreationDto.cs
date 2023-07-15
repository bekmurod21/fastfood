namespace FastFood.Service.DTOs.Attachment
{
    public class AttachmentForCreationDto
    {
        public byte[] File { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
    }
}
