using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.ABC.Accounts
{
    [Authorize]
    public class AccountTableModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public AccountTableModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Driver> Driver { get;set; }

        
        //This get provides a list of Paged Accounts
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "DriverID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var AccountQuery = _context.ActCostAccount
                .Include(b=>b.Branch)
               .Select(acc => new
               {
                   accountID = acc.ActCostAccountID,
                   accountName = acc.Description,
                   accountNo = acc.AccountNo,
                   branch = acc.Branch.BranchName,
               }
               );

            totalResultsCount = AccountQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                AccountQuery = AccountQuery
                        .Where(
                d => d.accountName.ToLower().Contains(Model.search.value.ToLower()) ||
                        d.accountNo.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.branch.ToString().ToLower().Contains(Model.search.value.ToLower()) 
                        );

                filteredResultsCount = AccountQuery.Count();
            }
            var Result = await AccountQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] ActCostAccount obj)
        {
            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.ActCostAccount.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Account removed successfully");
                }
                catch(DbUpdateException d)
                {
                    return new JsonResult("Account not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Account not removed.");
            }
        }
    }
}
