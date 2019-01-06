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
using Microsoft.AspNetCore.Identity;

namespace CicotiWebApp.Pages.Invoice
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        [BindProperty]
        public DateTime ExecuteDate { get; set;}

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
            ExecuteDate = DateTime.Now;
        }

        public async Task<JsonResult> OnPostUpdate([FromBody] List<InvoiceStatus> InvoiceListing)
        {
            if (InvoiceListing != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    var UserId = _userManager.GetUserId(HttpContext.User);
                    CicotiWebApp.Models.Invoice InvoiceItem;

                    //Update the Invoice Table in Database
                    foreach (var In in InvoiceListing)
                    {
                        In.UserID = UserId;
                        InvoiceItem = _context.Invoices.FirstOrDefault(i => i.InvoiceID == In.InvoiceID);
                        InvoiceItem.StatusID = In.StatusID;
                        _context.Attach(InvoiceItem).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    //Update the InvoiceStatus Table in the Database
                    _context.InvoiceStatus.AddRange(InvoiceListing);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Invoice Status successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Invoice Status not Updated." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Status not removed.");
            }
        
           
        }
    }
}
