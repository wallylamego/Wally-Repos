using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CicotiWebApp.Pages.Invoice
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;
        
        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
            PopulateStatusSL();
        }

        public SelectList StatusSL { get; set; }

        public void PopulateStatusSL(object selectedStatus = null)
        {
            var StatusQuery = from c in _context.Status
                               orderby c.SortOrder
                               select c;
            StatusSL = new SelectList(StatusQuery.AsNoTracking(),
                        "StatusID", "Name", selectedStatus);
        }

        [BindProperty]
        public Status Status { get;set; }
        
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "invoiceNumber",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var InvoiceQuery = _context.Invoices
               .Select(i => new
               {
                   i.InvoiceID,
                   i.InvoiceNumber,
                   i.InvoicePrintDate,
                   StatusName = i.Status.Name,
               }
               );

            totalResultsCount = InvoiceQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                InvoiceQuery = InvoiceQuery
                        .Where(
                i => i.InvoiceNumber.ToLower().Contains(Model.search.value.ToLower())
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] Status obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.Status.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Status removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Status not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Status not removed.");
            }
        }
        public  void OnGetAsync()
        {
            PopulateStatusSL();
        }

        public async Task<JsonResult> OnPostUpdate([FromBody] List<CicotiWebApp.Models.Invoice> InvoiceListing)
        {
             int i = 10;

            return new JsonResult("Test");
        }
    }
}
