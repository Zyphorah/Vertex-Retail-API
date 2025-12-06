namespace _521.tpfinal.api.models.Dtos.CartItem
{
    public class CartItemDto
    {
        public required Guid Id { get; set; }
        public required Guid ShoppingCartId { get; set; }
        public required Guid ProductId { get; set; }
        public required string ProductName { get; set; }
        public required decimal ProductPrice { get; set; }
        public required int Quantity { get; set; }
        public required decimal SubTotal { get; set; }
    }
}

