using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.Brand
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CicotiWebApp.Models.Brand> Brand { get;set; }

        
        //This get provides a list of Paged Brands
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "DriverID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var BrandQuery = _context.Brand
               .Include(p=>p.Principle)
               .Select(b => new
               {
                   b.BrandID,
                   BrandName = b.Description,
                   PrincipalName = b.Principle.PrincipalName,
               }
               );

            totalResultsCount = BrandQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                BrandQuery = BrandQuery
                        .Where(
                d => d.BrandName.ToLower().Contains(Model.search.value.ToLower()) ||
                        d.PrincipalName.ToString().ToLower().Contains(Model.search.value.ToLower()));

                filteredResultsCount = BrandQuery.Count();
            }
            var Result = await BrandQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] CicotiWebApp.Models.Brand obj)
        {
            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.Brand.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Brand removed successfully");
                }
                catch(DbUpdateException d)
                {
                    return new JsonResult("Brand not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Brand not removed.");
            }
        }
    }
}
