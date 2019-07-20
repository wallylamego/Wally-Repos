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
    public class DeliveryStatusPivotModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DeliveryStatusPivotModel(CicotiWebApp.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Report Report { get; set; }

        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {
            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "invoiceDate",
                out bool SortDir, out string SortBy);

            //First create the View of the new model you wish to display to the user
           
           
            var InvoiceQuery = _context.VwDeliveryStatusPivot
               .Select(i => new
               {
                   i.InvoiceDate,
                   i.ProductType,
                   i.Finance,
                   i.Transport,
                   i.Warehouse,
                   i.Pod,
                   i.Other,
                   i.Total,
                   i.UnDelivered
               }
               );

            //Filter based on Users Input
            
            InvoiceQuery = InvoiceQuery.Where(i => i.InvoiceDate >= Model.StartDate).Where
                (i=> i.InvoiceDate <=  Model.EndDate);

            totalResultsCount = InvoiceQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                InvoiceQuery = InvoiceQuery
                        .Where(
                i => i.ProductType.ToLower().Contains(Model.search.value.ToLower()) ||
                     i.InvoiceDate.ToString().ToLower().Contains(Model.search.value.ToLower())
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

        public IActionResult OnGet()
        {
            Report = new Report();
            Report.ReportName = "Daily Update";
            Report.StartDate = DateTime.Now;
            Report.EndDate = DateTime.Now;
            return Page();
        }


    }
}
