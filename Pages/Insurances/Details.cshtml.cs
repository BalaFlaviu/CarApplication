using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarApplication.Data;
using CarApplication.Models;

namespace CarApplication.Pages.Insurances
{
    public class DetailsModel : PageModel
    {
        private readonly CarApplicationContext _context;

        public DetailsModel(CarApplicationContext context)
        {
            _context = context;
        }

        public CarApplication.Models.Insurance Insurance { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurance = await _context.Insurances
                .Include(i => i.Car)
                .ThenInclude(c => c.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insurance == null)
            {
                return NotFound();
            }
            Insurance = insurance;
            return Page();
        }
    }
}