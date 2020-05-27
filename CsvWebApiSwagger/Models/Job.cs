using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace CsvWebApiSwagger.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public string Requirements { get; set; }

        [EnumDataType(typeof(JobType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public JobType JobType { get; set; }
    }
}
