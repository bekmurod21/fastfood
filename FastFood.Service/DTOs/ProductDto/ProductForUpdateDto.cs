namespace FastFood.Service.DTOs.ProductDto
{
    public class ProductForUpdateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public string Description { get; set; }
    }
}
