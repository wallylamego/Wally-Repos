using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;


namespace CicotiWebApp.Pages.Employee.Department
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CicotiWebApp.Models.Department> Department { get;set; }
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "DepartmentID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var DepartmentQuery = _context.Department
               .Select(d => new
               {
                   Id = d.DepartmentID,
                   d.DepartmentName,
                  }
               );

            totalResultsCount = DepartmentQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                DepartmentQuery = DepartmentQuery
                        .Where(
                d => d.DepartmentName.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = DepartmentQuery.Count();
            }
            var Result = await DepartmentQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] CicotiWebApp.Models.Department obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.Department.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Department removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Department not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Department not removed.");
            }
        }
        public async Task OnGetAsync()
        {
            Department = await _context.Department.ToListAsync();
        }
    }
}
