using FastFood.Service.DTOs.ProductDto;

namespace FastFood.Service.DTOs.CartDto
{
    public class CartItemForResultDto
    {
        public long Id { get; set; }
        public long CartId { get; set; }
        public ProductForResultDto Product { get; set; }
        public int Amount { get; set; }
        public decimal AmountTotal { get; set; }
        public bool IsOrdered { get; set; }
    }
}
