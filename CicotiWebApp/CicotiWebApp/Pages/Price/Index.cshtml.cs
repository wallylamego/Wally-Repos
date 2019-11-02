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

namespace CicotiWebApp.Pages.Price
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

        public IList<CicotiWebApp.Models.Price> Price { get;set; }
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {

            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "code",
                out bool SortDir, out string SortBy);


            //First create the View of the new model you wish to display to the user
            var PriceQuery = _context.Prices
                .Include(u=>u.SKU)
                .Include(f=>f.PriceType)
                .Include(b=>b.Branch)
                .Include(r=>r.Region)
               .Select(p => new
               {
                   Id = p.PriceID,
                   p.SKU.Code,
                   SkuName = p.SKU.Description,
                   PriceType = p.PriceType.Description,
                   p.PriceInclVat,
                   p.PriceExlcVat,
                   Branch = p.Branch.BranchName,
                   Region = p.Region.RegionName
               }
               );

            totalResultsCount = PriceQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                PriceQuery = PriceQuery
                        .Where(
                c => c.Code.ToLower().Contains(Model.search.value.ToLower()) ||
                 c.SkuName.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = PriceQuery.Count();
            }
            var Result = await PriceQuery
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

        //public async Task<IActionResult> OnPostUpload([FromBody] Report report)
        public async Task<IActionResult> OnPostUpload(IFormFile reportfile)
        {
            
            ExcelImportExport excelImport = new ExcelImportExport(
                _hostingEnvironment, _context);

            excelImport.ImportUpload(reportfile);

            return new JsonResult("Price File Uploaded Successfully");
        }





        public async Task<IActionResult> OnDeleteDelete([FromBody] CicotiWebApp.Models.Price obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    _context.Prices.Remove(obj);
                    await _context.SaveChangesAsync();
                    return new JsonResult("Price Item removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Price not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Price not removed.");
            }
        }
        public async Task OnGetAsync()
        {
            Price = await _context.Prices.ToListAsync();
        }
    }
}
