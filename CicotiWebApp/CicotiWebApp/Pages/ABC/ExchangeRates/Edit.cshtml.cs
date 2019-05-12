using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.ABC.ExchangeRates
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public EditModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ExchangeRate ExchangeRate { get; set; }

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



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExchangeRate = await _context.ExchangeRates.FirstOrDefaultAsync(m => m.ExchangeRateID == id);

            if (ExchangeRate == null)
            {
                return NotFound();
            }
            GetCurrencyList();
            GetPeriodList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.Attach((ExchangeRate)ExchangeRate).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExchangeRateExists(ExchangeRate.ExchangeRateID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToPage("./Index");
        }

        private bool ExchangeRateExists(int id)
        {
            return _context.ExchangeRates.Any(e => e.ExchangeRateID == id);
        }
    }
}
