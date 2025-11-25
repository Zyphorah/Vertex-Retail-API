using System.ComponentModel.DataAnnotations;

namespace _521.tpfinal.web.Models
{
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