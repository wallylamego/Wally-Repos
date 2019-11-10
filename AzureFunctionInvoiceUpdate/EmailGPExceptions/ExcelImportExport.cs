using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;


namespace EmailGPExceptions
{
    public class ExcelImportExport
    {
        readonly IWorkbook workbook;
        readonly ISheet excelSheet;
     //   private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string _sWebRootFolder;
        private readonly string _sFileName;
        private FileStream _fs;
    //  private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public ExcelImportExport(String sfileName
            //, IHostingEnvironment hostingEnvironment,
            //CicotiWebApp.Data.ApplicationDbContext context
            )
        {
            //_hostingEnvironment = hostingEnvironment;
            //_sWebRootFolder = _hostingEnvironment.WebRootPath;
            _sFileName = sfileName;
            //_context = context;
            workbook = new XSSFWorkbook();
            excelSheet = workbook.CreateSheet("Export");
        }
        public ExcelImportExport(
            //IHostingEnvironment hostingEnvironment,
            //CicotiWebApp.Data.ApplicationDbContext context
            )
        {
            //_hostingEnvironment = hostingEnvironment;
            //_sWebRootFolder = _hostingEnvironment.WebRootPath;
            //_context = context;
        }

        #region StreamingUpload to Azure Storage Account

        private async Task<bool> UploadToBlob(string filename, Stream stream = null, string storageConnectionString)
        {
            CloudStorageAccount storageAccount = null;
            CloudBlobContainer cloudBlobContainer = null;

            // Check whether the connection string can be parsed.

            if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
            {
                try
                {

                    // Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.

                    CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
                    // Create a container called 'uploadblob' and append a GUID value to it to make the name unique. 
                    cloudBlobContainer = cloudBlobClient.GetContainerReference("fam");

                    //  await cloudBlobContainer.CreateAsync();
                    // Set the permissions so the blobs are public. 

                    //BlobContainerPermissions permissions = new BlobContainerPermissions
                    //{
                    //    PublicAccess = BlobContainerPublicAccessType.Blob
                    //};

                    //await cloudBlobContainer.SetPermissionsAsync(permissions);


                    // Get a reference to the blob address, then upload the file to the blob.

                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(filename);

                    // OPTION B: pass in memory stream directly

                    await cloudBlockBlob.UploadFromStreamAsync(stream);

                    return true;

                }

                catch (StorageException ex)

                {

                    return false;

                }

                finally

                {

                    // OPTIONAL: Clean up resources, e.g. blob container

                    //if (cloudBlobContainer != null)

                    //{

                    //    await cloudBlobContainer.DeleteIfExistsAsync();

                    //}

                }

            }
            else
            {
                return false;
            }



        }
        
        #endregion StreamingUpload to Azure Storage Account

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

       





    }


    
}
