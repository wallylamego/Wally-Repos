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

namespace CicotiWebApp.Pages.ABC.OtherIncome
{
    [Authorize]
    public class OtherIncomeItemModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public OtherIncomeItemModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public SelectList SubPeriodSL { get; set; }
        public SelectList SubPrincipleSL { get; set; }

        public void PopulatePrincipleSL(object selectedPrinciple = null)
        {
            var SubPrincipleQuery = from s in _context.Principle
                                      orderby s.PrincipleID
                                      select s;
            SubPrincipleSL = new SelectList(SubPrincipleQuery.AsNoTracking(),
                        "PrincipleID", "PastelName", selectedPrinciple);
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
        public ActCostAccountAmtPrinciple AccAmtPrinciple { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ActCostAccountAmtPrinciple.Add(AccAmtPrinciple);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnGetAsync(int? ID)
        {
            AccAmtPrinciple = new Models.ActCostAccountAmtPrinciple { };


            if (ID != null)
            {
                AccAmtPrinciple = await _context.ActCostAccountAmtPrinciple
                    .SingleOrDefaultAsync(m => m.ActCostAccountAmtPrincipleID == ID);
            }
            PopulatePeriodSL();
            PopulatePrincipleSL();
            return Page();
        }
        #region Update Amt Principle Details
        //Updates the existing Driver Details
        public async Task<IActionResult> OnPutUpdateAmtPrin([FromBody] Models.ActCostAccountAmtPrinciple obj)
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
                    return new JsonResult("Amt Per Principle not saved." + d.InnerException.Message);
                }
            }
            return new JsonResult("Amt Per Principle saved.");
        }

        //Inserts a new Employee with details
        public async Task<IActionResult> OnPostInsertAmtPrin([FromBody] Models.ActCostAccountAmtPrinciple obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Fleet")))
            {
                try
                {
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    int id = obj.ActCostAccountAmtPrincipleID; // Yes it's here
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Amt Principle Not Added." + d.InnerException.Message);
                }
            }

            else
            {
                return new JsonResult("Amt Principle Not Inserted");
            }

        }
        #endregion DriverUpdates

    }
}