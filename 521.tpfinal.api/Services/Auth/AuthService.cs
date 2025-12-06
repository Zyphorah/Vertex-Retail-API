using _521.tpfinal.api.models.Dtos.LoginModel;
using _521.tpfinal.api.Models.Constance;
using _521.tpfinal.api.Utils;

namespace _521.tpfinal.api.Services.Auth
{
    public class AuthService(Repository.User.Interfaces.IUsersRepository usersRepository, IConfiguration configuration, PasswordHasher passwordHasher) : Interfaces.IAuthService
    {
        private readonly Repository.User.Interfaces.IUsersRepository _usersRepository = usersRepository;
        private readonly JwtTokenHelper _jwtTokenHelper = new(configuration);
        private readonly PasswordHasher _passwordHasher = passwordHasher;

        public Task<LoginResponseDto> Login(LoginModelDto loginDto)
        {
            // Récupère tous les utilisateurs et trouve celui avec l'email
            var users = _usersRepository.GetAll();
            var user = users.FirstOrDefault(u => u.Email == loginDto.Email) ?? throw new Exception("Email ou mot de passe incorrect");

            // Vérifie le mot de passe avec hash (avec email comme salt supplémentaire)
            if (!_passwordHasher.Verify(loginDto.PasswordHash, user.PasswordHash, user.Email))
                throw new Exception("Email ou mot de passe incorrect");

            // Génère le JWT token 
            var token = _jwtTokenHelper.GenerateJwtToken(user);

            return Task.FromResult(new LoginResponseDto
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddDays(7)
            });
        }

        public Task<RegisterResponseDto> Register(RegisterDto registerDto)
        {
            var userId = Guid.NewGuid();
            var cartId = Guid.NewGuid();
            
            // Créer l'utilisateur avec un panier vide
            var newUser = new models.User
            {
                Id = userId,
                Email = registerDto.Email,
                PasswordHash = _passwordHasher.Hash(registerDto.PasswordHash, registerDto.Email),
                Name = registerDto.Name,
                Role = Roles.Client,
                ShoppingCarts = new List<models.ShoppingCart>
                {
                    new models.ShoppingCart
                    {
                        Id = cartId,
                        UserId = userId,
                        TotalPrice = 0,
                        User = null!,
                        CartItems = new List<models.CartItem>()
                    }
                }
            };
            
            this._usersRepository.Add(newUser);
            
            return Task.FromResult(new RegisterResponseDto
            {
                Message = "Utilisateur créé avec succès"
            });
        }
    }
}