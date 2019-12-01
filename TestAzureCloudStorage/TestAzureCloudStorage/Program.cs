using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestAzureCloudStorage
{
    class Program
    {
        // public static string storageString = "DefaultEndpointsProtocol=https;AccountName=storageaccountcicot937c;AccountKey=oz8EBYpNH/0HVLG2Ay6RrVETRCW7srKvjOWcTcW7N2xxSfZx2skyKx+O7we/FbUP/m4xE9aBbowwM9VERJeHJw==;EndpointSuffix=core.windows.net";
        public static string storageString = "DefaultEndpointsProtocol=https;AccountName=wallylamego;AccountKey=U8P4jvgMuDdTJ2kkhlz5u6yYccMnIolGRJ1RCWLHKT0sMrSvGWmC9JkQpkClWNHAGnY49XXdgJ4aWy1bCQRLkw==;EndpointSuffix=core.windows.net";
        public static string GPExceptionSQLString = "SELECT [Reference],[TxDate],[Code]," +
                "[Name],[WarehouseName],[ClientGroup],[ClientGroupName],[AreaCode],[AreaDescription],[RepCode],[RepName]," +
                "[Account],[ucARCallFrequency],[ucARRep],[ucARSegment],[ulARType],[ItemCode],[itemgroup],[ItemDescription]," +
                "[Branch],[Warehousecode],[ActualQuantity],[ActualSalesValue],[Profit],[Cost],[ProfitPerc],[RequiredGP]," +
                "[ActualPrice],[PriceVariance],[PriceComment],[AccountMobilePrice],[BranchMobilePrice]," +
                "[ValueChainPrice],[DiffActAMP],[DiffActBMP],[DiffActVCP],[RequiredGPValue], [LostGPValue], [Region], [WarehouseType], [Channel],[PrincipalABC] FROM [dbo].[VwGPVariances]";
        public static string connectionString = "Data Source = wallylamego.database.windows.net; Initial Catalog = CICOTIDB; User ID = wallylamego; Password=!Star09012012;Connect Timeout = 30; Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void  Main(string[] args)
        {
         //   var connectionString = Environment.GetEnvironmentVariable("Connection", EnvironmentVariableTarget.Process);
         //   var storageString = Environment.GetEnvironmentVariable("AzureWebJobsStorage", EnvironmentVariableTarget.Process);
         //   var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY", EnvironmentVariableTarget.Process);

            ExcelImportExport excelImportExport = new ExcelImportExport("GPException.xlsx");

            //Run the GP Exceptions Stored Procedure
            using (SqlConnection objConn = new SqlConnection(connectionString))
            {
                // Connection object 
                objConn.Open();

                // Command text 
                var strText = "exec sp_GrossProfitExceptionUpdate";

                // Command Object 
                using (SqlCommand objCmd = new SqlCommand(strText, objConn))
                {
                    // Execute procedure 
                    var rows = objCmd.ExecuteNonQueryAsync();

                    // This should always be 1 
                }

                // Close the object 
                objConn.Close();
            }

            List<GPException> GPExceptionList = new List<GPException>();
            GPExceptionList = ExcuteObject<GPException>(GPExceptionSQLString,
                false).ToList();
            //do something with the result - people

            var countExceptions = GPExceptionList.Count();
            Console.Write("There are: " + countExceptions.ToString() + "Exceptions");

            ExcelImportExport ExcelExport = new ExcelImportExport();
             ExcelExport.SaveFileExcelToAzureStorageAsync(GPExceptionList, storageString, "GPExceptionsConsoleAppV7.xlsx").Wait();
           
            // Expo
            //MemoryStream MemoryStream = await ExcelExport.CreateExcelFileAsync(GPExceptionList, "GPExceptions");
        //    await ExcelExport.UploadToBlob("GPExceptions", storageString, MemoryStream);

            Console.WriteLine("File Created");
        }

        public static DataTable Select(string storedProcedureorCommandText, bool isStoredProcedure = true)
        {
         //   var connectionString = Environment.GetEnvironmentVariable("Connection", EnvironmentVariableTarget.Process);

            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    if (!isStoredProcedure)
                    {
                        command.CommandType = CommandType.Text;
                    }
                    command.CommandText = storedProcedureorCommandText;
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
        public static IEnumerable<T> ExcuteObject<T>(string storedProcedureorCommandText, bool isStoredProcedure = true)
        {
            List<T> items = new List<T>();
            var dataTable = Select(storedProcedureorCommandText, isStoredProcedure); //this will use the DataTable Select function
            foreach (var row in dataTable.Rows)
            {
                T item = (T)Activator.CreateInstance(typeof(T), row);
                items.Add(item);
            }
            return items;
        }

    }
}
