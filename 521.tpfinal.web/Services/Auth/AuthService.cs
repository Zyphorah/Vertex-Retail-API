using _521.tpfinal.web.Models;

namespace _521.tpfinal.web.Services.Auth
{
    public class AuthService(HttpClient httpClient) : Interfaces.IAuthService
    {
        private readonly HttpClient _httpClient = httpClient;

        public Task<(bool success, string token)> LoginAsync(Login loginModel)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            return _httpClient.PostAsJsonAsync("api/auth/login", loginModel)
                .ContinueWith(async responseTask =>
                {
                    var response = await responseTask;
                    if (response.IsSuccessStatusCode)
                    {
                        var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                        return (true, loginResponse?.Token ?? string.Empty);   
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        return (false, errorMessage);
                    }
                }).Unwrap();
        }

        public Task<(bool success, string message)> RegisterAsync(Models.User user)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            return _httpClient.PostAsJsonAsync("api/auth/register", user)
                .ContinueWith(async responseTask =>
                {
                    var response = await responseTask;
                    if (response.IsSuccessStatusCode)
                    {
                        return (true, "Registration successful.");      

                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        return (false, errorMessage);
                    }
                }).Unwrap();
        }
    }
}