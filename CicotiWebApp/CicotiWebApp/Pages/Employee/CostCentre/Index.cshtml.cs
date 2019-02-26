using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;


namespace CicotiWebApp.Pages.Employee.CostCentre
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CicotiWebApp.Models.CostCentre> CostCentre { get;set; }
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "CostCentreID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var CostCentreQuery = _context.CostCentre
               .Select(c => new
               {
                   Id = c.CostCentreID,
                   c.CostCentreName,
                  
                }
               );

            totalResultsCount = CostCentreQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                CostCentreQuery = CostCentreQuery
                        .Where(
                c => c.CostCentreName.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = CostCentreQuery.Count();
            }
            var Result = await CostCentreQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] CicotiWebApp.Models.CostCentre obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.CostCentre.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Cost Centre removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Cost Centre not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Cost Centre not removed.");
            }
        }
        public async Task OnGetAsync()
        {
            CostCentre = await _context.CostCentre.ToListAsync();
        }
    }
}
