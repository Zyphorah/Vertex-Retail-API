using System.ComponentModel.DataAnnotations;

namespace _521.tpfinal.api.models.Dtos.User
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Le nom est requis")]
        public required string Name { get; set; }
        
        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Le rôle est requis")]
        public required string Role { get; set; }
        

        [Required(ErrorMessage = "Le mot de passe est requis")]
        [StringLength(100, ErrorMessage = "Le mot de passe ne peut pas dépasser 100 caractères")]
        public required string PasswordHash { get; set; }
    }
}