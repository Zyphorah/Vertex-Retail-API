using Microsoft.AspNetCore.Mvc;

namespace _521.tpfinal.web.Services.Logout.Interfaces
{
    public interface ILogout
    {
        Task<IActionResult> OnPostAsync();
    }
}