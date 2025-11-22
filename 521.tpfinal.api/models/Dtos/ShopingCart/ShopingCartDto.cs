public class ShopingCartDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
    public decimal TotalPrice { get; set; }
}