namespace _521.tpfinal.api.models
{
    public class CartItem
    {
        public required Guid Id { get; set; }
        // Foreign keys
        public required Guid ProductId { get; set; }
        public required Guid ShoppingCartId { get; set; }

        // Utilisée comme historique du prix au moment de l'ajout au panier 
        // (pour éviter que le prix change plus tard n'affecte les anciens items dans le panier)
        public required int Quantity { get; set; }
        public required decimal UnitPrice { get; set; }

        // Navigation des propriétés
        public Product? Product { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
    }
}