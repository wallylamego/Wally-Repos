using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;


namespace CicotiWebApp.Pages.Vehicles.Fleet
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Vehicle> Vehicles { get;set; }

        



        public async Task<JsonResult> OnPostFleetPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "VehicleID",
                out bool SortDir, out string SortBy);

            var VehicleQuery = _context.Vehicles
                .Include(m=>m.Model)
                .Include(b=>b.Branch)
                .Include(c=>c.CostCentre)
                .Include(e=>e.Employee)
                .Include(vp=>vp.VehiclePurpose)
               .Where(v=>v.SubContractor.SubContractorID == 2)
               .Select(v => new
               {
                   v.VehicleID,
                   purpose = v.VehiclePurpose.Description,
                   Branch = v.Branch.BranchName,
                   CostCentre = v.CostCentre.CostCentreName,
                   Employee = v.Employee.FirstName,
                   v.RegistrationNumber,
                   Make = v.Model.Make.MakeName,
                   Model = v.Model.ModelName,
                   FuelType = v.Model.FuelType.Description,
                   DriveType = v.Model.DriveType.Description,
                   Tonnage = v.Model.VehicleType.Description,
                   v.FixedAssetsNumber,
                   v.AcquisitionDate,
                   AcquisitionCost = v.AcquistionCost,
                   v.DepreciationMonths
               }
               );

            totalResultsCount = VehicleQuery.Count();
            filteredResultsCount = totalResultsCount;
            
            if (!string.IsNullOrEmpty(Model.search.value))
            {
                VehicleQuery = VehicleQuery
                        .Where(
                v => v.RegistrationNumber.ToLower().Contains(Model.search.value.ToLower()) ||
                    v.Branch.ToLower().Contains(Model.search.value.ToLower()) ||
                    v.CostCentre.ToLower().Contains(Model.search.value.ToLower()) ||
                     v.Employee.ToLower().Contains(Model.search.value.ToLower()) ||
                     v.FixedAssetsNumber.ToLower().Contains(Model.search.value.ToLower()) ||
                     v.FuelType.ToLower().Contains(Model.search.value.ToLower()) ||
                     v.Make.ToLower().Contains(Model.search.value.ToLower()) ||
                     v.Model.ToLower().Contains(Model.search.value.ToLower()) ||
                      v.Tonnage.ToLower().Contains(Model.search.value.ToLower()) ||
                       v.DriveType.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = VehicleQuery.Count();
            }
            var Result = await VehicleQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] Vehicle obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.Vehicles.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Vehicle removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Vehicle not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Vehicle not removed.");
            }
        }
        public async Task OnGetAsync()
        {
            Vehicles = await _context.Vehicles.ToListAsync();
        }
    }
}
