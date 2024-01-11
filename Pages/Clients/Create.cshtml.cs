using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PostgreSQL.Data
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Clients Client { get; set; } // Folosind BindProperty pentru legarea automata a datelor din formular

        public string ErrorMessage = "";
        public string SuccessMessage = "";

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "All fields are required.";
                return Page();
            }

            // Adaugam clientul in BD
            _context.Clients.Add(Client);
            await _context.SaveChangesAsync();

            SuccessMessage = "New Client Added Successfully";
            return RedirectToPage("./Index"); 
        }
    }
}
