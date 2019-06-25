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

namespace CicotiWebApp.Pages.ABC.StaffAllocation
{
    [Authorize]
    public class StaffAllocationItemModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public StaffAllocationItemModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public SelectList SubPeriodSL { get; set; }
        public SelectList SubSiloSL { get; set; }

        public void PopulateSiloSL(object selectedSilo = null)
        {
            var SubSiloQuery = from s in _context.Silo
                                      orderby s.SiloID
                                      select s;
            SubSiloSL = new SelectList(SubSiloQuery.AsNoTracking(),
                        "SiloID", "SiloName", selectedSilo);
        }

        public void PopulatePeriodSL(object selectedPeriod = null)
        {
            var PeriodQuery = from s in _context.ActCostPeriods
                                      orderby s.ActCostPeriodID
                                      select s;
            SubPeriodSL = new SelectList(PeriodQuery.AsNoTracking(),
                        "ActCostPeriodID", "Period", selectedPeriod);
        }

        [BindProperty]
        public ActCostSiloAllocation ActCostSiloAllocation { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ActCostSiloAllocations.Add(ActCostSiloAllocation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnGetAsync(int? ID)
        {
            ActCostSiloAllocation = new Models.ActCostSiloAllocation { };

            if (ID != null)
            {
                ActCostSiloAllocation = await _context.ActCostSiloAllocations
                    .Include(a=>a.Silo)
                    .Include(e=>e.Employee)
                    .SingleOrDefaultAsync(m => m.ActCostSiloAllocationID == ID);
            }
            PopulatePeriodSL();
            PopulateSiloSL();
            return Page();
        }
        #region Update Staff Allocation Principle Details
        //Updates the existing Staff Allocation Details
        public async Task<IActionResult> OnPutUpdateStaffAlloc([FromBody] Models.ActCostSiloAllocation obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") ))
            {
                try
                {
                    //Set the split to be per SILO
                    obj.ActCostAllocationSplitID = 12;
                    _context.Attach(obj).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Staff Alocation not saved." + d.InnerException.Message);
                }
            }
            return new JsonResult("Staff Allocation saved.");
        }

        //Inserts a new Staff Allocation
        public async Task<IActionResult> OnPostInsertStaffAlloc([FromBody] Models.ActCostSiloAllocation obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Fleet")))
            {
                try
                {
                    //Allocation Split is set to per Silo
                    obj.ActCostAllocationSplitID = 12;
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    int id = obj.ActCostSiloAllocationID; // Yes it's here
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Staff Allocation Per Silo Not Added." + d.InnerException.Message);
                }
            }

            else
            {
                return new JsonResult("Staff Allocation Per Silo Not Inserted");
            }

        }
        #endregion StaffAllocation

    }
}