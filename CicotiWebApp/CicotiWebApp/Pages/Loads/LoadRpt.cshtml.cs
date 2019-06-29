using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;
using System.IO;
using CicotiWebApp.SQLViews;
using CicotiWebApp.Services;
using Microsoft.AspNetCore.Hosting;

namespace CicotiWebApp.Pages.Loads
{
    public class LoadRptModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnvironment;

        public LoadRptModel(CicotiWebApp.Data.ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        [BindProperty]
        public Report Report { get; set; }
        
        public async Task<IActionResult> OnPostExport(Report report)
        {
            string sFileName =report.ReportName;
            ExcelImportExport excelExport = new ExcelImportExport(sFileName, 
                _hostingEnvironment);
            MemoryStream memory = new MemoryStream();
            if (report.ReportName == "VwLoadSummary")
            {
                var ReportList = _context.VwLoadSummary.Where
                                (d => d.LoadDate >= report.StartDate && d.LoadDate <= report.EndDate)
                                .ToList();
                memory = await excelExport.CreateExcelFileAsync(ReportList);
            }
            if (report.ReportName == "VwLoadDetail")
            {
                var ReportList = _context.VwLoadDetail.Where
                                (d => d.LoadDate >= report.StartDate && d.LoadDate <= report.EndDate)
                                .ToList();
                memory = await excelExport.CreateExcelFileAsync(ReportList);
            }

            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }
        public IActionResult OnGet()
        {
            Report = new Report();
            Report.ReportName = "VwLoadSummary";
            Report.StartDate = DateTime.Now;
            Report.EndDate = DateTime.Now;
            return Page();
        }
    }
}
