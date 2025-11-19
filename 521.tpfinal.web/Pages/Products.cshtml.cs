using _521.tpfinal.web.Models;
using _521.tpfinal.web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _521.tpfinal.web.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IApiService _apiService;

        public List<Product> Products { get; set; } = new List<Product>();

        public ProductsModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Appel public, pas besoin d'authentification
            Products = await _apiService.GetProductsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            // (À implémenter par l'étudiant)
            // 1. Vérifier si l'usager est authentifié
            // 2. Appeler _apiService.AddToCartAsync(productId, 1);
            // 3. Rediriger vers la page ou afficher un message
            Console.WriteLine($"Ajout du produit {productId} au panier...");

            return RedirectToPage();
        }
    }
}
