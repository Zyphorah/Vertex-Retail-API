using _521.tpfinal.web.Services;
using _521.tpfinal.web.Services.Auth.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace _521.tpfinal.web.Pages
{
    public class LoginModel(IAuthService authService) : PageModel
    {
        private readonly IAuthService _authService = authService;

        [BindProperty]
        public required Models.Login Input { get; set; }

        public void OnGet()
        {
            // Page de connexion simple
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            // 1. Appeler l'API pour tenter de se connecter
            var (success, token) = await _authService.LoginAsync(Input);

            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Tentative de connexion invalide.");
                return Page();
            }

            // 2. Le token JWT a été reçu. Maintenant, on crée le cookie d'authentification.

            // Lire le token pour en extraire les claims (infos de l'usager)
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            // Créer les "claims" pour le cookie
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? "Unknown"),
                new(ClaimTypes.Role, jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "User"),
                // IMPORTANT: Stocker le token JWT lui-même dans les claims du cookie
                // pour pouvoir le réutiliser lors des appels API.
                new("jwt", token)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                // Gérer la persistance du cookie
                IsPersistent = true,
                ExpiresUtc = jwtToken.ValidTo
            };

            // 3. Connecter l'usager (créer le cookie)
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return LocalRedirect(returnUrl);
        }
    }
}
