using _521.tpfinal.web.Models;

namespace _521.tpfinal.web.Services.Auth
{
    public class AuthService : Interfaces.IAuthService
    {
        public Task<(bool success, string token)> LoginAsync(Login loginModel)
        {
            throw new NotImplementedException();
        }

        public Task<(bool success, string message)> RegisterAsync(Models.User user)
        {
            throw new NotImplementedException();
        }
    }
}