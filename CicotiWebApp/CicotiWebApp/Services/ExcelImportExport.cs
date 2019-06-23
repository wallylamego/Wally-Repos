using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
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

        public ExcelImportExport(String sfileName, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _sWebRootFolder = _hostingEnvironment.WebRootPath;
            _sFileName = sfileName;
            workbook = new XSSFWorkbook();
            excelSheet = workbook.CreateSheet("Export");
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

    }
}
