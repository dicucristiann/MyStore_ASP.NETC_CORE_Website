using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyStore_ASP_NET_CORE_WebApp.Data;
using PostgreSQL.Data;
using System.Threading.Tasks;

namespace MyStore_ASP_NET_CORE_WebApp.Pages.Purchase
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var cartItemFromDb = await _context.Carts.FindAsync(CartItem.Id);
            if (cartItemFromDb == null)
            {
                return NotFound();
            }

            cartItemFromDb.Quantity = CartItem.Quantity; // Actualizarea cantității
            await _context.SaveChangesAsync(); // Salvarea modificărilor

            return RedirectToPage("./Index");
        }
    }
}
