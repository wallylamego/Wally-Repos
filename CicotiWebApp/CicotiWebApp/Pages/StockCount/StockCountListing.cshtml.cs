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
    public class StockCountListingModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public StockCountListingModel(CicotiWebApp.Data.ApplicationDbContext context)
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
            var StockCountQuery = _context.StockCountItems
               .Include(s=>s.SKU)
               .Include(u=>u.UOM)
               .Include(q => q.StockQuality)
               .Select(s => new
               {
                   StockCountItemID = s.StockCountItemID,
                   code = s.SKU.Code,
                   sku =s.SKU.Description,
                   qty = s.Qty,
                   uom = s.UOM.Description,
                   quality = s.StockQuality.Description,
                   s.Comments,
                   principleName = s.SKU.Principle.PrincipalName,
                }
               );

            totalResultsCount = StockCountQuery.Count();
            filteredResultsCount = totalResultsCount;

           if (!string.IsNullOrEmpty(Model.search.value))
            {
                StockCountQuery = StockCountQuery
                        .Where(
                c => c.sku.ToLower().Contains(Model.search.value.ToLower()) ||
                     c.principleName.ToLower().Contains(Model.search.value.ToLower()) ||
                     c.code.ToLower().Contains(Model.search.value.ToLower()) ||
                     c.quality.ToLower().Contains(Model.search.value.ToLower())
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] CicotiWebApp.Models.StockCountItem obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.StockCountItems.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Stock Count Item removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Stock Count not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Stock Count Item not removed.");
            }
        }
        public IActionResult OnGet()
        {
            return Page();
        }


    }
}
