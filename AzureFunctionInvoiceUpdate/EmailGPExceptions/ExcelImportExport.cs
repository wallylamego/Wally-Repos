using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using SendGrid.Helpers.Mail;

namespace EmailGPExceptions
{
    public class ExcelImportExport
    {
        readonly IWorkbook workbook;
        readonly ISheet excelSheet;
   
        private readonly string _sFileName;
    

        public ExcelImportExport(String sfileName
            
            )
        {
            
            _sFileName = sfileName;
            
            workbook = new XSSFWorkbook();
            excelSheet = workbook.CreateSheet("Export");
        }
        public ExcelImportExport(
            
            )
        {
           
            workbook = new XSSFWorkbook();
            excelSheet = workbook.CreateSheet("Export");
        }



        public async Task<bool> SaveFileExcelToAzureStorageAsync(List<GPException> ReportListing, string storageConnectionString, string fileName, TraceWriter log, string containerString)
        {

            DataTable dt = ToDataTable(ReportListing);

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

            try
            {
                MemoryStream ms = new MemoryStream();
                using (MemoryStream tempStream = new MemoryStream())
                {
                    workbook.Write(tempStream);
                    var byteArray = tempStream.ToArray();
                    ms.Write(byteArray, 0, byteArray.Length);
                }

                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(containerString);
                await container.CreateIfNotExistsAsync();
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                ms.Position = 0;
                blockBlob.UploadFromStreamAsync(ms).Wait();
                log.Info("File Uploaded");
                return true;
            }
            catch (Exception ex)
            {
                log.Info("File Not Uploaded" + ex.Message.ToString());
                return false;
            }

        }


        public void AttachEmailtoMessage(String storageConnectionString, String ContainerRefName, string fileName, SendGridMessage msg)
        {
            // Code for adding sender, recipient etc...
            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(ContainerRefName);
            var blob = container.GetBlockBlobReference(fileName);
            var ms = new MemoryStream();
            blob.DownloadToStreamAsync(ms).Wait();

            var blobBytes = GetBytesFromStream(ms);

            ms.Position = 0;
            msg.AddAttachmentAsync(fileName, ms).Wait();
           

          //  msg.AddAttachment(fileName, Convert.ToBase64String(blobBytes));
           
            // msg.AddAttachment(ms, "originalfilename.png");

        }

        private static byte[] GetBytesFromStream(Stream inputStream)
        {
            byte[] result;
            using (var ms = new MemoryStream())
            {
                inputStream.CopyTo(ms);
                result = ms.ToArray();
            }
            return result;
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
