namespace _521.tpfinal.api.models.Dtos.ShopingCart
{
    public class CartItemDto
    {
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }
}
