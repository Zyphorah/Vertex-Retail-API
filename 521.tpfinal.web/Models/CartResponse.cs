namespace _521.tpfinal.web.Models
{
    public class CartResponse
    {
        public CartDto? Cart { get; set; }
        public int ItemCount { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class CartDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<CartItemDto> Items { get; set; } = [];
        public decimal TotalPrice { get; set; }
    }

    public class CartItemDto
    {
        public Guid Id { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }
}
