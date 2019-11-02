using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.ABC.Warehouses
{
    [Authorize]
    public class WarehouseTableModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public WarehouseTableModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ActCostWarehouse> Warehouse { get;set; }

        
        //This get provides a list of Paged Warehouses
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "ActCostWarehouseID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var WarehouseQuery = _context.ActCostWarehouse
                .Include(b=>b.Branch)
                .Include(c=>c.ActCostChannel)
                .Include(sc=>sc.ActCostWarehouseType)
               .Select(w => new
               {
                   w.ActCostWarehouseID,
                   w.WarehouseName,
                   Branch = w.Branch.BranchName,
                   Channel = w.ActCostChannel.ChannelName,
                   WarehouseType = w.ActCostWarehouseType.Description,
                   w.WarehouseCode
               }
               );

            totalResultsCount = WarehouseQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                WarehouseQuery = WarehouseQuery
                        .Where(
                w => w.WarehouseName.ToLower().Contains(Model.search.value.ToLower()) ||
                        w.WarehouseCode.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        w.Branch.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        w.Channel.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        w.WarehouseType.ToString().ToLower().Contains(Model.search.value.ToLower()) 
                        );

                filteredResultsCount = WarehouseQuery.Count();
            }
            var Result = await WarehouseQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] ActCostWarehouse obj)
        {
            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.ActCostWarehouse.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Warehouse removed successfully");
                }
                catch(DbUpdateException d)
                {
                    return new JsonResult("Warehouse not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Warehouse not removed.");
            }
        }
    }
}
