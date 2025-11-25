using _521.tpfinal.api.models.Dtos.LoginModel;
using _521.tpfinal.api.Models.Constance;
using _521.tpfinal.api.Utils;

namespace _521.tpfinal.api.Services.Auth
{
    public class AuthService(Repository.User.Interfaces.IUsersRepository usersRepository, IConfiguration configuration) : Interfaces.IAuthService
    {
        private readonly Repository.User.Interfaces.IUsersRepository _usersRepository = usersRepository;
        private readonly JwtTokenHelper _jwtTokenHelper = new JwtTokenHelper(configuration);

        public Task<LoginResponseDto> Login(LoginModelDto loginDto)
        {
            // Récupère tous les utilisateurs et trouve celui avec l'email
            var users = _usersRepository.GetAll();
            var user = users.FirstOrDefault(u => u.Email == loginDto.Email) ?? throw new Exception("Email ou mot de passe incorrect");

            // Vérifie le mot de passe avec hash
            if (!PasswordHasher.Verify(loginDto.PasswordHash, user.PasswordHash))
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
            this._usersRepository.Add(new models.User
            {
                Id = Guid.NewGuid(),
                Email = registerDto.Email,
                PasswordHash = PasswordHasher.Hash(registerDto.PasswordHash),
                Name = registerDto.Name,
                ShoppingCarts = new List<models.ShoppingCart>(),
                Role = Roles.Client
            });
            return Task.FromResult(new RegisterResponseDto
            {
                Message = "Utilisateur créé avec succès"
            });
        }
    }
}