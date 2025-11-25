namespace _521.tpfinal.web.Models
{
    public class ShoppingCart
    {
        public required Guid Id { get; set; }
        // Foreign key pour l'utilisateur
        public required Guid UserId { get; set; }
        public required decimal TotalPrice { get; set; }

        public required User User { get; set; }
        public required List<CartItem> CartItems { get; set; }
    }
}