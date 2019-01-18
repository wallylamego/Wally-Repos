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
using Microsoft.AspNetCore.Identity;

namespace CicotiWebApp.Pages.Invoice
{
    [Authorize]
    public class InvoiceStatusModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public InvoiceStatusModel(CicotiWebApp.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        

        public async Task<IActionResult> OnGetAsync(int? InvoiceID)
        {
            Invoice = new CicotiWebApp.Models.Invoice { };

            if (InvoiceID != null)
            {
                Invoice = await _context.Invoices
                   // .Include(i=>i.)
                    
                    .SingleOrDefaultAsync(i=> i.InvoiceID == InvoiceID);
            }

            return Page();
        }

        [BindProperty]
        public CicotiWebApp.Models.Invoice Invoice { get; set; }

        //get a list of invoices which have been selected for loading
        public async Task<JsonResult> OnPostInvoiceStatusPaging([FromForm] DataTableAjaxPostModel Model)
        {
            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "CreatedUtc",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var InvoiceStatusQuery = _context.InvoiceStatus
                .Include(l=>l.Load)
               .Select(i => new
               {
                   i.InvoiceID,
                   StatusName = i.Status.Name,
                   StatusDate = i.CreatedUtc,
                   User= i.User.UserName,
                   i.Load.LoadDate,
                   i.Load.LoadName,
                   i.LoadID
               }
               ).Where(i => i.InvoiceID == Model.InvoiceID);

            totalResultsCount = InvoiceStatusQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                InvoiceStatusQuery = InvoiceStatusQuery
                        .Where(
                i => i.User.ToLower().Contains(Model.search.value.ToLower()) ||
                     i.StatusName.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = InvoiceStatusQuery.Count();
            }
            var Result = await InvoiceStatusQuery
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

    }
}