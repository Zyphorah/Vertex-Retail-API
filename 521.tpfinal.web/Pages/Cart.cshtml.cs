using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using _521.tpfinal.web.Models;
using _521.tpfinal.web.Services.Cart.Interfaces;

namespace _521.tpfinal.web.Pages
{
    [Authorize(Roles = "Client")]
    public class CartModel : PageModel
    {
        private readonly ICartService _cartService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartResponse? CartResponse { get; set; }
        public Receipt? Receipt { get; set; }
        public string? ErrorMessage { get; set; }
        public bool ShowReceipt { get; set; } = false;

        public CartModel(ICartService cartService, IHttpContextAccessor httpContextAccessor)
        {
            _cartService = cartService;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetToken()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("jwt")?.Value ?? "";
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var token = GetToken();
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/Auth/Login");
            }

            try
            {
                CartResponse = await _cartService.GetCartAsync(token);
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Erreur lors du chargement du panier: {ex.Message}";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateQuantityAsync(Guid cartItemId, int quantity)
        {
            var token = GetToken();
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/Auth/Login");
            }

            try
            {
                var (success, message) = await _cartService.UpdateItemQuantityAsync(cartItemId, quantity, token);
                
                if (success)
                {
                    TempData["SuccessMessage"] = "Quantité mise à jour!";
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

        public async Task<IActionResult> OnPostRemoveItemAsync(Guid cartItemId)
        {
            var token = GetToken();
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/Auth/Login");
            }

            try
            {
                var (success, message) = await _cartService.RemoveItemFromCartAsync(cartItemId, token);
                
                if (success)
                {
                    TempData["SuccessMessage"] = "Article retiré du panier!";
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

        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            var token = GetToken();
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/Auth/Login");
            }

            try
            {
                var (success, receipt) = await _cartService.CheckoutAsync(token);
                
                if (success && receipt != null)
                {
                    // Stocker le reçu dans TempData pour l'afficher
                    TempData["Receipt"] = System.Text.Json.JsonSerializer.Serialize(receipt);
                    return RedirectToPage("/Receipt");
                }
                else
                {
                    TempData["ErrorMessage"] = receipt?.Message ?? "Erreur lors du checkout";
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
