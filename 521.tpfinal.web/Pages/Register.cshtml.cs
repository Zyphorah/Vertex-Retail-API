using _521.tpfinal.web.Services.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

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

    public class RegisterInput
    {
        [Required(ErrorMessage = "Le nom est requis.")]
        [Display(Name = "Nom")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "L'email est requis.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        [Display(Name = "Email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis.")]
        [StringLength(100, ErrorMessage = "Le mot de passe doit avoir au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public required string PasswordHash { get; set; }

        [Required(ErrorMessage = "La confirmation du mot de passe est requise.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmez le mot de passe")]
        public required string ConfirmPassword { get; set; }
    }
}
