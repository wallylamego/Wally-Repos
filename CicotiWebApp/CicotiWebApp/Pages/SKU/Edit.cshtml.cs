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

namespace CicotiWebApp.Pages.SKU
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
        public CicotiWebApp.Models.SKU SKU { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SKU = await _context.SKUs.FirstOrDefaultAsync(m => m.SKUID == id);

            if (SKU == null)
            {
                return NotFound();
            }
            PopulatePrincipalSL();
            PopulateUOMSL();
            PopulateBrandSL();
            return Page();
        }
        public SelectList UOMSL { get; set; }
        public void PopulateUOMSL(object selectedUOM = null)
        {
            var UOMQuery = from v in _context.UOM
                                       orderby v.Description
                                       select v;
            UOMSL = new SelectList(UOMQuery.AsNoTracking(),
                        "UOMID", "Description", selectedUOM);
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
        public SelectList BrandSL { get; set; }
        public void PopulateBrandSL(object selectedBrand = null)
        {
            var BrandQuery = from v in _context.Brand
                                 orderby v.Description
                                 select v;
            BrandSL = new SelectList(BrandQuery.AsNoTracking(),
                        "BrandID", "Description", selectedBrand);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (HttpContext.User.IsInRole("Manager") || (HttpContext.User.IsInRole("Admin")))
            {
                try
                {
                    if (SKU.SKUID == 0)
                    {
                        _context.SKUs.Add(SKU);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Attach((CicotiWebApp.Models.SKU)SKU).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SKUExists(SKU.SKUID))
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

        private bool SKUExists(int id)
        {
            return _context.SKUs.Any(e => e.SKUID == id);
        }
    }
}
