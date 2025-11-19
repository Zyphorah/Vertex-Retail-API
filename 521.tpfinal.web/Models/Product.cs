namespace _521.tpfinal.web.Models
{
    // Modèle simple pour un produit.
    // Vous devrez le compléter pour correspondre à votre API.
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
