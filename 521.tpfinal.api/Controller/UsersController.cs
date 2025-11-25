using Microsoft.AspNetCore.Mvc;
using _521.tpfinal.api.Repository.User.Interfaces;
using _521.tpfinal.api.Services.User.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using _521.tpfinal.api.Models.Constance;

namespace _521.tpfinal.api.Controller
{   
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            this._usersService = usersService;
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("admin")]
        public async Task<IActionResult> CreateAdmin(models.Dtos.User.CreateUserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (string.IsNullOrWhiteSpace(userDto.PasswordHash) || userDto.PasswordHash.Length < 6)
                {
                    return BadRequest(new { error = "Le mot de passe doit contenir au moins 6 caractères" });
                }

                // Vérifier que le rôle correspond à Admin
                if (userDto.Role != Roles.Admin)
                {
                    return BadRequest(new { error = "Le rôle doit être Admin" });
                }

                await this._usersService.AddAdministrator(userDto);
                return StatusCode(201, new { message = "Admin créé avec succès" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, models.Dtos.User.UpdateUserDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Récupère le rôle et l'ID de l'utilisateur courant
                var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                
                // Vérifie les permissions
                if (userRole != "Admin" && userIdClaim != id.ToString())
                {
                    return Forbid("Vous ne pouvez modifier que votre propre compte");
                }

                // Empêche un Client de modifier le rôle
                if (userRole != "Admin" && !string.IsNullOrEmpty(updateDto.Role))
                {
                    return Forbid("Seul un admin peut modifier le rôle");
                }

                // Validation supplémentaire
                if (!string.IsNullOrWhiteSpace(updateDto.PasswordHash) && updateDto.PasswordHash.Length < 6)
                {
                    return BadRequest(new { error = "Le mot de passe doit contenir au moins 6 caractères" });
                }

                await this._usersService.Update(id, updateDto);
                return Ok(new { message = "Usager mis à jour avec succès" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var user = this._usersService.GetById(id);
                if (user == null)
                {
                    return NotFound(new { error = "Usager non trouvé" });
                }

                await this._usersService.Delete(user);
                return Ok(new { message = "Usager supprimé avec succès" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}