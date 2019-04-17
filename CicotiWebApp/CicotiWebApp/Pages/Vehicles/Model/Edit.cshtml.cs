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

namespace CicotiWebApp.Pages.Vehicles.Model
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public EditModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CicotiWebApp.Models.Model Model { get; set; }

        public SelectList FuelTypeSL { get; set; }
        public SelectList DriveTypeSL { get; set; }
        public SelectList MakeSL { get; set; }
        public SelectList VehicleTypeSL { get; set; }

        public void PopulatFuelTypeSL(object selectedFuelType = null)
        {
            var FuelTypeQuery = from f in _context.FuelTypes
                                orderby f.Description
                                select f;
            FuelTypeSL = new SelectList(FuelTypeQuery.AsNoTracking(),
                        "FuelTypeID", "Description", selectedFuelType);
        }
        public void PopulateDriveTypeSL(object selectedDriveType = null)
        {
            var DriveTypeQuery = from d in _context.DriveTypes
                                 orderby d.Description
                                 select d;
            DriveTypeSL = new SelectList(DriveTypeQuery.AsNoTracking(),
                        "DriveTypeID", "Description", selectedDriveType);
        }
        public void PopulateMakeSL(object selectedMake = null)
        {
            var MakeQuery = from d in _context.Make
                            orderby d.MakeName
                            select d;
            MakeSL = new SelectList(MakeQuery.AsNoTracking(),
                        "MakeID", "MakeName", selectedMake);
        }
        public void PopulateVehicleTypeSL(object selectedVehicleType = null)
        {
            var VehicleTypeQuery = from d in _context.VehicleTypes
                                   orderby d.Description
                                   select d;
            VehicleTypeSL = new SelectList(VehicleTypeQuery.AsNoTracking(),
                        "VehicleTypeID", "Description", selectedVehicleType);
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Model = await _context.Models.FirstOrDefaultAsync(m => m.ModelID == id);

            if (Model == null)
            {
                return NotFound();
            }
            PopulateDriveTypeSL();
            PopulateMakeSL();
            PopulatFuelTypeSL();
            PopulateVehicleTypeSL();
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
                    _context.Attach((CicotiWebApp.Models.Model)Model).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(Model.ModelID))
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

        private bool ModelExists(int id)
        {
            return _context.Models.Any(e => e.ModelID == id);
        }
    }
}
