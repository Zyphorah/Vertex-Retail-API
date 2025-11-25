using Microsoft.AspNetCore.Authentication.Cookies;
using _521.tpfinal.web.Services;
using _521.tpfinal.web.Services.Auth.Interfaces;
using _521.tpfinal.web.Services.Auth;
using _521.tpfinal.web.Services.Cart.Interfaces;
using _521.tpfinal.web.Services.Cart;
using _521.tpfinal.web.Services.Product.Interfaces;
using _521.tpfinal.web.Services.Product;
using _521.tpfinal.web.Services.User.Interfaces;
using _521.tpfinal.web.Services.User;

var builder = WebApplication.CreateBuilder(args);

// 1. Authentification par cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/AccessDenied";
    });

// 2. HttpClientFactory + ApiService (enregistrement DI)
var apiBaseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl")
    ?? throw new InvalidOperationException("Configuration value 'ApiBaseUrl' is not set.");

builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddHttpClient<ICartService, CartService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddHttpClient<IProductsService, ProductsService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddHttpClient<IUsersService, UsersService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

// 3. IHttpContextAccessor (pour lire le JWT du cookie)
builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();  