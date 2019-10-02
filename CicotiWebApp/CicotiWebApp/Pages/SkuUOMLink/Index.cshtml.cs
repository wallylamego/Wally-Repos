using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;


namespace CicotiWebApp.Pages.SkuUOMLink
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CicotiWebApp.Models.SKU> Status { get;set; }
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "code",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var SKUQuery = _context.SkuUomLinks
                .Include(u=>u.SKU)
                .Include(t=>t.ToUOM)
                .Include(f=>f.FromUOM)
               .Select(s => new
               {
                   Id = s.SkuUomLinkID,
                   s.SKU.Code,
                   SkuName = s.SKU.Description,
                   conversionDescription = s.Description,
                   FromUom = s.FromUOM.Description,
                   ToUom = s.ToUOM.Description,
                   s.ConversionFactor,
                }
               );

            totalResultsCount = SKUQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                SKUQuery = SKUQuery
                        .Where(
                c => c.Code.ToLower().Contains(Model.search.value.ToLower()) ||
                c.conversionDescription.ToLower().Contains(Model.search.value.ToLower()) ||
                 c.SkuName.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = SKUQuery.Count();
            }
            var Result = await SKUQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] CicotiWebApp.Models.SkuUomLink obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.SkuUomLinks.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("SKU removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("SKU not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("SKU not removed.");
            }
        }
        public async Task OnGetAsync()
        {
            Status = await _context.SKUs.ToListAsync();
        }
    }
}
