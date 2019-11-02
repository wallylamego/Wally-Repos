using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CicotiWebApp.Services
{
    public class ExcelImportExport
    {
        readonly IWorkbook workbook;
        readonly ISheet excelSheet;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string _sWebRootFolder;
        private readonly string _sFileName;
        private FileStream _fs;
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public ExcelImportExport(String sfileName, IHostingEnvironment hostingEnvironment,
            CicotiWebApp.Data.ApplicationDbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _sWebRootFolder = _hostingEnvironment.WebRootPath;
            _sFileName = sfileName;
            _context = context;
            workbook = new XSSFWorkbook();
            excelSheet = workbook.CreateSheet("Export");
        }
        public ExcelImportExport(IHostingEnvironment hostingEnvironment,
            CicotiWebApp.Data.ApplicationDbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _sWebRootFolder = _hostingEnvironment.WebRootPath;
            _context = context;
        }

        public async Task<MemoryStream> DownloadAsync(string filename)
        {
            var memory = new MemoryStream();
            using (var stream = new FileStream(Path.Combine(_sWebRootFolder, _sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return memory;
        }

        public async Task<MemoryStream> CreateExcelFileAsync<T>(List<T> list)
        {
            var memory = new MemoryStream();

            using (_fs = new FileStream(Path.Combine(_sWebRootFolder, _sFileName), FileMode.Create, FileAccess.Write))
            {
                DataTable dt = ToDataTable(list);

                int columnNo = 0;
                int rowNo = 0;
                IRow row = excelSheet.CreateRow(rowNo);

                //First Create the Headers
                foreach (DataColumn column in dt.Columns)
                {
                    row.CreateCell(columnNo).SetCellValue(column.ColumnName);
                    columnNo += 1;
                }

                foreach (DataRow dr in dt.Rows)
                {
                    rowNo += 1;
                    row = excelSheet.CreateRow(rowNo);
                    columnNo = 0;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        row.CreateCell(columnNo).SetCellValue(dr[dc].ToString());
                        columnNo += 1;
                    }
                }
                workbook.Write(_fs);
            }
            using (var stream = new FileStream(Path.Combine(_sWebRootFolder, _sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return memory;
        }

        public static DataTable CreateDataTableForPropertiesOfType<T>()
        {
            DataTable dt = new DataTable();
            PropertyInfo[] piT = typeof(T).GetProperties();
            foreach (PropertyInfo pi in piT)
            {
                Type propertyType = null;
                if (pi.PropertyType.IsGenericType)
                {
                    propertyType = pi.PropertyType.GetGenericArguments()[0];
                }
                else
                {
                    propertyType = pi.PropertyType;
                }
                DataColumn dc = new DataColumn(pi.Name, propertyType);

                if (pi.CanRead)
                {
                    dt.Columns.Add(dc);
                }
            }
            return dt;
        }
        public static DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            var table = CreateDataTableForPropertiesOfType<T>();
            PropertyInfo[] piT = typeof(T).GetProperties();
            foreach (var item in items)
            {
                var dr = table.NewRow();
                for (int property = 0; property < table.Columns.Count; property++)
                {
                    if (piT[property].CanRead)
                    {
                        var value = piT[property].GetValue(item, null);
                        if (piT[property].PropertyType.IsGenericType)
                        {
                            if (value == null)
                            {
                                dr[property] = DBNull.Value;
                            }
                            else
                            {
                                dr[property] = piT[property].GetValue(item, null);
                            }
                        }
                        else
                        {
                            dr[property] = piT[property].GetValue(item, null);
                        }
                    }
                }
                table.Rows.Add(dr);
            }
            return table;
        }

        [Route("ImportUpload")]
        public string ImportUpload(IFormFile reportfile)
        {
            string folderName = "Upload";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            // Delete Files from Directory
            System.IO.DirectoryInfo di = new DirectoryInfo(newPath);
            foreach (FileInfo filesDelete in di.GetFiles())
            {
                filesDelete.Delete();
            }// End Deleting files form directories

            if (!Directory.Exists(newPath))// Crate New Directory if not exist as per the path
            {
                Directory.CreateDirectory(newPath);
            }
            var fiName = Guid.NewGuid().ToString() + Path.GetExtension(reportfile.FileName);
            using (var fileStream = new FileStream(Path.Combine(newPath, fiName), FileMode.Create))
            {
                reportfile.CopyTo(fileStream);
            }
            // Get uploaded file path with root
            string rootFolder = _hostingEnvironment.WebRootPath;
            string fileName = @"Upload/" + fiName;
            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
                int totalRows = workSheet.Dimension.Rows;
                List<CicotiWebApp.Models.Price> reportList = new List<CicotiWebApp.Models.Price>();
                for (int i = 2; i <= totalRows; i++)
                {
                    try
                    {
                        //string Title = workSheet?.Cells[i, 1]?.Value?.ToString();
                        //string Url = workSheet?.Cells[i, 2]?.Value?.ToString();
                        int SKUID = int.Parse(workSheet?.Cells[i, 1]?.Value?.ToString());
                        int PriceTypeID = int.Parse(workSheet?.Cells[i, 2]?.Value?.ToString());
                        double PriceInclVat = double.Parse(workSheet?.Cells[i, 3]?.Value?.ToString());
                        double PriceExlcVat = double.Parse(workSheet?.Cells[i, 4]?.Value?.ToString());
                        int RegionID = int.Parse(workSheet?.Cells[i, 5]?.Value?.ToString());
                        int BranchID = int.Parse(workSheet?.Cells[i, 6]?.Value?.ToString());
                        DateTime PriceDate = DateTime.Parse(workSheet?.Cells[i, 7]?.Value?.ToString());
                        reportList.Add(new CicotiWebApp.Models.Price
                        {
                            SKUID = SKUID,
                            PriceTypeID = PriceTypeID,
                            PriceInclVat = PriceInclVat,
                            PriceExlcVat = PriceExlcVat,
                            RegionID = RegionID,
                            BranchID = BranchID,
                            PriceDate = PriceDate
                            //  SKUID = Title,
                            //  Url = Url,
                        });
                    }
                    catch (Exception Ex)
                    {
                        // Exception
                    }
                }

                _context.Prices.AddRange(reportList);
                _context.SaveChanges();

                return "Uploaded";
            }
        }





    }
}
