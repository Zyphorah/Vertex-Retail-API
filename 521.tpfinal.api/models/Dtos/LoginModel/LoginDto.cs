using System.ComponentModel.DataAnnotations;

public class LoginModelDto
{
    [Required(ErrorMessage = "L'email est requis")]
    [EmailAddress]
    required public string Email { get; set; }

    [Required(ErrorMessage = "Le mot de passe est requis")]
    [DataType(DataType.Password)]
    required public string PasswordHash { get; set; }
}