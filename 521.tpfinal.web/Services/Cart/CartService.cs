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
            var response = await this._httpClient.PostAsJsonAsync("api/cart/items", payload);
            
            if (response.IsSuccessStatusCode)
            {
                return (true, "Item added to cart successfully.");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                return (false, $"Failed to add item to cart: {error}");
            }
        }

        public async Task<(bool success, Receipt? receipt)> CheckoutAsync(string token)
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            var response = await this._httpClient.PostAsync("api/cart/checkout", null);
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var receipt = System.Text.Json.JsonSerializer.Deserialize<Receipt>(content,
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return (true, receipt);
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                return (false, new Receipt 
                { 
                    Status = "Failed", 
                    Message = $"Checkout failed: {error}" 
                });
            }
        }

        public async Task<CartResponse?> GetCartAsync(string token)
        {
            try
            {
                this._httpClient.DefaultRequestHeaders.Clear();
                this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                
                var response = await this._httpClient.GetAsync("api/cart");
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var cartResponse = System.Text.Json.JsonSerializer.Deserialize<CartResponse>(content,
                        new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return cartResponse;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<(bool success, string message)> RemoveItemFromCartAsync(Guid cartItemId, string token)
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            var response = await this._httpClient.DeleteAsync($"api/cart/items/{cartItemId}");
            
            if (response.IsSuccessStatusCode)
            {
                return (true, "Item removed from cart successfully.");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                return (false, $"Failed to remove item from cart: {error}");
            }
        }

        public async Task<(bool success, string message)> UpdateItemQuantityAsync(Guid cartItemId, int quantity, string token)
        {
            this._httpClient.DefaultRequestHeaders.Clear();
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            var payload = new { quantity };
            var response = await this._httpClient.PutAsJsonAsync($"api/cart/items/{cartItemId}", payload);
            
            if (response.IsSuccessStatusCode)
            {
                return (true, "Item quantity updated successfully.");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                return (false, $"Failed to update item quantity: {error}");
            }
        }
    }
}
