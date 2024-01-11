using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PostgreSQL.Data
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Data.Clients> ListClients { get; private set; }


        public async Task OnGetAsync()
        {
            ListClients = await _context.Clients.ToListAsync();
        }
    }
}
