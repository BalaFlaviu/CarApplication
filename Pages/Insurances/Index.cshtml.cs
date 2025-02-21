using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarApplication.Data;
using CarApplication.Models;

namespace CarApplication.Pages.Insurances
{
    public class IndexModel : PageModel
    {
        private readonly CarApplicationContext _context;

        public IndexModel(CarApplicationContext context)
        {
            _context = context;
        }

        public IList<CarApplication.Models.Insurance> Insurance { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Insurance = await _context.Insurances
                .Include(i => i.Car)
                .ThenInclude(c => c.Owner)
                .OrderByDescending(i => i.StartDate)
                .ToListAsync();
        }
    }
}