namespace _521.tpfinal.web.Models
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalPrice { get; set; }

        public User? User { get; set; }
        public List<CartItem> CartItems { get; set; } = [];
    }
}