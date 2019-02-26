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

        public CreateModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateSubContractorSL();
            PopulateVehicleTypeSL();
            PopulateBranchTypeSL();
            PopulateCostCentreSL();
            return Page();
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; }

        public SelectList VehicleTypeSL { get; set; }
        public SelectList BranchSL { get; set; }
        public SelectList CostCentreSL { get; set; }
        public SelectList VehiclePurposeSL { get; set; }

        public void PopulateVehicleTypeSL(object selectedVehicleType = null)
        {
            var VehicleTypesQuery = from v in _context.VehicleTypes
                              orderby v.Description
                              select v;
            VehicleTypeSL = new SelectList(VehicleTypesQuery.AsNoTracking(),
                        "VehicleTypeID", "Description", selectedVehicleType);
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

        public void PopulateSubContractorSL(object selectedSubContractor = null)
        {
            var SubContractorsQuery = from s in _context.SubContractor
                                    orderby s.Name
                                    select s;
            SubContractorSL = new SelectList(SubContractorsQuery.AsNoTracking(),
                        "SubContractorID", "Name", selectedSubContractor);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Vehicle.RegNumberABB = Vehicle.RegNumberABB.ToString().Replace(" ", "").Trim();
            Vehicle.VehiclePurposeID = 2;
            _context.Vehicles.Add(Vehicle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}