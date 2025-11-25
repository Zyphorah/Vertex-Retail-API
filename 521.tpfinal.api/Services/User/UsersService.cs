using _521.tpfinal.api.models.Dtos.User;
using _521.tpfinal.api.models.Dtos.ShopingCart;
using _521.tpfinal.api.models.Dtos.CartItem;

namespace _521.tpfinal.api.Services.User
{
    public class UsersService(Repository.User.Interfaces.IUsersRepository usersRepository) : Interfaces.IUsersService
    {
        private readonly Repository.User.Interfaces.IUsersRepository _usersRepository = usersRepository;

        public Task Add(CreateUserDto user)
        {
            return this._usersRepository.Add(new models.User
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Role = user.Role,
                ShoppingCarts = new List<models.ShoppingCart>()
            });
        }

        public Task<bool> Delete(UserDto user)
        {
            // Récupérer l'utilisateur complet depuis la BD avec ses ShoppingCarts
            var existingUser = this._usersRepository.GetById(user.Id);
            
            if (existingUser == null)
            {
                throw new Exception($"Utilisateur avec l'ID {user.Id} non trouvé");
            }

            return this._usersRepository.Delete(existingUser);
        }

        public List<UserDto> GetAll()
        {
            List<models.User> users = this._usersRepository.GetAll();
            List<UserDto> userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                UserDto userDto = new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Role = user.Role,
                    PasswordHash = user.PasswordHash,
                    ShoppingCarts = user.ShoppingCarts.Select(sc => new ShoppingCartDto
                    {
                        Id = sc.Id,
                        UserId = sc.UserId,
                        Items = sc.CartItems.Select(ci => new CartItemDto
                        {
                            ShoppingCartId = ci.ShoppingCartId,
                            ProductId = ci.ProductId,
                            ProductName = ci.Product.Name,
                            ProductPrice = ci.UnitPrice,
                            Quantity = ci.Quantity,
                            SubTotal = ci.Quantity * ci.UnitPrice
                        }).ToList(),
                        TotalPrice = sc.TotalPrice
                    }).ToList()
                };
                userDtos.Add(userDto);
            }
            return userDtos;
        }

        public UserDto? GetById(Guid id)
        {
            var user = this._usersRepository.GetById(id);
            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                PasswordHash = user.PasswordHash,
                ShoppingCarts = user.ShoppingCarts.Select(sc => new ShoppingCartDto
                {
                    Id = sc.Id,
                    UserId = sc.UserId,
                    Items = sc.CartItems.Select(ci => new CartItemDto
                    {
                        ShoppingCartId = ci.ShoppingCartId,
                        ProductId = ci.ProductId,
                        ProductName = ci.Product.Name,
                        ProductPrice = ci.UnitPrice,
                        Quantity = ci.Quantity,
                        SubTotal = ci.Quantity * ci.UnitPrice
                    }).ToList(),
                    TotalPrice = sc.TotalPrice
                }).ToList()
            };
        }

        public Task<bool> Update(Guid id, UpdateUserDto user)
        {
            var existingUser = this._usersRepository.GetById(id);
            if (existingUser == null)
            {
                throw new Exception($"Utilisateur avec l'ID {id} non trouvé");
            }

            existingUser.Name = user.Name ?? existingUser.Name;
            existingUser.Email = user.Email ?? existingUser.Email;
            existingUser.PasswordHash = user.PasswordHash ?? existingUser.PasswordHash;
            existingUser.Role = user.Role ?? existingUser.Role;

            return this._usersRepository.Update(existingUser);
        }
    }
}