using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;
using CicotiWebApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CicotiWebApp.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnvironment;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IList<CicotiWebApp.Models.CustomerAccountLocationLink> Price { get;set; }
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "CustomerAccountLocationLink",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var AccountLocationQuery = _context.CustomerAccountLocationLink
                .Include(u=>u.Location)
                .Include(u=>u.Location.Province)
                .Include(f=>f.CustomerAccount)
               .Select(c => new
               {
                   Id = c.CustomerAccountLocationLinkID,
                   AccountNo = c.CustomerAccount.AccountNumber,
                   CustomerName = c.CustomerAccount.AccountDescription,
                   Address = c.CustomerAccount.Address,
                   c.DefaultLocation,
                   c.Location.Province.ProvinceName,
                   c.Location.LocationName,
                   c.Location.LocationID,
                   c.CustomerAccountID
               }
               );

            totalResultsCount = AccountLocationQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                AccountLocationQuery = AccountLocationQuery
                        .Where(
                c => c.AccountNo.ToLower().Contains(Model.search.value.ToLower()) ||
                 c.CustomerName.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = AccountLocationQuery.Count();
            }
            var Result = await AccountLocationQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] CicotiWebApp.Models.CustomerAccountLocationLink obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Fleet") || HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Manager"))
            {
                try
                {
                    _context.CustomerAccountLocationLink.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Customer Location Item removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Customer Location removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Customer Location not removed.");
            }
        }
        public async Task OnGetAsync()
        {
            Price = await _context.CustomerAccountLocationLink.ToListAsync();
        }
    }
}
