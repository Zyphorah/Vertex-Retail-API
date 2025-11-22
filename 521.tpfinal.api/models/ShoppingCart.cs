public class ShoppingCartDto
{
    public int Id { get; set; }
    public List<ProductDto> Products { get; set; }
    public decimal TotalPrice { get; set; }
}