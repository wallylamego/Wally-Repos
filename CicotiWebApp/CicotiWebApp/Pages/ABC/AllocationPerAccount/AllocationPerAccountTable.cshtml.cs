using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.ABC.AllocationPerAccount
{
    [Authorize]
    public class AllocationPerAccountTableModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public AllocationPerAccountTableModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        //This get provides a list of Paged Accounts
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {
            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "ActCostAccountPerPrincipleID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var AccountQuery = _context.ActCostAccountPerPrinciple
                .Include(a=>a.ActCostAccount)
                .Include(p=>p.ActCostPeriod)
                .Include(pp=>pp.Principle)
                .Include(asp=>asp.ActCostAccount.ActCostDriver)
                .Include(asl=>asl.ActCostAccount.ActCostAllocationSplit)
               .Select(acc => new
               {
                   acc.ActCostAccountPerPrincipleID,
                   acc.ActCostAccount.AccountNo,
                   AccountName = acc.ActCostAccount.Description,
                   acc.ActCostPeriod.Period,
                   CostDriver = acc.ActCostAccount.ActCostDriver.Description,
                   CostAllocationSplit = acc.ActCostAccount.ActCostAllocationSplit.Description,
                   acc.AllocAccountPerc,
                   acc.Comments
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
                        d.AccountName.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.CostDriver.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.CostAllocationSplit.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.CostDriver.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.Period.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.Comments.ToString().ToLower().Contains(Model.search.value.ToLower())
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] ActCostAccountPerPrinciple obj)
        {
            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.ActCostAccountPerPrinciple.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Account Per Principle removed successfully");
                }
                catch(DbUpdateException d)
                {
                    return new JsonResult("Account Per Principle not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Account Per Principle not removed.");
            }
        }
    }
}
