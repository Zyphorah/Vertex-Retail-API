using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using _521.tpfinal.web.Models;

namespace _521.tpfinal.web.Pages
{
    [Authorize(Roles = "Client")]
    public class ReceiptModel : PageModel
    {
        public Receipt? Receipt { get; set; }

        public IActionResult OnGet()
        {
            var receiptJson = TempData["Receipt"]?.ToString();
            
            if (string.IsNullOrEmpty(receiptJson))
            {
                return RedirectToPage("/Cart");
            }

            Receipt = System.Text.Json.JsonSerializer.Deserialize<Receipt>(receiptJson,
                new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return Page();
        }
    }
}
