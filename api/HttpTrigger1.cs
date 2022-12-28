using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace Company.Function
{
    public static class HttpTrigger1
    {
        private static readonly HttpClient httpClient = new HttpClient();

        [FunctionName("HttpTrigger1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            StringContent content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://lesjddt11f1.azurewebsites.net/api/HttpTrigger1?code=PFpjFoX0wwhgqgT32tjLFAtwsvGT_NBygfNbtp1cM3uXAzFun97RrA==", content);

            var responseMessage = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"---> Response:{responseMessage}");

            return new OkObjectResult("Payload Received");
        }
    }
}
