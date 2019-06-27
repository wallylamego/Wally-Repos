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

namespace CicotiWebApp.Pages.ABC.InsuranceType
{
    [Authorize]
    public class InsuranceTypeItemModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public InsuranceTypeItemModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public SelectList SubPeriodSL { get; set; }
        public SelectList SubCostDriverSL { get; set; }

        public void PopulateCostDriverSL(object selectedCostDriver = null)
        {
            var SubCostDriverQuery = from s in _context.ActCostDrivers
                                      orderby s.Description
                                      select s;
            SubCostDriverSL = new SelectList(SubCostDriverQuery.AsNoTracking(),
                        "ActCostDriverID", "Description", selectedCostDriver);
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
        public ActCostInsuranceType ActCostInsuranceType { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ActCostInsuranceType.Add(ActCostInsuranceType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnGetAsync(int? ID)
        {
            ActCostInsuranceType = new Models.ActCostInsuranceType { };

            if (ID != null)
            {
                ActCostInsuranceType = await _context.ActCostInsuranceType
                    .Include(a=>a.ActCostDriver)
                    .Include(e=>e.ActCostPeriod)
                    .SingleOrDefaultAsync(m => m.ActCostInsuranceTypeID == ID);
            }
            PopulatePeriodSL();
            PopulateCostDriverSL();
            return Page();
        }
        #region Update Insurance Type  Details
        //Updates the existing Insurance Type  Details
        public async Task<IActionResult> OnPutUpdateInsuranceType([FromBody] Models.ActCostInsuranceType obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") ))
            {
                try
                {
                    //Set the split to be per SILO
                    obj.ActCostInsuranceTypeID = 12;
                    _context.Attach(obj).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Insurance Type not saved." + d.InnerException.Message);
                }
            }
            return new JsonResult("Insurance Type not saved saved.");
        }

        //Inserts a new Insurance Type
        public async Task<IActionResult> OnPostInsertInsuranceType([FromBody] Models.ActCostInsuranceType obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Fleet")))
            {
                try
                {
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    int id = obj.ActCostInsuranceTypeID; // Yes it's here
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Act Cost Insurance Not Added." + d.InnerException.Message);
                }
            }

            else
            {
                return new JsonResult("Act Cost Insurance Not Inserted");
            }

        }
        #endregion Insurance Type
    }
}