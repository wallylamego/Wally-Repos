using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Data.SqlClient;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace EmailGPExceptions
{
    public static class RunGPExeception
    {
        public static string GPExceptionSQLString = "SELECT [Reference],[TxDate],[Code]," +
                "[Name],[WarehouseName],[ClientGroup],[ClientGroupName],[AreaCode],[AreaDescription],[RepCode],[RepName]," +
                "[Account],[ucARCallFrequency],[ucARRep],[ucARSegment],[ulARType],[ItemCode],[itemgroup],[ItemDescription],"+
                "[Branch],[Warehousecode],[ActualQuantity],[ActualSalesValue],[Profit],[Cost],[ProfitPerc],[RequiredGP]," +
                "[ActualPrice],[PriceVariance],[PriceComment],[AccountMobilePrice],[BranchMobilePrice],"+
                "[ValueChainPrice],[DiffActAMP],[DiffActBMP],[DiffActVCP], [RequiredGPValue], [LostGPValue], [Region], [WarehouseType], [Channel],[PrincipalABC] FROM [dbo].[VwGPVariances]";

        public static string FileName = "GPExceptions.xlsx";
        public static string ContainerName = "excelcontainer";


        [FunctionName("fnctEmailGPExceptions")]
        public static async Task RunAsync([TimerTrigger("0 */180 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
           
            var connectionString = Environment.GetEnvironmentVariable("Connection", EnvironmentVariableTarget.Process);
            var storageString = Environment.GetEnvironmentVariable("AzureWebJobsStorage", EnvironmentVariableTarget.Process);
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY", EnvironmentVariableTarget.Process);

            ExcelImportExport excelImportExport = new ExcelImportExport("GPException");


            log.Info($"value of storageString is: {storageString}");
            log.Info($"value of apiKey is: {apiKey}");
            log.Info($"value of connectionString is: {connectionString}");
            
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
            

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
                    log.Info("sp_GrossProfitExceptionUpdate stored procedure updated");
                }

                // Close the object 
                objConn.Close();
            }

            List<GPException> GPExceptionList = new List<GPException>();
            GPExceptionList = ExcuteObject<GPException>(GPExceptionSQLString, 
                false).ToList();
            

            var countExceptions = GPExceptionList.Count();
            log.Info("There are: " + countExceptions.ToString() + "Exceptions");

            ExcelImportExport ExcelExport = new ExcelImportExport();

            ExcelExport.SaveFileExcelToAzureStorageAsync(GPExceptionList, storageString, FileName, log, ContainerName).Wait();
            log.Info("GP Exception File created in Azure Storage Area.");
            var client = new SendGridClient(apiKey);
            //  var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", htmlContent, false);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("azure_c05013700011f601571a8f26f8fb4397@azure.com", "GP Exception Team"),
                Subject = "GP Exceptions",
                PlainTextContent = "Hi Please find the GP Exceptions. There are " + countExceptions.ToString() + "Exceptions.",
                HtmlContent = "<strong>" + "Hi Please find the GP Exceptions.There are " + countExceptions.ToString() + "Exceptions." + "</strong>"

            };
            msg.AddTo(new EmailAddress("w.fernandes@otisa.co.za", "Test User"));
            ExcelExport.AttachEmailtoMessage(storageString, ContainerName, FileName, msg);
            
            var response = await client.SendEmailAsync(msg);

            log.Info("Response from email server: " + response.StatusCode.ToString());
        }
        public static DataTable Select(string storedProcedureorCommandText, bool isStoredProcedure = true)
        {
            var connectionString = Environment.GetEnvironmentVariable("Connection", EnvironmentVariableTarget.Process);

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
