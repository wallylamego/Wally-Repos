using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;


namespace CicotiWebApp.Pages.ABC.ExchangeRates
{
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ExchangeRate> ExchangeRates { get;set; }
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "Name",
                out bool SortDir, out string SortBy);

            //First create the View of the new model you wish to display to the user
            var ExchangeQuery = _context.ExchangeRates
                .Include(a=>a.ActCostPeriod)
                .Include(c=>c.SecondCurrency)
                .Include(cf=>cf.FirstCurrency)
               .Select(e => new
               {
                   e.ExchangeRateID,
                   FirstCurrency = e.FirstCurrency.CurrencyName,
                   SecondCurrency = e.SecondCurrency.CurrencyName,
                   e.Description,
                   e.ActCostPeriod.Period,
                   e.AverageRate,
                   e.ClosingRate,
               }
               );

            totalResultsCount = ExchangeQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                ExchangeQuery = ExchangeQuery
                        .Where(
                c => c.FirstCurrency.ToLower().Contains(Model.search.value.ToLower()) ||
                c.SecondCurrency.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = ExchangeQuery.Count();
            }
            var Result = await ExchangeQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] ExchangeRate obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.ExchangeRates.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Exchange Rate removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Exchange Rate not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Exchange not removed.");
            }
        }
        public async Task OnGetAsync()
        {
            ExchangeRates = await _context.ExchangeRates.ToListAsync();
        }
    }
}
