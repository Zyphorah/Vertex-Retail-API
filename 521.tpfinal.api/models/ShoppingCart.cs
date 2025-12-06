namespace _521.tpfinal.api.models
{
    public class ShoppingCart
    {
        public required Guid Id { get; set; }
        // Foreign key pour l'utilisateur
        public required Guid UserId { get; set; }
        public required decimal TotalPrice { get; set; }

        public User? User { get; set; }
        public List<CartItem> CartItems { get; set; } = [];
    }
}