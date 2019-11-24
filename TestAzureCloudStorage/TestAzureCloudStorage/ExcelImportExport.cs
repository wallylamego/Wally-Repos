using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace TestAzureCloudStorage
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
         //   _sWebRootFolder = _hostingEnvironment.WebRootPath;
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
            workbook = new XSSFWorkbook();
            excelSheet = workbook.CreateSheet("Export");
        }

        #region StreamingUpload to Azure Storage Account

        public async Task<bool> UploadToBlobAsync(string filename, string storageConnectionString, Stream stream = null)
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

        public async Task<MemoryStream> CreateExcelFileAsync<T>(List<T> list, string FileName)
        {
            var memory = new MemoryStream();

            Microsoft.Win32.SafeHandles.SafeFileHandle handle = null;
            //using (_fs = new FileStream(FileName, FileMode.Create, FileAccess.Write))
            using (_fs = new FileStream(handle, FileAccess.Write))
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

    

        public async Task<bool> SaveFileExcelToAzureStorageAsync<T>(List<T> list, string storageConnectionString, string fileName)
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

            try
            {
                MemoryStream ms = new MemoryStream();
                using (MemoryStream tempStream = new MemoryStream())
                {
                    workbook.Write(tempStream);
                    var byteArray = tempStream.ToArray();
                    ms.Write(byteArray, 0, byteArray.Length);
                }
               
               
                //You need to create a storage account and put your azure storage connection string in following place
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                // CloudBlobContainer container = blobClient.GetContainerReference("fam");

                
                Console.Write("1. Creating Container");
                CloudBlobContainer container = blobClient.GetContainerReference("fam");

              //  CloudBlockBlob blob = container.GetBlockBlobReference("helloworld.txt");
              //  blob.UploadTextAsync("Hello, World!").Wait();


                //bool result = false;
                //try
                //{
                //    BlobRequestOptions requestOptions = new BlobRequestOptions() { RetryPolicy = new NoRetry() };
                //    result = await container.CreateIfNotExistsAsync(requestOptions, null);
                //   //  await container.CreateAsync();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message.ToString());
                //}

                //  bool result = await container.CreateIfNotExistsAsync();
                // container.CreateIfNotExistsAsync();
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
               // CloudBlockBlob blockBlob = container.GetBlockBlobReference("StockImport.txt");
                ms.Position = 0;
                await blockBlob.UploadFromStreamAsync(ms);


                //var blockBlob = container.GetBlockBlobReference("SalesRepImport.xlsx");
              //  using (var fileStream = System.IO.File.OpenRead(@"C:\Users\wallyf\StockImport.txt"))
              //  {
              //      fileStream.Position = 0;
              //      await blockBlob.UploadFromStreamAsync(fileStream);
              //  }
              ////  await blockBlob.UploadFromFileAsync("C:\\Users\\wallyf\\SalesRepImport.xlsx");
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
             //   Console.Write(ex.InnerException.Message.ToString());
                Console.Write(ex.InnerException.InnerException.ToString());
                return false;
            }



            //   workbook.Write(memorystream = new MemoryStream());

            // memorystream.Position = 0;
            // return memorystream;
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
