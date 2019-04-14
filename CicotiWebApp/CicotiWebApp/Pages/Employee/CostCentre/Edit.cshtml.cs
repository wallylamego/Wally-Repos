using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.Employee.CostCentre
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public EditModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CicotiWebApp.Models.CostCentre CostCentre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CostCentre = await _context.CostCentre.FirstOrDefaultAsync(m => m.CostCentreID == id);

            if (CostCentre == null)
            {
                return NotFound();
            }
            return Page();
        }

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
                    _context.Attach((CicotiWebApp.Models.CostCentre)CostCentre).State = EntityState.Modified;
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
