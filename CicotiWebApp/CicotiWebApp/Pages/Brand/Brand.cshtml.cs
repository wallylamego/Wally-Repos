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

namespace CicotiWebApp.Pages.Brand
{
    [Authorize]
    public class BrandModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public BrandModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public SelectList PrincipleSL { get; set; }

        public void PopulatePrincipleSL(object selectedPrinciple = null)
        {
            var PrinciplesQuery = from s in _context.Principle
                                      where s.PrincipleID != 2
                                      orderby s.PastelName
                                      select s;
            PrincipleSL = new SelectList(PrinciplesQuery.AsNoTracking(),
                        "PrincipleID", "PastelName", selectedPrinciple);
        }

       
        [BindProperty]
        public CicotiWebApp.Models.Brand Brand { get; set; }

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
                    _context.Brand.Add(Brand);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Brand has been created successfully.");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Brand not created." + d.InnerException.Message);
                }
            }

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnGetAsync(int? BrandID)
        {
            Brand = new Models.Brand { };


            if (BrandID != null)
            {
                Brand = await _context.Brand
                    .SingleOrDefaultAsync(m => m.BrandID == BrandID);
            }
            PopulatePrincipleSL();
            return Page();
        }
        #region Update Brand Details
        //Updates the existing Brand Details
        public async Task<IActionResult> OnPutUpdateBrand([FromBody] Models.Brand obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Manager")))
            {
                try
                {
                    _context.Attach(obj).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Brand Changes not saved." + d.InnerException.Message);
                }
            }
            return new JsonResult("Brand Changes not saved. You do not have access rights to save these changes");
        }

        //Inserts a new Brand with details
        public async Task<IActionResult> OnPostInsertBrand([FromBody] Models.Brand obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Fleet")))
            {
                try
                {
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    int id = obj.BrandID; // Yes it's here
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Brand Not Added." + d.InnerException.Message);
                }
            }

            else
            {
                return new JsonResult("Brand Not Inserted");
            }

        }
        #endregion BrandUpdates

    }
}