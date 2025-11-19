using _521.tpfinal.web.Models;

namespace _521.tpfinal.web.Services
{
    // Interface pour le service API
    // Vous devrez ajouter des méthodes ici, ex.: pour le panier et les usagers
    public interface IApiService
    {
        Task<(bool, string)> LoginAsync(LoginModel model);

        // Méthodes pour les Produits
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);

        // Exemple d'appel protégé (Admin)
        Task<bool> AddProductAsync(Product product);

        //TODO: (À ajouter...)
        // Task<bool> UpdateProductAsync(int id, Product product);
        // Task<bool> DeleteProductAsync(int id);
        // Task<Cart> GetCartAsync();
        // ... etc.
    }
}
