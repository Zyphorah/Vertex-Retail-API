using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using _521.tpfinal.web.Models;
using _521.tpfinal.web.Services.User.Interfaces;

namespace _521.tpfinal.web.Pages.Admin.ManageUsers
{
    [Authorize(Roles = "Admin")]
    public class ManageUsersModel : PageModel
    {
        private readonly IUsersService _usersService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public List<User> Users { get; set; } = [];
        public string? ErrorMessage { get; set; }

        public ManageUsersModel(IUsersService usersService, IHttpContextAccessor httpContextAccessor)
        {
            _usersService = usersService;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetToken()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("jwt")?.Value ?? "";
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var token = GetToken();
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/Auth/Login");
            }

            try
            {
                Users = await _usersService.GetAllAsync(token);
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Erreur lors du chargement des utilisateurs: {ex.Message}";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid userId)
        {
            var token = GetToken();
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/Auth/Login");
            }

            try
            {
                var (success, message) = await _usersService.DeleteAsync(userId, token);
                
                if (success)
                {
                    TempData["SuccessMessage"] = "Utilisateur supprimé avec succès!";
                }
                else
                {
                    TempData["ErrorMessage"] = $"Erreur: {message}";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erreur lors de la suppression: {ex.Message}";
            }

            return RedirectToPage();
        }
    }
}
