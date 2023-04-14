using FastFood.Domain.Commons;
using FastFood.Domain.Entities.Commons;
using FastFood.Domain.Enums;

namespace FastFood.Domain.Entities.Products
{
    public class Product : Auditable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public long CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        public long? FileId { get; set; }
        public Attachment Attachment { get; set; }
    }

}
