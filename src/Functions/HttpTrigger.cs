using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AzureServerlessTemplate.Services;

namespace AzureServerlessTemplate.Functions
{
    public class HttpTrigger
    {
        private readonly ISampleService _sampleService;

        public HttpTrigger(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        [FunctionName("HttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string responseMessage = await _sampleService.GetGreetingAsync(name ?? "Anonymous");

            return new OkObjectResult(responseMessage);
        }
    }
}
