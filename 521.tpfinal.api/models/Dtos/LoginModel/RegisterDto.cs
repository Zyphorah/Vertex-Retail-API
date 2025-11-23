using System.ComponentModel.DataAnnotations;

public class RegisterDto
{
    [Required(ErrorMessage = "Le nom est requis")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "L'email est requis")]
    [EmailAddress]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Le mot de passe est requis")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
