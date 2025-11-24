namespace _521.tpfinal.api.models.Dtos.LoginModel
{
    public class LoginResponseDto
    {
        public required string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}