using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarApplication.Data;
using CarApplication.Models;

namespace CarApplication.Pages.Owners
{
    public class IndexModel : PageModel
    {
        private readonly CarApplicationContext _context;

        public IndexModel(CarApplicationContext context)
        {
            _context = context;
        }

        public IList<Owner> Owner { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Owners != null)
            {
                Owner = await _context.Owners
                    .Include(o => o.Cars)
                    .ToListAsync();
            }
        }
    }
}
