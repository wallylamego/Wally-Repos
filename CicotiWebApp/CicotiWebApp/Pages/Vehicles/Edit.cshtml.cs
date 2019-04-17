using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.Vehicles
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public EditModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList VehicleTypeSL { get; set; }

        public void PopulateVehicleTypeSL(object selectedVehicleType = null)
        {
            var VehicleTypesQuery = from v in _context.VehicleTypes
                                    orderby v.Description
                                    select v;
            VehicleTypeSL = new SelectList(VehicleTypesQuery.AsNoTracking(),
                        "VehicleTypeID", "Description", selectedVehicleType);
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


        [BindProperty]
        public Vehicle Vehicle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            PopulateSubContractorSL();
            PopulateVehicleTypeSL();
            if (id == null)
            {
                return NotFound();
            }

            Vehicle = await _context.Vehicles.FirstOrDefaultAsync(m => m.VehicleID == id);

            if (Vehicle == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            if (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Fleet"))
            {
                try
                {
                    Vehicle.RegNumberABB = Vehicle.RegNumberABB.ToString().Replace(" ", "").Trim();
                    //set this as a delivery vehicle
                    Vehicle.VehiclePurposeID = 2;
                    _context.Attach(Vehicle).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(Vehicle.VehicleID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToPage("./Index");
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.VehicleID == id);
        }
    }
}
