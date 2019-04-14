using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CicotiWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CicotiWebApp.Pages.Employee.CostCentre
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public CreateModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CicotiWebApp.Models.CostCentre CostCentre { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.CostCentre.Add(CostCentre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostCentreExists(CostCentre.CostCentreID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
           
            return RedirectToPage("./Index");
        }
        private bool CostCentreExists(int id)
        {
            return _context.CostCentre.Any(e => e.CostCentreID == id);
        }
    }
}