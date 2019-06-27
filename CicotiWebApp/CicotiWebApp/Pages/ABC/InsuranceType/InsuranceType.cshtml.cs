using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.ABC.InsuranceType
{
    [Authorize]
    public class InsuranceTypeTableModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public InsuranceTypeTableModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        //This get provides a list of Staff Allocation Items
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "ActCostInsuranceTypeID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var InsQuery = _context.ActCostInsuranceType
                .Include(p=>p.ActCostPeriod)
                .Include(a=>a.ActCostDriver)
               .Select(i => new
               {
                   i.ActCostInsuranceTypeID,
                   Insurance = i.Description,
                   CostDriver = i.ActCostDriver.Description,
                   i.ActCostPeriod.Period,
                   i.Amount
               }
               );

            totalResultsCount = InsQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                InsQuery = InsQuery
                        .Where(
                d => d.Period.ToLower().Contains(Model.search.value.ToLower()) ||
                        d.Insurance.ToLower().Contains(Model.search.value.ToLower()) ||
                        d.CostDriver.ToString().ToLower().Contains(Model.search.value.ToLower()) 
                       );

                filteredResultsCount = InsQuery.Count();
            }
            var Result = await InsQuery
                        .Skip(Model.start)
                        .Take(Model.length)
                        .OrderBy(SortBy, SortDir)
                        .ToListAsync();

            var value = new
            {
                // this is what datatables wants sending back
                draw = Model.draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = Result
            };
            return new JsonResult(value);
        }

        public async Task<IActionResult> OnDeleteDelete([FromBody] ActCostInsuranceType obj)
        {
            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.ActCostInsuranceType.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Insurance Type Removed  successfully");
                }
                catch(DbUpdateException d)
                {
                    return new JsonResult("Insurance Type not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Insurance Type not removed.");
            }
        }
    }
}
