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

namespace CicotiWebApp.Pages.ABC.Principal
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
        public CicotiWebApp.Models.Principle Principal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            Principal = await _context.Principle.FirstOrDefaultAsync(m => m.PrincipleID == id);

           
            PopulatePrincipalSL();
            PopulateSiloSL();
           
            return Page();
        }
        public SelectList SiloSL { get; set; }
        public void PopulateSiloSL(object selectedSilo = null)
        {
            var SiloQuery = from v in _context.Silo
                                       orderby v.SiloName
                                       select v;
            SiloSL = new SelectList(SiloQuery.AsNoTracking(),
                        "SiloID", "SiloName", selectedSilo);
        }
        public SelectList PrincipalSL { get; set; }
        public void PopulatePrincipalSL(object selectedPrincipal = null)
        {
            var PrincipalQuery = from v in _context.Principle
                           orderby v.PrincipalName
                           select v;
            PrincipalSL = new SelectList(PrincipalQuery.AsNoTracking(),
                        "PrincipleID", "PrincipalName", selectedPrincipal);
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if ((HttpContext.User.IsInRole("Admin")))
            {
                try
                {
                    if (Principal.PrincipleID == 0)
                    {
                        _context.Principle.Add(Principal);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Attach((CicotiWebApp.Models.Principle)Principal).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrincipalExists(Principal.PrincipleID))
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

        private bool PrincipalExists(int id)
        {
            return _context.Principle.Any(e => e.PrincipleID == id);
        }
    }
}
