public class UserDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
    public required List<ShoppingCartDto> ShoppingCarts { get; set; }
}