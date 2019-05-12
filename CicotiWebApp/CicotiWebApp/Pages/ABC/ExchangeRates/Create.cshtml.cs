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

namespace CicotiWebApp.Pages.ABC.ExchangeRates
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public CreateModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public SelectList CurrencySL { get; set; }
        public SelectList PeriodSL { get; set; }

        public void GetCurrencyList(
            object selectedCurrency = null)
        {
            var CurrencyQuery = from c in _context.Currency
                                orderby c.CurrencyName
                                select c;
            CurrencySL = new SelectList(CurrencyQuery.AsNoTracking(),
                        "CurrencyID", "CurrencyName", selectedCurrency);

        }

        public void GetPeriodList(
            object selectedPeriod = null)
        {
            var PeriodQuery = from c in _context.ActCostPeriods
                              orderby c.ActCostPeriodID
                              select c;
            PeriodSL = new SelectList(PeriodQuery.AsNoTracking(),
                        "ActCostPeriodID", "Period", selectedPeriod);

        }
        public IActionResult OnGet()
        {
            GetCurrencyList();
            GetPeriodList();
            return Page();
        }

        [BindProperty]
        public ExchangeRate  ExchangeRate { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (HttpContext.User.IsInRole("Admin"))
            {
                _context.ExchangeRates.Add((ExchangeRate)ExchangeRate);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}