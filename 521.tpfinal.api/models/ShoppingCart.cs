public class ShoppingCartDto
{
    public required int Id { get; set; }
    public required List<ProductDto> Products { get; set; }
    public required decimal TotalPrice { get; set; }
}