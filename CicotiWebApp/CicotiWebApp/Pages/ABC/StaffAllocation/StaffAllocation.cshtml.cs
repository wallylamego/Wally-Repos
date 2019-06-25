using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.ABC.StaffAllocation
{
    [Authorize]
    public class StaffAllocationTableModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public StaffAllocationTableModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        //This get provides a list of Staff Allocation Items
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "ActCostSiloAllocationID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var AlloSiloQuery = _context.ActCostSiloAllocations
                .Include(p=>p.ActCostPeriod)
                .Include(s=>s.Silo)
                .Include(e=>e.Employee)
               .Select(s => new
               {
                   s.ActCostSiloAllocationID,
                   Silo = s.Silo.SiloName,
                   s.ActCostPeriod.Period,
                   s.Employee.EmployeeNo,
                   s.Employee.LastName,
                   s.AllocPercentage,
                   s.Description,
                   s.Comments
               }
               );

            totalResultsCount = AlloSiloQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                AlloSiloQuery = AlloSiloQuery
                        .Where(
                d => d.Period.ToLower().Contains(Model.search.value.ToLower()) ||
                        d.Description.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.LastName.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.Comments.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.EmployeeNo.ToString().ToLower().Contains(Model.search.value.ToLower()));

                filteredResultsCount = AlloSiloQuery.Count();
            }
            var Result = await AlloSiloQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] ActCostSiloAllocation obj)
        {
            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.ActCostSiloAllocations.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Silo Removed  successfully");
                }
                catch(DbUpdateException d)
                {
                    return new JsonResult("Silo Allocation not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Silo Allocation not removed.");
            }
        }
    }
}
