using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CicotiWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CicotiWebApp.Pages.Vehicles.Fleet
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;
        private VehicleBusinessLayer _vehicleBusLayer;
        public CreateModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
            _vehicleBusLayer = new VehicleBusinessLayer();
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; }

        public SelectList VehicleTypeSL { get; set; }
        public SelectList BranchSL { get; set; }
        public SelectList CostCentreSL { get; set; }
        public SelectList VehiclePurposeSL { get; set; }
        public SelectList VehicleStatusSL { get; set; }

        public void PopulateVehicleTypeSL(object selectedVehicleType = null)
        {
            var VehicleTypesQuery = from v in _context.VehicleTypes
                              orderby v.Description
                              select v;
            VehicleTypeSL = new SelectList(VehicleTypesQuery.AsNoTracking(),
                        "VehicleTypeID", "Description", selectedVehicleType);
        }
        public void PopulateVehicleStatusSL(object selectedVehicleStatusSL = null)
        {
            var VehicleStatusQuery = from v in _context.VehicleStatus
                                    orderby v.Description
                                    select v;
            VehicleStatusSL = new SelectList(VehicleStatusQuery.AsNoTracking(),
                        "VehicleStatusID", "Description", selectedVehicleStatusSL);
        }
        public void PopulateBranchTypeSL(object selectedBranch = null)
        {
            var BranchQuery = from b in _context.Branch
                                    orderby b.BranchName
                                    select b;
            BranchSL = new SelectList(BranchQuery.AsNoTracking(),
                        "BranchID", "BranchName", selectedBranch);
        }
        public void PopulateCostCentreSL(object selectedCostCentre = null)
        {
            var CostCentreQuery = from c in _context.CostCentre
                                    orderby c.CostCentreName
                                    select c;
            CostCentreSL = new SelectList(CostCentreQuery.AsNoTracking(),
                        "CostCentreID", "CostCentreName", selectedCostCentre);
        }
        public void PopulateVehiclePurposeSL(object selectedVehiclePurpose = null)
        {
            var VehiclePurposeQuery = from c in _context.VehiclePurpose
                                  orderby c.Description
                                  select c;
            VehiclePurposeSL = new SelectList(VehiclePurposeQuery.AsNoTracking(),
                        "VehiclePurposeID", "Description", selectedVehiclePurpose);
        }
        public SelectList SubContractorSL { get; set; }

        public async Task<IActionResult> OnGetAsync(int? VehicleID)
        {
            Vehicle = new Vehicle { };
            PopulateSubContractorSL();
            PopulateVehicleTypeSL();
            PopulateBranchTypeSL();
            PopulateCostCentreSL();
            PopulateVehiclePurposeSL();
            PopulateVehicleStatusSL();

            if (VehicleID != null)
            {
                Vehicle = await _context.Vehicles
                    .Include(v => v.Branch)
                    .Include(c => c.CostCentre)
                    .Include(e => e.Employee)
                    .Include(e => e.Employee.Branch)
                    .Include(e=> e.Employee.JobDescription)
                    .Include(m => m.Model)
                    .Include(m => m.Model.Make)
                    .Include(m => m.Model.VehicleType)
                    .Include(m => m.Model.FuelType)
                    .Include(m => m.Model.DriveType)
                    .SingleOrDefaultAsync(m => m.VehicleID == VehicleID);
            }
            return Page();
        }
        public void PopulateSubContractorSL(object selectedSubContractor = null)
        {
            var SubContractorsQuery = from s in _context.SubContractor
                                    orderby s.Name
                                    select s;
            SubContractorSL = new SelectList(SubContractorsQuery.AsNoTracking(),
                        "SubContractorID", "Name", selectedSubContractor);
        }

        #region Vehicles
        //Updates the existing Vehicle
        public async Task<IActionResult> OnPutUpdateVehicle([FromBody] Vehicle obj)
        {
            if (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Fleet"))
            {
                try
                {
                    obj.RegNumberABB = obj.RegistrationNumber.ToString().Replace(" ", "").Trim();
                    obj.SubContractorID = 2;
                    obj.ActCostAllocationSplitID = _vehicleBusLayer.FindAllocationSplitID(obj.CostCentreID);
                    _context.Attach(obj).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Vehicle Changes not saved." + d.InnerException.Message);
                }
            }
            return new JsonResult("You do not have access to these changes");
        }
        public async Task<JsonResult> OnPostEmployeePaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "EmployeeID",
                out bool SortDir, out string SortBy);

            var EmployeeQuery = _context.Employees
                .Include(m => m.Department)
                .Include(m => m.JobDescription)
                .Include(b => b.Branch)
                .Include(c => c.CostCentre)
               .Select(e => new
               {
                   e.EmployeeID,
                   e.EmployeeNo,
                   JobDescription = e.JobDescription.Description,
                   e.FirstName,
                   e.LastName,
                   e.Branch.BranchName,
               }
               );

            totalResultsCount = EmployeeQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                EmployeeQuery = EmployeeQuery
                        .Where(
                v => v.FirstName.ToLower().Contains(Model.search.value.ToLower()) ||
                     v.LastName.ToLower().Contains(Model.search.value.ToLower()) ||
                     v.EmployeeNo.ToLower().Contains(Model.search.value.ToLower()) ||
                     v.BranchName.ToLower().Contains(Model.search.value.ToLower()) ||
                     v.JobDescription.ToLower().Contains(Model.search.value.ToLower())
                      );

                filteredResultsCount = EmployeeQuery.Count();
            }
            var Result = await EmployeeQuery
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

        //Inserts a new Vehicle with details
        public async Task<IActionResult> OnPostInsertVehicle([FromBody] Vehicle obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Fleet")))
            {
                try
                {
                    string regNo = obj.RegistrationNumber.ToString().Replace(" ", "").Trim();
                    regNo = regNo.ToString().Replace("-", "").Replace("/", "");
                    obj.RegNumberABB = regNo;
                    obj.ActCostAllocationSplitID = _vehicleBusLayer.FindAllocationSplitID(obj.CostCentreID);
                    //enter CICOTI SubContractor Number
                    obj.SubContractorID = 2;
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    int id = obj.VehicleID; // Yes it's here
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Vehicle Not Added." + d.InnerException.Message);
                }
            }

            else
            {
                return new JsonResult("Insert Destination was null");
            }

        }
        public async Task<IActionResult> OnDeleteDelete([FromBody] Vehicle obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Fleet"))
            {
                try
                {
                    _context.Vehicles.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Vehicles removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Vehicles not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Vehicles not removed.");
            }
        }





        #endregion UpdateFleet





    }
}