using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using CicotiWebApp.Services;
using CicotiWebApp.SQLViews;

namespace CicotiWebApp.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnvironment;
        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
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
                .Include(r=> r.ReportsTo)
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
                   ReportTo = e.ReportsTo.FirstName + " " + e.ReportsTo.LastName,
                   e.StartDate,
                   e.EndDate
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
        public async Task<IActionResult> OnPostExport()
        {
           // string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = @"employeeDetails.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            //  FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            //  var memory = new MemoryStream();
            ExcelImportExport excelExport = new ExcelImportExport(sFileName, _hostingEnvironment);
            List<VwEmployeeViewSalesRepCode> EmployeeList =  _context.VwEmployeeViewSalesRepCode.ToList();
            MemoryStream memory = await excelExport.CreateExcelFileAsync(EmployeeList);
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }
    }
}
