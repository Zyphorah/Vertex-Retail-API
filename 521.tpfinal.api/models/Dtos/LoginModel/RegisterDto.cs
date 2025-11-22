public class RegisterDto
{
    [Required(ErrorMessage = "Le nom est requis")]
    public string Name { get; set; }

    [Required(ErrorMessage = "L'email est requis")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Le mot de passe est requis")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
