using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarApplication.Data;
using CarApplication.Models;

namespace CarApplication.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CarApplicationContext _context;

        public IndexModel(CarApplicationContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cars != null)
            {
                Car = await _context.Cars
                    .Include(c => c.Owner)
                    .ToListAsync();
            }
        }
    }
}