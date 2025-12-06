using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using _521.tpfinal.web.Models;
using _521.tpfinal.web.Services.Product.Interfaces;

namespace _521.tpfinal.web.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class EditProductModel : PageModel
    {
        private readonly IProductsService _productsService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [BindProperty]
        public Product Product { get; set; } = new()
        {
            Id = Guid.Empty,
            Name = "",
            Description = "",
            Price = 0m,
            Category = "",
            Stock = 0,
            CartItems = []
        };

        public EditProductModel(IProductsService productsService, IHttpContextAccessor httpContextAccessor)
        {
            _productsService = productsService;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetToken()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("jwt")?.Value ?? "";
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            try
            {
                Product = await _productsService.GetByIdAsync(id);
                if (Product == null)
                {
                    TempData["ErrorMessage"] = "Produit non trouvé.";
                    return RedirectToPage("/Products/Products");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erreur: {ex.Message}";
                return RedirectToPage("/Products/Products");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var token = GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    ModelState.AddModelError(string.Empty, "Token d'authentification manquant. Veuillez vous reconnecter.");
                    return Page();
                }

                var (success, message) = await _productsService.UpdateAsync(Product.Id, Product, token);

                if (success)
                {
                    TempData["SuccessMessage"] = "Produit modifié avec succès!";
                    return RedirectToPage("/Products/Products");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Erreur lors de la modification: {message}");
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
