using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarApplication.Data;
using CarApplication.Models;

namespace CarApplication.Pages.Services
{
    public class EditModel : PageModel
    {
        private readonly CarApplicationContext _context;

        public EditModel(CarApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Service Service { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .Include(s => s.Car)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (service == null)
            {
                return NotFound();
            }
            Service = service;

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

            _context.Attach(Service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(Service.Id))
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

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}