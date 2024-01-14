using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PostgreSQL.Data;
using System.Threading.Tasks;

namespace MyStore_ASP_NET_CORE_WebApp.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HomeProduct HomeProduct { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.HomeProducts.Add(HomeProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
