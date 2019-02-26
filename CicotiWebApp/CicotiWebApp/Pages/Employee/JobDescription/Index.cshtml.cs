using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;


namespace CicotiWebApp.Pages.Employee.JobDescription
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CicotiWebApp.Models.JobDescription> JobDescription { get;set; }
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "JobDescriptionID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var JobDescriptionQuery = _context.JobDescription
               .Select(j => new
               {
                   Id = j.JobDescriptionID,
                   j.Description,
                  
                }
               );

            totalResultsCount = JobDescriptionQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                JobDescriptionQuery = JobDescriptionQuery
                        .Where(
                c => c.Description.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = JobDescriptionQuery.Count();
            }
            var Result = await JobDescriptionQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] CicotiWebApp.Models.JobDescription obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.JobDescription.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Job Description removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Job Description not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Job Description not removed.");
            }
        }
        public async Task OnGetAsync()
        {
            JobDescription = await _context.JobDescription.ToListAsync();
        }
    }
}
