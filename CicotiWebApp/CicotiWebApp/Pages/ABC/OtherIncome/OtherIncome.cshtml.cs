using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.ABC.OtherIncome
{
    [Authorize]
    public class OtherIncomeTableModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public OtherIncomeTableModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        //This get provides a list of Other Income Items
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "ActCostAccountAmtPrincipleID",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var PrincipleAmtQuery = _context.ActCostAccountAmtPrinciple
                .Include(p=>p.ActCostPeriod)
                .Include(pr=>pr.Principle)
                .Include(a=>a.ActCostAccount)
               .Select(Pamt => new
               {
                    Pamt.ActCostAccountAmtPrincipleID
                   ,Principle = Pamt.Principle.PastelName
                   ,Period = Pamt.ActCostPeriod.Period
                   ,Account = Pamt.ActCostAccountID
                   ,AccountName = Pamt.ActCostAccount.Description
                   ,Amount = Pamt.Amount
                   ,Comments = Pamt.Comments
               }
               );

            totalResultsCount = PrincipleAmtQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                PrincipleAmtQuery = PrincipleAmtQuery
                        .Where(
                d => d.Principle.ToLower().Contains(Model.search.value.ToLower()) ||
                        d.Period.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.Account.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.Comments.ToString().ToLower().Contains(Model.search.value.ToLower()) ||
                        d.Amount.ToString().ToLower().Contains(Model.search.value.ToLower()));

                filteredResultsCount = PrincipleAmtQuery.Count();
            }
            var Result = await PrincipleAmtQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] ActCostAccountAmtPrinciple obj)
        {
            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.ActCostAccountAmtPrinciple.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Other Income Removed  successfully");
                }
                catch(DbUpdateException d)
                {
                    return new JsonResult("Other Income Amount not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Other Income not removed.");
            }
        }
    }
}
