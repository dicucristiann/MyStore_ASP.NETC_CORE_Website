using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyStore_ASP_NET_CORE_WebApp.Data; // Ajustează acest namespace conform proiectului tău

namespace MyStore_ASP_NET_CORE_WebApp.Pages.Products
{
    public class AddToCartModel : PageModel
    {
        private readonly AppDbContext _context;

        public AddToCartModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync(int productId, int quantity)
        {
            var product = await _context.HomeProducts.FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }

            var cartItem = new Cart
            {
                HomeProductId = productId,
                Quantity = quantity
            };

            _context.Carts.Add(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
