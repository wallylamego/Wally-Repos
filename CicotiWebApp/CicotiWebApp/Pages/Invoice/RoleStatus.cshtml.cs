using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;
using CicotiWebApp.SQLViews;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace CicotiWebApp.Pages.Invoice
{
    public class RoleStatusModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleStatusModel(CicotiWebApp.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {
            int filteredResultsCount = 0;
            int totalResultsCount = 0;
            int Test = Model.FilterItemID;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "roleName",
                out bool SortDir, out string SortBy);

            //First create the View of the new model you wish to display to the user
           
           
            var RoleStatusQuery = _context.VwInvoiceStatusRoles
               .Select(i => new
               {
                   i.RoleName,
                   i.StatusName,
                   i.SortOrder,
               }
               );

            //Filter based on Users Input
           
            totalResultsCount = RoleStatusQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                RoleStatusQuery = RoleStatusQuery
                        .Where(
                i => i.RoleName.ToLower().Contains(Model.search.value.ToLower()) ||
                     i.StatusName.ToLower().Contains(Model.search.value.ToLower()) 
                       );

                filteredResultsCount = RoleStatusQuery.Count();
            }
            var Result = await RoleStatusQuery
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

        public async Task<IActionResult>  OnGetAsync()
        {
            return Page();
        }


    }
}
