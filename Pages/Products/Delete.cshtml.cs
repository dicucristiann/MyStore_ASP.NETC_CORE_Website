using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PostgreSQL.Data;
using System.Threading.Tasks;

namespace MyStore_ASP_NET_CORE_WebApp.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HomeProduct HomeProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HomeProduct = await _context.HomeProducts.FindAsync(id);

            if (HomeProduct == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HomeProduct = await _context.HomeProducts.FindAsync(id);

            if (HomeProduct != null)
            {
                _context.HomeProducts.Remove(HomeProduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
