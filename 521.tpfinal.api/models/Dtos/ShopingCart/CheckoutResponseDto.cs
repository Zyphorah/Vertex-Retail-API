namespace _521.tpfinal.api.models.Dtos.ShopingCart
{
    public class CheckoutResponseDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<CartItemDto> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Completed";
    }
}
