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

namespace CicotiWebApp.Pages.Employee.SalesRepEmployee
{
    [Authorize]
    public class SalesRepEmployeeModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public SalesRepEmployeeModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
       
        [BindProperty]
        public SalesRepCodeEmployeeNoLink SalesRepEmployLink { get; set; }

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
                    _context.SalesRepCodeEmployeeNoLink.Add(SalesRepEmployLink);
                    await _context.SaveChangesAsync();
                    return new JsonResult("SalesRepEmployeeLink has been created successfully.");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("SalesRepEmployeeLink not created." + d.InnerException.Message);
                }
            }

            return RedirectToPage("./Listing");
        }
        public async Task<IActionResult> OnGetAsync(int? LinkID)
        {
            SalesRepEmployLink = new SalesRepCodeEmployeeNoLink { };


            if (LinkID != null)
            {
                SalesRepEmployLink = await _context.SalesRepCodeEmployeeNoLink.Include(e=>e.Employee).Include(s=>s.SalesRep)
                    .SingleOrDefaultAsync(m => m.SalesRepCodeEmployeeNoLinkID == LinkID);
            }
            return Page();
        }
        #region Update RepEmployeeLink Details
        //Updates the existing SalesLink Details
        public async Task<IActionResult> OnPutUpdateRepEmployeeLink([FromBody] SalesRepCodeEmployeeNoLink obj)
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
                    return new JsonResult("Rep Employee Changes not saved." + d.InnerException.Message);
                }
            }
            return new JsonResult("Rep Employee not saved. You do not have access rights to save these changes");
        }

        //Inserts a new Employee with details
        public async Task<IActionResult> OnPostInsertRepEmployeeLink([FromBody] SalesRepCodeEmployeeNoLink obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("HR")))
            {
                try
                {
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    int id = obj.SalesRepCodeEmployeeNoLinkID; // Yes it's here
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Sales Rep Employee Not Added." + d.InnerException.Message);
                }
            }

            else
            {
                return new JsonResult("Sales Rep Not Inserted");
            }
        }
        #endregion SalesRepEmployee Updates

    }
}