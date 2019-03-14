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

namespace CicotiWebApp.Pages.Reports
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public  IndexModel(CicotiWebApp.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {
            int filteredResultsCount = 0;
            int totalResultsCount = 0;
            int Test = Model.FilterItemID;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "invoiceNumber",
                out bool SortDir, out string SortBy);

            //First create the View of the new model you wish to display to the user
           
           
            var InvoiceQuery = _context.VwDeliveryStatusDetails
               .Select(i => new
               {
                   i.InvoiceID,
                   i.InvoiceNumber,
                   i.InvoicePrintDate,
                   i.LastStatusDate,
                   i.StatusName,
                   i.TargetExpiryTime,
                   i.ExpiryTime,
                   slaStatus = i.SLAStatus,
                   i.StatusID
               }
               );

            //Filter based on Users Input
            if (Model.StatusID != 0)
            {
                InvoiceQuery = InvoiceQuery.Where(i => i.StatusID == Model.StatusID);
            }

            totalResultsCount = InvoiceQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                InvoiceQuery = InvoiceQuery
                        .Where(
                i => i.InvoiceNumber.ToLower().Contains(Model.search.value.ToLower()) ||
                     i.StatusName.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = InvoiceQuery.Count();
            }
            var Result = await InvoiceQuery
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
