using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;


namespace CicotiWebApp.Pages.Vehicles.Make
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CicotiWebApp.Models.Make> Make { get;set; }
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "MakeID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var MakeQuery = _context.Make
               .Select(c => new
               {
                   Id = c.MakeID,
                   c.MakeName                  
                }
               );

            totalResultsCount = MakeQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                MakeQuery = MakeQuery
                        .Where(
                c => c.MakeName.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = MakeQuery.Count();
            }
            var Result = await MakeQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] CicotiWebApp.Models.Make obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.Make.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Make removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Make not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Make not removed.");
            }
        }
        public async Task OnGetAsync()
        {
            Make = await _context.Make.ToListAsync();
        }
    }
}
