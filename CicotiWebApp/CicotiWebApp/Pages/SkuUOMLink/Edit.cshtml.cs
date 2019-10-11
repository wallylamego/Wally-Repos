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

namespace CicotiWebApp.Pages.SkuUOMLink
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
        public CicotiWebApp.Models.SkuUomLink SkuUomLink { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            SkuUomLink = await _context.SkuUomLinks.Include(s=>s.SKU).FirstOrDefaultAsync(m => m.SkuUomLinkID == id);

            ////if (SkuUomLink == null)
            ////{
            ////    return NotFound();
            ////}
            PopulatePrincipalSL();
            PopulateFromUOMSL();
            PopulateToUOMSL();
            PopulateBrandSL();
            return Page();
        }
        public SelectList UOFromMSL { get; set; }
        public SelectList UOToMSL { get; set; }
        public void PopulateFromUOMSL(object selectedFromUOM = null)
        {
            var UOMQuery = from v in _context.UOM
                                       orderby v.Description
                                       select v;
            UOFromMSL = new SelectList(UOMQuery.AsNoTracking(),
                        "UOMID", "Description", selectedFromUOM);
        }
        public void PopulateToUOMSL(object selectedToUOM = null)
        {
            var UOMQuery = from v in _context.UOM
                           orderby v.Description
                           select v;
            UOToMSL = new SelectList(UOMQuery.AsNoTracking(),
                        "UOMID", "Description", selectedToUOM);
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
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            if (HttpContext.User.IsInRole("Manager") || (HttpContext.User.IsInRole("Admin")))
            {
                try
                {
                    if (SkuUomLink.SkuUomLinkID == 0)
                    {
                        _context.SkuUomLinks.Add(SkuUomLink);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Attach((CicotiWebApp.Models.SkuUomLink)SkuUomLink).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SKULinkExists(SkuUomLink.SkuUomLinkID))
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

        private bool SKULinkExists(int id)
        {
            return _context.SkuUomLinks.Any(e => e.SkuUomLinkID == id);
        }
    }
}
