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
        private WorkFlowRule workFlowRule;

        public  IndexModel(CicotiWebApp.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            workFlowRule = new WorkFlowRule(_context, _userManager);
        }

        public SelectList StatusSL { get; set; }

        public async Task PopulateStatusSLAsync(object selectedStatus = null)
        {
            StatusSL = await workFlowRule.getAuthorisedStatusAsync(HttpContext);
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

            await PopulateStatusSLAsync();
            ExecuteDate = DateTime.Now;


            //First create the View of the new model you wish to display to the user


            var InvoiceQuery = _context.Invoices
               .Include(a => a.CustomerAccount)
               .Include(w => w.InvoiceProductType)
               .Select(i => new
               {
                   i.InvoiceID,
                   i.InvoiceNumber,
                   i.InvoicePrintDate,
                   AccountNo = i.CustomerAccount.AccountNumber,
                   AccountName = i.CustomerAccount.AccountDescription,
                   i.InvoiceProductType.ProductType,
                   StatusName = i.Status.Name,
                   i.StatusID
               }
               );

            switch (Model.StatusID)
            {
                case 0:
                    //where status not equal to POD and Cancelled by Credit Note
                    InvoiceQuery = InvoiceQuery.Where(i => i.StatusID != 8).Where(i => i.StatusID != 10)
                        .OrderBy(i => i.InvoicePrintDate);
                    break;
                default:
                    InvoiceQuery = InvoiceQuery.Where(i => i.StatusID == Model.StatusID)
                    .OrderBy(i => i.InvoicePrintDate);
                    break;
}           

            totalResultsCount = InvoiceQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                InvoiceQuery = InvoiceQuery
                        .Where(
                i => i.InvoiceNumber.ToLower().Contains(Model.search.value.ToLower()) ||
                     i.StatusName.ToLower().Contains(Model.search.value.ToLower()) ||
                     i.AccountNo.ToLower().Contains(Model.search.value.ToLower()) ||
                     i.AccountName.ToLower().Contains(Model.search.value.ToLower()) ||
                     i.ProductType.ToLower().Contains(Model.search.value.ToLower()) 
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
        public async Task<IActionResult>  OnGetAsync()
        {
            await PopulateStatusSLAsync();
            ExecuteDate = DateTime.Now;
            return Page();
        }

        public async Task<JsonResult> OnPutUpdate([FromBody] List<InvoiceStatus> InvoiceListing)
        {
            int NewInvoiceStatusID = 0;
            string InvoiceNotAdded = "WorkFlow Sequence Error: Invoices Not Added: ";
            int InvProcessedCount = 0;
            int InvNotProcessedCount = 0;

            if (InvoiceListing != null && InvoiceListing.Count() > 0)
            {

                NewInvoiceStatusID = InvoiceListing.First().StatusID;
                //First Check if this user can update the Invoice to this Status
                if (await workFlowRule.WorkFlowRuleRole(NewInvoiceStatusID, HttpContext))
                {
                    try
                    {
                        var UserId = _userManager.GetUserId(HttpContext.User);
                        CicotiWebApp.Models.Invoice InvoiceItem;
                       
                        //Update the Invoice Table in Database
                        foreach (var In in InvoiceListing)
                        {
                            InvoiceItem = _context.Invoices.FirstOrDefault(i => i.InvoiceID == In.InvoiceID);
                            if (workFlowRule.WorFlowRuleSequence(In.StatusID, InvoiceItem.StatusID))
                            {
                                In.UserID = UserId;
                                InvoiceItem.StatusID = In.StatusID;
                                _context.Attach(InvoiceItem).State = EntityState.Modified;
                                _context.Add(In);
                                await _context.SaveChangesAsync();
                                InvProcessedCount += InvProcessedCount + 1;
                            }
                            else
                            {
                                InvNotProcessedCount += InvNotProcessedCount + 1;
                                InvoiceNotAdded +=  InvoiceItem.InvoiceNumber + "; ";
                            }
                        }
                        if (InvNotProcessedCount == 0)
                        {
                            return new JsonResult("Success: No of Invoices Processed: " + InvProcessedCount);
                        }
                        else
                        {
                            return new JsonResult("No of Invoices Processed Successfully: " + InvProcessedCount +" . " + "No of Invoices Not Processed: " + InvNotProcessedCount + "; " + InvoiceNotAdded);
                        }

                    }
                    catch (DbUpdateException d)
                    {
                        return new JsonResult("Invoice Status not Updated. " + d.InnerException.Message);
                    }
                }
                else
                {
                    return new JsonResult("Invoice Status not Updated. You do not have rights to update to this Invoice Status.");
                }
            }//Nothing has been selected for updating
            return new JsonResult("You have not selected Deliveries / Invoices for Updating");
        }
    }
}
