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

namespace CicotiWebApp.Pages.Drivers
{
    [Authorize]
    public class DriverModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public DriverModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public SelectList SubContractorSL { get; set; }

        public void PopulateSubContractorSL(object selectedSubContractor = null)
        {
            var SubContractorsQuery = from s in _context.SubContractor
                                      where s.SubContractorID != 2
                                      orderby s.Name
                                      select s;
            SubContractorSL = new SelectList(SubContractorsQuery.AsNoTracking(),
                        "SubContractorID", "Name", selectedSubContractor);
        }

       
        [BindProperty]
        public Driver Driver { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (HttpContext.User.IsInRole("Fleet") || (HttpContext.User.IsInRole("Admin")))
            {
                try
                {
                    _context.Drivers.Add(Driver);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Driver has been created successfully.");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Driver not created." + d.InnerException.Message);
                }
            }

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnGetAsync(int? DriverID)
        {
            Driver = new Models.Driver { };


            if (DriverID != null)
            {
                Driver = await _context.Drivers
                    .SingleOrDefaultAsync(m => m.DriverID == DriverID);
            }
            PopulateSubContractorSL();
            return Page();
        }
        #region Update Driver Details
        //Updates the existing Driver Details
        public async Task<IActionResult> OnPutUpdateDriver([FromBody] Models.Driver obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Fleet")))
            {
                try
                {
                    _context.Attach(obj).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Driver Changes not saved." + d.InnerException.Message);
                }
            }
            return new JsonResult("Drivers Changes not saved. You do not have access rights to save these changes");
        }

        //Inserts a new Employee with details
        public async Task<IActionResult> OnPostInsertDriver([FromBody] Models.Driver obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Fleet")))
            {
                try
                {
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    int id = obj.DriverID; // Yes it's here
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Driver Not Added." + d.InnerException.Message);
                }
            }

            else
            {
                return new JsonResult("Driver Not Inserted");
            }

        }
        #endregion DriverUpdates

    }
}