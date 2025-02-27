﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarApplication.Data;
using CarApplication.Models;

namespace CarApplication.Pages.Owners
{
    public class DeleteModel : PageModel
    {
        private readonly CarApplicationContext _context;

        public DeleteModel(CarApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Owner Owner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners
                .Include(o => o.Cars)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (owner == null)
            {
                return NotFound();
            }
            Owner = owner;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners.FindAsync(id);
            if (owner != null)
            {
                Owner = owner;
                _context.Owners.Remove(Owner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}