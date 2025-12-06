
namespace _521.tpfinal.web.Services.Product
{
    public class ProductsService(HttpClient httpClient) : Interfaces.IProductsService
    {
        private readonly HttpClient _httpClient = httpClient;

        public Task<(bool success, string message)> AddAsync(Models.Product product, string token)
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            // Créer un objet anonyme avec seulement les champs nécessaires (sans CartItems)
            var productData = new
            {
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.Category,
                product.Stock
            };
            
            return this._httpClient.PostAsJsonAsync("api/products", productData)
                .ContinueWith(async responseTask =>
                {
                    var response = await responseTask;
                    if (response.IsSuccessStatusCode)
                    {
                        return (true, "Product added successfully.");
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        return (false, $"Failed to add product: {response.ReasonPhrase} - {errorContent}");
                    }
                }).Unwrap();
        }

        public async Task<(bool success, string message)> DeleteAsync(Guid id, string token)
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            var response = await this._httpClient.DeleteAsync($"api/products/{id}");
            if (response.IsSuccessStatusCode)
            {
                return (true, "Product deleted successfully.");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return (false, $"Failed to delete product: {response.ReasonPhrase} - {errorContent}");
            }
        }

        public async Task<List<Models.Product>> GetAllAsync()
        {
            try
            {
                var response = await this._httpClient.GetAsync("api/products");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var products = System.Text.Json.JsonSerializer.Deserialize<List<Models.Product>>(content,
                        new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return products ?? new List<Models.Product>();
                }
                else
                {
                    return new List<Models.Product>();
                }
            }
            catch
            {
                return new List<Models.Product>();
            }
        }

        public async Task<Models.Product> GetByIdAsync(Guid id)
        {
            try
            {
                var response = await this._httpClient.GetAsync($"api/products/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var product = System.Text.Json.JsonSerializer.Deserialize<Models.Product>(content,
                        new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return product!;
                }
                else
                {
                    throw new HttpRequestException($"Failed to get product: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Error retrieving product: {ex.Message}");
            }
        }

        public async Task<(bool success, string message)> UpdateAsync(Guid id, Models.Product product, string token)
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            var productData = new
            {
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.Category,
                product.Stock
            };
            
            var response = await this._httpClient.PutAsJsonAsync($"api/products/{id}", productData);
            if (response.IsSuccessStatusCode)
            {
                return (true, "Product updated successfully.");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return (false, $"Failed to update product: {response.ReasonPhrase} - {errorContent}");
            }
        }
    }
}