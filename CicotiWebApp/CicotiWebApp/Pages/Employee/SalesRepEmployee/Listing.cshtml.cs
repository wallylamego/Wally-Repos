using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.Employee.SalesRepEmployee
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        //This get provides a list of Paged Employee Sales Rep Links
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {
            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "SalesRepEmplo",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var SalesRepEmployeeQuery = _context.SalesRepCodeEmployeeNoLink
                .Include(e=>e.Employee)
                .Include(s=>s.SalesRep)
               .Select(l => new
               {
                   LinkNo = l.SalesRepCodeEmployeeNoLinkID,
                   l.Employee.EmployeeNo,
                   EmployeeName = l.Employee.FirstName + l.Employee.LastName,
                   l.SalesRep.SalesRepCode,
                   l.SalesRep.SalesRepName
               }
               );

            totalResultsCount = SalesRepEmployeeQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                SalesRepEmployeeQuery = SalesRepEmployeeQuery
                        .Where(
                d => d.EmployeeName.ToLower().Contains(Model.search.value.ToLower()) ||
                        d.EmployeeNo.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.SalesRepName.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.SalesRepCode.ToString().ToLower().Contains(Model.search.value.ToLower()));

                filteredResultsCount = SalesRepEmployeeQuery.Count();
            }
            var Result = await SalesRepEmployeeQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] SalesRepCodeEmployeeNoLink obj)
        {
            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.SalesRepCodeEmployeeNoLink.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("SalesRepEmployeeLink removed successfully");
                }
                catch(DbUpdateException d)
                {
                    return new JsonResult("SalesRepEmployeeLink not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("SalesRepEmployeeLink not removed.");
            }
        }
    }
}
