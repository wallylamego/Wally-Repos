using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;


namespace CicotiWebApp.Pages.Loads
{
    public class LoadRptModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public LoadRptModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Load> Loads { get;set; }
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "LoadName",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var LoadQuery = _context.Loads
                .Include(s=>s.LoadStatus)
                .Include(d=>d.Destination.StartLocation)
                .Include(d=>d.Destination.EndLocation)
               .Select(l => new
               {
                   l.LoadID,
                   l.LoadDate,
                   l.LoadName,
                   LoadStatus= l.LoadStatus.Description,
                   SubContrator = l.Driver.SubContractor.Name,
                   l.Vehicle.RegistrationNumber,
                   Destination = l.Destination.EndLocation.LocationName + " : " +
                                    l.Destination.StartLocation.LocationName,
                   DriverName = l.Driver.FirstName + l.Driver.Surname,
                   LoadCreateDate = l.CreatedUtc,
                   LoadCreatedBy = l.User.UserName,
                   l.LoadStatusID
               }
               );

            if (Model.LoadStatus.ToUpper().Contains("INCOMPLETE"))
            {
                LoadQuery = LoadQuery.Where(l => l.LoadStatusID == 1);
            }

            totalResultsCount = LoadQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                LoadQuery = LoadQuery
                        .Where(
                c => c.SubContrator.ToLower().Contains(Model.search.value.ToLower()) ||
                     c.DriverName.ToLower().Contains(Model.search.value.ToLower()) ||
                     c.Destination.ToLower().Contains(Model.search.value.ToLower()) ||
                     c.RegistrationNumber.ToLower().Contains(Model.search.value.ToLower()) ||
                     c.LoadStatus.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = LoadQuery.Count();
            }
            var Result = await LoadQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] Load obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.Loads.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Loads removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Load not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Load not removed.");
            }
        }
        public async Task OnGetAsync()
        {
            Loads = await _context.Loads.ToListAsync();
        }
    }
}
