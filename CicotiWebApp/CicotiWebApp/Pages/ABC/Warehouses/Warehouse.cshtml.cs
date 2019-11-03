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

namespace CicotiWebApp.Pages.ABC.Warehouses
{
    [Authorize]
    public class WarehouseModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public WarehouseModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        public SelectList BranchSL { get; set; }
        public SelectList ChannelSL { get; set; }
        public SelectList WarehouseTypeSL { get; set; }

        
       
        public void PopulateBranchSL(object selectedBranch = null)
        {
            var BranchQuery = from s in _context.Branch
                                      orderby s.BranchName
                                      select s;
            BranchSL = new SelectList(BranchQuery.AsNoTracking(),
                        "BranchID", "BranchName", selectedBranch);
        }
        public void PopulateChannelSL(object selectedChannel = null)
        {
            var ChannelQuery = from s in _context.ActCostChannel
                                      orderby s.ChannelName
                                      select s;
            ChannelSL = new SelectList(ChannelQuery.AsNoTracking(),
                        "ActCostChannelID", "ChannelName", selectedChannel);
        }
        
        public void PopulateWarehouseTypeSL(object selectedWarehouseType = null)
        {
            var WarehouseTypeQuery = from s in _context.ActCostWarehouseTypes
                                      orderby s.Description
                                      select s;
            WarehouseTypeSL = new SelectList(WarehouseTypeQuery.AsNoTracking(),
                        "ActCostWarehouseTypeID", "Description", selectedWarehouseType);
        }


        [BindProperty] 
        public ActCostWarehouse Warehouse { get; set; }

        public async Task<IActionResult> OnGetAsync(int? ActCostWarehouseID)
        {
            Warehouse = new ActCostWarehouse { };


            if (ActCostWarehouseID != null)
            {
                Warehouse = await _context.ActCostWarehouse
                    .SingleOrDefaultAsync(m => m.ActCostWarehouseID == ActCostWarehouseID);
            }
            PopulateBranchSL();
            PopulateChannelSL();
            PopulateWarehouseTypeSL();
            return Page();
        }
        #region Update Account Details
        //Updates the existing Account Details
        public async Task<IActionResult> OnPutUpdateWarehouse([FromBody] Models.ActCostWarehouse obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") ))
            {
                try
                {
                    _context.Attach(obj).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Warehouse Changes not saved." + d.InnerException.Message);
                }
            }
            return new JsonResult("Warehouses Changes not saved.");
        }

        //Inserts a new Account with details
        public async Task<IActionResult> OnPostInsertWarehouse([FromBody] Models.ActCostWarehouse obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin")))
            {
                try
                {
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    int id = obj.ActCostWarehouseID; // Yes it's here
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Warehouse Not Added." + d.InnerException.Message);
                }
            }

            else
            {
                return new JsonResult("Warehouse Not Inserted");
            }

        }
        #endregion WarehouseUpdates
}
}