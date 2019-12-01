using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Configuration;
using System.Data.SqlClient;


namespace AzureFunctionInvoiceUpdate
{
    public static class RunInvoiceUpdate
    {
        [FunctionName("fnctInvoiceUpdate")]
        public static void Run([TimerTrigger("0 */10 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            //var strConn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //var strConn = ConfigurationManager.AppSettings["Connection"];

            // Get Connection strings(put local and Azure env together)
            var connParameter = "Connection";
            var storageParameter = "AzureWebJobsStorage";
           // var Prefix = "SQLAZURECONNSTR_";
            var connectionString = System.Environment.GetEnvironmentVariable($"{connParameter}");
            var storageString = System.Environment.GetEnvironmentVariable($"{storageParameter}");
            log.Info($"value of storageString is: {storageString}");
            //if (string.IsNullOrEmpty(connectionString))
            //{
            //    connectionString = System.Environment.GetEnvironmentVariable($"{Prefix}{connParameter}");
            //}




            log.Info($"value of connectionString is: {connectionString}");
            //if (strConn != null)
            //{
            //    log.Info("Connection string obtained");
            //}

            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
            log.Info("In New Module");
            // Grab connection string 

            using (SqlConnection objConn = new SqlConnection(connectionString))
            {
                // Connection object 
                objConn.Open();

                // Command text 
                var strText = "exec PastelInvoiceUpdate";

                // Command Object 
                using (SqlCommand objCmd = new SqlCommand(strText, objConn))
                {
                    // Execute procedure 
                    var rows = objCmd.ExecuteNonQueryAsync();

                    // This should always be 1 
                    log.Info($"{rows} rows were updated in this Version - date 29-11-2019 1804");
                }

                // Close the object 
                objConn.Close();

            }
        }
    }
}
