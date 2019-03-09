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

namespace CicotiWebApp.Pages.Loads
{
    [Authorize]
    public class LoadModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private  WorkFlowRule _workFlowRule;


        public LoadModel(CicotiWebApp.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _workFlowRule = new WorkFlowRule( _context, _userManager);
        }

        public void PopulateStatusSL(object selectedStatus = null)
        {
            var StatusQuery = from c in _context.Status
                              orderby c.SortOrder
                              select c;
            StatusSL = new SelectList(StatusQuery.AsNoTracking(),
                        "StatusID", "Name", selectedStatus);
        }
        public void PopulateLoadStatusSL(object selectedLoadStatus = null)
        {
            var LoadStatusQuery = from c in _context.LoadStatus
                              orderby c.Description
                              select c;
            LoadStatusSL = new SelectList(LoadStatusQuery.AsNoTracking(),
                        "LoadStatusID", "Description", selectedLoadStatus);
        }
        public SelectList StatusSL { get; set; }
        public SelectList LoadStatusSL { get; set; }

        [BindProperty]
        public Status Status { get; set; }
        [BindProperty]
        public DateTime ExecuteDate { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? LoadID)
        {
            Load = new Load { };
            PopulateLoadStatusSL();
            if (LoadID != null)
            {
                Load = await _context.Loads
                    .Include(v=>v.Vehicle)
                    .Include(s=>s.Vehicle.SubContractor)
                    .Include(v=>v.Vehicle.VechileType)
                    .Include(d=>d.Driver)
                    .SingleOrDefaultAsync(m => m.LoadID == LoadID);
            }

            return Page();
        }

        [BindProperty]
        public Load Load { get; set; }

        #region Paging
        //get a list of invoices which have been selected for loading
        public async Task<JsonResult> OnPostInvoiceSelectedPaging([FromForm] DataTableAjaxPostModel Model)
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
                   i.LoadID
               }
               ).Where(i => i.LoadID == Model.LoadID);

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

        //get a list of Available invoices for Loading
        public async Task<JsonResult> OnPostInvoicePaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;
            int Test = Model.FilterItemID;

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
                   i.StatusID
               }
               ).Where(i=> i.StatusID == 3);

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
        //get a list of vehicles
        public async Task<JsonResult> OnPostVehiclePaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "VehicleID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var VehicleQuery = _context.Vehicles
               .Where(v=>v.VehiclePurposeID == 2)
               .Select(v => new
               {
                   v.VehicleID,
                   v.RegistrationNumber,
                   vehicleType = v.VechileType.Description,
                   SubContractor = v.SubContractor.Name
               }
               );

            totalResultsCount = VehicleQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                VehicleQuery = VehicleQuery
                        .Where(
                v => v.RegistrationNumber.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = VehicleQuery.Count();
            }
            var Result = await VehicleQuery
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
        //This get provides a list of Paged Drivers
        public async Task<JsonResult> OnPostDriverPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "DriverID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var DriverQuery = _context.Drivers
               .Select(driv => new
               {
                   SubContractor = driv.SubContractor.Name,
                   driv.DriverID,
                   driv.FirstName,
                   driv.Surname,
                   driv.CellNumber,
                  }
               );

            totalResultsCount = DriverQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                DriverQuery = DriverQuery
                        .Where(
                d => d.FirstName.ToLower().Contains(Model.search.value.ToLower()) ||
                        d.Surname.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.CellNumber.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.SubContractor.ToString().ToLower().Contains(Model.search.value.ToLower()));

                filteredResultsCount = DriverQuery.Count();
            }
            var Result = await DriverQuery
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

        #endregion Paging
       
        #region UpdateLoads
        //Updates the existing Load Header
        public async Task<IActionResult> OnPutUpdateLoad([FromBody] Load obj)
        {
            try
            {
                _context.Attach(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new JsonResult(obj);
            }
            catch (DbUpdateException d)
            {
                return new JsonResult("Load Changes not saved." + d.InnerException.Message);
            }
        }

        //Inserts a new Load with a Load Headers
        public async Task<IActionResult> OnPostInsertLoad([FromBody] Load obj)
        {
            if (obj != null)
            {
                try
                {
                    obj.UserID = _userManager.GetUserId(HttpContext.User);
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    int id = obj.LoadID; // Yes it's here
                    obj.User = await _userManager.GetUserAsync(HttpContext.User);
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Load Not Added." + d.InnerException.Message);
                }
            }

            else
            {
                return new JsonResult("Insert Destination was null");
            }

        }
        #endregion UploadLoads

        #region Update the Status of the Invoices Items to on Load Schedule

        //Add New Invoices to the Load Schedule
        public async Task<JsonResult> OnPostUpdate([FromBody] List<InvoiceStatus> InvoiceListing)
        {
            //Check if user can update this status to : Load Schedule
            if (InvoiceListing != null && await _workFlowRule.WorkFlowRuleRole(5, HttpContext))
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
                        //Update to WH: Loading Schedule.
                        InvoiceItem.StatusID = 5;
                        In.StatusID = 5;
                        //Add the Current Load Id to the Invoice
                        InvoiceItem.LoadID = In.LoadID;
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
                return new JsonResult("Invoices not removed OR you do not have access to this functionality.");
            }
        }
        //Delete Existing Invoices from the Load Schedule
        public async Task<IActionResult> OnPostRemoveInvoiceItems([FromBody] List<InvoiceStatus> InvoiceListing)
        {
            if (InvoiceListing != null && await _workFlowRule.WorkFlowRuleRole(5, HttpContext))
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
                        //Update to WH: Received.
                        InvoiceItem.StatusID = 4;
                        In.StatusID = 4;
                        //Remove the Current Load Id From the Invoice. Set to Null. As this invoice will be assigned
                        //to another load
                        InvoiceItem.LoadID =  null;
                        In.LoadID = null;
                        _context.Attach(InvoiceItem).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    //Update the InvoiceStatus Table in the Database
                    _context.InvoiceStatus.AddRange(InvoiceListing);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Invoice Status Updated successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Invoice Status not Updated." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Invoices not removed OR you do not have access to this functionality.");
            }

        }
        
        #endregion
        
    }
}