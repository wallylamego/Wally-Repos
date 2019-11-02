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

namespace CicotiWebApp.Pages.StockCount
{
    public class FindSKUModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public FindSKUModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public CicotiWebApp.Models.SKU SKU { get; set; }
        public UOM UOM { get; set; }
        public SelectList UOMSL { get; set; }
        public SelectList QualitySL { get; set; }
        public CicotiWebApp.Models.StockCountItem StockCountItem { get; set; }

        public void PopulateUOMSL(object selectedUOM = null)
        {
            var UOMsQuery = from v in _context.UOM
                                       orderby v.Description
                                       select v;
            UOMSL = new SelectList(UOMsQuery.AsNoTracking(),
                        "UOMID", "Description", selectedUOM);
        }
        public void PopulateQualitySL(object selectedQuality = null)
        {
            var QualityQuery = from v in _context.StockQuality
                            orderby v.Description
                            select v;
            QualitySL = new SelectList(QualityQuery.AsNoTracking(),
                        "StockQualityID", "Description", selectedQuality);
        }

        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "code",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var SKUQuery = _context.SKUs
               .Include(p=>p.Principle)
               .Include(u=>u.UOM)
               .Select(s => new
               {
                   Id = s.SKUID,
                   s.Code,
                   s.Description,
                   principleName = s.Principle.PrincipalName,
                   uomID = s.UOM.UOMID,
                   uomDescription = s.UOM.Description
                }
               );

            totalResultsCount = SKUQuery.Count();
            filteredResultsCount = totalResultsCount;

           if (!string.IsNullOrEmpty(Model.search.value))
            {
                SKUQuery = SKUQuery
                        .Where(
                c => c.Description.ToLower().Contains(Model.search.value.ToLower()) ||
                     c.principleName.ToLower().Contains(Model.search.value.ToLower()) ||
                     c.Code.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = SKUQuery.Count();
            }
            var Result = await SKUQuery
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

        public async Task<IActionResult> OnDeleteDelete([FromBody] CicotiWebApp.Models.SKU obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.SKUs.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("SKU removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("SKU not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("SKU not removed.");
            }
        }
        public IActionResult OnGet()
        {
            PopulateUOMSL();
            PopulateQualitySL();
            return Page();
        }

        public async Task<IActionResult> OnPostInsert([FromBody] StockCountItem obj)
        {
            if (obj != null)
            {
                try
                {
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    int id = obj.StockCountItemID; // Yes it's here
                    return new JsonResult(id);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Stock Item Not Added." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Stock Item not Loaded");
            }

        }

    }
}
