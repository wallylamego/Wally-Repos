using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.Employee.SalesReps
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      //  public IList<Driver> Driver { get;set; }

        
        //This get provides a list of Paged Sales Reps
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "DriverID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var SalesRepQuery = _context.SalesReps
               .Select(sp => new
               {
                   sp.SalesRepCode,
                   sp.SalesRepID,
                   sp.SalesRepName
               }
               );

            totalResultsCount = SalesRepQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                SalesRepQuery = SalesRepQuery
                        .Where(
                d => d.SalesRepName.ToLower().Contains(Model.search.value.ToLower()) ||
                        d.SalesRepCode.ToString().ToLower().Contains(Model.search.value.ToLower()));

                filteredResultsCount = SalesRepQuery.Count();
            }
            var Result = await SalesRepQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] SalesRep obj)
        {
            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.SalesReps.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Sales Rep removed successfully");
                }
                catch(DbUpdateException d)
                {
                    return new JsonResult("Sales Rep not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Sales Rep not removed.");
            }
        }
    }
}
