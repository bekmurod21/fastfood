using FastFood.Service.DTOs.ProductDto;


namespace FastFood.Service.DTOs.OrderDto
{
    public class OrderItemForResultDto
    {
        public long Id { get; set; }
        public int Amount { get; set; }
        public decimal AmountTotal { get; set; }

        public long ProductId { get; set; }
        public ProductForResultDto Product { get; set; }
    }
}
