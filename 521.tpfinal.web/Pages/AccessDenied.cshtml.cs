using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _521.tpfinal.web.Pages
{
    public class AccessDeniedModel : PageModel
    {
        public string? ReturnUrl { get; set; }

        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }
    }
}
