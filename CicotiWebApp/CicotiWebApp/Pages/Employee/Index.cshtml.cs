using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;


namespace CicotiWebApp.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Employee> Employees { get;set; }

        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "EmployeeID",
                out bool SortDir, out string SortBy);

            var EmployeeQuery = _context.Employees
                .Include(m=>m.Department)
                .Include(m=>m.JobDescription)
                .Include(b=>b.Branch)
                .Include(c=>c.CostCentre)
               .Select(e => new
               {
                   e.EmployeeID,
                   e.EmployeeNo,
                   JobDescription = e.JobDescription.Description,
                   Name = e.FirstName + " " + e.LastName,
                   Department = e.Department.DepartmentName,
                   Branch = e.Branch.BranchName,
                   CostCentre = e.CostCentre.CostCentreName,
                   e.ReportsToID,
                   e.StartDate
               }
               );

            totalResultsCount = EmployeeQuery.Count();
            filteredResultsCount = totalResultsCount;
            
            if (!string.IsNullOrEmpty(Model.search.value))
            {
                EmployeeQuery = EmployeeQuery
                        .Where(
                v => v.Name.ToLower().Contains(Model.search.value.ToLower()) ||
                     v.CostCentre.ToLower().Contains(Model.search.value.ToLower()) ||
                     v.EmployeeNo.ToLower().Contains(Model.search.value.ToLower()) ||
                     v.CostCentre.ToLower().Contains(Model.search.value.ToLower()) ||
                     v.Department.ToLower().Contains(Model.search.value.ToLower()) ||
                     v.JobDescription.ToLower().Contains(Model.search.value.ToLower())
                      );

                filteredResultsCount = EmployeeQuery.Count();
            }
            var Result = await EmployeeQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] Models.Employee obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.Employees.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Emloyee removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Employee not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Employee not removed.");
            }
        }
        public async Task OnGetAsync()
        {
            Employees = await _context.Employees.ToListAsync();
        }
    }
}
