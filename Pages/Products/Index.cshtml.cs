using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PostgreSQL.Data;
namespace MyStore_ASP_NET_CORE_WebApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<HomeProduct> HomeProducts { get; set; }

        public async Task OnGetAsync()
        {
            HomeProducts = await _context.HomeProducts.ToListAsync();
        }
    }
}
