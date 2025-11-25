using System.ComponentModel.DataAnnotations;

namespace _521.tpfinal.api.models.Dtos.User
{
    public class UpdateUserDto
    {
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
        public string? Name { get; set; }

        [StringLength(100, ErrorMessage = "L'email ne peut pas dépasser 100 caractères")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide")]
        public string? Email { get; set; }
        
        [StringLength(100, ErrorMessage = "Le mot de passe ne peut pas dépasser 100 caractères")]
        public string? PasswordHash { get; set; }
        
        [StringLength(100, ErrorMessage = "Le rôle ne peut pas dépasser 100 caractères")]
        public string? Role { get; set; }
    }
}