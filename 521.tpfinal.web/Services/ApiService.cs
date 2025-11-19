using _521.tpfinal.web.Models;

namespace _521.tpfinal.web.Services
{
    // Implémentation du service qui appelle l'API
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        // Données bidons pour le squelette de site
        private static List<Product> GetDummyProducts() => new List<Product>
        {
            new Product { Id =1, Name = "Café", Description = "Café moulu250g", Price =6.49m, Category = "Épicerie" },
            new Product { Id =2, Name = "Thé Vert", Description = "Sachet de20", Price =4.29m, Category = "Épicerie" },
            new Product { Id =3, Name = "Clavier", Description = "Clavier mécanique", Price =79.99m, Category = "Informatique" },
            new Product { Id =4, Name = "Souris", Description = "Souris sans fil", Price =24.99m, Category = "Informatique" },
            new Product { Id =5, Name = "Cahier", Description = "Cahier ligné200 pages", Price =2.49m, Category = "Papeterie" },
        };


        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(bool, string)> LoginAsync(LoginModel model)
        {
            //TODO: À implémenter par l'étudiant : appel POST vers l'API pour se connecter

            await Task.Delay(100); // Simule un appel asynchrone

            return (false, "Non implémenté");
        }

        public Task<List<Product>> GetProductsAsync()
        {
            // Données bidons pour le prototypage
            return Task.FromResult(GetDummyProducts());
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            // Retourne un produit bidon correspondant à l'id, ou un produit par défaut
            var product = GetDummyProducts().FirstOrDefault(p => p.Id == id)
                ?? new Product
                {
                    Id = id,
                    Name = $"Produit {id}",
                    Description = "Produit bidon (mock)",
                    Price = 9.99m + id,
                    Category = "Divers"
                };

            return Task.FromResult(product);
        }


        public async Task<bool> AddProductAsync(Product product)
        {
            //TODO: À implémenter par l'étudiant : appel POST vers l'API pour ajouter un produit
            await Task.Delay(100); // Simule un appel asynchrone

            return false;
        }


    }
}
