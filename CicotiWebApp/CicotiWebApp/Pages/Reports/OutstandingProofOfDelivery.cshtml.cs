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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using CicotiWebApp.Services;
using System.IO;

namespace CicotiWebApp.Pages.Reports
{
    [Authorize]
    public class OutstandingPODModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnvironment;

        public OutstandingPODModel(CicotiWebApp.Data.ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        [BindProperty]
        public Report Report { get; set; }

        public async Task<IActionResult> OnPostExport([FromBody] Report report)
        {
            string sFileName = report.FileName;
            ExcelImportExport excelExport = new ExcelImportExport(sFileName,
                _hostingEnvironment,_context);
            MemoryStream memory = new MemoryStream();
           
                var ReportList = _context.VwInvoiceWeightSummary.Where
                                (d => d.InvoiceDate >= report.StartDate && d.InvoiceDate <= report.EndDate &&
                                d.StatusID != 8 && d.StatusID != 10)
                                .ToList();
                memory = await excelExport.CreateExcelFileAsync(ReportList);
            
            return new JsonResult("File Created Successfully");
        }

        public IActionResult OnGet()
        {
            Report = new Report();
            Report.ReportName = "VwInvoiceWeightSummary";
            Report.StartDate = DateTime.Now;
            Report.EndDate = DateTime.Now;
            return Page();
        }
    }
}