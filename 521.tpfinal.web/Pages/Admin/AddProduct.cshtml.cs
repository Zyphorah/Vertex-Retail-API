using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using _521.tpfinal.web.Models;
using _521.tpfinal.web.Services.Product.Interfaces;

namespace _521.tpfinal.web.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class AddProductModel : PageModel
    {
        private readonly IProductsService _productsService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [BindProperty]
        public Product Product { get; set; } = new()
        {
            Id = Guid.NewGuid(),
            Name = "",
            Description = "",
            Price = 0m,
            Category = "",
            Stock = 0,
            CartItems = []
        };

        public AddProductModel(IProductsService productsService, IHttpContextAccessor httpContextAccessor)
        {
            _productsService = productsService;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Récupérer le token JWT du cookie
                var token = _httpContextAccessor.HttpContext?.User.FindFirst("jwt")?.Value ?? "";

                if (string.IsNullOrEmpty(token))
                {
                    ModelState.AddModelError(string.Empty, "Token d'authentification manquant. Veuillez vous reconnecter.");
                    return Page();
                }

                // Vérifier que l'utilisateur est admin
                var userRole = _httpContextAccessor.HttpContext?.User.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value ?? 
                               _httpContextAccessor.HttpContext?.User.FindFirst("role")?.Value ?? "";
                
                if (userRole != "Admin")
                {
                    ModelState.AddModelError(string.Empty, "Vous n'avez pas les permissions pour ajouter un produit.");
                    return Page();
                }

                // Générer un nouvel ID pour le produit
                Product.Id = Guid.NewGuid();
                Product.CartItems = new List<CartItem>();

                // Appeler le service pour ajouter le produit
                var (success, message) = await _productsService.AddAsync(Product, token);

                if (success)
                {
                    TempData["SuccessMessage"] = "Produit ajouté avec succès!";
                    return RedirectToPage("/Products/Products");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Erreur lors de l'ajout du produit: {message}");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Une erreur s'est produite: {ex.Message}");
                return Page();
            }
        }
    }
}
