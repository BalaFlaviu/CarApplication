using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarApplication.Data;
using CarApplication.Models;

namespace CarApplication.Pages.Services
{
    public class CreateModel : PageModel
    {
        private readonly CarApplicationContext _context;

        public CreateModel(CarApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Încărcăm lista de mașini pentru dropdown
            ViewData["CarId"] = new SelectList(_context.Cars
                .Select(c => new
                {
                    c.Id,
                    DisplayName = $"{c.Brand} {c.Model} - {c.Owner.Name}"
                }), "Id", "DisplayName");
            return Page();
        }

        [BindProperty]
        public Service Service { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Reîncărcăm lista de mașini în caz de eroare
                ViewData["CarId"] = new SelectList(_context.Cars
                    .Select(c => new
                    {
                        c.Id,
                        DisplayName = $"{c.Brand} {c.Model} - {c.Owner.Name}"
                    }), "Id", "DisplayName");
                return Page();
            }

            _context.Services.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
