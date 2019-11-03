using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;


namespace CicotiWebApp.Pages.ABC.Principal
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "PrincipleID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var PrincipalQuery = _context.Principle
                .Include(u=>u.Silo)
                .Include(m=>m.MainPrinciple)
               .Select(s => new
               {
                   s.PrincipleID,
                   mainPrincipal = s.MainPrinciple.PrincipalName,
                   s.PrincipalName,
                   s.PastelName,
                   gp = s.GPPercentage,
                   s.Silo.SiloName,
                   s.SortOrder
                }
               );

            totalResultsCount = PrincipalQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                PrincipalQuery = PrincipalQuery
                        .Where(
                c => c.PrincipalName.ToLower().Contains(Model.search.value.ToLower()) ||
                 c.SiloName.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = PrincipalQuery.Count();
            }
            var Result = await PrincipalQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] CicotiWebApp.Models.SKU obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.SKUs.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Principal removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Principal not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Principal not removed.");
            }
        }
        
    }
}
