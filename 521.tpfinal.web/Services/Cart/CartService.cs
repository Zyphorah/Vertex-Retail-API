using _521.tpfinal.web.Models;

namespace _521.tpfinal.web.Services.Cart
{
    public class CartService(HttpClient httpClient) : Interfaces.ICartService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<(bool success, string message)> AddItemToCartAsync(Guid productId, int quantity, string token)
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            var payload = new { productId, quantity };
            var response = await this._httpClient.PostAsJsonAsync("api/cart/add", payload);
            
            if (response.IsSuccessStatusCode)
            {
                return (true, "Item added to cart successfully.");
            }
            else
            {
                return (false, $"Failed to add item to cart: {response.ReasonPhrase}");
            }
        }

        public async Task<(bool success, Receipt receipt)> CheckoutAsync(string token)
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            var response = await this._httpClient.PostAsync("api/cart/checkout", null);
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var receipt = System.Text.Json.JsonSerializer.Deserialize<Receipt>(content,
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return (true, receipt!);
            }
            else
            {
                return (false, new Receipt 
                { 
                    Status = "Failed", 
                    Message = $"Checkout failed: {response.ReasonPhrase}" 
                });
            }
        }

        public async Task<ShoppingCart> GetCartAsync(string token)
        {
            try
            {
                this._httpClient.DefaultRequestHeaders.Clear();
                this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                
                var response = await this._httpClient.GetAsync("api/cart");
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var cart = System.Text.Json.JsonSerializer.Deserialize<ShoppingCart>(content,
                        new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return cart!;
                }
                else
                {
                    throw new HttpRequestException($"Failed to get cart: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Error retrieving cart: {ex.Message}");
            }
        }

        public async Task<(bool success, string message)> RemoveItemFromCartAsync(Guid cartItemId, string token)
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            var response = await this._httpClient.DeleteAsync($"api/cart/{cartItemId}");
            
            if (response.IsSuccessStatusCode)
            {
                return (true, "Item removed from cart successfully.");
            }
            else
            {
                return (false, $"Failed to remove item from cart: {response.ReasonPhrase}");
            }
        }

        public async Task<(bool success, string message)> UpdateItemQuantityAsync(Guid cartItemId, int quantity, string token)
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            var payload = new { quantity };
            var response = await this._httpClient.PutAsJsonAsync($"api/cart/{cartItemId}", payload);
            
            if (response.IsSuccessStatusCode)
            {
                return (true, "Item quantity updated successfully.");
            }
            else
            {
                return (false, $"Failed to update item quantity: {response.ReasonPhrase}");
            }
        }
    }
}
