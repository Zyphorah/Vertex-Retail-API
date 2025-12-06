using _521.tpfinal.web.Models;
using _521.tpfinal.web.Services.Product.Interfaces;
using _521.tpfinal.web.Services.Cart.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _521.tpfinal.web.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IProductsService _apiService;
        private readonly ICartService _cartService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public List<Product> Products { get; set; } = new List<Product>();

        public ProductsModel(IProductsService apiService, ICartService cartService, IHttpContextAccessor httpContextAccessor)
        {
            _apiService = apiService;
            _cartService = cartService;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetToken()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("jwt")?.Value ?? "";
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                // Appel public, pas besoin d'authentification
                Products = await _apiService.GetAllAsync();
                return Page();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
                Products = new List<Product>();
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
        {
            // 1. Vérifier si l'usager est authentifié
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                TempData["ErrorMessage"] = "Vous devez être connecté pour ajouter au panier.";
                return RedirectToPage("/Auth/Login");
            }

            // 2. Récupérer le token JWT
            var token = GetToken();
            if (string.IsNullOrEmpty(token))
            {
                TempData["ErrorMessage"] = "Session expirée. Veuillez vous reconnecter.";
                return RedirectToPage("/Auth/Login");
            }

            try
            {
                // 3. Appeler le service pour ajouter au panier
                var (success, message) = await _cartService.AddItemToCartAsync(productId, 1, token);
                
                if (success)
                {
                    TempData["SuccessMessage"] = "Produit ajouté au panier!";
                }
                else
                {
                    TempData["ErrorMessage"] = message;
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erreur: {ex.Message}";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteProductAsync(Guid productId)
        {
            // Vérifier si l'utilisateur est admin
            if (!User.IsInRole("Admin"))
            {
                TempData["ErrorMessage"] = "Vous n'avez pas les permissions pour supprimer un produit.";
                return RedirectToPage();
            }

            var token = GetToken();
            if (string.IsNullOrEmpty(token))
            {
                TempData["ErrorMessage"] = "Session expirée. Veuillez vous reconnecter.";
                return RedirectToPage("/Auth/Login");
            }

            try
            {
                var (success, message) = await _apiService.DeleteAsync(productId, token);
                
                if (success)
                {
                    TempData["SuccessMessage"] = "Produit supprimé avec succès!";
                }
                else
                {
                    TempData["ErrorMessage"] = message;
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erreur: {ex.Message}";
            }

            return RedirectToPage();
        }
    }
}
