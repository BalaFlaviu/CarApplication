using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarApplication.Data;
using CarApplication.Models;

namespace CarApplication.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly CarApplicationContext _context;

        public IndexModel(CarApplicationContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Service = await _context.Services
                .Include(s => s.Car)
                .ThenInclude(c => c.Owner)
                .ToListAsync();
        }
    }
}