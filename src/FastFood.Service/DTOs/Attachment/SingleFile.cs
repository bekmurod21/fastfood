using Microsoft.AspNetCore.Http;

namespace FastFood.Service.DTOs.Attachment
{
    public class SingleFile
    {
        public IFormFile File { get; set; }
    }
}
