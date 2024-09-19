using System;

namespace AzureServerlessTemplate.Models
{
    public class SampleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public SampleModel()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"SampleModel: Id={Id}, Name={Name}, CreatedDate={CreatedDate}";
        }
    }
}
