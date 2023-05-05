using AutoMapper;
using FastFood.Data.IRepositories;
using FastFood.Data.Repositories;
using FastFood.Domain.Entities.Commons;
using FastFood.Service.Interfaces;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FastFood.Service.Services
{
    public class AttachmentService : IAttachmentService
    {

        public ValueTask<bool> DeleteFileAsync(Expression<Func<Attachment, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Attachment> ModifyFieAsync(long id, Stream stream)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Attachment> UploadFileAsync(Stream stream, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
