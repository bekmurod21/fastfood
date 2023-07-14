namespace FastFood.Service.DTOs.CartDto
{
    public class CartForResultDto
    {
        public long Id { get; set; }
        public IEnumerable<CartItemForUpdateDto> Items { get; set; }
    }
}
