using System.ComponentModel.DataAnnotations;

namespace _521.tpfinal.web.Models
{
    // Modèle simple pour la page de connexion
    // Vous pouvez le modifier selon vos besoins
    public class LoginModel
    {
        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}