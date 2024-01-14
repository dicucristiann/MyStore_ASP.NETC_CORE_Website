using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore_ASP_NET_CORE_WebApp.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyStore_ASP_NET_CORE_WebApp.Pages.Purchase
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cart CartItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CartItem = await _context.Carts.FirstOrDefaultAsync(m => m.Id == id);

            if (CartItem == null)
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

            CartItem = await _context.Carts.FindAsync(id);
            if (CartItem != null)
            {
                _context.Carts.Remove(CartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
