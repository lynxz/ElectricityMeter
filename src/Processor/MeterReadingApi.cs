using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Processor
{
    public static class MeterReadingApi
    {
        [FunctionName("MeterReadingApi")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "devices/{deviceId}")] HttpRequest req, 
            string deviceId,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var builder = new DbContextOptionsBuilder<IotContext>();
            builder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));
            using var context = new IotContext(builder.Options);

            var reading = await context.MeterReadings.OrderByDescending(d => d.Timestamp).FirstOrDefaultAsync(m => m.SerialNumber == deviceId);

            if (reading == null)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            }
            
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(reading), Encoding.UTF8, "application/json")
            };
        }
    }
}
