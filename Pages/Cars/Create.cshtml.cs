using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarApplication.Data;
using CarApplication.Models;

namespace CarApplication.Pages.Cars
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
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Name");
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
