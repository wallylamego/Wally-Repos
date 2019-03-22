using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CicotiWebApp.Pages.StockCount
{
    public class StockCountSummaryModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public StockCountSummaryModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "Code",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var StockCountQuery = _context.VwStockCountSummary
               .Select(s => new
               {
                   NoOfCounts = s.NoOfCounts,
                   Code = s.Code,
                   Description =s.SKUName,
                   Qty = s.Qty,
                   Quality = s.Quality,
                   UOM = s.UOM,
                   PrincipleName = s.PrincipalName,
                }
               );

            totalResultsCount = StockCountQuery.Count();
            filteredResultsCount = totalResultsCount;

           if (!string.IsNullOrEmpty(Model.search.value))
            {
                StockCountQuery = StockCountQuery
                        .Where(
                c => c.Code.ToLower().Contains(Model.search.value.ToLower()) ||
                     c.PrincipleName.ToLower().Contains(Model.search.value.ToLower()) ||
                     c.Quality.ToLower().Contains(Model.search.value.ToLower()) ||
                     c.UOM.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = StockCountQuery.Count();
            }
            
            var Result = await StockCountQuery
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

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

     
    }
}
