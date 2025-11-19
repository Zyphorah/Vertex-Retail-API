using _521.tpfinal.web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace _521.tpfinal.web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IApiService _apiService;

        [BindProperty]
        public Models.LoginModel Input { get; set; }

        public LoginModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        public void OnGet()
        {
            // Page de connexion simple
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // 1. Appeler l'API pour tenter de se connecter
            var (success, token) = await _apiService.LoginAsync(Input);

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
                new Claim(ClaimTypes.Name, jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value),
                new Claim(ClaimTypes.Role, jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value),
                // IMPORTANT: Stocker le token JWT lui-même dans les claims du cookie
                // pour pouvoir le réutiliser lors des appels API.
                new Claim("jwt", token)
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
