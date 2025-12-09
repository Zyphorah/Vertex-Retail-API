using _521.tpfinal.api.models;
using _521.tpfinal.api.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configurer les paramètres JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"] ?? throw new Exception("JWT SecretKey is missing"));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ClockSkew = TimeSpan.Zero // pour désactiver la tolérance par défaut de 5 minutes
    };
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<AppDbContext>();

// Enregistrer les repositories
builder.Services.AddScoped<_521.tpfinal.api.Repository.User.Interfaces.IUsersRepository,
                           _521.tpfinal.api.Repository.User.DbUsersRepository>();
builder.Services.AddScoped<_521.tpfinal.api.Repository.Product.Interfaces.IProductsRepository,
                           _521.tpfinal.api.Repository.Product.DbProductsRepository>();
builder.Services.AddScoped<_521.tpfinal.api.Repository.ShoppingCart.Interfaces.IShoppingCartRepository,
                           _521.tpfinal.api.Repository.ShoppingCart.DbShoppingCartRepository>();

// Enregistrer les services
builder.Services.AddScoped<_521.tpfinal.api.Services.Auth.Interfaces.IAuthService, 
                           _521.tpfinal.api.Services.Auth.AuthService>();
builder.Services.AddScoped<_521.tpfinal.api.Services.Product.Interfaces.IProductService,
                           _521.tpfinal.api.Services.Product.ProductService>();
builder.Services.AddScoped<_521.tpfinal.api.Services.ShoppingCart.Interfaces.IShoppingCartService,
                           _521.tpfinal.api.Services.ShoppingCart.ShoppingCartService>();
builder.Services.AddScoped<_521.tpfinal.api.Services.User.Interfaces.IUsersService,
                           _521.tpfinal.api.Services.User.UsersService>();

builder.Services.AddOpenApi();

builder.Services.AddSingleton<PasswordHasher>();

var app = builder.Build();

// Initialiser l'administrateur au démarrage
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    // Elle vérifie si la DB existe. Sinon, elle la crée avec toutes les tables.
    context.Database.EnsureCreated(); 
    
    var passwordHasher = scope.ServiceProvider.GetRequiredService<PasswordHasher>();
    AdminInitializer.Initialize(context, passwordHasher);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
