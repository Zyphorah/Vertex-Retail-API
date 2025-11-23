public class CartItem
{
    public required int Id { get; set; }
    // Foreign keys
    public required int ProductId { get; set; }
    public required int ShoppingCartId { get; set; }

    // Utilisée comme historique du prix au moment de l'ajout au panier 
    // (pour éviter que le prix change plus tard n'affecte les anciens items dans le panier)
    public required int Quantity { get; set; }
    public required decimal UnitPrice { get; set; }

    // Navigation des propriétés
    public required Product Product { get; set; }
    public required ShoppingCart ShoppingCart { get; set; }
}