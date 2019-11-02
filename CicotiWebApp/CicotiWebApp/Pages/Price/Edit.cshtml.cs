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

namespace CicotiWebApp.Pages.Price
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
        public CicotiWebApp.Models.Price Price { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            Price = await _context.Prices.Include(s=>s.SKU).FirstOrDefaultAsync(m => m.PriceID == id);

            ////if (SkuUomLink == null)
            ////{
            ////    return NotFound();
            ////}
            PopulateRegionSL();
            PopulateBranchSL();
            PopulatePriceTypeSL();
            return Page();
        }
        public SelectList BranchSL { get; set; }
        
        public void PopulateBranchSL(object selectedBranch = null)
        {
            var BranchQuery = from s in _context.Branch
                              orderby s.BranchName
                              select s;
            BranchSL = new SelectList(BranchQuery.AsNoTracking(),
                        "BranchID", "BranchName", selectedBranch);
        }
        public SelectList RegionSL { get; set; }
        public void PopulateRegionSL(object selectedRegion = null)
        {
            var RegionQuery = from v in _context.Region
                           orderby v.RegionName
                           select v;
            RegionSL = new SelectList(RegionQuery.AsNoTracking(),
                        "RegionID", "RegionName", selectedRegion);
        }
        public SelectList PriceTypeSL { get; set; }
        public void PopulatePriceTypeSL(object selectedPriceType = null)
        {
            var PriceTypeQuery = from v in _context.PriceTypes
                              orderby v.Description
                              select v;
            PriceTypeSL = new SelectList(PriceTypeQuery.AsNoTracking(),
                        "PriceTypeID", "Description", selectedPriceType);
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
                    if (Price.PriceID == 0)
                    {
                        _context.Prices.Add(Price);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Attach((CicotiWebApp.Models.Price)Price).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceExists(Price.PriceID))
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

        private bool PriceExists(int id)
        {
            return _context.Prices.Any(e => e.PriceID == id);
        }
    }
}
