using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarApplication.Data;
using CarApplication.Models;

namespace CarApplication.Pages.Insurances
{
    public class EditModel : PageModel
    {
        private readonly CarApplicationContext _context;

        public EditModel(CarApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarApplication.Models.Insurance Insurance { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurance = await _context.Insurances
                .Include(i => i.Car)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (insurance == null)
            {
                return NotFound();
            }

            Insurance = insurance;

            ViewData["CarId"] = new SelectList(_context.Cars
                .Select(c => new
                {
                    c.Id,
                    DisplayName = $"{c.Brand} {c.Model} - {c.Owner.Name}"
                }), "Id", "DisplayName");

            return Page();
        }

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

            _context.Attach(Insurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceExists(Insurance.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InsuranceExists(int id)
        {
            return _context.Insurances.Any(e => e.Id == id);
        }
    }
}
