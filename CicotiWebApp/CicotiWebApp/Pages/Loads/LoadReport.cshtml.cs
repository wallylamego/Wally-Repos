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

namespace CicotiWebApp.Pages.Loads
{
    [Authorize]
    public class LoadReportModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;
        private IHostingEnvironment _hostingEnvironment;

        public LoadReportModel(CicotiWebApp.Data.ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
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
            return new JsonResult("File Created Successfully");
        }

        //public async Task<IActionResult> Download(string filename)
        //{
        //    //ExcelImportExport excelExport = new ExcelImportExport(filename,
        //    //   _hostingEnvironment);
        //    //MemoryStream memory = await excelExport.DownloadAsync(filename);

        //    //var NewFile = File(memory, System.Net.Mime.MediaTypeNames.Application.Octet, filename);


        //    //return NewFile;
            


        //}




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