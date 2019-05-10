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

namespace CicotiWebApp.Pages.Employee.SalesReps
{
    [Authorize]
    public class SalesRepModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public SalesRepModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public SalesRep SalesRep { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (HttpContext.User.IsInRole("HR") || (HttpContext.User.IsInRole("Admin")))
            {
                try
                {
                    _context.SalesReps.Add(SalesRep);
                    await _context.SaveChangesAsync();
                    return new JsonResult("SaleRep has been created successfully.");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("SalesRep not created." + d.InnerException.Message);
                }
            }

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnGetAsync(int ? SalesRepID)
        {
            SalesRep = new Models.SalesRep { };


           if (SalesRepID != null)
            {
                SalesRep = await _context.SalesReps
                    .SingleOrDefaultAsync(m => m.SalesRepID == SalesRepID);
            }
            return Page();
        }
        #region Update Driver Details
        //Updates the existing Driver Details
        public async Task<IActionResult> OnPutUpdateSalesRep([FromBody] SalesRep obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("HR")))
            {
                try
                {
                    _context.Attach(obj).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("SaleRep Changes not saved." + d.InnerException.Message);
                }
            }
            return new JsonResult("Sales Rep not saved. You do not have access rights to save these changes");
        }

        //Inserts a new Employee with details
        public async Task<IActionResult> OnPostInsertSalesRep([FromBody] SalesRep obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("HR")))
            {
                try
                {
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    int id = obj.SalesRepID; // Yes it's here
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("SalesRep Not Added." + d.InnerException.Message);
                }
            }

            else
            {
                return new JsonResult("Sales Rep Not Inserted");
            }

        }
        #endregion SalesRepUpdates

    }
}