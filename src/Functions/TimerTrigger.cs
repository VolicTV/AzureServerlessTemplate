using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using AzureServerlessTemplate.Services;

namespace AzureServerlessTemplate.Functions
{
    public class TimerTrigger
    {
        private readonly ISampleService _sampleService;

        public TimerTrigger(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        [FunctionName("TimerTrigger")]
        public async Task RunAsync([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            string greeting = await _sampleService.GetGreetingAsync("Timer");
            log.LogInformation(greeting);
        }
    }
}
