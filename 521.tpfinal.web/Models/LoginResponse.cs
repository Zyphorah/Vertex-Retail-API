namespace _521.tpfinal.web.Models
{
    public class LoginResponse
    {
        public required string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string? Message { get; set; }
    }
}
