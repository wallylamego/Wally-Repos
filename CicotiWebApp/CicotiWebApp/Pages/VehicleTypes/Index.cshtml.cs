﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;


namespace CicotiWebApp.Pages.VehicleTypes
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<VehicleType> VehicleType { get;set; }
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "Description",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var VehicleTypesQuery = _context.VehicleTypes
               .Select(v => new
               {
                   v.VehicleTypeID,
                   v.Description
               }
               );

            totalResultsCount = VehicleTypesQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                VehicleTypesQuery = VehicleTypesQuery
                        .Where(
                v => v.Description.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = VehicleTypesQuery.Count();
            }
            var Result = await VehicleTypesQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] VehicleType obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.VehicleTypes.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Vehicle Type removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Vehicle Type  not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Vehicle Type  not removed.");
            }
        }
        public async Task OnGetAsync()
        {
            VehicleType = await _context.VehicleTypes.ToListAsync();
        }
    }
}
