using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarApplication.Data;
using CarApplication.Models;

namespace CarApplication.Pages.Insurances
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
            ViewData["CarId"] = new SelectList(_context.Cars
                .Select(c => new
                {
                    c.Id,
                    DisplayName = $"{c.Brand} {c.Model} - {c.Owner.Name}"
                }), "Id", "DisplayName");

            // Setăm data de început implicită la ziua curentă
            Insurance = new CarApplication.Models.Insurance { StartDate = DateTime.Today };
            return Page();
        }

        [BindProperty]
        public CarApplication.Models.Insurance Insurance { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CarId"] = new SelectList(_context.Cars
                    .Select(c => new
                    {
                        c.Id,
                        DisplayName = $"{c.Brand} {c.Model} - {c.Owner.Name}"
                    }), "Id", "DisplayName");
                return Page();
            }

            _context.Insurances.Add(Insurance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}