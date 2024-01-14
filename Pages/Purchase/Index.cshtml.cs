using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore_ASP_NET_CORE_WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MyStore_ASP_NET_CORE_WebApp.Pages.Purchase
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Cart> CartItems { get; set; }

        public async Task OnGetAsync()
        {
            CartItems = await _context.Carts
                                      .Include(c => c.Product) // Acesta este pasul crucial
                                      .ToListAsync();
        }

    }
}
