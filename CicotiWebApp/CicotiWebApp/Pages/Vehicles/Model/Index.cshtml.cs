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

namespace CicotiWebApp.Pages.Vehicles.Model
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

       



        public IList<CicotiWebApp.Models.Model> Model { get;set; }
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "ModelID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var ModelQuery = _context.Models.
                Include(f=>f.FuelType).
                Include(d=>d.DriveType).
                Include(m=>m.Make)
                .Select(m => new
               {
                   Id = m.ModelID,
                   m.ModelName,
                   FuelType = m.FuelType.Description,
                   DriveType = m.DriveType.Description,
                   Make = m.Make.MakeName,
                   Wheels = m.NoOfWheels
                }
               );

            totalResultsCount = ModelQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                ModelQuery = ModelQuery
                        .Where(
                c => c.ModelName.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = ModelQuery.Count();
            }
            var Result = await ModelQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] CicotiWebApp.Models.Model obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.Models.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Model removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Model not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Model not removed.");
            }
        }
        public async Task OnGetAsync()
        {
            Model = await _context.Models.ToListAsync();
        }
    }
}
