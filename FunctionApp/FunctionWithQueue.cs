using System;
using System.Data.SqlClient;
using Amizade.Domain.Model.Entities;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public static class FunctionWithQueue
    {
        [FunctionName("FunctionWithQueue")]
        public static void Run([QueueTrigger("function-update-date-queue", Connection = "AzureWebJobsStorage")] AmigoEntity amigo, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed.");

            var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var textSql = $@"UPDATE [dbo].[Amigo] SET [UltimaVisualizacao] = GETDATE() WHERE [Id] = {amigo.Id};";

                using (SqlCommand cmd = new SqlCommand(textSql, conn))
                {
                    var rowsAffected = cmd.ExecuteNonQuery();
                    log.LogInformation($"rowsAffected: {rowsAffected}");
                }
            }

        }
    }
}
