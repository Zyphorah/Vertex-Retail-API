using _521.tpfinal.web.Models;
using _521.tpfinal.web.Services.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _521.tpfinal.web.Pages
{
    public class RegisterModel(IAuthService authService) : PageModel
    {
        private readonly IAuthService _authService = authService;

        [BindProperty]
        public required RegisterInput Input { get; set; }

        public void OnGet()
        {
            // Page d'inscription simple
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Vérifier que les mots de passe correspondent
            if (Input.PasswordHash != Input.ConfirmPassword)
            {
                ModelState.AddModelError(nameof(Input.ConfirmPassword), "Les mots de passe ne correspondent pas.");
                return Page();
            }

            // Créer un objet User pour l'API
            var user = new Models.User
            {
                Id = Guid.NewGuid(),
                Name = Input.Name,
                Email = Input.Email,
                PasswordHash = Input.PasswordHash,
                Role = "User", // Rôle par défaut
                ShoppingCarts = new List<Models.ShoppingCart>()
            };

            // Appeler l'API pour enregistrer l'utilisateur
            var (success, message) = await _authService.RegisterAsync(user);

            if (!success)
            {
                ModelState.AddModelError(string.Empty, message);
                return Page();
            }

            // Inscription réussie, rediriger vers la page de connexion
            return RedirectToPage("Login");
        }
    }
}
