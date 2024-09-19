using System;
using System.Threading.Tasks;
using AzureServerlessTemplate.Models;

namespace AzureServerlessTemplate.Services
{
    public interface ISampleService
    {
        Task<string> GetGreetingAsync(string name);
        Task<SampleModel> CreateSampleModelAsync(string name);
    }

    public class SampleService : ISampleService
    {
        public async Task<string> GetGreetingAsync(string name)
        {
            // Simulate some async operation
            await Task.Delay(100);

            return $"Hello, {name}! Welcome to Azure Functions.";
        }

        public async Task<SampleModel> CreateSampleModelAsync(string name)
        {
            // Simulate some async operation
            await Task.Delay(100);

            return new SampleModel
            {
                Id = new Random().Next(1, 1000),  // Just for demo, use a proper ID generation in real apps
                Name = name
            };
        }
    }
}