
namespace _521.tpfinal.web.Services.User
{
    public class UsersService(HttpClient httpClient) : Interfaces.IUsersService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<List<Models.User>> GetAllAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            var response = await _httpClient.GetAsync("api/users");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[DEBUG] GetAllAsync response: {content}");
                
                var users = System.Text.Json.JsonSerializer.Deserialize<List<Models.User>>(content,
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return users ?? [];
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[DEBUG] GetAllAsync error: {response.StatusCode} - {errorContent}");
            }
            return [];
        }

        public Task<(bool success, string message)> CreateAdminAsync(Models.User user, string token)
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return this._httpClient.PostAsJsonAsync("api/users/admin", user)
                .ContinueWith(async responseTask =>
                {
                    var response = await responseTask;
                    if (response.IsSuccessStatusCode)
                    {
                        return (true, "Administrator created successfully.");
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        return (false, errorMessage);
                    }
                }).Unwrap();
        }

        public Task<(bool success, string message)> DeleteAsync(Guid userId, string token)
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return this._httpClient.DeleteAsync($"api/users/{userId}")
                .ContinueWith(async responseTask =>
                {
                    var response = await responseTask;
                    if (response.IsSuccessStatusCode)
                    {
                        return (true, "User deleted successfully.");
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        return (false, errorMessage);
                    }
                }).Unwrap();
        }

        public Task<(bool success, string message)> UpdateAsync(Guid userId, Models.User user, string token)
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return this._httpClient.PutAsJsonAsync($"api/users/{userId}", user)
                .ContinueWith(async responseTask =>
                {
                    var response = await responseTask;
                    if (response.IsSuccessStatusCode)
                    {
                        return (true, "User updated successfully.");
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