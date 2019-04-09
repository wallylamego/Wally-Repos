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

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "ActCostAccountID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var AccountQuery = _context.ActCostAccount
                .Include(b=>b.Branch)
                .Include(c=>c.ActCostCategory)
                .Include(sc=>sc.ActCostSubCategory)
                .Include(cd=>cd.ActCostDriver)
                .Include(sp=>sp.ActCostAllocationSplit)
               .Select(acc => new
               {
                   acc.ActCostAccountID,
                   AccountName = acc.Description,
                   AccountNo = acc.AccountNo,
                   Branch = acc.Branch.BranchName,
                   Category = acc.ActCostCategory.Description,
                   SubCategory = acc.ActCostSubCategory.Description,
                   CostDriver = acc.ActCostDriver.Description,
                   AllocationSplit = acc.ActCostAllocationSplit.Description
               }
               );

            totalResultsCount = AccountQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                AccountQuery = AccountQuery
                        .Where(
                d => d.AccountName.ToLower().Contains(Model.search.value.ToLower()) ||
                        d.AccountNo.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.Branch.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.Category.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.SubCategory.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.CostDriver.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.AllocationSplit.ToString().ToLower().Contains(Model.search.value.ToLower())
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
