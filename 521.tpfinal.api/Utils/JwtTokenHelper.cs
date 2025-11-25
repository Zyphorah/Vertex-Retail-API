using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace _521.tpfinal.api.Utils
{
    public class JwtTokenHelper
    {
        private readonly IConfiguration _configuration;

        public JwtTokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(models.User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Création des claims (informations sur l'utilisateur)
            var claims = new List<Claim>()
            {
                // On peut ajouter plusieurs infos dans le jeton selon nos besoins.
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            // Récupération de notre chaine secrète pour générer la clé de sécurité
            var secretKey = _configuration["JwtSettings:SecretKey"] 
                ?? throw new Exception("JWT SecretKey is missing in configuration");
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // Création du jeton
            var token = new JwtSecurityToken(
                // 'Par qui' et 'pour qui' (on ignore ces valeurs)
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                
                // Mes infos sur l'utilisateur
                claims: claims,
                
                // Valide pour 7 jours
                expires: DateTime.UtcNow.AddDays(7),
                
                // On crypte en Sha256
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            // On génère et retourne la clé représentant le token.
            return tokenHandler.WriteToken(token);
        }
    }
}
