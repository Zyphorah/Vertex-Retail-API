namespace _521.tpfinal.web.Models
{
    public class Product
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required string Category { get; set; }
        public required int Stock { get; set; }
        
        // Un produit peut avoir plusieurs CartItems donc une liste de plusieurs instance de même produit
        public required List<CartItem> CartItems { get; set; }
    }
}